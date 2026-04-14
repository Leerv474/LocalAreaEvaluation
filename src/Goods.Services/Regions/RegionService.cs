using Goods.Domain.Regions;
using Goods.Domain.Services;
using Goods.Tools.Types;
using Goods.Tools.Types.Results;

public class RegionService : IRegionService
{
    public Result SaveLocalArea(RegionBlank regionBlank)
    {
        if (String.IsNullOrWhiteSpace(regionBlank.Name)) {
            return Result.Failed("Введите название региона");
        }
        if (String.IsNullOrWhiteSpace(regionBlank.FederalDistrict)) {
            return Result.Failed("Введите название Федерального округа");
        }
        if (regionBlank.PlateCodes is null) {
            return Result.Failed("Укажите ");
        }
        regionBlank.PlateCodes = regionBlank.PlateCodes.Distinct().ToArray();
    }

    public Region? GetRegion(int RegionId)
    {
        throw new NotImplementedException();
    }

    public Page<Region> GetRegionPage(int page, int countInPage)
    {
        throw new NotImplementedException();
    }

    public Result MarkRegionAsRemoved(int RegionId)
    {
        throw new NotImplementedException();
    }
}
