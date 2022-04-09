import { Observable, Subject, take, tap } from 'rxjs';
import { Injectable } from '@angular/core';
import { IEmployee } from 'src/app/shared/interfaces/employees/IEmployee';
import { IPaginatedEmployees } from 'src/app/shared/interfaces/employees/IPaginatedEmployees';
import { EmployeesRepository } from '../../repositories/employees-repository/employees-repository';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  paginatedEmployees$ = new Subject<IPaginatedEmployees>();
  employee$ = new Subject<IEmployee>();

  constructor(
    private employeesRepository: EmployeesRepository) { }

  getEmployeeById(employeeId: string): void {
    this.employeesRepository.getEmployeeById(employeeId)
      .pipe(take(1),
        tap(res => console.log(res)))
      .subscribe(result => this.employee$.next(result));
  }

  getEmployees(pageIndex: number, pageSize: number): void {
    this.employeesRepository.getEmployees(pageIndex, pageSize)
      .pipe(
        tap(res => console.log(res)),
        take(1))
      .subscribe(result => this.paginatedEmployees$.next(result));
  }

  createEmployee(employee: IEmployee): void {
    this.employeesRepository.createEmployee(employee)
      .pipe(
        tap(res => console.log(res)),
        take(1))
      .subscribe();
  }

  updateEmployee(employee: IEmployee): void {
    this.employeesRepository.updateEmployee(employee)
      .pipe(
        tap(res => console.log(res)),
        take(1))
      .subscribe()
  }
}
