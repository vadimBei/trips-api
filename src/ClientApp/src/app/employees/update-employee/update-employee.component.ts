import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import * as moment from 'moment';
import { ActivatedRoute } from '@angular/router';

import { IEmployee } from 'src/app/shared/interfaces/employees/IEmployee';
import { EmployeesService } from '../services/employees-service/employees.service';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.scss']
})
export class UpdateEmployeeComponent implements OnInit {

  employee$ = this.employeesService.employee$;

  employeeId = "";

  updateEmployeeForm = new FormGroup({
    name: new FormControl(),
    lastName: new FormControl(),
    email: new FormControl(),
    phone: new FormControl(),
    age: new FormControl(),
    dateOfBirth: new FormControl()
  });

  constructor(
    private activatedRoute: ActivatedRoute,
    private employeesService: EmployeesService
  ) { }

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params => {
      this.employeeId = params['id'];
    });

    this.getEmployee(this.employeeId);

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

  getEmployee(employeeId: string) {
    debugger;

    this.employeesService.getEmployeeById(employeeId);
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
