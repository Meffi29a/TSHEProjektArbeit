CREATE TABLE [dbo].[Personen]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Alter] INT NOT NULL, 
    [Gewicht] INT NOT NULL, 
    [Groesse] INT NOT NULL, 
    [Geschlecht] BIT NOT NULL, 
    [Name] NCHAR(10) NOT NULL
)
