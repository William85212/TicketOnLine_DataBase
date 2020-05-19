CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL  identity,
	[Nom] NVARCHAR(50) NOT NULL, 
    [Prenom] NVARCHAR(50) NOT NULL, 
    [DateNaissance] DATETIME2 NOT NULL, 
    [Sexe] NVARCHAR(1) NOT NULL, 
    [Adresse] NVARCHAR(MAX) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [IsActive] BIT NOT NULL, 
    [IsAdmin] BIT NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_Client] PRIMARY KEY ([Id]),
    CONSTRAINT [uk_Client] UNIQUE ([Email]) 
)
