using Areas.Domain.LocalAreas;
using Areas.Domain.LocalAreas.Repositories.Queries;
using Areas.Services.LocalAreas.Repositories.Converters;
using Areas.Services.LocalAreas.Repositories.Interfaces;
using Areas.Tools.Types;
using Areas.Tools.Utils;

namespace Areas.Services.LocalAreas.Repositories;

public class LocalAreaRepository : ILocalAreaRepository
{
    public LocalArea? GetLocalArea(Guid localAreaId)
    {
        return DatabaseUtils
            .Get(
                Sql.GetLocalAreaById,
                (parameters) =>
                {
                    parameters.AddWithValue("@l_localAreaId", localAreaId);
                },
                (reader) => reader.ToLocalAreaDb()
            )
            ?.ToLocalArea();
    }

    public Page<LocalArea> GetLocalAreaPage(int page, int countInPage)
    {
        (Int32 offset, Int32 limit) = NumberUtils.NormalizeRange(page, countInPage);

        return DatabaseUtils
            .GetPage(
                Sql.GetLocalAreaPage,
                (parameters) =>
                {
                    parameters.AddWithValue("@l_offset", offset);
                    parameters.AddWithValue("@l_limit", limit);
                },
                (reader) => reader.ToLocalAreaDb()
            )
            .Convert(localAreaDb => localAreaDb.ToLocalArea());
    }

    public void MarkLocalAreaAsRemoved(Guid localAreaId)
    {
        DatabaseUtils.Execute(
            Sql.MarkLocalAreaAsRemoved,
            (parameters) =>
            {
                parameters.AddWithValue("@l_localAreaId", localAreaId);
                parameters.AddWithValue("@l_currentDateTimeUtc", DateTime.UtcNow);
            }
        );
    }

    public void SaveLocalArea(LocalAreaBlank LocalAreaBlank)
    {
        DatabaseUtils.Execute(
            Sql.LocalAreaSave,
            (parameters) =>
            {
                parameters.AddWithValue("l_id", LocalAreaBlank.Id!.Value);
                parameters.AddWithValue("l_name", LocalAreaBlank.Name!);
                parameters.AddWithValue("l_areaType", (Int32)LocalAreaBlank.AreaType!);
                parameters.AddWithValue("l_population", LocalAreaBlank.Population!);
                parameters.AddWithValue("l_establishmentDate", LocalAreaBlank.EstablishmentDate!);
                parameters.AddWithValue("l_averageHotelBill", LocalAreaBlank.AverageHotelBill!);
                parameters.AddWithValue("l_isHeroCity", LocalAreaBlank.IsHeroCity!);
                parameters.AddWithValue("l_regionId", LocalAreaBlank.RegionId!);
                parameters.AddWithValue("l_currentDateTimeUtc", DateTime.UtcNow);
            }
        );
    }
}
