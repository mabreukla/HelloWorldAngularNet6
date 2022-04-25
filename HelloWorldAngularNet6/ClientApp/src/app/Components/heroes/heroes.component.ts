import { Component, Input, OnInit } from '@angular/core';
import { Hero } from '../../Models/hero';
import { HeroService } from '../../Services/hero.service';
import { Universe } from '../../Models/universe';
import { UniverseService } from '../../Services/universe.service';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})

export class HeroesComponent implements OnInit {
  // Fields
  public heroes: Hero[] = [];
  private heroService: HeroService;
  private universeService: UniverseService;
  @Input() universes?: Universe[];
  @Input() selectedUniverse: string;
  
  // Ctor
  constructor(heroService: HeroService, universeService: UniverseService) {
    this.heroService = heroService;
    this.universeService = universeService;
    this.selectedUniverse = "None";
  }

  // Methods
  getHeroes(): void {
    this.heroService.getHeroes().subscribe(heroes => this.heroes = heroes);
  }

  getUniverses(): void {
    this.universeService.getUniverses().subscribe(universes => this.universes = universes);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) {
      return;
    }

    let universe = this.selectedUniverse;

    this.heroService.addHero({ name, universe } as Hero)
      .subscribe(hero => {
        this.heroes.push(hero);
      });
  }

  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroService.deleteHero(hero.id).subscribe();
  }

  // Lifecycle
  ngOnInit(): void {
    this.getHeroes();
    this.getUniverses();
  }
}
