CREATE TABLE IF NOT EXISTS "Make" (
   "Id" int4 PRIMARY KEY Generated Always as Identity,
   "Name" VARCHAR(20) NOT NULL UNIQUE
);


CREATE TABLE IF NOT EXISTS "Model" (
   "Id" int4 PRIMARY KEY Generated Always as Identity,
   "Name" VARCHAR(20) NOT NULL UNIQUE,
   "MakeId" int4,
    CONSTRAINT fk_make
      FOREIGN KEY("MakeId") 
	  REFERENCES "Make"("Id")
);


CREATE TABLE IF NOT EXISTS "Owner" (
   "Id" int4 PRIMARY KEY Generated Always as Identity,
   "Name" VARCHAR(20) NOT NULL,
   "Surname" VARCHAR(30) NOT NULL
);

CREATE TABLE IF NOT EXISTS "Vehicle" (
   "Id" int4 PRIMARY KEY Generated Always as Identity,
   "OwnerId" int4 NOT NULL,
   "ModelId" int4 NOT NULL,
   "ProductionYear" int4,
	"VIN" VARCHAR(30) UNIQUE,
	"Plate" VARCHAR(10) UNIQUE,
	"CurrentMillage" int8,
	CONSTRAINT fk_model
      FOREIGN KEY("ModelId") 
	  REFERENCES "Model"("Id"),	
	CONSTRAINT fk_owner
      FOREIGN KEY("OwnerId") 
	  REFERENCES "Owner"("Id")
);

CREATE TABLE IF NOT EXISTS "Service" (
   "Id" int4 PRIMARY KEY Generated Always as Identity,
   "VehicleId" int4 NOT NULL,
   "Millage" int4 NOT NULL,
	"ServiceType" VARCHAR(30) NOT NULL,
	"Description" text,
	"InvoiceScan" text,
	CONSTRAINT fk_vehicle
      FOREIGN KEY("VehicleId") 
	  REFERENCES "Vehicle"("Id")
);

-- INSERT INTO "Service"("VehicleId", "Millage", "ServiceDate","ServiceType", "Description", "InvoiceScan") VALUES(1, 225599, '2022-10-12','Wymiana oleju i filtrów', 'Wymiana oleju w silniku i skrzyni biegów, wymiana filtrów: powietrza, oleju, oleju w skrzyni biegów','')
