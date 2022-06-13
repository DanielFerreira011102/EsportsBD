import random

from GetSQLData import GetSQLDataStandard

def getTeamCaptain(lst):
    query = "SELECT * FROM getRandomTeamCaptain(?)"
    capt = []

    for t in lst:
        lst = GetSQLDataStandard(query, [t])
        if lst:
            capt.append(lst[0])
        else:
            capt.append(None)

    return capt

def getTeamsList(number):
    query = "SELECT id FROM TEAM"

    lst = GetSQLDataStandard(query)

    return random.sample(lst, number)

def generateRandomTeamCaptain(number):

    rec = []
    teams = getTeamsList(number)
    capt = getTeamCaptain(teams)

    for i in range(0, number):
        rec.append([teams[i], capt[i]])

    return rec
