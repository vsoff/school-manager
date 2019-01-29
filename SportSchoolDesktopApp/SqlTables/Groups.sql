CREATE TABLE [dbo].[Groups]
(
	[GroupId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(30) NOT NULL, 
    [Description] TEXT NULL, 
    [TrainerId] INT NOT NULL,
	CONSTRAINT [FK_Groups_Trainers] FOREIGN KEY ([TrainerId]) REFERENCES [Trainers]([TrainerId]),
)
