CREATE TABLE [dbo].[Paiement]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Paier] BIT NOT NULL, 
    [IdPaiement] INT NOT NULL, 
    [EnvoieFacture] BIT NULL, 
    CONSTRAINT [FK_Paiement_ToTable] FOREIGN KEY ([IdPaiement]) REFERENCES [Event]([Id])
)
