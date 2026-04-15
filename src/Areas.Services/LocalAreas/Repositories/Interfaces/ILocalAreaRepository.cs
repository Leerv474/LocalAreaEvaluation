using Areas.Domain.LocalAreas;
using Areas.Tools.Types;

namespace Areas.Services.LocalAreas.Repositories.Interfaces;

public interface ILocalAreaRepository
{
    void SaveLocalArea(LocalAreaBlank localAreaBlank);
    Page<LocalArea> GetLocalAreaPage(Int32 page, Int32 countInPage);
    LocalArea? GetLocalArea(Guid LocalAreaId);
    void MarkLocalAreaAsRemoved(Guid LocalAreaId);
    LocalAreaDetails? GetLocalAreaDetails(Guid localAreaId);
}
