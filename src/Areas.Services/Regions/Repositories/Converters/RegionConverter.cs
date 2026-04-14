using Areas.Domain.Regions;
using Areas.Services.Regions.Repositories.Models;
using Npgsql;

namespace Areas.Services.Regions.Repositories.Converters;

internal static class RegionConverter
{
    internal static Region[] ToRegions(this RegionDb[] regionDbs) =>
        [.. regionDbs.Select(ToRegion)];

    internal static Region ToRegion(this RegionDb RegionDb)
    {
        return new Region(
            RegionDb.Id,
            RegionDb.Name,
            RegionDb.FederalDistrict,
            RegionDb.PlateCodes
        );
    }

    internal static RegionDb ToRegionDb(this NpgsqlDataReader reader)
    {
        return new RegionDb(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            reader.GetString(reader.GetOrdinal("federaldistrict")),
            reader.IsDBNull(reader.GetOrdinal("platecodes"))
                ? Array.Empty<String>()
                : reader.GetFieldValue<String[]>(reader.GetOrdinal("platecodes")),
            reader.GetBoolean(reader.GetOrdinal("isremoved")),
            reader.IsDBNull(reader.GetOrdinal("modifiedat"))
                ? null
                : reader.GetDateTime(reader.GetOrdinal("modifiedat")),
            reader.GetDateTime(reader.GetOrdinal("createdat"))
        );
    }
}
