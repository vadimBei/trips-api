import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import * as moment from 'moment';

import { IEmployee } from 'src/app/shared/interfaces/employees/IEmployee';
import { EmployeesService } from '../services/employees-service/employees.service';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.scss']
})
export class UpdateEmployeeComponent implements OnInit {

  employee$ = this.employeesService.employee$;

  updateEmployeeForm = new FormGroup({
    name: new FormControl(),
    lastName: new FormControl(),
    email: new FormControl(),
    phone: new FormControl(),
    age: new FormControl(),
    dateOfBirth: new FormControl()
  });

  employeeId = "";

  constructor(
    private employeesService: EmployeesService
  ) { }

  ngOnInit(): void {
    this.getEmployee();

    this.employee$
      .subscribe(res => {
        this.updateEmployeeForm.setValue({
          name: res.name,
          lastName: res.lastName,
          email: res.email,
          phone: res.phone,
          age: res.age,
          dateOfBirth: moment(res.dateOfBirth).format('yyyy-MM-DD')
        });

        this.employeeId = res.id;
      });
  }

  getEmployee() {
    this.employeesService.getEmployeeById("68e4fff6-f4cb-496f-9cae-c69d4268b332");
  }

  onSubmit(): void {
    this.updateEmployee(this.updateEmployeeForm.value);
  }

  updateEmployee(employee: IEmployee): void {
    employee.id = this.employeeId;

    this.employeesService.updateEmployee(employee);
  }

  ngOnDestroy(): void {
    this.employee$.unsubscribe();
  }
}
