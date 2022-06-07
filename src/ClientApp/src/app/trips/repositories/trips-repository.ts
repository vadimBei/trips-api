import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IPaginatedTrips } from 'src/app/shared/interfaces/trips/IPaginatedTrips';
import { GatewayRoutes } from 'src/app/shared/enums/routes/GatewayRoutes';
import { TripsRoutes } from 'src/app/shared/enums/routes/TripsRoutes';
import { ITripFilter } from '../interfaces/ITripFilter';
import { ITrip } from 'src/app/shared/interfaces/trips/ITrip';
import { IChangeTripStatusCommand } from '../interfaces/commands/IChangeTripStatusCommand';
import { IUpdateTripCommand } from '../interfaces/commands/IUpdateTripCommand';
import { ICreateTripCommand } from '../interfaces/commands/ICreateTripCommand';
import * as moment from 'moment';

@Injectable({
    providedIn: 'root'
})
export class TripsRepository {
    constructor(private httpClient: HttpClient) {
    }

    getTrips(filter: ITripFilter): Observable<IPaginatedTrips> {
        return this.httpClient.get<IPaginatedTrips>(
            GatewayRoutes.Development + TripsRoutes.GetTrips,
            {
                params: {
                    page: filter.page,
                    limit: filter.limit,
                    // locationObjectId: filter.locationObjectId,
                    // dateFrom: moment
                    // dateTo: filter.dateTo
                    // status: filter.status,
                    // search: filter.search
                }
            }
        );
    }

    getTripById(tripId: number): Observable<ITrip> {
        return this.httpClient.get<ITrip>(
            GatewayRoutes.Development + TripsRoutes.GetTripById,
            {
                params: {
                    id: tripId
                }
            }
        );
    }

    getApprovedTrips(): Observable<IPaginatedTrips> {
        return this.httpClient.get<IPaginatedTrips>(
            GatewayRoutes.Development + TripsRoutes.GetApprovedTrips
        );
    }

    deleteTrip(tripId: number): Observable<Object> {
        return this.httpClient.delete(
            GatewayRoutes.Development + TripsRoutes.DeleteTrip,
            {
                params: {
                    id: tripId
                }
            }
        );
    }

    changeTripStatus(command: IChangeTripStatusCommand): Observable<ITrip> {
        return this.httpClient.post<ITrip>(
            GatewayRoutes.Development + TripsRoutes.ChangeTripStatus,
            command
        );
    }

    updateTrip(command: IUpdateTripCommand): Observable<ITrip> {
        return this.httpClient.post<ITrip>(
            GatewayRoutes.Development + TripsRoutes.UpdateTrip,
            command
        );
    }

    createTrip(command: ICreateTripCommand): Observable<ITrip> {
        return this.httpClient.post<ITrip>(
            GatewayRoutes.Development + TripsRoutes.CreateTrip,
            command
        );
    }
}