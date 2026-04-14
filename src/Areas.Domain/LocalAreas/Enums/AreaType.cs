using System.ComponentModel.DataAnnotations;

namespace Areas.Domain.LocalAreas.Enums;

public enum AreaType {
	[Display(Name = "Город")]
    City = 1,
	[Display(Name = "Деревня")]
    Village = 2,
	[Display(Name = "Сельская местность")]
    CountrySide = 3,
}
