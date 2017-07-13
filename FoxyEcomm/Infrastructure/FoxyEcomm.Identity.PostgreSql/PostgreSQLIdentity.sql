 CREATE TABLE "roles" ( 
  "id" varchar(128) NOT NULL,
  "name" varchar(256) NOT NULL,
  PRIMARY KEY ("id")
);

CREATE TABLE "members" (
  "id" character varying(128) NOT NULL,
  "username" character varying(256) NOT NULL,
  "passwordhash" character varying(256),
  "securitystamp" character varying(256),
  "email" character varying(256) DEFAULT NULL::character varying,
  "emailConfirmed" boolean NOT NULL DEFAULT false,
  PRIMARY KEY ("id")
);

CREATE TABLE "memberClaims" ( 
  "id" serial NOT NULL,
  "claimtype" varchar(256) NULL,
  "claimvalue" varchar(256) NULL,
  "memberid" varchar(128) NOT NULL,
  PRIMARY KEY ("id")
);

CREATE TABLE "memberlogins" ( 
  "memberid" varchar(128) NOT NULL,
  "loginprovider" varchar(128) NOT NULL,
  "poviderkey" varchar(128) NOT NULL,
  PRIMARY KEY ("memberid", "loginprovider", "poviderkey")
);

CREATE TABLE "memberroles" ( 
  "memberid" varchar(128) NOT NULL,
  "roleid" varchar(128) NOT NULL,
  PRIMARY KEY ("memberid", "roleid")
);

CREATE INDEX "ix_memberclaims_memberid"	ON "memberClaims"	("memberid");
CREATE INDEX "ix_memberlogins_memberid"	ON "memberlogins"	("memberid");
CREATE INDEX "ix_memberroles_roleid"	ON "memberroles"	("roleid");
CREATE INDEX "ix_memberroles_memberid"	ON "memberroles"	("memberid");

ALTER TABLE "memberclaims"
  ADD CONSTRAINT "fk_memberclaims_members_member_id" FOREIGN KEY ("memberid") REFERENCES "members" ("id")
  ON DELETE CASCADE;

ALTER TABLE "memberlogins"
  ADD CONSTRAINT "fk_memberlogins_members_memberid" FOREIGN KEY ("memberid") REFERENCES "members" ("id")
  ON DELETE CASCADE;

ALTER TABLE "memberroles"
  ADD CONSTRAINT "fk_memberroles_roles_roleid" FOREIGN KEY ("roleid") REFERENCES "roles" ("id")
  ON DELETE CASCADE;

ALTER TABLE "memberroles"
  ADD CONSTRAINT "fk_memberroles_members_memberid" FOREIGN KEY ("memberid") REFERENCES "members" ("id")
  ON DELETE CASCADE;