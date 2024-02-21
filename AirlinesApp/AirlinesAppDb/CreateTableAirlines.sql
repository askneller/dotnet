-- =========================================
-- Create table template
-- =========================================
USE airline;
GO

IF OBJECT_ID('airlines', 'U') IS NOT NULL
  DROP TABLE airlines
GO

CREATE TABLE airlines
(
	Id int IDENTITY NOT NULL,
	Name varchar(255) NOT NULL,
	Code varchar(3) NOT NULL,
	CONSTRAINT PK_airlines PRIMARY KEY (Id)
);
GO

-- =========================================
INSERT INTO airlines(Name, Code) VALUES
	('Spirit Airline', 'SA'),
	('Sky Blue Airlines', 'SB'),
	('Oz Airways', 'OA'),
	('AUSAS', 'AA'),
	('Tasair', 'TA');
GO
