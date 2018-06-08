CREATE TABLE [dbo].[errorLog]
(
	[error_id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [message] VARCHAR(MAX) NULL, 
    [stacktrace] VARCHAR(MAX) NULL, 
    [source] VARCHAR(50) NULL, 
    [date] DATETIME NULL DEFAULT GETDATE()
)
