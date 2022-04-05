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

  constructor(
    private employeesRepository: EmployeesRepository) { }

  getEmployeeById(employeeId: string): Subject<IEmployee> {
    let employee$ = new Subject<IEmployee>();

    this.employeesRepository.getEmployeeById(employeeId)
      .pipe(take(1))
      .subscribe(result => employee$.next(result));

    return employee$;
  }

  getEmployees(pageIndex: number, pageSize: number): void {
    this.employeesRepository.getEmployees(pageIndex, pageSize)
      .pipe(take(1))
      .subscribe(result => this.paginatedEmployees$.next(result));
  }
}
