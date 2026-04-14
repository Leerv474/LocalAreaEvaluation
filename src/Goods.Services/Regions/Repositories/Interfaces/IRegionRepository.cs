using Goods.Domain.Regions;
using Goods.Tools.Types;

namespace Goods.Services.Regions.Repositories.Interfaces;

public interface IRegionRepository
{
	void SaveRegion(RegionBlank RegionBlank);
	Page<Region> GetRegionsPage(Int32 page, Int32 countInPage);
	Region? GetRegion(Guid RegionId);
	void MarkRegionAsRemoved(Guid RegionId);
}
