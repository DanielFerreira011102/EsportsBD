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
DROP FUNCTION IF EXISTS getGamePlayerData;

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
		WHERE (NOT EXISTS
		(SELECT *  
		   FROM  PLAYER P
		   WHERE U.username = P.username)
		)
		AND NOT EXISTS(
				(SELECT *  
		   FROM  TEAM_STAFF P
		   WHERE U.username = P.username)
		)
		AND NOT EXISTS(
				(SELECT *  
		   FROM  EVENT_STAFF P
		   WHERE U.username = P.username)
		)
		)
GO

GO
CREATE FUNCTION getUsersNotEventStaff()
RETURNS TABLE
AS
	RETURN (
		SELECT U.username 
		FROM [USER] U
		WHERE (NOT EXISTS
		(SELECT *  
		   FROM  EVENT_STAFF ES
		   WHERE U.username = ES.username)
		)
				AND NOT EXISTS(
				(SELECT *  
		   FROM  PLAYER P
		   WHERE U.username = P.username)
		)
		AND NOT EXISTS(
				(SELECT *  
		   FROM  TEAM_STAFF P
		   WHERE U.username = P.username)
		)
		)
GO

GO
CREATE FUNCTION getUsersNotTeamStaff()
RETURNS TABLE
AS
	RETURN (
		SELECT U.username 
		FROM [USER] U
		WHERE (NOT EXISTS
		(SELECT *  
		   FROM  TEAM_STAFF TS
		   WHERE U.username = TS.username)
	   )
	   		AND NOT EXISTS(
				(SELECT *  
		   FROM  EVENT_STAFF P
		   WHERE U.username = P.username)
		)
		AND NOT EXISTS(
				(SELECT *  
		   FROM  PLAYER P
		   WHERE U.username = P.username)
		))
GO

GO
CREATE FUNCTION getTeams(@GAME VARCHAR(25))
RETURNS TABLE
AS
	RETURN (SELECT id FROM TEAM WHERE game=@GAME)
GO

CREATE FUNCTION getGamePlayerData(@GAME VARCHAR(25))
RETURNS TABLE
AS
	RETURN (
		SELECT * FROM PLAYER AS P, (SELECT id, [name] FROM TEAM) AS T WHERE P.game=@GAME AND P.team_id = T.id
	)
GO
