-- =============================================
-- Create database template
-- =============================================
USE master;
GO

-- Drop the database if it already exists
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = 'airline'
)
DROP DATABASE airline;
GO

CREATE DATABASE airline;
GO
