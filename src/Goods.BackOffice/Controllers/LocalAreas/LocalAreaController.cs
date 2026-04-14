using Goods.Domain.LocalAreas;
using Goods.Domain.Services;
using Goods.Tools.Types.Results;
using Goods.Tools.Types;
using Microsoft.AspNetCore.Mvc;

namespace Goods.BackOffice.Controllers.LocalAreas;

public class LocalAreasController(ILocalAreaService localAreasService) : AppController
{
	[HttpPost("local_areas/save")]
	public Result SaveLocalAreas([FromBody] LocalAreaBlank local_areaBlank)
	{
		return localAreasService.SaveLocalArea(local_areaBlank);
	}

	[HttpGet("local_areas/get_page")]
	public Page<LocalArea> GetLocalAreasPage([FromQuery] Int32 page, [FromQuery] Int32 countInPage)
	{
		return localAreasService.GetLocalAreaPage(page, countInPage);
	}

	[HttpGet("local_areas/get_by_id")]
	public LocalArea? GetLocalArea([FromQuery] Guid localAreaId)
	{
		return localAreasService.GetLocalArea(localAreaId);
	}

	[HttpGet("local_areas/mark_product_as_removed")]
	public Result MarkLocalAreaAsRemoved([FromQuery] Guid localAreaId)
	{
		return localAreasService.MarkLocalAreaAsRemoved(localAreaId);
	}
}
