﻿CREATE TABLE [dbo].[Rezepte]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NCHAR(30) NOT NULL, 
    [Menge] INT NOT NULL
)
