using System.ComponentModel.DataAnnotations;

namespace Areas.Domain.Regions.Enums;

public enum FederalDistrict
{
    [Display(Name = "Центральный")]
    Central = 1,

    [Display(Name = "Северо-Западный")]
    NorthWestern = 2,

    [Display(Name = "Южный")]
    Sothern = 3,

    [Display(Name = "Северо-Кавказский")]
    NorthCaucasus = 4,

    [Display(Name = "Приволжский")]
    Volda = 5,

    [Display(Name = "Уральский")]
    Urals = 6,

    [Display(Name = "Сибирский")]
    Siberia = 7,

    [Display(Name = "Дальневосточный")]
    FarEastern = 8,
}

public static class DistrictExtensions
{
    public static int GetValuableAge(this FederalDistrict d) =>
        d switch
        {
            FederalDistrict.Central => 100,
            FederalDistrict.NorthWestern => 80,
            FederalDistrict.Sothern => 120,
            FederalDistrict.NorthCaucasus => 140,
            FederalDistrict.Volda => 130,
            FederalDistrict.Urals => 110,
            FederalDistrict.Siberia => 70,
            FederalDistrict.FarEastern => 70,
            _ => 100,
        };
}
