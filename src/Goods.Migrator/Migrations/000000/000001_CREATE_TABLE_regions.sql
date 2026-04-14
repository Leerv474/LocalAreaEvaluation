CREATE TABLE(
    id UUID PRIMARY KEY,
    name VARCHAR NOT NULL,
    federaldistrict VARCHAR NOT NULL,
    platecodes INT [] NOT NULL,
    isremoved BOOLEAN DEFAULT FALSE NOT NULL,
    createdat timestamptz DEFAULT now() NOT NULL,
    modifiedat timestamptz DEFAULT now NOT NULL
)
