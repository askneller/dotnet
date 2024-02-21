-- Creates the login AirlineUser with password 'pword123'.  
CREATE LOGIN AirlineUser   
    WITH PASSWORD = 'pword123';  
GO  

-- Creates a database user for the login created above.  
CREATE USER AirlineUser FOR LOGIN AirlineUser;  
GO

-- User needs to have db_datareader and db_datawriter permissions added