 CREATE TABLE "roles" ( 
  "id" varchar(128) NOT NULL,
  "name" varchar(256) NOT NULL,
  PRIMARY KEY ("id")
);

CREATE TABLE "subscribers" (
  "id" character varying(128) NOT NULL,
  "username" character varying(256) NOT NULL,
  "passwordhash" character varying(256),
  "securitystamp" character varying(256),
  "email" character varying(256) DEFAULT NULL::character varying,
  "emailconfirmed" boolean NOT NULL DEFAULT false,
  PRIMARY KEY ("id")
);

CREATE TABLE "subscriberclaims" ( 
  "id" serial NOT NULL,
  "claimtype" varchar(256) NULL,
  "claimvalue" varchar(256) NULL,
  "subscriberid" varchar(128) NOT NULL,
  PRIMARY KEY ("id")
);

CREATE TABLE "subscriberlogins" ( 
  "subscriberid" varchar(128) NOT NULL,
  "loginprovider" varchar(128) NOT NULL,
  "poviderkey" varchar(128) NOT NULL,
  PRIMARY KEY ("subscriberid", "loginprovider", "poviderkey")
);

CREATE TABLE "subscriberroles" ( 
  "subscriberid" varchar(128) NOT NULL,
  "roleid" varchar(128) NOT NULL,
  PRIMARY KEY ("subscriberid", "roleid")
);

CREATE INDEX "ix_subscriberclaims_subscriberid"	ON "subscriberclaims"	("subscriberid");
CREATE INDEX "ix_subscriberlogins_subscriberid"	ON "subscriberlogins"	("subscriberid");
CREATE INDEX "ix_subscriberroles_roleid"	ON "subscriberroles"	("roleid");
CREATE INDEX "ix_subscriberroles_subscriberid"	ON "subscriberroles"	("subscriberid");

ALTER TABLE "subscriberclaims"
  ADD CONSTRAINT "fk_subscriberclaims_subscribers_subscriber_id" FOREIGN KEY ("subscriberid") REFERENCES "subscribers" ("id")
  ON DELETE CASCADE;

ALTER TABLE "subscriberlogins"
  ADD CONSTRAINT "fk_subscriberlogins_subscribers_subscriberid" FOREIGN KEY ("subscriberid") REFERENCES "subscribers" ("id")
  ON DELETE CASCADE;

ALTER TABLE "subscriberroles"
  ADD CONSTRAINT "fk_subscriberroles_roles_roleid" FOREIGN KEY ("roleid") REFERENCES "roles" ("id")
  ON DELETE CASCADE;

ALTER TABLE "subscriberroles"
  ADD CONSTRAINT "fk_subscriberroles_subscribers_subscriberid" FOREIGN KEY ("subscriberid") REFERENCES "subscribers" ("id")
  ON DELETE CASCADE;