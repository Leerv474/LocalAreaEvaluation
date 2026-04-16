using Areas.Domain.Regions;
using Areas.Domain.Regions.Enums;
using Areas.Services.Regions.Repositories.Models;
using Npgsql;

namespace Areas.Services.Regions.Repositories.Converters;

internal static class RegionConverter
{
    internal static Region[] ToRegions(this RegionDb[] regionDbs) =>
        [.. regionDbs.Select(ToRegion)];

    internal static Region ToRegion(this RegionDb regionDb)
    {
        return new Region(
            regionDb.Id,
            regionDb.Name,
            regionDb.FederalDistrict,
            regionDb.PlateCodes
        );
    }

    internal static RegionDb ToRegionDb(this NpgsqlDataReader reader)
    {
        return new RegionDb(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            (FederalDistrict)reader.GetInt32(reader.GetOrdinal("federaldistrict")),
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

    internal static RegionItem[] ToRegionItems(this RegionItemDb[] regionItemDbs) =>
        [.. regionItemDbs.Select(ToRegionItem)];

    internal static RegionItem ToRegionItem(this RegionItemDb regionItemDb)
    {
        return new RegionItem(regionItemDb.Id, regionItemDb.Name);
    }

    internal static RegionItemDb ToRegionItemDb(this NpgsqlDataReader reader)
    {
        return new RegionItemDb(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name"))
        );
    }

    internal static RegionDetailsDb ToRegionDetailsDb(this NpgsqlDataReader reader)
    {
        return new RegionDetailsDb(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            (FederalDistrict)reader.GetInt32(reader.GetOrdinal("federaldistrict")),
            reader.IsDBNull(reader.GetOrdinal("platecodes"))
                ? Array.Empty<String>()
                : reader.GetFieldValue<String[]>(reader.GetOrdinal("platecodes")),
            reader.GetInt32(reader.GetOrdinal("localitycount"))
        );
    }

    internal static RegionDetails ToRegionDetails(this RegionDetailsDb regionDetailsDb)
    {
        return new RegionDetails(
            regionDetailsDb.Id,
            regionDetailsDb.Name,
            regionDetailsDb.FederalDistrict,
            regionDetailsDb.PlateCodes,
            regionDetailsDb.LocalityCount
        );
    }
}
