import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { IEmployee } from 'src/app/shared/interfaces/employees/IEmployee';
import { EmployeesService } from '../services/employees-service/employees.service';

@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.scss']
})
export class CreateEmployeeComponent implements OnInit {
  
  createEmployeeForm = new FormGroup({
    name: new FormControl(),
    lastName: new FormControl(),
    email: new FormControl(),
    phone: new FormControl(),
    age: new FormControl(),
    dateOfBirth: new FormControl(),
  })

  constructor(
    private employeesService: EmployeesService
  ) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    this.createEmployee(this.createEmployeeForm.value);
  }

  createEmployee(employee: IEmployee): void {
    this.employeesService.createEmployee(employee);
  }
}
