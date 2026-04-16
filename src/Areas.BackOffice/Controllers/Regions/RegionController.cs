using Areas.Domain.Regions;
using Areas.Domain.Services;
using Areas.Tools.Types.Results;
using Areas.Tools.Types;
using Microsoft.AspNetCore.Mvc;

namespace Areas.BackOffice.Controllers.Regions;

public class RegionsController(IRegionService regionsService) : AppController
{
	[HttpPost("regions/save")]
	public Result SaveRegions([FromBody] RegionBlank regionBlank)
	{
		return regionsService.SaveRegion(regionBlank);
	}

	[HttpGet("regions/get_page")]
	public Page<RegionDetails> GetRegionsPage([FromQuery] Int32 page, [FromQuery] Int32 countInPage)
	{
		return regionsService.GetRegionPage(page, countInPage);
	}

	[HttpGet("regions/get_by_id")]
	public Region? GetRegion([FromQuery] Guid regionId)
	{
        return regionsService.GetRegion(regionId);
	}

	[HttpGet("regions/mark_region_as_removed")]
	public Result MarkRegionAsRemoved([FromQuery] Guid regionId)
	{
		return regionsService.MarkRegionAsRemoved(regionId);
	}

    [HttpGet("regions/get_all_items")]
    public RegionItem[] GetAllRegionItems()
    {
        return regionsService.GetAllRegionItems();
    }
}
