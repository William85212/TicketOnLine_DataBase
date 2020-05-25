CREATE TABLE [dbo].[Event]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [NomSpectacle] NVARCHAR(50) NOT NULL, 
    [Realisateur] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Duree] TIME NOT NULL,  
    [PlaceRestante] INT NOT NULL,  
    [Image] nvarchar(50),
    [prix ] INT NOT NULL, 
)
