-- =========================================
-- Create table template
-- =========================================
USE airline;
GO

IF OBJECT_ID('flight', 'U') IS NOT NULL
  DROP TABLE flight
GO

CREATE TABLE flight
(
	Id int IDENTITY NOT NULL,
	Airline int NOT NULL,
	Code varchar(10) NOT NULL,
	Source int NOT NULL,
	Departure time(0) NOT NULL,
	Destination int NOT NULL,
	Arrival time(0) NOT NULL,
	CONSTRAINT PK_flight PRIMARY KEY (Id),
	CONSTRAINT FK_flight_airlines_id FOREIGN KEY (Airline) REFERENCES airlines(Id),
	CONSTRAINT FK_flight_airport_source FOREIGN KEY (Source) REFERENCES airport(Id),
	CONSTRAINT FK_flight_airport_destination FOREIGN KEY (Destination) REFERENCES airport(Id),
);
GO

-- =========================================
