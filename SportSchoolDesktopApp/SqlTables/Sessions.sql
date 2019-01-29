CREATE TABLE [dbo].[Sessions]
(
	[SessionId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GroupId] INT NOT NULL, 
    [Time] TIME NOT NULL, 
    [Date] DATE NOT NULL,
    CONSTRAINT [FK_Sessions_Groups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([GroupId]),
)
