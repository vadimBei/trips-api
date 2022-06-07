import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { EmployeeRoutingModule } from './trips-routing.module';
import { EmployeesModule } from '../employees/employees.module';
import { CreateTripComponent } from './create-trip/create-trip.component';
import { UpdateTripComponent } from './update-trip/update-trip.component';
import { ApprovedTripsComponent } from './approved-trips/approved-trips.component';
import { TripsListComponent } from './trips-list/trips-list.component';
import { AlgoliaLocationsModule } from '../shared/components/algolia-locations/algolia-locations.module';

@NgModule({
    declarations: [
        CreateTripComponent,
        UpdateTripComponent,
        ApprovedTripsComponent,
        TripsListComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        EmployeeRoutingModule,
        EmployeesModule,
        AlgoliaLocationsModule  
    ],
    exports: [

    ]
})
export class TripsModule { }