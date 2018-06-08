CREATE TABLE [dbo].[Product]
(
	[product_id] BIGINT NOT NULL PRIMARY KEY,
	[name] NVARCHAR(128) NOT NULL, 
    [price] DECIMAL(18, 2) NOT NULL, 
    [product_description] NCHAR(1000) NULL,

)
