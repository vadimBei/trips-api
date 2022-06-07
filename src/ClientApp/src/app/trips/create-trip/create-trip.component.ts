import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TripVehicleType } from 'src/app/shared/enums/trips/TripVehicleType';

@Component({
  selector: 'app-create-trip',
  templateUrl: './create-trip.component.html',
  styleUrls: ['./create-trip.component.scss']
})
export class CreateTripComponent implements OnInit {
  vehicleTypes = Object.values(TripVehicleType);

  createTripForm = new FormGroup({
    dateFrom: new FormControl(),
    dateTo: new FormControl(),
    comment: new FormControl(),
    goal: new FormControl(),
    vehicleType: new FormControl(this.vehicleTypes[0]),
  });

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    this.createTripForm.value;
  }
}
