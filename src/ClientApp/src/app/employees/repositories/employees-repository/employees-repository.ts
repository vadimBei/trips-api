import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { IEmployee } from 'src/app/shared/interfaces/employees/IEmployee';
import { EmployeeRoutes } from 'src/app/shared/enums/routes/EmoloyeeRoutes';
import { IPaginatedEmployees } from 'src/app/shared/interfaces/employees/IPaginatedEmployees';

@Injectable({
  providedIn: 'root'
})
export class EmployeesRepository {
  private gatewayUrl = "http://localhost:11000/";

  constructor(private http: HttpClient) { }

  getEmployeeById(employeeId: string): Observable<IEmployee> {
    return this.http.get<IEmployee>(this.gatewayUrl + EmployeeRoutes.GetEmployeeById + employeeId);
  }

  getEmployees(pageIndex: number, pageSize: number): Observable<IPaginatedEmployees> {
    let params = `${pageIndex}/${pageSize}`;

    return this.http.get<IPaginatedEmployees>(this.gatewayUrl + EmployeeRoutes.GetEmployees + params);
  }
}
