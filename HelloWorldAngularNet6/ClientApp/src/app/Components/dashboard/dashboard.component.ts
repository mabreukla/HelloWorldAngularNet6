import { Component, OnInit } from '@angular/core';
import { Hero } from '../../Models/hero';
import { HeroService } from '../../Services/hero.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.css' ]
})

export class DashboardComponent implements OnInit {
  // Fields
  heroes: Hero[] = [];
  private heroService: HeroService;

  // Ctor
  constructor(heroService: HeroService) {
    this.heroService = heroService;
  }

  // Methods
  getHeroes(): void {
    this.heroService.getHeroes()
      .subscribe(heroes => this.heroes = heroes.slice(0, 4));
  }

  // Lifecycles
  ngOnInit(): void {
    this.getHeroes();
  }
}