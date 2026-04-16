import { AreaType } from "./enums/areaType";
import { LocalArea } from "./localArea";

export interface LocalAreaBlank {
    id: string | null,
    name: string | null,
    areaType: AreaType | null,
    population: number | null,
    establishmentDate: Date | null,
    averageHotelBill: number | null,
    isHeroCity: boolean | null,
    regionId: string | null,
}

export namespace LocalAreaBlank {
  export function getDefault(): LocalAreaBlank {
    return {
      id: null,
      name: null,
      areaType: AreaType.City,
      population: null,
      establishmentDate: null,
      averageHotelBill: null,
      isHeroCity: false,
      regionId: null,
    }
  }

  export function fromLocalArea(localArea: LocalArea): LocalAreaBlank {
    return {
      id: localArea.id,
      name: localArea.name,
      areaType: localArea.areaType,
      population: localArea.population,
      establishmentDate: localArea.establishmentDate,
      averageHotelBill: localArea.averageHotelBill,
      isHeroCity: localArea.isHeroCity,
      regionId: localArea.regionId,
    };
  }
}
