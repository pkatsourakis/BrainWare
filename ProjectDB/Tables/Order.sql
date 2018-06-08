CREATE TABLE [dbo].[Order]
(
	[order_id] BIGINT NOT NULL PRIMARY KEY IDENTITY,
	[description] NVARCHAR(1000) NOT NULL, 
    [company_id] BIGINT NOT NULL, 
    CONSTRAINT [FK_order_to_company] FOREIGN KEY ([company_id]) REFERENCES [Company]([company_id]),
)
