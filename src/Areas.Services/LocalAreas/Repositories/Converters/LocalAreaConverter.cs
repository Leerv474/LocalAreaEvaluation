using Areas.Domain.LocalAreas;
using Areas.Domain.LocalAreas.Enums;
using Areas.Services.LocalAreas.Repositories.Models;
using Npgsql;

namespace Areas.Services.LocalAreas.Repositories.Converters;

internal static class LocalAreaConverter
{
    internal static LocalArea[] ToLocalAreas(this LocalAreaDb[] localAreaDbs) =>
        [.. localAreaDbs.Select(ToLocalArea)];

    internal static LocalArea ToLocalArea(this LocalAreaDb localAreaDb)
    {
        return new LocalArea(
            localAreaDb.Id,
            localAreaDb.Name,
            localAreaDb.AreaType,
            localAreaDb.Population,
            localAreaDb.EstablishmentDate,
            localAreaDb.AverageHotelBill,
            localAreaDb.IsHeroCity,
            localAreaDb.RegionId
        );
    }

    internal static LocalAreaDb ToLocalAreaDb(this NpgsqlDataReader reader)
    {
        return new LocalAreaDb(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            (AreaType)reader.GetInt32(reader.GetOrdinal("areatype")),
            reader.GetInt32(reader.GetOrdinal("population")),
            reader.GetFieldValue<DateOnly>(reader.GetOrdinal("establishmentdate")),
            reader.GetDouble(reader.GetOrdinal("averagehotelbill")),
            reader.GetBoolean(reader.GetOrdinal("isherocity")),
            reader.GetGuid(reader.GetOrdinal("regionid")),
            reader.GetBoolean(reader.GetOrdinal("isremoved")),
            reader.IsDBNull(reader.GetOrdinal("modifiedat"))
                ? null
                : reader.GetDateTime(reader.GetOrdinal("modifiedat")),
            reader.GetDateTime(reader.GetOrdinal("createdat"))
        );
    }

    internal static LocalAreaDetails ToLocalAreaDetails(this LocalAreaDetailsDb localAreaDetailsDb)
    {
        {
            return new LocalAreaDetails(
                localAreaDetailsDb.Id,
                localAreaDetailsDb.Name,
                localAreaDetailsDb.AreaType,
                localAreaDetailsDb.Population,
                localAreaDetailsDb.EstablishmentDate,
                localAreaDetailsDb.AverageHotelBill,
                localAreaDetailsDb.IsHeroCity,
                localAreaDetailsDb.RegionName
            );
        }
    }

    internal static LocalAreaDetailsDb ToLocalAreaDetailsDb(this NpgsqlDataReader reader)
    {
        return new LocalAreaDetailsDb(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            ((AreaType)reader.GetInt32(reader.GetOrdinal("areatype"))).ToString(),
            reader.GetInt32(reader.GetOrdinal("population")),
            reader.GetFieldValue<DateOnly>(reader.GetOrdinal("establishmentdate")),
            reader.GetDouble(reader.GetOrdinal("averagehotelbill")),
            reader.GetBoolean(reader.GetOrdinal("isherocity")),
            reader.GetString(reader.GetOrdinal("regionname")),
            reader.GetBoolean(reader.GetOrdinal("isremoved")),
            reader.IsDBNull(reader.GetOrdinal("modifiedat"))
                ? null
                : reader.GetDateTime(reader.GetOrdinal("modifiedat")),
            reader.GetDateTime(reader.GetOrdinal("createdat"))
        );
    }
}
