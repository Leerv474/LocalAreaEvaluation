import { FederalDistrict } from "./enums/federalDistrict";
import { Region } from "./region";

export interface RegionBlank {
    id: string | null,
    name: string | null,
    federalDistrict: FederalDistrict | null,
    plateCodes: string[]
}

export namespace RegionBlank {
  export function getDefault(): RegionBlank {
    return {
      id: null,
      name: null,
      federalDistrict: FederalDistrict.Central,
      plateCodes: [] 
    }
  }

  export function fromRegion(region: Region): RegionBlank {
    return {
      id: region.id,
      name: region.name,
      federalDistrict: region.federalDistrict,
      plateCodes: region.plateCodes
    };
  }
}
