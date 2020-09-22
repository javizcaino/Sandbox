CREATE TABLE [dbo].[ProductRatings] (
    [Id]        INT                IDENTITY (1, 1) NOT NULL,
    [ProductId] INT                NOT NULL,
    [Rating]    INT                NOT NULL,
    [RatedOn]   DATETIMEOFFSET (7) CONSTRAINT [DF_ProductRatings_RatedOn] DEFAULT (getutcdate()) NOT NULL,
    [UserName]  VARCHAR (200)      NOT NULL,
    [Comments]  NVARCHAR (500)     CONSTRAINT [DF_ProductRatings_Comments] DEFAULT ('') NOT NULL,
    CONSTRAINT [FK_ProductRatings_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
);

