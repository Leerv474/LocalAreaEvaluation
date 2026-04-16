using Areas.Domain.LocalAreas;
using Areas.Domain.LocalAreas.Enums;
using Areas.Domain.Regions;
using Areas.Domain.Services;
using Areas.Services.LocalAreas.Repositories.Interfaces;
using Areas.Services.Regions.Repositories.Interfaces;
using Areas.Tools.Types;
using Areas.Tools.Types.Results;
using Areas.Domain.Regions.Enums;

namespace Areas.Services.LocalAreas;

public class LocalAreaService(ILocalAreaRepository localAreaRepository, IRegionRepository regionRepository) : ILocalAreaService
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

    public Page<LocalAreaDetails> GetLocalAreaPage(Int32 page, Int32 countInPage)
    {
        return localAreaRepository.GetLocalAreaPage(page, countInPage);
    }

    public Result MarkLocalAreaAsRemoved(Guid localAreaId)
    {
        LocalArea? existsLocalArea = localAreaRepository.GetLocalArea(localAreaId);
        if (existsLocalArea is null)
        {
            return Result.Failed("Населенный пункт не найден.");
        }
        localAreaRepository.MarkLocalAreaAsRemoved(localAreaId);
        return Result.Success();
    }

    public Boolean EvaluateLocalArea(Guid localAreaId)
    {
        LocalArea? localArea = GetLocalArea(localAreaId);
        if (localArea is null)
        {
            return false;
        }
        if (localArea.IsHeroCity)
        {
            return true;
        }
        if (localArea.AreaType == AreaType.Village || localArea.AreaType == AreaType.CountrySide)
        {
            return false;
        }
        int areaAge = DateTime.Today.Year - localArea.EstablishmentDate.Year;
        Region? region = regionRepository.GetRegion(localArea.RegionId);
        if (region is null) {
            return false;
        }
        if (areaAge >= region.FederalDistrict.GetValuableAge())
        {
            return true;
        }
        return false;
    }

    public LocalAreaDetails? GetLocalAreaDetails(Guid localAreaId)
    {
        return localAreaRepository.GetLocalAreaDetails(localAreaId);
    }
}
