import sys
import pypyodbc as odbc
from GenerateUser import *
from GenerateTeam import *
from GenerateGame import *
from GeneratePlayer import *
from GenerateTeamStaff import *
from GenerateOrganization import *

""" --------- CONSTANTS --------- """

# TEAM AND SERIES IDENTITY COLUMN DOESN'T NEED TO BE SPECIFIED

AttrMap = {'[USER]': 7, 'TOURNAMENT': 10, 'TEAM_STAFF_ROLE': 2, 'TEAM_STAFF': 5, 'TEAM_PLAYS': 2, 'TEAM': 8, 'STAT': 5,
           'SERIES': 4, 'PLAYER_STATS': 3, 'PLAYER_PLAYS': 2, 'PLAYER': 11, 'PARTICIPATES_IN': 3, 'ORGANIZATION': 3,
           'MAP': 4, 'GAME_TYPE': 2, 'GAME': 3, 'EVENT_STAFF_ROLE': 3, 'EVENT_STAFF': 3, 'TEAM_CAPTAIN': 2,
           'SERIES_RESULT': 4, 'SERIES_MVP': 2, 'MAP_RESULT': 4, }

DRIVER = 'SQL Server'
SERVER_NAME = 'LAPTOP-C8296JRI\\SQLEXPRESS'
DATABASE_NAME = 'Esports'

conn_string = f"""
    Driver={{{DRIVER}}};
    Server={SERVER_NAME};
    Database={DATABASE_NAME};
    Trust_Connection=yes;
"""

""" --------- FUNCTIONS --------- """

def insert_statement(table: str):

    values_str = '(' + ", ".join(['?']*AttrMap[table]) + ')'

    return """
        INSERT INTO {MyTable}
        VALUES {MyVal}
        """.format(MyTable=table, MyVal=values_str)


def insert(table: str, records: list):

    try:
        conn = odbc.connect(conn_string)
    except Exception as e:
        print(e)
        print('task is terminated')
        sys.exit()
    else:
        cursor = conn.cursor()

    try:
        for record in records:
            print(record)
            cursor.execute(insert_statement(table), record)
    except Exception as ex:
        cursor.rollback()
        print(ex.value)
        print('transaction rolled back')
    else:
        print('records inserted successfully')
        cursor.commit()
        cursor.close()
    finally:
        if conn.connected == 1:
            print('connection closed')
            conn.close()

""" --------- TEST --------- """

""" INSERT USERS """
# records = generateUser(50)
# insert('[USER]', records)

""" INSERT GAMES AND TYPE """
# records1, records2 = generateGames()
# insert('GAME', records1)
# insert('GAME_TYPE', records2)

""" INSERT TEAMS """
# records = generateRandomTeams(280)
# insert('TEAM', records)

""" INSERT PLAYERS """
# records = generateRandomPlayers(800)
# insert('PLAYER', records)

""" INSERT TEAM STAFF AND ROLE """
# records1, records2 = generateRandomTeamStaff(200)
# insert('TEAM_STAFF', records1)
# insert('TEAM_STAFF_ROLE', records2)

""" INSERT ORGANIZATION """
# records = generateRandomOrgs(100)
# insert('ORGANIZATION', records)
