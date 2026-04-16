export enum FederalDistrict {
  Central = 1,
  NorthWestern = 2,
  Sothern = 3,
  NorthCaucasus = 4,
  Volda = 5,
  Urals = 6,
  Siberia = 7,
  FarEastern = 8,
}

export namespace FederalDistrict {
  export const getDisplayName = (federalDistrict: FederalDistrict): string => {
    switch (federalDistrict) {
      case FederalDistrict.Central:
        return "Центральный";
      case FederalDistrict.NorthWestern:
        return "Северо-Западный";
      case FederalDistrict.Sothern:
        return "Южный";
      case FederalDistrict.NorthCaucasus:
        return "Северо-Кавказский";
      case FederalDistrict.Volda:
        return "Приволжский";
      case FederalDistrict.Urals:
        return "Уральский";
      case FederalDistrict.Siberia:
        return "Сибирский";
      case FederalDistrict.FarEastern:
        return "Дальневосточный";
    }
  };
}
