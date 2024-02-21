-- =========================================
-- Create table template
-- =========================================
USE airline;
GO

IF OBJECT_ID('route', 'U') IS NOT NULL
  DROP TABLE route
GO

-- =========================================
CREATE TABLE route
(
	Id int IDENTITY NOT NULL,
	Airline int NOT NULL,
	Source int NOT NULL,
	Destination int NOT NULL,
	CONSTRAINT PK_route PRIMARY KEY (Id),
	CONSTRAINT FK_airlines_id FOREIGN KEY (Airline) REFERENCES airlines(Id),
	CONSTRAINT FK_airport_source FOREIGN KEY (Source) REFERENCES airport(Id),
	CONSTRAINT FK_airport_destination FOREIGN KEY (Destination) REFERENCES airport(Id),
)
GO

-- =========================================
INSERT INTO route(Airline, Source, Destination) VALUES
	(1, 1, 2),
	(1, 1, 3),
	(1, 1, 5),
	(1, 1, 6),
	(1, 1, 7),
	(1, 1, 8),
	(1, 1, 9),
	(1, 1, 10),

	(1, 2, 1),
	(1, 2, 3),
	(1, 2, 5),
	(1, 2, 6),
	(1, 2, 7),
	(1, 2, 8),
	(1, 2, 9),
	(1, 2, 10),
	(1, 2, 11),

	(1, 3, 1),
	(1, 3, 2),
	(1, 3, 5),
	(1, 3, 6),
	(1, 3, 7),
	(1, 3, 8),
	(1, 3, 9),
	(1, 3, 10),
	(1, 3, 11);

GO
