namespace Areas.Domain.LocalAreas.Repositories.Queries;

internal static class Sql
{
    internal static String LocalAreaSave =>
        @"
            insert into local_areas (
                    id,
                    name,
                    areatype,
                    population,
                    establishmentdate,
                    averagehotelbill,
                    isherocity,
                    regionid,
                    createdat
                    )
            values (
                    @l_id,
                    @l_name,
                    @l_areaType,
                    @l_population,
                    @l_establishmentDate,
                    @l_averageHotelBill,
                    @l_isHeroCity,
                    @l_regionId,
                    @l_currentDateTimeUtc
                    )
            on conflict (id) do update set
                name = @l_name,
                areatype = @l_areaType,
                population = @l_population,
                establishmentdate = @l_establishmentDate,
                averagehotelbill = @l_averageHotelBill,
                isherocity = @l_isHeroCity,
                modifiedat = @l_currentDateTimeUtc
        ";

    internal static String GetLocalAreaPage =>
        @"
			SELECT COUNT(*) OVER() as count, * FROM local_areas
			WHERE NOT isremoved 
			ORDER BY createdat DESC 
			OFFSET @l_offset 
			LIMIT @l_limit
        ";
    internal static String GetLocalAreaById =>
        @"
            select * from local_areas  where id = @l_localAreaId and not isremoved
        ";
    internal static String MarkLocalAreaAsRemoved =>
        @"
            update local_areas set isremoved = true, modifiedat = @l_currentDateTimeUtc
            where id = @l_localAreaId
        ";

    internal static String GetLocalAreaDetailsById =>
        @"
            select 
                l.id as id,
                l.name as name,
                l.areatype as areatype,
                l.population as population,
                l.establishmentdate as establishmentdate,
                l.averagehotelbill as averagehotelbill,
                l.isherocity as isherocity,
                r.name as regionname,
                l.isremoved as isremoved,
                l.modifiedat as modifiedat,
                l.createdat as createdat
            from local_areas l
            left join regions r on l.regionid = r.id
            where l.id = @l_localAreaId and not l.isremoved
        ";
}
