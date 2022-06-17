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
DROP FUNCTION IF EXISTS checkPlayerIGL;
GO
DROP FUNCTION IF EXISTS getGamePlayerData;
GO
DROP FUNCTION IF EXISTS getRandomTeamCaptain;
GO
DROP FUNCTION IF EXISTS getPlayerInfo;
GO
DROP FUNCTION IF EXISTS getGameTeamData;
GO
DROP FUNCTION IF EXISTS getTeamInfo;
GO
DROP FUNCTION IF EXISTS getOrgLogo;
GO
DROP FUNCTION IF EXISTS getTeamPlayersRegion;
GO
DROP FUNCTION IF EXISTS getTeamGameRegion;
GO
DROP FUNCTION IF EXISTS getGameEventData;
GO
DROP FUNCTION IF EXISTS getEventInfo;
GO
DROP FUNCTION IF EXISTS getWinner;
GO
DROP VIEW IF EXISTS getNewID

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

CREATE FUNCTION getGameTeamData(@GAME VARCHAR(25))
RETURNS TABLE
AS
	RETURN (
		SELECT ranking, [name], earnings FROM TEAM AS T WHERE T.game=@GAME
	)
GO

CREATE VIEW getNewID AS SELECT NEWID() AS NEW_ID;

GO
CREATE FUNCTION getRandomTeamCaptain(@TEAM INT)
RETURNS TABLE
AS
	RETURN (SELECT TOP 1 username FROM PLAYER AS P WHERE P.team_id = @TEAM ORDER BY (select new_id from getNewID))
GO

GO
CREATE FUNCTION getPlayerInfo(@rank INT, @GAME VARCHAR(25))
RETURNS TABLE
AS
	RETURN (SELECT username, real_name, profile_url, twitter_url, twitch_url, team_join_date FROM PLAYER WHERE ranking=@rank AND game=@GAME)
GO

GO
CREATE FUNCTION checkPlayerIGL(@username VARCHAR(25))
RETURNS BIT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM TEAM_CAPTAIN WHERE captain = @Username)
		RETURN 1	
	RETURN 0	
END
GO

GO
CREATE FUNCTION getTeamInfo(@rank INT, @GAME VARCHAR(25))
RETURNS TABLE
AS
	RETURN (SELECT wins, losses, ties, logo_url FROM TEAM WHERE ranking=@rank AND game=@GAME)
GO

GO
CREATE FUNCTION getOrgLogo(@name VARCHAR(25))
RETURNS VARCHAR(500)
AS
BEGIN
	DECLARE @LOGO VARCHAR(500);
	SELECT @LOGO = logo_url FROM ORGANIZATION WHERE [name]=@name
	RETURN @LOGO
END
GO

GO
CREATE FUNCTION getTeamPlayersRegion(@id INT)
RETURNS VARCHAR(20)
AS
BEGIN
RETURN (SELECT TOP 1 region
		FROM [USER] U, PLAYER P
			WHERE U.username=P.username AND P.team_id = @id
				GROUP BY region
					ORDER BY COUNT(region) DESC)
END
GO

GO
CREATE FUNCTION getTeamGameRegion(@region VARCHAR(20), @game VARCHAR(25))
RETURNS @Teams TABLE(id INT)
AS
BEGIN
	IF (@region = 'World')
		INSERT INTO @Teams SELECT id FROM TEAM
	ELSE
		INSERT INTO @Teams SELECT id FROM TEAM WHERE game=@game AND (SELECT dbo.getTeamPlayersRegion(id))=@region

	RETURN
END
GO

CREATE FUNCTION getGameEventData(@GAME VARCHAR(25))
RETURNS TABLE
AS
	RETURN (
		SELECT [name], [format], region, prize_pool FROM TOURNAMENT WHERE game=@GAME
	)
GO

GO
CREATE FUNCTION getEventInfo(@name VARCHAR(50))
RETURNS TABLE
AS
	RETURN (SELECT organization, [start_date], end_date, number_teams, [status] FROM TOURNAMENT WHERE [name]=@name)
GO

GO
CREATE FUNCTION getWinner(@name VARCHAR(50))
RETURNS TABLE
AS
	RETURN (SELECT [name] FROM TOURNAMENT_WINNER AS TW, TEAM AS T WHERE TW.[tournament]=@name AND T.id = TW.team_id)
GO





