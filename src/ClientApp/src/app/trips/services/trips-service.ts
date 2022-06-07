import { Injectable } from '@angular/core';
import { Subject, take, tap } from 'rxjs';

import { IPaginatedTrips } from 'src/app/shared/interfaces/trips/IPaginatedTrips';
import { ITrip } from 'src/app/shared/interfaces/trips/ITrip';
import { IChangeTripStatusCommand } from '../interfaces/commands/IChangeTripStatusCommand';
import { ICreateTripCommand } from '../interfaces/commands/ICreateTripCommand';
import { IUpdateTripCommand } from '../interfaces/commands/IUpdateTripCommand';
import { ITripFilter } from '../interfaces/ITripFilter';
import { TripsRepository } from '../repositories/trips-repository';

@Injectable({
    providedIn: 'root'
})
export class TripsService {
    paginatedTrips$ = new Subject<IPaginatedTrips>();
    trip$ = new Subject<ITrip>();

    constructor(private tripsRepository: TripsRepository) {
    }

    getTrips(filter: ITripFilter): void {
        this.tripsRepository.getTrips(filter)
            .pipe(
                take(1),
                tap(res => console.log(res))
            )
            .subscribe(result => this.paginatedTrips$.next(result));
    }

    getTripById(tripId: number): void {
        this.tripsRepository.getTripById(tripId)
            .pipe(
                take(1),
                tap(res => console.log(res))
            )
            .subscribe(result => this.trip$.next(result));
    }

    getApprovedTrips(): void {
        this.tripsRepository.getApprovedTrips()
            .pipe(
                take(1),
                tap(res => console.log(res))
            )
            .subscribe(result => this.paginatedTrips$.next(result));
    }

    deleteTrip(tripId: number): void {
        this.tripsRepository.deleteTrip(tripId)
            .pipe(
                take(1)
            )
            .subscribe();
    }

    changeTripStatus(command: IChangeTripStatusCommand): void {
        this.tripsRepository.changeTripStatus(command)
            .pipe(
                take(1),
                tap(res => console.log(res))
            )
            .subscribe(result => this.trip$.next(result));
    }

    updateTrip(command: IUpdateTripCommand): void {
        this.tripsRepository.updateTrip(command)
            .pipe(
                take(1),
                tap(res => console.log(res))
            )
            .subscribe(result => this.trip$.next(result));
    }

    createTrip(command: ICreateTripCommand): void {
        this.tripsRepository.createTrip(command)
            .pipe(
                take(1),
                tap(res => console.log(res))
            )
            .subscribe(result => this.trip$.next(result));
    }
}