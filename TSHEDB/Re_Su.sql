
CREATE TABLE [dbo].[Re_Su]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Rezept_ID] INT NOT NULL, 
    [Substanz_ID] INT NOT NULL, 
    [Menge] INT NOT NULL, 

    CONSTRAINT [FK_Re_Su_Substanzen] FOREIGN KEY ([Substanz_ID]) REFERENCES [Substanzen]([Id]),
    CONSTRAINT [FK_Re_Su_Rezepte] FOREIGN KEY ([Rezept_ID]) REFERENCES [Rezepte]([Id]),
)
