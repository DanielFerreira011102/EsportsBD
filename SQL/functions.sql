USE Esports
GO
DROP FUNCTION IF EXISTS CheckUserExists;
GO
DROP FUNCTION IF EXISTS CheckUserMatchPassword;
GO
DROP FUNCTION IF EXISTS getUsersNotPlayers;
GO
DROP FUNCTION IF EXISTS getUsersNotEventStaff;
GO
DROP FUNCTION IF EXISTS getUsersNotTeamStaff;
GO
DROP FUNCTION IF EXISTS getTeams;

GO
CREATE FUNCTION CheckUserExists(@Username VARCHAR(25), @Email VARCHAR(50)) 
RETURNS BIT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM [USER] WHERE username = @Username OR email = @Email)
		RETURN 1	
	RETURN 0	
END
GO

GO
CREATE FUNCTION CheckUserMatchPassword(@Username VARCHAR(25), @Password VARCHAR(30)) 
RETURNS BIT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM [USER] WHERE username = @Username AND [password] = @Password)
		RETURN 1	
	RETURN 0	
END
GO

GO
CREATE FUNCTION getUsersNotPlayers()
RETURNS TABLE
AS
	RETURN (
		SELECT U.username 
		FROM [USER] U
		WHERE NOT EXISTS
		(SELECT *  
		   FROM  PLAYER P
		   WHERE U.username = P.username)
	   )
GO

GO
CREATE FUNCTION getUsersNotEventStaff()
RETURNS TABLE
AS
	RETURN (
		SELECT U.username 
		FROM [USER] U
		WHERE NOT EXISTS
		(SELECT *  
		   FROM  EVENT_STAFF ES
		   WHERE U.username = ES.username)
	   )
GO

GO
CREATE FUNCTION getUsersNotTeamStaff()
RETURNS TABLE
AS
	RETURN (
		SELECT U.username 
		FROM [USER] U
		WHERE NOT EXISTS
		(SELECT *  
		   FROM  TEAM_STAFF TS
		   WHERE U.username = TS.username)
	   )
GO

GO
CREATE FUNCTION getTeams(@GAME VARCHAR(25))
RETURNS TABLE
AS
	RETURN (SELECT id FROM TEAM WHERE game=@GAME)
GO
