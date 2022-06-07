import { Injectable } from '@angular/core';
import { Subject, tap, take } from 'rxjs';
import { IAlgoliaLocation } from 'src/app/shared/interfaces/algolia/IAlgoliaLocation';
import { AlgoliaLocationRepository } from '../repositories/algolia-location-repository';

@Injectable({
    providedIn: 'root'
})
export class AlgoliaLocationService {
    algoliaLocations$ = new Subject<IAlgoliaLocation[]>();
    algoliaLocation$ = new Subject<IAlgoliaLocation>();

    constructor(
        private algoliaLocationRepository: AlgoliaLocationRepository) {
    }

    searchLocationByName(pattern: string): void {
        this.algoliaLocationRepository.searchLocationByName(pattern)
            .pipe(
                take(1),
                tap(res => console.log(res))
            )
            .subscribe(result => this.algoliaLocations$.next(result));
    }

    searchLocationByObjectId(objectId: string): void {
        this.algoliaLocationRepository.searchLocationByObjectId(objectId)
            .pipe(
                take(1),
                tap(res => console.log(res))
            )
            .subscribe(result => this.algoliaLocation$.next(result));
    }
}