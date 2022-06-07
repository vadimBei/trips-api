import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        loadChildren: () =>
          import('./trips/trips.module').then((m) => {
            return m.TripsModule;
          })
      },
      {
        path: 'trips',
        loadChildren: () =>
          import('./trips/trips.module').then((m) => {
            return m.TripsModule;
          })
      },
      {
        path: 'employees',
        loadChildren: () =>
          import('./employees/employees.module').then((m) => {
            return m.EmployeesModule;
          })
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
