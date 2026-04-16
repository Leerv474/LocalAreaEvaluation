import { Page } from "../../tools/types/page";
import { AreaType } from "./enums/areaType";

export class LocalAreaDetails {
  constructor(
    public readonly id: string,
    public readonly name: string,
    public readonly areaType: AreaType,
    public readonly population: number,
    public readonly establishmentDate: Date,
    public readonly averageHotelBill: number,
    public readonly isHeroCity: boolean,
    public readonly regionName: string,
  ) {}
}

export function mapToLocalAreaDetailsPage(data: any): Page<LocalAreaDetails> {
  return Page.convert(data, mapToLocalAreaDetails);
}

export function mapToLocalAreaDetailsList(data: any[]): LocalAreaDetails[] {
  return data.map(mapToLocalAreaDetails);
}

export function mapToLocalAreaDetails(data: any): LocalAreaDetails {
  return new LocalAreaDetails(
    data.id,
    data.name,
    data.areaType,
    data.population,
    data.establishmentDate,
    data.averageHotelBill,
    data.isHeroCity,
    data.regionName,
  );
}
