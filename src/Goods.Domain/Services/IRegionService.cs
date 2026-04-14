using Goods.Domain.Regions;
using Goods.Tools.Types;
using Goods.Tools.Types.Results;

namespace Goods.Domain.Services;

public interface IRegionService
{
    Result SaveLocalArea(RegionBlank regionBlank);
    Page<Region> GetRegionPage(Int32 page, Int32 countInPage);
    Region? GetRegion(Int32 RegionId);
    Result MarkRegionAsRemoved(Int32 RegionId);
}
