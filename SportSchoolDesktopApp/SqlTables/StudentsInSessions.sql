CREATE TABLE [dbo].[StudentsInSessions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentId] INT NOT NULL, 
    [SessionId] INT NOT NULL,
    CONSTRAINT [FK_StudentsInSessions_Students] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId]),
    CONSTRAINT [FK_StudentsInSessions_Sessions] FOREIGN KEY ([SessionId]) REFERENCES [Sessions]([SessionId]),
)
