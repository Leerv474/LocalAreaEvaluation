import { Page } from "../../tools/types/page";
import { Result } from "../../tools/types/results/result";
import { mapToRegion, mapToRegionsPage, Region } from "./region";
import { RegionBlank } from "./regionBlank";
import { mapToRegionItems, RegionItem } from "./regionItem";

export class RegionsProvider {
  private static readonly headers: HeadersInit = [
    ["X-Requested-With", "XMLHttpRequest"],
    ["Content-Type", "application/json"],
  ];

  public static async saveRegion(regionBlank: RegionBlank): Promise<Result> {
    const response = await fetch("/regions/save", {
      method: "POST",
      headers: this.headers,
      body: JSON.stringify(regionBlank),
    });
    const json = await response.json();

    return Result.get(json);
  }

  public static async getRegionsPage(
    page: number,
    countInPage: number,
  ): Promise<Page<Region>> {
    const response = await fetch(
      `/regions/get_page?page=${page}&countInPage=${countInPage}`,
      {
        method: "GET",
        headers: this.headers,
      },
    );
    const json = await response.json();

    return mapToRegionsPage(json);
  }

  public static async getRegionById(regionId: string): Promise<Region | null> {
    const response = await fetch(`/regions/get_by_id?regionId=${regionId}`, {
      method: "GET",
      headers: this.headers,
    });
    const json = await response.json();

    return mapToRegion(json);
  }

  public static async markRegionAsRemoved(regionId: string): Promise<Result> {
    const response = await fetch(
      `/regions/mark_as_removed?regionId=${regionId}`,
      {
        method: "GET",
        headers: this.headers,
      },
    );
    const json = await response.json();

    return Result.get(json);
  }

  public static async getAllRegionItems(): Promise<RegionItem[]> {
    const response = await fetch(`/regions/get_all_items`, {
      method: "GET",
      headers: this.headers,
    });
    const json = await response.json();
    return mapToRegionItems(json);
  }
}
