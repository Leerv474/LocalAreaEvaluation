using Areas.Domain.LocalAreas;
using Areas.Domain.Services;
using Areas.Services.LocalAreas.Repositories.Interfaces;
using Areas.Tools.Types;
using Areas.Tools.Types.Results;

namespace Areas.Services.LocalAreas;

public class LocalAreaService(ILocalAreaRepository localAreaRepository) : ILocalAreaService
{
    private const Int32 MAX_LOCAL_AREA_NAME_LENGTH = 255;

    public Result SaveLocalArea(LocalAreaBlank localAreaBlank)
    {
        if (String.IsNullOrWhiteSpace(localAreaBlank.Name))
        {
            return Result.Failed("Введите название Населенного пункта");
        }
        if (localAreaBlank.Name.Length == MAX_LOCAL_AREA_NAME_LENGTH)
        {
            return Result.Failed(
                $"Название населенного пункта слишком длинное. Максимально допустимо {MAX_LOCAL_AREA_NAME_LENGTH} символов"
            );
        }
        if (localAreaBlank.AreaType is null)
        {
            return Result.Failed("Введите тип населенного пункта");
        }
        if (localAreaBlank.Population is null)
        {
            return Result.Failed("Введите численность населения");
        }
        if (localAreaBlank.EstablishmentDate is null)
        {
            return Result.Failed("Введите дату основания");
        }
        if (localAreaBlank.AverageHotelBill is null)
        {
            return Result.Failed("Введите среднюю стоимость номера в отеле");
        }
        if (localAreaBlank.IsHeroCity is null)
        {
            return Result.Failed("Укажите, является ли населенный пункт Городом-героем");
        }
        if (localAreaBlank.RegionId is null)
        {
            return Result.Failed("Укажите регион населенного пункта");
        }

        localAreaBlank.Id ??= Guid.NewGuid();
        localAreaRepository.SaveLocalArea(localAreaBlank);
        return Result.Success();
    }

    public LocalArea? GetLocalArea(Guid localAreaId)
    {
        return localAreaRepository.GetLocalArea(localAreaId);
    }

    public Page<LocalArea> GetLocalAreaPage(Int32 page, Int32 countInPage)
    {
        return localAreaRepository.GetLocalAreaPage(page, countInPage);
    }

    public Result MarkLocalAreaAsRemoved(Guid localAreaId)
    {
        LocalArea? existsLocalArea = GetLocalArea(localAreaId);
        if (existsLocalArea is null)
        {
            return Result.Failed("Населенный пункт не найден.");
        }
        localAreaRepository.MarkLocalAreaAsRemoved(localAreaId);
        return Result.Success();
    }
}
