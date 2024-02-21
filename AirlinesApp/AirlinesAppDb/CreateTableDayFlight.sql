-- =========================================
-- Create table template
-- =========================================
USE airline;
GO

IF OBJECT_ID('day_flight', 'U') IS NOT NULL
  DROP TABLE day_flight
GO

CREATE TABLE day_flight
(
	Id int IDENTITY NOT NULL,
	Flight int NOT NULL,
	Day date NOT NULL,
	CONSTRAINT PK_day_flight PRIMARY KEY (Id),
	CONSTRAINT FK_day_flight_flight_id FOREIGN KEY (Flight) REFERENCES flight(Id),
);
GO

-- =========================================
