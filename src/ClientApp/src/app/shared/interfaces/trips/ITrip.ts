import { TripStatus } from "../../enums/trips/TripStatus";
import { TripType } from "../../enums/trips/TripType";
import { TripVehicleType } from "../../enums/trips/TripVehicleType";
import { IAlgoliaLocation } from "../algolia/IAlgoliaLocation";
import { IEmployee } from "../employees/IEmployee";

export interface ITrip {
    id: string;
    dateFrom: Date;
    dateTo: Date;
    approvedDate?: Date;
    comment: string;
    goal: string;
    type: TripType;
    status: TripStatus;
    vehicleType: TripVehicleType;
    author: IEmployee;
    approvedEmployee?: IEmployee;
    locations: IAlgoliaLocation[];
    participants: IEmployee[];
}