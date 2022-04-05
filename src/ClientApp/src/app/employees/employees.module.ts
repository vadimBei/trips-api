import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeesListComponent } from './employees-list/employees-list.component';

import { EmployeeRoutingModule } from './employee-routing.module';

@NgModule({
  declarations: [
    EmployeesListComponent
  ],
  imports: [
    CommonModule,
    EmployeeRoutingModule
  ],
  exports: [
    
  ]
})
export class EmployeesModule { }
