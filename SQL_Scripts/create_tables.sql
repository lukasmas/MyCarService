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
	"VIN" VARCHAR(30),
	"Plate" VARCHAR(10),
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

INSERT INTO "Service"("VehicleId", "Millage", "ServiceDate","ServiceType", "Description", "InvoiceScan") VALUES(1, 225599, '2022-10-12','Wymiana oleju i filtrów', 'Wymiana oleju w silniku i skrzyni biegów, wymiana filtrów: powietrza, oleju, oleju w skrzyni biegów','')
CREATE TABLE IF NOT EXISTS "User"(
   "Id" int4 PRIMARY KEY Generated Always as Identity,
   "Username" VARCHAR(20) NOT NULL UNIQUE,
   "Password" VARCHAR(30) NOT NULL,
   "Email" VARCHAR(30) NOT NULL UNIQUE,
	"Salt" VARCHAR(32) NOT NULL,
	"OwnerId" int4,
	CONSTRAINT fk_user_owner
      FOREIGN KEY("OwnerId") 
	  REFERENCES "Owner"("Id")
)

CREATE TABLE IF NOT EXISTS "ServiceReminder"(
   "Id" int4 PRIMARY KEY Generated Always as Identity,
	"ServiceId" int4 NOT NULL,
	"InKilometers" int4,
	"InTime" date,	
   "Message" VARCHAR(100) NOT NULL,
	CONSTRAINT fk_service
      FOREIGN KEY("ServiceId") 
	  REFERENCES "Service"("Id")
)

INSERT INTO "ServiceReminder"("ServiceId","InKilometers","InTime","Message") VALUES (1, 40000, '2026-10-12', 'Wymiana oleju w skrzyni biegów');
select * from "ServiceReminder" join "Service" on "Service"."Id" = "ServiceReminder"."ServiceId" join "Vehicle" on "Vehicle"."Id" = "Service"."VehicleId" 

