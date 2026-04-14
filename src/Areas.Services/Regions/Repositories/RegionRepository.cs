using Areas.Domain.Regions;
using Areas.Domain.Regions.Repositories.Queries;
using Areas.Services.Regions.Repositories.Converters;
using Areas.Services.Regions.Repositories.Interfaces;
using Areas.Tools.Types;
using Areas.Tools.Utils;

namespace Areas.Services.Regions.Repositories;

public class RegionRepository : IRegionRepository
{
    public Region? GetRegion(Guid regionId)
    {
        return DatabaseUtils
            .Get(
                Sql.GetRegionById,
                (parameters) =>
                {
                    parameters.AddWithValue("@r_regionId", regionId);
                },
                (reader) => reader.ToRegionDb()
            )
            ?.ToRegion();
    }

    public Page<Region> GetRegionsPage(int page, int countInPage)
    {
        (Int32 offset, Int32 limit) = NumberUtils.NormalizeRange(page, countInPage);

        return DatabaseUtils
            .GetPage(
                Sql.GetRegionPage,
                (parameters) =>
                {
                    parameters.AddWithValue("@r_offset", offset);
                    parameters.AddWithValue("@r_limit", limit);
                },
                (reader) => reader.ToRegionDb()
            )
            .Convert(regionDb => regionDb.ToRegion());
    }

    public void MarkRegionAsRemoved(Guid regionId)
    {
        DatabaseUtils.Execute(
            Sql.MarkRegionAsRemoved,
            (parameters) =>
            {
                parameters.AddWithValue("@r_regionId", regionId);
                parameters.AddWithValue("@r_currentDateTimeUtc", DateTime.UtcNow);
            }
        );
    }

    public void SaveRegion(RegionBlank RegionBlank)
    {
        DatabaseUtils.Execute(
            Sql.RegionSave,
            (parameters) =>
            {
                parameters.AddWithValue("r_id", RegionBlank.Id!.Value);
                parameters.AddWithValue("r_name", RegionBlank.Name!);
                parameters.AddWithValue("r_federalDistrict", RegionBlank.FederalDistrict!);
                parameters.AddWithValue("r_plateCodes", RegionBlank.PlateCodes!);
                parameters.AddWithValue("r_currentDateTimeUtc", DateTime.UtcNow);
            }
        );
    }
}
