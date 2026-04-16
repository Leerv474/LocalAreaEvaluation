export enum AreaType {
  City = 1,
  Village = 2,
  CountrySide = 3,
}
export namespace AreaType {
  export const getDisplayName = (areaType: AreaType): string => {
    switch (areaType) {
      case AreaType.City:
        return "Город";
      case AreaType.Village:
        return "Деревня";
      case AreaType.CountrySide:
        return "Сельская местность";
    }
  };
}
