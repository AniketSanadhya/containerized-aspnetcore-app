import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditCarsComponent } from './add-edit-cars.component';

describe('AddEditCarsComponent', () => {
  let component: AddEditCarsComponent;
  let fixture: ComponentFixture<AddEditCarsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditCarsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditCarsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
