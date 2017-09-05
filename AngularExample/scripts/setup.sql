USE master;  
GO  

--Delete the TestData database if it exists.  
IF EXISTS(SELECT * from sys.databases WHERE name='ASPNETCore_SPA_Demo')  
BEGIN  
    DROP DATABASE ASPNETCore_SPA_Demo;  
END  

--Create a new database called TestData.  
CREATE DATABASE ASPNETCore_SPA_Demo;

USE ASPNETCore_SPA_Demo  
GO  

CREATE LOGIN SPA_DB_USER WITH PASSWORD = '************';  

CREATE USER SPA_DB_USER;
GO

GRANT ALTER ANY USER TO SPA_DB_USER;    
GRANT CONTROL TO SPA_DB_USER;
GO   

CREATE TABLE dbo.Items
   (ItemId int PRIMARY KEY NOT NULL,  
    Completed bit NOT NULL,  
    Description text NULL,  
    Deadline datetime NULL)  
GO  

