import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { GatewayRoutes } from 'src/app/shared/enums/routes/GatewayRoutes';
import { AlgoliaRoutes } from 'src/app/shared/enums/routes/AlgoliaRoutes';
import { IAlgoliaLocation } from 'src/app/shared/interfaces/algolia/IAlgoliaLocation';

@Injectable({
    providedIn: 'root'
})
export class AlgoliaLocationRepository {
    constructor(private httpClient: HttpClient) {
    }

    searchLocationByName(pattern: string): Observable<IAlgoliaLocation[]> {
        return this.httpClient.get<IAlgoliaLocation[]>(
            GatewayRoutes.Development + AlgoliaRoutes.SearchByName,
            {
                params: {
                    name: pattern
                }
            }
        );
    }

    searchLocationByObjectId(objectId: string): Observable<IAlgoliaLocation> {
        return this.httpClient.get<IAlgoliaLocation>(
            GatewayRoutes.Development + AlgoliaRoutes.SearchByObjectId,
            {
                params: {
                    objectId: objectId
                }
            }
        );
    }
}