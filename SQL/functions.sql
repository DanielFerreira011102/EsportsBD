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
DROP FUNCTION IF EXISTS getMatchData;
GO
DROP FUNCTION IF EXISTS getMatchInfo;
GO
DROP FUNCTION IF EXISTS getMatchWinner;
GO
DROP FUNCTION IF EXISTS CheckPlayerExists;
GO
DROP FUNCTION IF EXISTS CheckIGNRegistered;
GO
DROP FUNCTION IF EXISTS CheckTeamExists;
GO
DROP FUNCTION IF EXISTS CheckTeamExists;
GO
DROP FUNCTION IF EXISTS CheckUserHasTeam;
GO
DROP FUNCTION IF EXISTS CheckUserHasTeamJoinRequest;
GO
DROP FUNCTION IF EXISTS getTeamMembers;
GO
DROP FUNCTION IF EXISTS getTeamInfoFromUsername;
GO
DROP FUNCTION IF EXISTS getTeamCaptain;
GO
DROP FUNCTION IF EXISTS getExtendedPlayerInfo;
GO
DROP FUNCTION IF EXISTS getExtendedTeamStaffInfo;
GO
DROP FUNCTION IF EXISTS getNotificationsCount;
GO
DROP FUNCTION IF EXISTS getTeamRequests;
GO
DROP FUNCTION IF EXISTS getUserData;
GO
DROP VIEW IF EXISTS getNewID
GO
CREATE FUNCTION getUserData(@User VARCHAR(25))
RETURNS TABLE
AS
	RETURN (SELECT [password], birthday, email, region, join_date, gender FROM [USER] WHERE username = @User)
GO

GO
CREATE FUNCTION getTeamRequests(@Username VARCHAR(25))
RETURNS @T TABLE (team VARCHAR(25), username VARCHAR(25), [role] VARCHAR(30), IGN VARCHAR(25))
AS
BEGIN
DECLARE @TEAM_ID INT
SELECT @TEAM_ID = team_id FROM PLAYER WHERE username = @Username
INSERT INTO @T SELECT [name], username, [role], IGN FROM TEAM_JOIN_REQUEST, TEAM WHERE team_id = @TEAM_ID AND team_id = id
RETURN
END
GO

GO
CREATE FUNCTION getNotificationsCount(@Username VARCHAR(25))
RETURNS INT
AS
BEGIN
DECLARE @TEAM_ID INT
DECLARE @NotificationCount INT
SELECT @TEAM_ID = team_id FROM PLAYER WHERE username = @Username
SELECT @NotificationCount = COUNT(*) FROM TEAM_JOIN_REQUEST WHERE team_id = @TEAM_ID
RETURN @NotificationCount
END
GO

GO
CREATE FUNCTION getExtendedTeamStaffInfo(@Username VARCHAR(25))
RETURNS TABLE
AS
RETURN (SELECT years_experience, team_join_date, real_name, [name] AS team 
				FROM TEAM_STAFF, TEAM AS T WHERE team_id = id AND username = @Username)
GO

GO
CREATE FUNCTION getExtendedPlayerInfo(@Username VARCHAR(25))
RETURNS TABLE
AS
RETURN (SELECT [name] AS team, P.ranking, IGN, real_name, team_join_date, profile_url, twitch_url, twitter_url, P.game, country
			FROM PLAYER AS P, TEAM AS T WHERE id = team_id AND username = @Username)
GO

GO
CREATE FUNCTION getTeamCaptain(@Username VARCHAR(25))
RETURNS VARCHAR(25)
AS
BEGIN
DECLARE @TEAM_ID INT
SELECT @TEAM_ID = team_id FROM PLAYER WHERE username = @Username
DECLARE @CAPTAIN VARCHAR(25)
SELECT @CAPTAIN = captain FROM TEAM_CAPTAIN WHERE team_id = @TEAM_ID
RETURN @CAPTAIN
END
GO

GO
CREATE FUNCTION getTeamInfoFromUsername(@Username VARCHAR(25)) 
RETURNS @T TABLE ([name] VARCHAR(25), ranking INT, logo_url VARCHAR(500), earnings FLOAT, wins INT, ties INT, losses INT, game VARCHAR(25)) 
AS
BEGIN
DECLARE @TEAM_ID INT
SELECT @TEAM_ID = team_id FROM PLAYER WHERE username = @Username
INSERT INTO @T SELECT [name], ranking, logo_url, earnings, wins, ties, losses, game FROM TEAM WHERE id = @TEAM_ID
RETURN
END
GO

GO
CREATE FUNCTION getTeamMembers(@Username VARCHAR(25)) 
RETURNS @T TABLE (username VARCHAR(25), [role] VARCHAR(30))
AS
BEGIN
DECLARE @TEAM_ID INT
SELECT @TEAM_ID = team_id FROM PLAYER WHERE username = @Username
INSERT INTO @T SELECT username, 'Player' as [role] FROM PLAYER WHERE team_id = @TEAM_ID UNION SELECT TS.username, [role] FROM TEAM_STAFF AS TS, TEAM_STAFF_ROLE AS TSR WHERE team_id = @TEAM_ID AND TS.username = TSR.username
RETURN
END
GO

GO
CREATE FUNCTION CheckTeamExists(@NAME VARCHAR(25), @Game VARCHAR(25)) 
RETURNS BIT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM TEAM WHERE [name] = @NAME AND @Game = GAME)
		RETURN 1	
	RETURN 0	
END
GO

GO
CREATE FUNCTION CheckUserHasTeam(@Username VARCHAR(25)) 
RETURNS BIT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM PLAYER WHERE username = @Username AND team_id IS NOT NULL)
		RETURN 1	
	RETURN 0	
END

GO
GO
CREATE FUNCTION CheckUserHasTeamJoinRequest(@Username VARCHAR(25)) 
RETURNS BIT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM TEAM_JOIN_REQUEST WHERE username = @Username)
		RETURN 1	
	RETURN 0	
END
GO

GO
CREATE FUNCTION CheckIGNRegistered(@IGN VARCHAR(25), @Game VARCHAR(25), @Username VARCHAR(25)) 
RETURNS BIT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM PLAYER WHERE IGN = @IGN AND @Game = GAME AND @Username != username)
		RETURN 1	
	RETURN 0	
END
GO

GO
CREATE FUNCTION CheckPlayerExists(@Username VARCHAR(25)) 
RETURNS BIT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM PLAYER WHERE username = @Username)
		RETURN 1	
	RETURN 0	
END
GO

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

CREATE FUNCTION getMatchData(@GAME VARCHAR(25))
RETURNS TABLE
AS
	RETURN (
		SELECT T.[name], S.id, S.[date], S.[status] FROM SERIES AS S, TOURNAMENT AS T WHERE T.game=@GAME AND S.tournament = T.[name]
	)
GO

CREATE FUNCTION getMatchInfo(@id INT, @Tournament VARCHAR(50))
RETURNS TABLE
AS
	RETURN (
	SELECT * FROM
		(SELECT organization FROM TOURNAMENT WHERE @Tournament = [name]) AS R,
		(SELECT best_of, [name], logo_url FROM SERIES AS S, TEAM_PLAYS AS TP, TEAM AS T WHERE S.id = @id AND S.id = TP.match_id AND T.id = TP.team_id) AS N
		)
GO

GO
CREATE FUNCTION getMatchWinner(@id INT)
RETURNS @t TABLE(winner VARCHAR (25), score_team1 INT, score_team2 INT)
AS
BEGIN
	DECLARE @winner INT
	SELECT @winner = winner FROM SERIES_RESULT AS SR WHERE SR.match_id = @id
	IF @winner != NULL
		INSERT INTO @t SELECT [name], score_team1, score_team2 FROM SERIES_RESULT AS SR, TEAM AS T WHERE SR.match_id = @id AND T.id = SR.winner
	ELSE
		INSERT INTO @t SELECT NULL, score_team1, score_team2 FROM SERIES_RESULT AS SR WHERE SR.match_id = @id
	RETURN
END
GO


