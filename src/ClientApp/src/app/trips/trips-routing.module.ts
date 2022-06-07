import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ApprovedTripsComponent } from './approved-trips/approved-trips.component';
import { TripsListComponent } from './trips-list/trips-list.component';
import { CreateTripComponent } from './create-trip/create-trip.component';
import { UpdateTripComponent } from './update-trip/update-trip.component';

const routes: Routes = [
    {
        path: '',
        component: TripsListComponent
    },
    {
        path: 'all',
        component: TripsListComponent
    },
    {
        path: 'approved',
        component: ApprovedTripsComponent
    },
    {
        path: 'create',
        component: CreateTripComponent
    },
    {
        path: 'update',
        component: UpdateTripComponent
      }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class EmployeeRoutingModule { }
