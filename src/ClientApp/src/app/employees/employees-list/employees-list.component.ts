import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { fromEvent, tap, map, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

import { EmployeesService } from '../services/employees-service/employees.service';
@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.scss']
})
export class EmployeesListComponent implements OnInit {
  hasNextPage: boolean = false;
  hasPreviousPage: boolean = false;
  subscription: Subscription = new Subscription;

  paginatedEmployees$ = this.employeeService.paginatedEmployees$
    .pipe(
      tap(responce => {
        this.hasNextPage = responce.hasNextPage;
        this.hasPreviousPage = responce.hasPreviousPage;
      })
    );

  @ViewChild('search') search!: ElementRef;

  constructor(
    private employeeService: EmployeesService
  ) {
  }

  ngOnInit(): void {
    this.getEmployees(1);
  }

  ngAfterViewInit() {
    this.subscription = fromEvent(this.search.nativeElement, 'input')
      .pipe(
        map((e: any) => e?.target?.value),
        debounceTime(1000),
        distinctUntilChanged(),
        tap(value => {
          this.employeeService.searchEmployees(value, 1, 10)
        }))
      .subscribe();
  }

  getEmployees(pageIndex: number) {
    this.employeeService.getEmployees(pageIndex, 3);
  }

  deleteEmployee(employeeId: string) {
    this.employeeService.deleteEmployee(employeeId);
  }

  previousPage(pageIndex: number): void {
    this.getEmployees(pageIndex);
  }

  nextPage(pageIndex: number): void {
    this.getEmployees(pageIndex);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}