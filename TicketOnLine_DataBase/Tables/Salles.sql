CREATE TABLE [dbo].[Salles]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Nom] NVARCHAR(50) NULL, 
    [Lieux] NVARCHAR(50) NULL, 
    [Capcite] INT NULL,
    [image] nvarchar(50)
)
