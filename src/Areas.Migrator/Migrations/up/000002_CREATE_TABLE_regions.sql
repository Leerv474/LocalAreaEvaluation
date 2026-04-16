CREATE TABLE IF NOT EXISTS regions(
    id UUID PRIMARY KEY,
    name VARCHAR NOT NULL,
    federaldistrict int4 NOT NULL,
    platecodes VARCHAR []NOT NULL,
    isremoved BOOLEAN DEFAULT FALSE NOT NULL,
    createdat timestamptz DEFAULT now() NOT NULL,
    modifiedat timestamptz
)
