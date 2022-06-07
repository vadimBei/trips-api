import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { IEmployee } from 'src/app/shared/interfaces/employees/IEmployee';
import { EmployeesRoutes } from 'src/app/shared/enums/routes/EmoloyeesRoutes';
import { IPaginatedEmployees } from 'src/app/shared/interfaces/employees/IPaginatedEmployees';
import { GatewayRoutes } from 'src/app/shared/enums/routes/GatewayRoutes';
import { ICreateEmployeeCommand } from '../../interfaces/commands/ICreateEmployeeCommand';
import { IUpdateEmployeeCommand } from '../../interfaces/commands/IUpdateEmployeeCommand';

@Injectable({
  providedIn: 'root'
})
export class EmployeesRepository {
  constructor(private httpClient: HttpClient) { }

  getEmployeeById(employeeId: string): Observable<IEmployee> {
    return this.httpClient.get<IEmployee>(
      GatewayRoutes.Development + EmployeesRoutes.GetEmployeeById + employeeId);
  }

  getEmployees(pageIndex: number, pageSize: number): Observable<IPaginatedEmployees> {
    return this.httpClient.get<IPaginatedEmployees>(
      GatewayRoutes.Development + EmployeesRoutes.GetEmployees,
      {
        params: {
          pageIndex: pageIndex,
          pageSize: pageSize
        }
      }
    );
  }

  createEmployee(employee: ICreateEmployeeCommand): Observable<IEmployee> {
    return this.httpClient.post<IEmployee>(
      GatewayRoutes.Development + EmployeesRoutes.CreateEmployee,
      employee);
  }

  updateEmployee(employee: IUpdateEmployeeCommand): Observable<IEmployee> {
    return this.httpClient.post<IEmployee>(
      GatewayRoutes.Development + EmployeesRoutes.UpdateEmployee,
      employee);
  }

  deleteEmployee(employeeId: string): Observable<Object> {
    return this.httpClient.delete(
      GatewayRoutes.Development + EmployeesRoutes.DeleteEmployee,
      {
        params: {
          id: employeeId
        }
      });
  }

  searchEmployees(pattern: string, pageIndex: number, pageSize: number): Observable<IPaginatedEmployees> {
    return this.httpClient.get<IPaginatedEmployees>(
      GatewayRoutes.Development + EmployeesRoutes.SearchEmployees,
      {
        params: {
          pattern: pattern,
          pageIndex: pageIndex,
          pageSize: pageSize
        }
      });
  }
}
