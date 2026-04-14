using Goods.Domain.Regions;
using Goods.Domain.Services;
using Goods.Tools.Types.Results;
using Goods.Tools.Types;
using Microsoft.AspNetCore.Mvc;

namespace Goods.BackOffice.Controllers.Regions;

public class RegionsController(IRegionService regionsService) : AppController
{
	[HttpPost("local_areas/save")]
	public Result SaveRegions([FromBody] RegionBlank regionBlank)
	{
		return regionsService.SaveRegion(regionBlank);
	}

	[HttpGet("local_areas/get_page")]
	public Page<Region> GetRegionsPage([FromQuery] Int32 page, [FromQuery] Int32 countInPage)
	{
		return regionsService.GetRegionPage(page, countInPage);
	}

	[HttpGet("local_areas/get_by_id")]
	public Region? GetRegion([FromQuery] Guid regionId)
	{
        return regionsService.GetRegion(regionId);
	}

	[HttpGet("local_areas/mark_product_as_removed")]
	public Result MarkRegionAsRemoved([FromQuery] Guid regionId)
	{
		return regionsService.MarkRegionAsRemoved(regionId);
	}
}
