import { CarsService } from './cars.service';
import { Component, OnInit } from '@angular/core';
import { Car } from '../models/cars';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  cars: Car[] = []
  constructor(public carService: CarsService,
              public router: Router) {
    this.getCars();
  }

  ngOnInit(): void {
  }

  getCars() {
    this.carService.getCars().subscribe(response => {
      this.cars = response;
    })
  }

  onDelete(id: number) {
    this.carService.deleteCar(id).subscribe(response => {
      // TODO: add error handling
      this.getCars();
    })
  }

}
