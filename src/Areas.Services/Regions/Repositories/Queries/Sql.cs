namespace Areas.Domain.Regions.Repositories.Queries;

internal static class Sql
{
    internal static String RegionSave =>
        @"
            INSERT INTO regions(
                id,
                name,
	        	federaldistrict,
                platecodes,
                createdat
            )
            VALUES (
                @r_id,
                @r_name,
                @r_federalDistrict,
                @r_plateCodes,
                @r_currentDateTimeUtc
            )
	        ON CONFLICT (id) DO UPDATE SET
	        	name = @r_name,
	        	federaldistrict = @r_federalDistrict,
	        	plateCodes = @r_plateCodes,
	        	modifiedat= @r_currentDateTimeUtc
        ";

    internal static String GetRegionPage =>
        @"
			SELECT COUNT(*) OVER() as count, * FROM regions
			WHERE NOT isremoved 
			ORDER BY createdat DESC 
			OFFSET @r_offset 
			LIMIT @r_limit
        ";
    internal static String GetRegionById =>
        @"
            SELECT * FROM regions WHERE id = @r_regionId AND NOT isremoved
        ";
    internal static String MarkRegionAsRemoved =>
        @"
			UPDATE regions
			SET isremoved = TRUE,
				modifiedat = @r_currentDateTimeUtc
			WHERE id = @r_regionId
        ";

    internal static String GetAllRegionItems =>
        @"
            select r.id as id, r.name as name from regions r;
        ";
}
