CREATE TABLE [dbo].[Customer]
(
	[cusID] int IDENTITY (1,1) NOT NULL,
	[cName] NVARCHAR (50) not NULL,
	[cphone] int not null,
	primary key clustered ([cusID] ASC) 
)
