/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.TodoItem)
BEGIN
	INSERT dbo.TodoItem (Text)
	VALUES ('First Item'), ('Second Item')
END

IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.PrayerRequestModel)
BEGIN
	INSERT dbo.PrayerRequestModel (Request)
	VALUES ('First Prayer Request, and it goes on for a while. This just keeps going. I can not do everything for you , and if I don''t than these stones will shout.Speak to me and don''t speak softly. He didn''t see his brother but there was his mother.'),
		('Second Prayer Request, and it''s short.')
END