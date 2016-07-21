CREATE TABLE [dbo].[Score]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UserName] VARCHAR(40) NOT NULL,
	[Score] INT NOT NULL,
	[Kills] INT NOT NULL,
	[Blocks] INT NOT NULL,
	[Missed] INT NOT NULL,
	[DateSubmitted] DATETIME NOT NULL

)
