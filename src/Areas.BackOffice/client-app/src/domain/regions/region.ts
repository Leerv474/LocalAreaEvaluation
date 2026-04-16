import { Page } from "../../tools/types/page";
import { FederalDistrict } from "./enums/federalDistrict";

export class Region {
  constructor(
    public readonly id: string,
    public readonly name: string,
    public readonly federalDistrict: FederalDistrict,
    public readonly plateCodes: string[]
  ) {}
}

export function mapToRegionsPage(data: any): Page<Region> {
  return Page.convert(data, mapToRegion);
}

export function mapToRegions(data: any[]): Region[] {
  return data.map(mapToRegion);
}

export function mapToRegion(data: any): Region {
  return new Region(
    data.id,
    data.name,
    data.federalDistrict,
    data.plateCodes
  );
}
