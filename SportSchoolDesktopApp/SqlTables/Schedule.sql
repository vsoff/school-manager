CREATE TABLE [dbo].[Schedule]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Days] VARCHAR(7) NOT NULL, 
    [TimeStart] INT NOT NULL, 
    [Hall] INT NOT NULL, 
    [IsPeriodic] BIT NOT NULL, 
    [GroupId] INT NOT NULL, 
    CONSTRAINT [FK_Schedule_Groups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([GroupId]),
)
