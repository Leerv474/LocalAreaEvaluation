DO $$
BEGIN IF NOT EXISTS(
    SELECT
        1
    FROM
        pg_constraint
    WHERE
        conname = 'fk_region_id'
) THEN ALTER TABLE IF EXISTS local_areas ADD CONSTRAINT fk_region_id FOREIGN KEY(regionid) REFERENCES regions(id)
ON DELETE CASCADE;

END IF;

END $$;


