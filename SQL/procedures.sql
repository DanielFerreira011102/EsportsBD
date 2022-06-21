USE Esports
GO
DROP PROCEDURE IF EXISTS resetID
GO
DROP PROCEDURE IF EXISTS whatNeedsIndexes
GO
DROP PROCEDURE IF EXISTS createIndexes
GO
DROP PROCEDURE IF EXISTS deletePT
GO
DROP PROCEDURE IF EXISTS helpIndex
GO
DROP PROCEDURE IF EXISTS createTeamPlayerExists
GO
DROP PROCEDURE IF EXISTS createTeamPlayerDoesNotExist
GO
DROP PROCEDURE IF EXISTS createTeamPlayerJoinRequest
GO
DROP PROCEDURE IF EXISTS removeStaffFromTeam
GO
DROP PROCEDURE IF EXISTS removePlayerFromTeam
GO
DROP PROCEDURE IF EXISTS acceptTeamPlayerExists
GO
DROP PROCEDURE IF EXISTS acceptTeamStaffExists
GO
DROP PROCEDURE IF EXISTS acceptPlayerDoesNotExist
GO
DROP PROCEDURE IF EXISTS acceptTeamStaffDoesNotExist
GO
DROP PROCEDURE IF EXISTS deleteTeam
GO

GO
CREATE PROCEDURE resetID
AS
BEGIN
	DBCC CHECKIDENT ('TEAM', RESEED, 0);
	DBCC CHECKIDENT ('SERIES', RESEED, 0);
END
GO

GO
CREATE PROCEDURE deleteTeam (@Username VARCHAR(25))
AS
BEGIN
DECLARE @TEAM_ID INT
SELECT @TEAM_ID = team_id FROM TEAM_CAPTAIN WHERE @Username = captain
UPDATE PLAYER SET team_id = NULL, team_join_date = NULL WHERE @TEAM_ID = team_id
UPDATE TEAM_STAFF SET team_id = NULL, team_join_date = NULL WHERE @TEAM_ID = team_id
DELETE FROM TEAM_CAPTAIN WHERE @TEAM_ID = team_id
DELETE FROM TEAM_JOIN_REQUEST WHERE @TEAM_ID = team_id
DELETE FROM TEAM WHERE @TEAM_ID = id
END
GO

GO
CREATE PROCEDURE acceptPlayerDoesNotExist(@IGN VARCHAR(25), @User VARCHAR(25))
AS
BEGIN
DECLARE @TEAM_ID INT
DECLARE @GAME VARCHAR(25)
SELECT @TEAM_ID = team_id FROM TEAM_JOIN_REQUEST WHERE @User = username
SELECT @GAME = game FROM TEAM WHERE @TEAM_ID = id
 DECLARE @lastPrank INT
 SELECT @lastPrank = MAX(ranking) FROM PLAYER WHERE @GAME = game 
INSERT INTO PLAYER (username, team_id, ranking, IGN, real_name, team_join_date, profile_url, twitter_url, twitch_url, game, country)
VALUES (@User, @TEAM_ID,  @lastPrank + 1, @IGN, NULL, GETDATE(), NULL, NULL, NULL, @GAME, NULL)
DELETE FROM TEAM_JOIN_REQUEST WHERE @User = username
END
GO

GO
CREATE PROCEDURE acceptTeamStaffDoesNotExist(@Role VARCHAR(30), @User VARCHAR(25))
AS
BEGIN
DECLARE @TEAM_ID INT
SELECT @TEAM_ID = team_id FROM TEAM_JOIN_REQUEST WHERE @User = username
INSERT INTO TEAM_STAFF (username, years_experience, team_join_date, real_name, team_id)
VALUES (@User, NULL, GETDATE(), NULL, @TEAM_ID)
INSERT INTO TEAM_STAFF_ROLE VALUES (@User, @Role)
DELETE FROM TEAM_JOIN_REQUEST WHERE @User = username
END
GO

GO
CREATE PROCEDURE acceptTeamPlayerExists(@IGN VARCHAR(25), @User VARCHAR(25))
AS
BEGIN
DECLARE @TEAM_ID INT
SELECT @TEAM_ID = team_id FROM TEAM_JOIN_REQUEST WHERE @User = username
UPDATE PLAYER SET team_id = @TEAM_ID, team_join_date = GETDATE(), IGN = @IGN WHERE @User = username
DELETE FROM TEAM_JOIN_REQUEST WHERE @User = username
END
GO

GO
CREATE PROCEDURE acceptTeamStaffExists(@Role VARCHAR(30), @User VARCHAR(25))
AS
BEGIN
DECLARE @TEAM_ID INT
SELECT @TEAM_ID = team_id FROM TEAM_JOIN_REQUEST WHERE @User = username
UPDATE TEAM_STAFF SET team_id = @TEAM_ID, team_join_date = GETDATE() WHERE @User = username
UPDATE TEAM_STAFF_ROLE SET [role] = @Role WHERE @User = username
DELETE FROM TEAM_JOIN_REQUEST WHERE @User = username
END
GO

GO
CREATE PROCEDURE removeStaffFromTeam(@Username VARCHAR(25))
AS
BEGIN
UPDATE TEAM_STAFF SET team_id = NULL, team_join_date = NULL WHERE @Username = username
END
GO

GO
CREATE PROCEDURE removePlayerFromTeam(@Username VARCHAR(25))
AS
BEGIN
UPDATE PLAYER SET team_id = NULL, team_join_date = NULL WHERE @Username = username
END
GO

GO
CREATE PROCEDURE createTeamPlayerJoinRequest(@TeamName VARCHAR(25), @Game VARCHAR(25), @IGN VARCHAR(25), @User VARCHAR(25))
AS
BEGIN
 DECLARE @TEAM_ID INT
 SELECT @TEAM_ID = id FROM TEAM WHERE [name] = @TeamName AND @Game = game
 INSERT INTO TEAM_JOIN_REQUEST (team_id, username, [role], IGN) VALUES (@TEAM_ID, @User, 'Player', @IGN)
END
GO

GO
CREATE PROCEDURE createTeamPlayerExists(@TeamName VARCHAR(25), @TeamLogo VARCHAR(500), @IGN VARCHAR(25), @Game VARCHAR(25), @User VARCHAR(25))
AS
BEGIN
 DECLARE @lastRank INT
 SELECT @lastRank = MAX(ranking) FROM TEAM WHERE game = @Game 
 INSERT INTO TEAM ([name], ranking, logo_url, earnings, wins, ties, losses, game) VALUES (@TeamName, @lastRank + 1, @TeamLogo, 0, 0, 0, 0, @Game)
 DECLARE @lastID INT
 SELECT @lastID = MAX(id) FROM TEAM
 UPDATE PLAYER SET team_id = @lastID, IGN = @IGN, game = @Game, team_join_date = GETDATE() WHERE username = @User
 INSERT INTO TEAM_CAPTAIN (team_id, captain) VALUES (@lastID, @User)
END
GO

GO
CREATE PROCEDURE createTeamPlayerDoesNotExist(@TeamName VARCHAR(25), @TeamLogo VARCHAR(500), @IGN VARCHAR(25), @Game VARCHAR(25), @User VARCHAR(25))
AS
BEGIN
 DECLARE @lastRank INT
 SELECT @lastRank = MAX(ranking) FROM TEAM WHERE game = @Game 
 INSERT INTO TEAM ([name], ranking, logo_url, earnings, wins, ties, losses, game) VALUES (@TeamName, @lastRank + 1, @TeamLogo, 0, 0, 0, 0, @Game)
 DECLARE @lastID INT
 SELECT @lastID = MAX(id) FROM TEAM
 DECLARE @lastPrank INT
 SELECT @lastPrank = MAX(ranking) FROM PLAYER WHERE @Game = game 
 INSERT INTO PLAYER (username, team_id, ranking, IGN, real_name, team_join_date, profile_url, twitter_url, twitch_url, game, country)
 VALUES (@User, @lastID,  @lastPrank, @IGN, NULL, GETDATE(), NULL, NULL, NULL, @Game, NULL)
 INSERT INTO TEAM_CAPTAIN (team_id, captain) VALUES (@lastID, @User)
END
GO

-- for test
GO
CREATE PROCEDURE deletePT
AS
BEGIN
	-- some are deleted on cascaded but just to make sure
	EXEC resetID
	DELETE FROM TEAM_STAFF_ROLE
	DELETE FROM TEAM_STAFF
	DELETE FROM TEAM_CAPTAIN
	DELETE FROM PLAYER
	DELETE FROM TEAM
END
GO
GO

CREATE PROCEDURE whatNeedsIndexes
AS
BEGIN
	-- Missing Indexes for current database by Index Advantage  (Query 57) (Missing Indexes)
	SELECT DISTINCT CONVERT(decimal(18,2), user_seeks * avg_total_user_cost * (avg_user_impact * 0.01)) AS [index_advantage], 
		migs.last_user_seek, mid.[statement] AS [Database.Schema.Table],
		mid.equality_columns, mid.inequality_columns, mid.included_columns,
		migs.unique_compiles, migs.user_seeks, migs.avg_total_user_cost, migs.avg_user_impact,
		OBJECT_NAME(mid.[object_id]) AS [Table Name], p.rows AS [Table Rows]
			FROM sys.dm_db_missing_index_group_stats AS migs WITH (NOLOCK)
				INNER JOIN sys.dm_db_missing_index_groups AS mig WITH (NOLOCK)
					ON migs.group_handle = mig.index_group_handle
						INNER JOIN sys.dm_db_missing_index_details AS mid WITH (NOLOCK)
					ON mig.index_handle = mid.index_handle
						INNER JOIN sys.partitions AS p WITH (NOLOCK)
					ON p.[object_id] = mid.[object_id]
					WHERE mid.database_id = DB_ID() 
						ORDER BY index_advantage DESC OPTION (RECOMPILE);

	SELECT TOP 25
		dm_mid.database_id AS DatabaseID,
		dm_migs.avg_user_impact*(dm_migs.user_seeks+dm_migs.user_scans) Avg_Estimated_Impact,
		dm_migs.last_user_seek AS Last_User_Seek,
		OBJECT_NAME(dm_mid.OBJECT_ID,dm_mid.database_id) AS [TableName],
			'CREATE INDEX [IX_' + OBJECT_NAME(dm_mid.OBJECT_ID,dm_mid.database_id) + '_'
			+ REPLACE(REPLACE(REPLACE(ISNULL(dm_mid.equality_columns,''),', ','_'),'[',''),']','') 
			+ CASE
				WHEN dm_mid.equality_columns IS NOT NULL
				AND dm_mid.inequality_columns IS NOT NULL THEN '_'
			ELSE ''
			END
			+ REPLACE(REPLACE(REPLACE(ISNULL(dm_mid.inequality_columns,''),', ','_'),'[',''),']','')
			+ ']'
			+ ' ON ' + dm_mid.statement
			+ ' (' + ISNULL (dm_mid.equality_columns,'')
			+ CASE WHEN dm_mid.equality_columns IS NOT NULL AND dm_mid.inequality_columns 
			IS NOT NULL THEN ',' ELSE
			'' END
			+ ISNULL (dm_mid.inequality_columns, '')
			+ ')'
			+ ISNULL (' INCLUDE (' + dm_mid.included_columns + ')', '') AS Create_Statement
				FROM sys.dm_db_missing_index_groups dm_mig
					INNER JOIN sys.dm_db_missing_index_group_stats dm_migs
					ON dm_migs.group_handle = dm_mig.index_group_handle
					INNER JOIN sys.dm_db_missing_index_details dm_mid
					ON dm_mig.index_handle = dm_mid.index_handle
						WHERE dm_mid.database_ID = DB_ID()
							ORDER BY Avg_Estimated_Impact DESC
END
GO

CREATE PROCEDURE createIndexes
AS 
BEGIN
	CREATE NONCLUSTERED INDEX PlayerTeamIndex ON PLAYER (team_id)
	CREATE NONCLUSTERED INDEX TeamGameIndex ON TEAM (game)
END
GO

CREATE PROC helpIndex
	--@objname nvarchar(776)		-- the table to check for indexes
as
	-- PRELIM
	set nocount on

	declare @objname nvarchar(776), 
			@objid int,			-- the object id of the table
			@indid smallint,	-- the index id of an index
			@groupid smallint,  -- the filegroup id of an index
			@indname sysname,
			@groupname sysname,
			@status int,
			@keys nvarchar(2126),	--Length (16*max_identifierLength)+(15*2)+(16*3)
			@dbname	sysname

	-- Check to see that the object names are local to the current database.
	select @dbname = parsename(@objname,3)

	if @dbname is not null and @dbname <> db_name()
	begin
			raiserror(15250,-1,-1)
			return (1)
	end


	-- create temp table
	create table #spindtab
	(
		
		table_name			sysname,
		index_name			sysname	collate database_default NOT NULL,
		stats				int,
		groupname			sysname collate database_default NOT NULL,
		index_keys			nvarchar(2126)	collate database_default NOT NULL -- see @keys above for length descr
	)


	-- OPEN CURSOR OVER TABLES (skip stats: bug shiloh_51196)
	declare ms_crs_tab cursor local static for
		select name from sysobjects
			where type = 'U'
	open ms_crs_tab
	fetch ms_crs_tab into @objname

	while @@fetch_status >= 0
	begin


	-- Check to see the the table exists and initialize @objid.
	select @objid = object_id(@objname)
	if @objid is NULL
	begin
		select @dbname=db_name()
		raiserror(15009,-1,-1,@objname,@dbname)
		return (1)
	end

	-- OPEN CURSOR OVER INDEXES (skip stats: bug shiloh_51196)
	declare ms_crs_ind cursor local static for
		select indid, groupid, name, status from sysindexes
			where id = @objid and indid > 0 and indid < 255 and (status & 64)=0 order by indid
	open ms_crs_ind
	fetch ms_crs_ind into @indid, @groupid, @indname, @status

	-- IF NO INDEX, QUIT
	--if @@fetch_status < 0
	--begin
	--	deallocate ms_crs_ind
	--	raiserror(15472,-1,-1) --'Object does not have any indexes.'
	--	return (0)
	--end

	-- Now check out each index, figure out its type and keys and
	--	save the info in a temporary table that we'll print out at the end.
	while @@fetch_status >= 0
	begin
		-- First we'll figure out what the keys are.
		declare @i int, @thiskey nvarchar(131) -- 128+3

		select @keys = index_col(@objname, @indid, 1), @i = 2
		if (indexkey_property(@objid, @indid, 1, 'isdescending') = 1)
			select @keys = @keys  + '(-)'

		select @thiskey = index_col(@objname, @indid, @i)
		if ((@thiskey is not null) and (indexkey_property(@objid, @indid, @i, 'isdescending') = 1))
			select @thiskey = @thiskey + '(-)'

		while (@thiskey is not null )
		begin
			select @keys = @keys + ', ' + @thiskey, @i = @i + 1
			select @thiskey = index_col(@objname, @indid, @i)
			if ((@thiskey is not null) and (indexkey_property(@objid, @indid, @i, 'isdescending') = 1))
				select @thiskey = @thiskey + '(-)'
		end

		select @groupname = groupname from sysfilegroups where groupid = @groupid

		-- INSERT ROW FOR INDEX
		insert into #spindtab values (@objname,@indname, @status, @groupname, @keys)

		-- Next index
		fetch ms_crs_ind into @indid, @groupid, @indname, @status
	end
	deallocate ms_crs_ind

	fetch ms_crs_tab into @objname
	end
	deallocate ms_crs_tab

	-- SET UP SOME CONSTANT VALUES FOR OUTPUT QUERY
	declare @empty varchar(1) select @empty = ''
	declare @des1			varchar(35),	-- 35 matches spt_values
			@des2			varchar(35),
			@des4			varchar(35),
			@des32			varchar(35),
			@des64			varchar(35),
			@des2048		varchar(35),
			@des4096		varchar(35),
			@des8388608		varchar(35),
			@des16777216	varchar(35)
	select @des1 = name from master.dbo.spt_values where type = 'I' and number = 1
	select @des2 = name from master.dbo.spt_values where type = 'I' and number = 2
	select @des4 = name from master.dbo.spt_values where type = 'I' and number = 4
	select @des32 = name from master.dbo.spt_values where type = 'I' and number = 32
	select @des64 = name from master.dbo.spt_values where type = 'I' and number = 64
	select @des2048 = name from master.dbo.spt_values where type = 'I' and number = 2048
	select @des4096 = name from master.dbo.spt_values where type = 'I' and number = 4096
	select @des8388608 = name from master.dbo.spt_values where type = 'I' and number = 8388608
	select @des16777216 = name from master.dbo.spt_values where type = 'I' and number = 16777216

	-- DISPLAY THE RESULTS
	select
		'table_name'=table_name,
		'index_name' = index_name,
		'index_description' = convert(varchar(210), --bits 16 off, 1, 2, 16777216 on, located on group
				case when (stats & 16)<>0 then 'clustered' else 'nonclustered' end
				+ case when (stats & 1)<>0 then ', '+@des1 else @empty end
				+ case when (stats & 2)<>0 then ', '+@des2 else @empty end
				+ case when (stats & 4)<>0 then ', '+@des4 else @empty end
				+ case when (stats & 64)<>0 then ', '+@des64 else case when (stats & 32)<>0 then ', '+@des32 else @empty end end
				+ case when (stats & 2048)<>0 then ', '+@des2048 else @empty end
				+ case when (stats & 4096)<>0 then ', '+@des4096 else @empty end
				+ case when (stats & 8388608)<>0 then ', '+@des8388608 else @empty end
				+ case when (stats & 16777216)<>0 then ', '+@des16777216 else @empty end
				+ ' located on ' + groupname),
		'index_keys' = index_keys
	from #spindtab
	order by table_name, index_name


	return (0) -- sp_helpindex
GO