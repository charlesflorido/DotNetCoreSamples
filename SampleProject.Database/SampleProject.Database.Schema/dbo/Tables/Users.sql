CREATE TABLE [dbo].[Users] (
    [Id]               UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [FirstName]        NVARCHAR (256)   NOT NULL,
    [LastName]         NVARCHAR (256)   NOT NULL,
    [Email]            VARCHAR (256)    NOT NULL,
    [AddressLine]      NVARCHAR (256)   NULL,
    [City]             NVARCHAR (128)   NULL,
    [State]            NVARCHAR (128)   NULL,
    [Zip]              NVARCHAR (16)    NULL,
    [DateOfBirth]      DATETIME         NULL,
    [CreditScore]      INT              NULL,
    [CreatedTimestamp] DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [UpdatedTimestamp] DATETIME         NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

