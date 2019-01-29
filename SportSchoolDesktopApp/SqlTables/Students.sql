CREATE TABLE [dbo].[Students]
(
	[StudentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(30) NOT NULL, 
    [LastName] VARCHAR(30) NOT NULL, 
    [MiddleName] VARCHAR(30) NULL, 
    [Birdth] SMALLDATETIME NULL, 
    [Phone] VARCHAR(15) NULL, 
)
