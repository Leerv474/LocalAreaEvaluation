import { Page } from "../../tools/types/page";
import { AreaType } from "./enums/areaType";

export class LocalArea {
  constructor(
    public readonly id: string,
    public readonly name: string,
    public readonly areaType: AreaType,
    public readonly population: number,
    public readonly establishmentDate: Date,
    public readonly averageHotelBill: number,
    public readonly isHeroCity: boolean,
    public readonly regionId: string,
  ) {}
}

export function mapToLocalAreasPage(data: any): Page<LocalArea> {
  return Page.convert(data, mapToLocalArea);
}

export function mapToLocalAreas(data: any[]): LocalArea[] {
  return data.map(mapToLocalArea);
}

export function mapToLocalArea(data: any): LocalArea {
  return new LocalArea(
    data.id,
    data.name,
    data.areaType,
    data.population,
    data.establishmentDate,
    data.averageHotelBill,
    data.isHeroCity,
    data.regionId,
  );
}
