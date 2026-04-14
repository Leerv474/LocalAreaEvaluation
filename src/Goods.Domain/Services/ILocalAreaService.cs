using Goods.Domain.LocalAreas;
using Goods.Tools.Types;
using Goods.Tools.Types.Results;

namespace Goods.Domain.Services;

public interface ILocalAreaService
{
    Result SaveLocalArea(LocalAreaBlank localAreaBlank);
    Page<LocalArea> GetLocalAreaPage(Int32 page, Int32 countInPage);
    LocalArea? GetLocalArea(Int32 localAreaId);
    Result MarkLocalAreaAsRemoved(Int32 localAreaId);
}
