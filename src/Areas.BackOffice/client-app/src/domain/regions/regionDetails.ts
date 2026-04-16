import { Page } from "../../tools/types/page";
import { FederalDistrict } from "./enums/federalDistrict";

export class RegionDetails {
  constructor(
    public readonly id: string,
    public readonly name: string,
    public readonly federalDistrict: FederalDistrict,
    public readonly plateCodes: string[],
    public readonly localityCount: number
  ) {}
}

export function mapToRegionDetailsPage(data: any): Page<RegionDetails> {
  return Page.convert(data, mapToRegionDetails);
}

export function mapToRegionDetailList(data: any[]): RegionDetails[] {
  return data.map(mapToRegionDetails);
}

export function mapToRegionDetails(data: any): RegionDetails {
  return new RegionDetails(
    data.id,
    data.name,
    data.federalDistrict,
    data.plateCodes,
    data.localityCount
  );
}
