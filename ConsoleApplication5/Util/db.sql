CREATE TABLE "employees" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"CardId"	INTEGER,
	"Name"	TEXT,
	"Department"	TEXT,
	"Role"	TEXT,
	"Salary"	INTEGER,
	"IsInVacation" NUMERIC,
	"DateVacationStart" DATETIME,
	"DateVacationEnd" DATETIME,
	"Permission" DATETIME,
	"PerReason" TEXT
);

CREATE TABLE "employeesDetails" (
	"Id" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"EmployeeCardId" INTEGER,
	"ActionType" TEXT,
	"Concept" TEXT,
	"Value" INTEGER
);

CREATE TABLE "pays" (
	"Id" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"EmployeeName" TEXT,
	"Department" TEXT,
	"Salary" INTEGER,
	"Incentives" INTEGER,
	"AFP" INTEGER,
	"ARS" INTEGER,
	"Discounts" INTEGER,
	"NetIncome" INTEGER
);