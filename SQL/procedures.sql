DROP PROCEDURE IF EXISTS resetID
DROP PROCEDURE IF EXISTS deletePT

GO
CREATE PROCEDURE resetID
AS
BEGIN
	DBCC CHECKIDENT ('TEAM', RESEED, 0);
	DBCC CHECKIDENT ('SERIES', RESEED, 0);
END
GO

-- for test
GO
CREATE PROCEDURE deletePT
AS
BEGIN
	EXEC resetID
	DELETE FROM PLAYER
	DELETE FROM TEAM
END
GO

EXEC resetID