CREATE TABLE [dbo].[Salles]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Nom] NVARCHAR(50) NULL, 
    [Lieux] NVARCHAR(50) NULL, 
    [Capcite] INT NULL,
    [image] nvarchar(50), 
    [IdEvent] INT NOT NULL, 
    [IdDateEvent] INT NOT NULL, 
    CONSTRAINT [FK_Salles_ToTable] FOREIGN KEY ([IdEvent]) REFERENCES [Event]([Id]), 
    CONSTRAINT [FK_Salles_ToTable_1] FOREIGN KEY ([IdDateEvent]) REFERENCES [DateEvent]([Id]) 
)
