import { TripStatus } from "src/app/shared/enums/trips/TripStatus";

export interface ITripFilter {
    page: number;
    limit: number;
    locationObjectId: string;
    dateFrom?: Date;
    dateTo?: Date;
    status: TripStatus;
    search: string;
    // SortField
    // SortOrder
}