using Areas.Domain.LocalAreas;
using Areas.Domain.Services;
using Areas.Tools.Types.Results;
using Areas.Tools.Types;
using Microsoft.AspNetCore.Mvc;

namespace Areas.BackOffice.Controllers.LocalAreas;

public class LocalAreasController(ILocalAreaService localAreasService) : AppController
{
	[HttpPost("local_areas/save")]
	public Result SaveLocalAreas([FromBody] LocalAreaBlank localAreaBlank)
	{
		return localAreasService.SaveLocalArea(localAreaBlank);
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

	[HttpGet("local_areas/mark_as_removed")]
	public Result MarkLocalAreaAsRemoved([FromQuery] Guid localAreaId)
	{
		return localAreasService.MarkLocalAreaAsRemoved(localAreaId);
	}

	[HttpGet("local_areas/evaluate")]
	public Boolean EvaluateLocalArea([FromQuery] Guid localAreaId)
	{
		return localAreasService.EvaluateLocalArea(localAreaId);
	}

	[HttpGet("local_areas/get_details_by_id")]
	public LocalAreaDetails? GetLocalAreaDetails([FromQuery] Guid localAreaId)
	{
		return localAreasService.GetLocalAreaDetails(localAreaId);
	}
}
