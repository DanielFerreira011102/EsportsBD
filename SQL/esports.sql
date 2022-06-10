USE Esports
GO
CREATE TABLE [USER] (
username VARCHAR(25) PRIMARY KEY,
[password] VARCHAR(30) NOT NULL,
birthday DATE,
email VARCHAR(50) UNIQUE NOT NULL,
region VARCHAR(20) DEFAULT('World'),
join_date DATE DEFAULT GETDATE(),
gender CHAR(1),
CHECK (gender = 'M' OR gender = 'F')
);

CREATE TABLE GAME (
[name] VARCHAR(25) PRIMARY KEY,
developer VARCHAR(25),
-- redefined platform
[platform] VARCHAR(25),
);

CREATE TABLE GAME_TYPE (
game VARCHAR(25) REFERENCES GAME([name]) ON DELETE CASCADE,
genre VARCHAR(25),
PRIMARY KEY(game, genre)
);

CREATE TABLE ORGANIZATION (
[name] VARCHAR(25) PRIMARY KEY,
contact VARCHAR(50) UNIQUE NOT NULL,
-- removed verified	
);

CREATE TABLE TEAM (
id INT PRIMARY KEY IDENTITY,
[name] VARCHAR(25) UNIQUE NOT NULL,
ranking INT,
captain VARCHAR(25),
logo_url VARCHAR(60),
number_players INT,
earnings INT DEFAULT 0,
wins INT DEFAULT 0,
ties INT DEFAULT 0,
losses INT DEFAULT 0,
game VARCHAR(25) REFERENCES GAME([name]),
);

CREATE TABLE TEAM_STAFF (
username VARCHAR(25) PRIMARY KEY REFERENCES [USER](username) ON DELETE CASCADE,
twitter_url VARCHAR(50),
years_experience INT,
team_join_date DATE,
real_name VARCHAR(30),
team_id INT REFERENCES TEAM(id),
);

CREATE TABLE TEAM_STAFF_ROLE (
username VARCHAR(25) REFERENCES TEAM_STAFF(username) ON DELETE CASCADE,
[role] VARCHAR(30),
PRIMARY KEY(username, [role])
);

CREATE TABLE PLAYER (
username VARCHAR(25) PRIMARY KEY REFERENCES [USER](username) ON DELETE CASCADE,
team_id INT REFERENCES TEAM(id),
ranking INT,
IGN VARCHAR(25) NOT NULL,
real_name VARCHAR(30) NOT NULL,
team_join_date DATE,
twitter_url VARCHAR(50),
twitch_url VARCHAR(50),
game VARCHAR(25) REFERENCES GAME([name]),
);
-- update team
ALTER TABLE TEAM ADD FOREIGN KEY (captain) REFERENCES PLAYER(username)

CREATE TABLE EVENT_STAFF (
username VARCHAR(25) REFERENCES [USER](username) ON DELETE CASCADE,
super_username VARCHAR(25),
organization VARCHAR(25) REFERENCES ORGANIZATION([name]) ON DELETE CASCADE,
PRIMARY KEY(username, organization),
-- removed years_experience INT,
-- removed event_join_date DATE,
);

-- redefined event_type
CREATE TABLE EVENT_STAFF_ROLE (
username VARCHAR(25),
organization VARCHAR(25),
[role] VARCHAR(30),
PRIMARY KEY(username, organization, [role])
);
-- update event_type
ALTER TABLE EVENT_STAFF_ROLE ADD FOREIGN KEY (username, organization) REFERENCES EVENT_STAFF(username, organization) ON DELETE CASCADE

CREATE TABLE TOURNAMENT (
[name] VARCHAR(25),
[format] VARCHAR(30) NOT NULL,
-- 'Single Elimination' 'Double Elimination' 'Multilevel' 'Round Robin' 'Swiss System'
prize_pool INT,
[start_date] DATETIME NOT NULL,
[end_date] DATETIME NOT NULL,
region VARCHAR(20),
number_teams INT NOT NULL,
game VARCHAR(25) REFERENCES GAME([name]),
organization VARCHAR(25) REFERENCES ORGANIZATION([name]) ON DELETE CASCADE,
[status] VARCHAR(20) DEFAULT 'UPCOMING',
PRIMARY KEY([name], organization)
);

CREATE TABLE PARTICIPATES_IN (
team_id INT REFERENCES TEAM(id) ON DELETE CASCADE,
tournament VARCHAR(25),
placement INT,
organization VARCHAR(25),
PRIMARY KEY(team_id, tournament)
);
-- update participates_in
ALTER TABLE PARTICIPATES_IN ADD FOREIGN KEY (tournament, organization) REFERENCES TOURNAMENT([name], organization) ON DELETE CASCADE

CREATE TABLE SERIES (
id INT IDENTITY,
[date] DATETIME NOT NULL,
-- splitted score for each team
score_team1 INT,
score_team2 INT,
-- made winner reference one of the teams (new relation 1:N)
winner INT REFERENCES TEAM(id),
best_of INT NOT NULL,
tournament VARCHAR(25),
organization VARCHAR(25),
mvp VARCHAR(25) REFERENCES PLAYER(username),
[status] VARCHAR(20) DEFAULT 'UPCOMING',
PRIMARY KEY(id, tournament, organization),
);
-- update series/matches
ALTER TABLE SERIES ADD FOREIGN KEY (tournament, organization) REFERENCES TOURNAMENT([name], organization) ON DELETE CASCADE

CREATE TABLE TEAM_PLAYS (
match_id INT,
tournament VARCHAR(25),
organization VARCHAR(25),
team_id INT REFERENCES TEAM(id) ON DELETE CASCADE,
PRIMARY KEY(match_id, tournament, organization, team_id) 
);
-- update team_plays
ALTER TABLE TEAM_PLAYS ADD FOREIGN KEY (match_id, tournament, organization) REFERENCES SERIES(id, tournament, organization) ON DELETE CASCADE

CREATE TABLE MAP (
number INT,
[name] VARCHAR(25) NOT NULL,
score_team1 INT,
score_team2 INT,
[time] INT,
match_id INT,
tournament VARCHAR(25),
organization VARCHAR(25),
-- removed name from primary keys
PRIMARY KEY(number, match_id, tournament, organization)
);
-- update map
ALTER TABLE MAP ADD FOREIGN KEY (match_id, tournament, organization) REFERENCES SERIES(id, tournament, organization) ON DELETE CASCADE

CREATE TABLE PLAYER_STATS (
map_number INT,
match_id INT,
tournament VARCHAR(25),
organization VARCHAR(25),
player VARCHAR(25) REFERENCES PLAYER(username) ON DELETE CASCADE
PRIMARY KEY (player, map_number, match_id, organization, tournament)
);
-- update player_stats
ALTER TABLE PLAYER_STATS ADD FOREIGN KEY (map_number, match_id, organization, tournament) REFERENCES MAP(number, match_id, tournament, organization) ON DELETE CASCADE

CREATE TABLE STAT (
[name] VARCHAR(20),
[value] INT,
player_username VARCHAR(25),
map_number INT,
match_id INT,
tournament VARCHAR(25),
organization VARCHAR(25),
PRIMARY KEY ([name], player_username, map_number, match_id, organization, tournament),
);
-- update stat
ALTER TABLE STAT ADD FOREIGN KEY (player_username, map_number, match_id, organization, tournament) REFERENCES PLAYER_STATS(player, map_number, match_id, organization, tournament) ON DELETE CASCADE

CREATE TABLE PLAYER_PLAYS (
player VARCHAR(25) REFERENCES PLAYER(username) ON DELETE CASCADE, 
match_id INT,
tournament VARCHAR(25),
organization VARCHAR(25),
PRIMARY KEY(player, match_id, tournament, organization)
);
-- update player_plays
ALTER TABLE PLAYER_PLAYS ADD FOREIGN KEY (match_id, tournament, organization) REFERENCES SERIES(id, tournament, organization) ON DELETE CASCADE
