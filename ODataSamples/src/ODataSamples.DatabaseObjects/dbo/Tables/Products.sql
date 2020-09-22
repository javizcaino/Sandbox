CREATE TABLE [dbo].[Products] (
    [Id]            INT                IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100)     NOT NULL,
    [CreatedOn]     DATETIMEOFFSET (7) DEFAULT (getutcdate()) NOT NULL,
    [LastUpdatedOn] DATETIMEOFFSET (7) DEFAULT (getutcdate()) NOT NULL,
    [DeletedOn]     DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

