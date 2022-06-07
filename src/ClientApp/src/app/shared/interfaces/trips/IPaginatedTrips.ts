import { ITrip } from "./ITrip";

export interface IPaginatedTrips {
    pageIndex: number;
    totalPages: number;
    hasPreviousPage: boolean;
    hasNextPage: boolean;
    items: ITrip[];
}