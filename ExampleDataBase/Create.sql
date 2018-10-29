CREATE TABLE `Work` (
	`Id`	INTEGER NOT NULL,
	`Name`	TEXT NOT NULL,
	`Description`	TEXT NOT NULL,
	`Start`	TEXT NOT NULL,
	`Finish`	TEXT NOT NULL,
	`State`	TEXT NOT NULL,
	PRIMARY KEY(`Id`)
);

CREATE TABLE `Task` (
	`Id`	INTEGER NOT NULL,
	`WorkId`	INTEGER NOT NULL,
	`Name`	INTEGER NOT NULL,
	`Description`	TEXT NOT NULL,
	`Start`	TEXT NOT NULL,
	`Finish`	TEXT NOT NULL,
	`State`	TEXT NOT NULL,
	PRIMARY KEY(`Id`,`WorkId`)
);

CREATE TABLE `TimeEvent` (
	`TaskId`	INTEGER NOT NULL,
	`WorkId`	INTEGER NOT NULL,
	`Id`	INTEGER NOT NULL,
	`RelatedId`	INTEGER NOT NULL,
	`Type`	INTEGER NOT NULL,
	`Time`	TEXT NOT NULL,
	`Name`	TEXT NOT NULL,
	`Observation`	TEXT NOT NULL,
	PRIMARY KEY(`TaskId`,`Id`,`WorkId`)
);

CREATE TABLE `EventType` (
	`Id`	INTEGER NOT NULL,
	`Name`	TEXT NOT NULL,
	`Type`	TEXT NOT NULL,
	PRIMARY KEY(`Id`)
);

insert or replace into EventType(Id, Name, type) values (1, "Task begin", "BEGIN");
insert or replace into EventType(Id, Name, type) values (2, "Pomodoro small pause begin", "BEGIN");
insert or replace into EventType(Id, Name, type) values (3, "Pomodoro small Pause end", "END");
insert or replace into EventType(Id, Name, type) values (4, "Pomodoro big pause begin", "BEGIN");
insert or replace into EventType(Id, Name, type) values (5, "Pomodoro big Pause end", "END");
insert or replace into EventType(Id, Name, type) values (6, "Task Stop", "BEGIN");
insert or replace into EventType(Id, Name, type) values (7, "Task Restart", "END");
insert or replace into EventType(Id, Name, type) values (8, "Task Canceled", "END");
insert or replace into EventType(Id, Name, type) values (9, "Task end", "END");


