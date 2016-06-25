CREATE TABLE [dbo].[PrayerRequestModel] (
	[Id]			VARCHAR(50) NOT NULL DEFAULT (NEWID()),
    [Request]         VARCHAR (8000) NULL,
    [Created]         DATETIME       DEFAULT (getdate()) NOT NULL,
    [Version] TIMESTAMP NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NULL DEFAULT SYSDATETIMEOFFSET(), 
    [UpdatedAt] DATETIMEOFFSET NULL DEFAULT SYSDATETIMEOFFSET(), 
    [Deleted] BIT NOT NULL DEFAULT 0, 

    PRIMARY KEY CLUSTERED ([Id] ASC)
);

