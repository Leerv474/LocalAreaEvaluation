using Goods.Domain.LocalAreas;
using Goods.Tools.Types;
using Goods.Tools.Types.Results;

namespace Goods.Domain.Services;

public interface ILocalAreaRepository
{
    Result SaveLocalArea(LocalAreaBlank localAreaBlank);
    Page<LocalArea> GetLocalAreaPage(Int32 page, Int32 countInPage);
    LocalArea? GetLocalArea(Int32 LocalAreaId);
    Result MarkLocalAreaAsRemoved(Int32 LocalAreaId);
}
