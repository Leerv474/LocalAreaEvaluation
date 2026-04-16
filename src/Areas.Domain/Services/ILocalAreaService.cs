using Areas.Domain.LocalAreas;
using Areas.Tools.Types;
using Areas.Tools.Types.Results;

namespace Areas.Domain.Services;

public interface ILocalAreaService
{
    Result SaveLocalArea(LocalAreaBlank localAreaBlank);
    Page<LocalAreaDetails> GetLocalAreaPage(Int32 page, Int32 countInPage);
    LocalArea? GetLocalArea(Guid localAreaId);
    Result MarkLocalAreaAsRemoved(Guid localAreaId);
    Boolean EvaluateLocalArea(Guid localAreaId);
    LocalAreaDetails? GetLocalAreaDetails(Guid localAreaId);
}
