﻿CREATE TABLE [dbo].[COMPANY]
(
	[COMPANY_ID] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [COMPANY_NAME] NCHAR(128) NOT NULL, 
    [COMPANY_DESCRIPTION] NCHAR(1000) NULL
)
