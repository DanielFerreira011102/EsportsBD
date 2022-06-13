import random
from datetime import datetime, timedelta
from GetSQLData import *


def generateRandomRole(number):
    roles = ['Statistician', 'Coach', 'Analyst', 'Manager', 'Head coach', 'Sports Psychologist', 'Mental health expert']
    return random.choices(roles, k=number)


def getRandomRealName(number):
    firstnames = []
    lastnames = []

    with open('firstnames.txt', 'r', encoding='utf8') as f:
        for first in f:
            data = first.strip().replace('\n', '')
            firstnames.append(data)

    with open('lastnames.txt', 'r', encoding='utf8') as f:
        for last in f:
            data = last.strip().replace('\n', '')
            lastnames.append(data)

    realnames = []
    for i in range(0, number):
        name = random.choice(firstnames) + " " + random.choice(lastnames)
        if len(name) <= 30:
            realnames.append(name)
        else:
            realnames.append(None)

    return realnames


def getTeamsList(number):
    query = "SELECT id FROM TEAM"

    lst = GetSQLDataStandard(query)

    return random.choices(lst, k=number)


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
    teams = getTeamsList(number)
    names = getRandomRealName(number)
    dates, experience = generateRandomDate(number)

    roles = []
    lst1 = list(set(random.choices(users, k=number)))
    lst2 = generateRandomRole(len(lst1))

    for i in range(0, number):
        member = [users[i], experience[i], dates[i], names[i], teams[i]]
        staff.append(member)

    for i in range(0, len(lst1)):
        role = [lst1[i], lst2[i]]
        roles.append(role)

    return staff, roles

