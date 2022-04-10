import { Component, OnInit } from '@angular/core';
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

  deleteEmployee(employeeId: string){
    this.employeeService.deleteEmployee(employeeId);
  }

  ngOnDestroy(): void {
    this.paginatedEmployees$.unsubscribe();
  }
}