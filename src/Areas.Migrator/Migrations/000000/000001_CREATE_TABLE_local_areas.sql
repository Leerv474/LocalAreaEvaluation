CREATE TABLE local_areas(
    id UUID PRIMARY KEY,
    name VARCHAR NOT NULL,
    areatype int4 NOT NULL,
    population int4 NOT NULL,
    establishmentdate DATE NOT NULL,
    averagehotelbill float8 NOT NULL,
    isherocity BOOLEAN NOT NULL,
    regionid UUID REFERENCES regions(id),
    isremoved BOOLEAN DEFAULT FALSE NOT NULL,
    createdat timestamptz DEFAULT now() NOT NULL,
    modifiedat timestamptz DEFAULT now NOT NULL
);
