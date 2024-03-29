import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        loadChildren: () =>
          import('./employees/employees.module').then((m) => {
            return m.EmployeesModule;
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
