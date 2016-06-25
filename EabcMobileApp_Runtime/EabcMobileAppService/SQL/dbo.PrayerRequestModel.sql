CREATE TABLE [dbo].[PrayerRequestModel]
(
        PrayerRequestId INT NOT NULL PRIMARY KEY,
		Request VARCHAR(8000) NULL,
        Created DATETIME NOT NULL DEFAULT(GETDATE())
)
