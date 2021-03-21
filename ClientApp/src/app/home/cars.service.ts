import { Car } from '../models/cars';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CarsService {

  constructor(public http: HttpClient) { }

  getCars() {
    return this.http.get<Car[]>('cars');
  }

  addCar(car: Car) {
    return this.http.post<Car>('cars', car);
  }

  deleteCar(id: number) {
    return this.http.delete('cars/' + id);
  }

  getById(id: number) {
    return this.http.get<Car>('cars/' + id);
  }

  updateCar(id: number, car: Car) {
    return this.http.put('cars/' + id, car);
  }

}
