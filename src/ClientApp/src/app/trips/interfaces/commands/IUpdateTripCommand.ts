import { TripVehicleType } from "src/app/shared/enums/trips/TripVehicleType";
import { ITripLocation } from "../ITripLocation";
import { ITripParticipan } from "../ITripParticipan";

export interface IUpdateTripCommand {
    id: number;
    dateFrom: Date;
    dateTo: Date;
    comment: string;
    goal: string;
    locations: ITripLocation[];
    participants: ITripParticipan[];
    vehicleType: TripVehicleType;
}