CREATE TABLE [dbo].[Trainers]
(
	[TrainerId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(30) NOT NULL, 
    [LastName] VARCHAR(30) NOT NULL, 
    [MiddleName] VARCHAR(30) NULL 
)
