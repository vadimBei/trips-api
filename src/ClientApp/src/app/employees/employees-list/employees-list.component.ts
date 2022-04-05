import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { IPaginatedEmployees } from 'src/app/shared/interfaces/employees/IPaginatedEmployees';
import { EmployeesService } from '../services/employees-service/employees.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.scss']
})
export class EmployeesListComponent implements OnInit {
  paginatedEmployees$ = this.employeeService.paginatedEmployees$;

  constructor(
    private employeeService: EmployeesService
  ) {
  }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees() {
    this.employeeService.getEmployees(1, 10);
  }

  ngOnDestroy(): void {
    this.paginatedEmployees$.unsubscribe();
  }
}