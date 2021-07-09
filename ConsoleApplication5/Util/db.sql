CREATE TABLE "employees" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"CardId"	INTEGER,
	"Name"	TEXT,
	"Department"	TEXT,
	"Role"	TEXT,
	"Salary"	INTEGER,
	"IsInVacation" NUMERIC,
	"DateVacationStart" DATETIME,
	"DateVacationEnd" DATETIME
);