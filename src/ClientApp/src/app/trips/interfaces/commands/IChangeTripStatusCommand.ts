import { TripStatus } from "src/app/shared/enums/trips/TripStatus";

export interface IChangeTripStatusCommand {
    id: number;
    status: TripStatus;
}