export class RegionItem {
  constructor(
    public readonly id: string,
    public readonly name: string,
  ) {}
}

export function mapToRegionItems(data: any[]): RegionItem[] {
  return data.map(mapToRegionItem);
}

export function mapToRegionItem(data: any): RegionItem {
  return new RegionItem(
    data.id,
    data.name,
  );
}
