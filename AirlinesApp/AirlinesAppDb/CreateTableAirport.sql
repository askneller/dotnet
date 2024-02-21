-- =========================================
-- Create table template
-- =========================================
USE airline;
GO

IF OBJECT_ID('airport', 'U') IS NOT NULL
  DROP TABLE airport
GO

CREATE TABLE airport
(
	Id int IDENTITY NOT NULL, 
	Name varchar(255) NOT NULL,
	City varchar(255) NOT NULL,
	Country varchar(255) NOT NULL,
	Code varchar(3) NOT NULL,
	CONSTRAINT PK_airport PRIMARY KEY (Id)
);
GO

-- =========================================
INSERT INTO airport(Name, City, Country, Code) VALUES
	('Brisbane Airport', 'Brisbane', 'Australia', 'BNE'),
	('Sydney Airport', 'Sydney', 'Australia', 'SYD'),
	('Melbourne Airport', 'Melbourne', 'Australia', 'MEL'),
	('Western Sydney Airport', 'Sydney', 'Australia', 'WSI'),
	('Adelaide Airport', 'Adelaide', 'Australia', 'ADL'),
	('Perth Airport', 'Perth', 'Australia', 'PER'),
	('Canberra Airport', 'Canberra', 'Australia', 'CBR'),
	('Hobart International Airport', 'Hobart', 'Australia', 'HBA'),
	('Newcastle Airport', 'Newcastle', 'Australia', 'NTL'),
	('Darwin International Airport', 'Darwin', 'Australia', 'DRW'),
	('Gold Coast Airport', 'Gold Coast', 'Australia', 'OOL');
GO
