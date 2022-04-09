import { HttpClient } from '@angular/common/http';
import { catchError, Observable, take, of, tap } from 'rxjs';
import { Injectable } from '@angular/core';
import { IEmployee } from 'src/app/shared/interfaces/employees/IEmployee';
import { EmployeeRoutes } from 'src/app/shared/enums/routes/EmoloyeeRoutes';
import { IPaginatedEmployees } from 'src/app/shared/interfaces/employees/IPaginatedEmployees';

@Injectable({
  providedIn: 'root'
})
export class EmployeesRepository {
  private gatewayUrl = "http://localhost:11000/";

  constructor(private httpClient: HttpClient) { }

  getEmployeeById(employeeId: string): Observable<IEmployee> {
    return this.httpClient.get<IEmployee>(
      this.gatewayUrl + EmployeeRoutes.GetEmployeeById + employeeId);
  }

  getEmployees(pageIndex: number, pageSize: number): Observable<IPaginatedEmployees> {
    let params = `${pageIndex}/${pageSize}`;

    return this.httpClient.get<IPaginatedEmployees>(
      this.gatewayUrl + EmployeeRoutes.GetEmployees + params);
  }

  createEmployee(employee: IEmployee): Observable<IEmployee> {
    return this.httpClient.post<IEmployee>(
      this.gatewayUrl + EmployeeRoutes.CreateEmployee,
      employee);
  }

  updateEmployee(employee: IEmployee): Observable<IEmployee> {
    return this.httpClient.post<IEmployee>(
      this.gatewayUrl + EmployeeRoutes.UpdateEmployee,
      employee);
  }
}
