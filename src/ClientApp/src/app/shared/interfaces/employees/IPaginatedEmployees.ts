import { IEmployee } from "./IEmployee";

export interface IPaginatedEmployees {
    pageIndex: number;
    totalPages: number;
    hasPreviousPage: boolean;
    hasNextPage: boolean;
    items: IEmployee[];
}