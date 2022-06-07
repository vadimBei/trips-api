import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs';

import { ITripFilter } from '../interfaces/ITripFilter';
import { TripsService } from '../services/trips-service';

@Component({
  selector: 'app-approved-trips',
  templateUrl: './approved-trips.component.html',
  styleUrls: ['./approved-trips.component.scss']
})
export class ApprovedTripsComponent implements OnInit {
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

    this.getApprovedTrips(this.tripFilter);
  }

  getApprovedTrips(filter: ITripFilter) {
    this.tripsService.getApprovedTrips();
  }

  previousPage(): void {
    this.tripFilter.page = this.tripFilter.page - 1;

    this.getApprovedTrips(this.tripFilter);
  }

  nextPage(): void {
    this.tripFilter.page = this.tripFilter.page + 1;

    this.getApprovedTrips(this.tripFilter);
  }
}
