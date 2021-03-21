import { CarsService } from '../home/cars.service';
import { Car } from './../models/cars';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-edit-cars',
  templateUrl: './add-edit-cars.component.html',
  styleUrls: ['./add-edit-cars.component.scss']
})
export class AddEditCarsComponent implements OnInit {

  car: Car = <Car>{};
  isEdit = false;
  constructor(public carService: CarsService,
    public router: Router,
    public activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(response => {
      if (response['id'] && response['id'] > 0) {
        this.isEdit = true;
        this.getById(response['id']);
      }
    })
  }

  ngOnInit() {
  }

  getById(id: number) {
    this.carService.getById(id).subscribe(response => {
      this.car = response;
    })
  }

  onSubmit() {
    if (!this.isEdit) {
      this.carService.addCar(this.car).subscribe(response => {
        if (response && response.id > 0) {
          this.router.navigate(['/']);
        }
      })
    }
    else {
      this.carService.updateCar(this.car.id, this.car).subscribe(response => {
        // TODO: add error handling
        this.router.navigate(['/']);
      })
    }
  }
}
