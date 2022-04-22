import { Component, OnInit, Input } from '@angular/core';
import { Hero } from '../hero';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HeroService } from '../hero.service';
import { UniverseService } from '../universe.service';
import { Universe } from '../universe';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: ['./hero-detail.component.css']
})

export class HeroDetailComponent implements OnInit {
  // Fields
  @Input() hero?: Hero;
  private route: ActivatedRoute;
  private heroService: HeroService;
  private location: Location;
  private universeService: UniverseService;
  @Input() universe?: Universe;
  @Input() universes?: Universe[];

  // Ctor
  constructor(activatedRoute: ActivatedRoute, heroService: HeroService, location: Location, universeService: UniverseService) {
    this.route = activatedRoute;
    this.heroService = heroService;
    this.location = location;
    this.universeService = universeService;
  }

  // Methods
  getHero(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.heroService.getHero(id).subscribe(hero => this.hero = hero);
  }

  getUniverses(): void {
    this.universeService.getUniverses().subscribe(universes => this.universes = universes);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if(this.hero) {
      this.heroService.updateHero(this.hero).subscribe(
        () => this.goBack());
    }
  }

  // Lifecycles
  ngOnInit(): void {
    this.getHero();
    this.getUniverses();
  }
}
