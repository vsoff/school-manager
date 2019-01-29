CREATE TABLE [dbo].[Subscriptions]
(
	[SubscriptionId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentId] INT NOT NULL, 
    [GroupId] INT NOT NULL, 
    [BuyTime] SMALLDATETIME NOT NULL, 
    [IsUnlimited] BIT NOT NULL, 
    [DateStart] DATE NOT NULL, 
    [DateEnd] DATE NOT NULL, 
    [SubHoursMax] INT NULL, 
    [SubHoursLeft] INT NOT NULL, 
    CONSTRAINT [FK_Subscriptions_Students] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId]),
    CONSTRAINT [FK_Subscriptions_Groups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([GroupId])
)
