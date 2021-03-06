import { Injectable } from '@angular/core';
import { Hero } from '../Models/hero';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class HeroService {
  // Fields
  private messageService: MessageService;
  private http: HttpClient;
  private heroesUrl = 'api/heroes';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json',
    'Access-Control-Allow-Origin' : '*',
    'Access-Control-Allow-Methods' : 'GET, POST, PATCH, PUT, DELETE, OPTIONS',
    'Access-Control-Allow-Headers' : 'Origin, Content-Type, X-Auth-Token'
    })
  };

  // Ctor
  constructor(http: HttpClient, messageService: MessageService) {
    this.http = http;
    this.messageService = messageService;
  }

  // Methods
  getHeroes(): Observable<Hero[]> {
    const heroes: Observable<Hero[]> = this.http.get<Hero[]>(this.heroesUrl, this.httpOptions)
      .pipe(
        tap(_ => this.log('fetchedHeroes')),
        catchError(this.handleError<Hero[]>('getHeroes', []))
    );

    return heroes;
  }

  getHero(id: number): Observable<Hero> {
    const url = `${ this.heroesUrl }/${ id }`;
    // Why does this work when getting just one?
    // The in memory api is smart enough to route the calls correctly (including put)
    let hero: Observable<Hero> = this.http.get<Hero>(url, this.httpOptions).pipe(
      tap(_ => this.log(`fetched hero id=${ id }`)),
      catchError(this.handleError<Hero>(`getHero id=${ id }`))
    );
    
    return hero;
  }

  /** Log a HeroService message with the MessageService  */
  private log(message: string) {
    this.messageService.add(`HeroService: ${ message }`);
  }

  /** PUT: update the hero on the server */
  updateHero(hero: Hero): Observable<any> {
    let returnValue: Observable<any> = this.http.put(this.heroesUrl, hero, this.httpOptions).pipe(
      tap(_ => this.log(`updated hero id=${hero.id}`)),
      catchError(this.handleError<any>('updateHero'))
    );

    return returnValue;
  }

  /** POST: add a new hero to the server */
  addHero(hero: Hero): Observable<Hero> {
    let returnValue: Observable<Hero> = this.http.post<Hero>(this.heroesUrl, hero, this.httpOptions).pipe(
      tap((newHero: Hero) => this.log(`added hero w/ id=${newHero.id}`)),
      catchError(this.handleError<Hero>('addHero'))
    );

    return returnValue;
  }

  /** DELETE: delete the hero from the server */
  deleteHero(id: number): Observable<Hero> {
    const url = `${this.heroesUrl}/${id}`;

    let returnValue: Observable<Hero> = this.http.delete<Hero>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted hero id=${id}`)),
      catchError(this.handleError<Hero>('deleteHero'))
    );

    return returnValue;
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    // Creates a function as a return value that will be used by the
    // http error handler to process the error
    let returnValue = (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };

    return returnValue;
  }

  /* GET heroes whose name contains search term */
  searchHeroes(term: string): Observable<Hero[]> {
    let returnValue: Observable<Hero[]>;

    if (!term.trim()) {
      // if not search term, return empty hero array.
      returnValue = of([]);
    } else {
      returnValue = this.http.get<Hero[]>(`${this.heroesUrl}/search?name=${term}`).pipe(
        tap(x => x.length ?
          this.log(`found heroes matching "${term}"`) :
          this.log(`no heroes matching "${term}"`)),
        catchError(this.handleError<Hero[]>('searchHeroes', []))
      );
    }

    return returnValue;
  }
}
