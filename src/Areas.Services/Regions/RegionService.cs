using Areas.Domain.Regions;
using Areas.Domain.Services;
using Areas.Services.Regions.Repositories.Interfaces;
using Areas.Tools.Types;
using Areas.Tools.Types.Results;

namespace Areas.Services.Regions;

public class RegionService (IRegionRepository regionRepository): IRegionService
{
    public Result SaveRegion(RegionBlank regionBlank)
    {
        if (String.IsNullOrWhiteSpace(regionBlank.Name)) {
            return Result.Failed("Введите название региона");
        }
        if (String.IsNullOrWhiteSpace(regionBlank.FederalDistrict)) {
            return Result.Failed("Введите название Федерального округа");
        }
        if (regionBlank.PlateCodes is null or []) {
            return Result.Failed("Укажите автомобильные коды");
        }
        regionBlank.PlateCodes = regionBlank.PlateCodes.Distinct().ToArray();

        regionBlank.Id ??= Guid.NewGuid();
        regionRepository.SaveRegion(regionBlank);
        return Result.Success();
    }

    public Region? GetRegion(Guid regionId)
    {
        return regionRepository.GetRegion(regionId);
    }

    public Page<Region> GetRegionPage(int page, int countInPage)
    {
        return regionRepository.GetRegionsPage(page, countInPage);
    }

    public Result MarkRegionAsRemoved(Guid regionId)
    {
        Region? existsRegion = GetRegion(regionId);
        if (existsRegion is null) {
            return Result.Failed("Регион не найден");
        }
        regionRepository.MarkRegionAsRemoved(regionId);
        return Result.Success();
    }
}
