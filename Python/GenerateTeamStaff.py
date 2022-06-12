import random
from datetime import datetime, timedelta
from GetSQLData import *

def getUsersNotTeamStaff(number):

    query = "SELECT * FROM getUsersNotTeamStaff()"

    return random.sample(GetSQLDataStandard(query), number)


def generateRandomDate(number, min_year=2017):
    max_year = datetime.now().year
    lst1 = []
    lst2 = []

    for i in range(0, number):

        decider = random.randint(0, 100)
        if decider > 20:
            # generate a datetime in format yyyy-mm-dd
            start = datetime(min_year, 1, 1, 00, 00, 00)
            years = max_year - min_year + 1
            end = start + timedelta(days=365 * years)
            date = (start + (end - start) * random.random()).strftime('%Y-%m-%d')
        else:
            date = None

        decider = random.randint(0, 100)
        if decider > 20:
            exp = random.randint(0, 18)
        else:
            exp = None

        lst1.append(date)
        lst2.append(exp)

    return lst1, lst2

def generateRandomTeamStaff(number):

    staff = []
    users = getUsersNotTeamStaff(number)
    dates, experience = generateRandomDate(number)
