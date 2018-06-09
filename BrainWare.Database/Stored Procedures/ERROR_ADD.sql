CREATE PROCEDURE [dbo].[ERROR_ADD]
	@message varchar(MAX),
	@stacktrace varchar(MAX),
	@source varchar(50),
	@errorLevel varchar(50)
AS
	INSERT INTO ERROR_LOG ([MESSAGE], STACKTRACE, SOURCE, ERROR_LEVEL) 
	VALUES (@message, @stacktrace, @source, @errorLevel)
RETURN 0
