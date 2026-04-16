using Areas.Domain.Regions;
using Areas.Tools.Types;
using Areas.Tools.Types.Results;

namespace Areas.Domain.Services;

public interface IRegionService
{
    Result SaveRegion(RegionBlank regionBlank);
    Page<RegionDetails> GetRegionPage(Int32 page, Int32 countInPage);
    Region? GetRegion(Guid regionId);
    Result MarkRegionAsRemoved(Guid regionId);
    RegionItem[] GetAllRegionItems();
}
