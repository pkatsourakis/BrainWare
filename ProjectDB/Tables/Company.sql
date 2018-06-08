CREATE TABLE [dbo].[Company]
(
	[company_id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NCHAR(128) NOT NULL, 
    [company_description] NCHAR(1000) NULL
)
