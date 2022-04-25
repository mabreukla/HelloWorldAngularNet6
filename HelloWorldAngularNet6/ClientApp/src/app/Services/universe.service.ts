import { Injectable } from '@angular/core';
import { Universe } from '../Models/universe';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class UniverseService {
  // Fields
  private messageService: MessageService;
  private http: HttpClient;
  private universesUrl = 'api/universes';
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
  getUniverses(): Observable<Universe[]> {
    const universes: Observable<Universe[]> = this.http.get<Universe[]>(this.universesUrl, this.httpOptions)
      .pipe(
        tap(_ => this.log('fetchedUniverses')),
        catchError(this.handleError<Universe[]>('getUniverses', []))
    );

    return universes;
  }

  getUniverse(id: number): Observable<Universe> {
    const url = `${ this.universesUrl }/${ id }`;
    let universe: Observable<Universe> = this.http.get<Universe>(url, this.httpOptions).pipe(
      tap(_ => this.log(`fetched universe id=${ id }`)),
      catchError(this.handleError<Universe>(`getUniverse id=${ id }`))
    );
    
    return universe;
  }

  /** Log a UniverseService message with the MessageService  */
  private log(message: string) {
    this.messageService.add(`UniverseService: ${ message }`);
  }

  // /** PUT: update the hero on the server */
  // updateHero(hero: Hero): Observable<any> {
  //   let returnValue: Observable<any> = this.http.put(this.universesUrl, hero, this.httpOptions).pipe(
  //     tap(_ => this.log(`updated hero id=${hero.id}`)),
  //     catchError(this.handleError<any>('updateHero'))
  //   );

  //   return returnValue;
  // }

  // /** POST: add a new hero to the server */
  // addHero(hero: Hero): Observable<Universe> {
  //   let returnValue: Observable<Universe> = this.http.post<Universe>(this.universesUrl, hero, this.httpOptions).pipe(
  //     tap((newHero: Hero) => this.log(`added hero w/ id=${newHero.id}`)),
  //     catchError(this.handleError<Universe>('addHero'))
  //   );

  //   return returnValue;
  // }

  // /** DELETE: delete the hero from the server */
  // deleteHero(id: number): Observable<Universe> {
  //   const url = `${this.universesUrl}/${id}`;

  //   let returnValue: Observable<Universe> = this.http.delete<Universe>(url, this.httpOptions).pipe(
  //     tap(_ => this.log(`deleted hero id=${id}`)),
  //     catchError(this.handleError<Universe>('deleteHero'))
  //   );

  //   return returnValue;
  // }

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

  // /* GET heroes whose name contains search term */
  // searchHeroes(term: string): Observable<Universe[]> {
  //   let returnValue: Observable<Universe[]>;

  //   if (!term.trim()) {
  //     // if not search term, return empty hero array.
  //     returnValue = of([]);
  //   } else {
  //     returnValue = this.http.get<Universe[]>(`${this.universesUrl}/?name=${term}`).pipe(
  //       tap(x => x.length ?
  //         this.log(`found heroes matching "${term}"`) :
  //         this.log(`no heroes matching "${term}"`)),
  //       catchError(this.handleError<Universe[]>('searchHeroes', []))
  //     );
  //   }

  //   return returnValue;
  // }
}
