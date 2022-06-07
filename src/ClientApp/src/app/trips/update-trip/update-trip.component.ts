import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { TripVehicleType } from 'src/app/shared/enums/trips/TripVehicleType';

@Component({
  selector: 'app-update-trip',
  templateUrl: './update-trip.component.html',
  styleUrls: ['./update-trip.component.scss']
})
export class UpdateTripComponent implements OnInit {
  vehicleTypes = Object.values(TripVehicleType);

  updateTripForm = new FormGroup({
    dateFrom: new FormControl(),
    dateTo: new FormControl(),
    comment: new FormControl(),
    goal: new FormControl(),
    vehicleType: new FormControl(),
  });

  constructor(
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    this.updateTripForm.value;
  }
}
