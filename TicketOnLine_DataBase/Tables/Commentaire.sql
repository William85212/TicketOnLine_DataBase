CREATE TABLE [dbo].[Commentaire]
(
	[Id] INT NOT NULL identity , 
    [Commentaire] NVARCHAR(MAX) NULL, 
    [IdClient] INT NULL, 
    [IdEvent] INT NULL, 
    CONSTRAINT [PK_Commentaire] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Commentaire_ToTable] FOREIGN KEY (IdClient) REFERENCES [Client]([Id]), 
    CONSTRAINT [FK_Commentaire_Evenement] FOREIGN KEY ([IdEvent]) REFERENCES [Event]([Id]), 
    
)
