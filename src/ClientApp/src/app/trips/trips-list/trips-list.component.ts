import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs';

import { ITripFilter } from '../interfaces/ITripFilter';
import { TripsService } from '../services/trips-service';

@Component({
  selector: 'app-trips-list',
  templateUrl: './trips-list.component.html',
  styleUrls: ['./trips-list.component.scss']
})
export class TripsListComponent implements OnInit {
  tripFilter: ITripFilter = {} as ITripFilter;

  hasNextPage: boolean = false;
  hasPreviousPage: boolean = false;

  paginatedTrips$ = this.tripsService.paginatedTrips$
    .pipe(
      tap(responce => {
        this.hasNextPage = responce.hasNextPage;
        this.hasPreviousPage = responce.hasPreviousPage;
      })
    );

  constructor(
    private tripsService: TripsService) { }

  ngOnInit(): void {
    this.tripFilter.page = 1;
    this.tripFilter.limit = 5;

    this.getTrips(this.tripFilter);
  }

  getTrips(filter: ITripFilter) {
    this.tripsService.getTrips(filter);
  }

  previousPage(): void {
    this.tripFilter.page = this.tripFilter.page - 1;

    this.getTrips(this.tripFilter);
  }

  nextPage(): void {
    this.tripFilter.page = this.tripFilter.page + 1;

    this.getTrips(this.tripFilter);
  }
}
