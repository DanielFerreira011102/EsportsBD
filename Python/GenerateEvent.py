import random
from datetime import datetime, timedelta

from GetSQLData import GetSQLDataStandard


def generateRandomRegion(number):
    lst = []
    regions = ['World', 'Europe', 'Turkey', 'South America', 'North America', 'Sub-Saharan Africa', 'Oceania',
               'North Africa', 'Middle East', 'Korea', 'China', 'Brazil', 'Asia-Pacific South', 'Asia-Pacific North']
    for i in range(0, number):
        lst.append(random.choice(regions))

    return lst


def generateRandomGame(number) -> list:
    lst = []
    games = ['CS:GO', 'Apex Legends', 'Rocket League', 'League of Legends', 'Valorant', 'Overwatch']

    for i in range(0, number):
        lst.append(random.choice(games))

    return lst


def getTeamsList():
    regions = ['World', 'Europe', 'Turkey', 'South America', 'North America', 'Sub-Saharan Africa', 'Oceania',
               'North Africa', 'Middle East', 'Korea', 'China', 'Brazil', 'Asia-Pacific South', 'Asia-Pacific North']
    games = ['CS:GO', 'Apex Legends', 'Rocket League', 'League of Legends', 'Valorant', 'Overwatch']
    group = [(x, y) for x in regions for y in games]
    dict = {}
    query = "SELECT * FROM getTeamGameRegion(?,?)"

    for i in group:
        teams = GetSQLDataStandard(query, [i[0], i[1]])
        dict[i] = teams

    return dict


def generateEventNames(number):
    names = []
    prizes = []
    with open('tournaments.txt', 'r', encoding='utf8') as f:
        for event in f:
            data = event.strip().replace('\n', '').split(',')
            decider = random.randint(0, 100)
            if len(data) > 1:
                if len(data[0]) <= 50:
                    names.append(data[0])
                    prizes.append(data[1])
            else:
                if len(data[0]) <= 50:
                    names.append(data[0])
                    prizes.append(generateRandomPrizePool())

    return random.sample(list(set(names)), number), random.sample(prizes, number)


def generateRandomPrizePool():
    begin = random.randint(random.randint(5, 500), 1000)  # second rand to prevent low number often
    end = random.randint(begin, random.randint(begin, 5000000))  # second rand to prevent low number often
    return round(random.uniform(begin, end), 2)


def getORGSList(number):
    query = "SELECT [name] FROM ORGANIZATION"

    return random.choices(GetSQLDataStandard(query), k=number)


def generateRandomDate(number):
    min_year = datetime.now().year - 1
    max_year = datetime.now().year + 1
    lst1 = []
    lst2 = []
    lst3 = []

    for i in range(0, number):
        # generate a datetime in format yyyy-mm-dd
        start = datetime(min_year, 1, 1, 00, 00, 00)
        years = max_year - min_year + 1
        end = start + timedelta(days=365 * years)
        date = (start + (end - start) * random.random())
        lst1.append(date)

    for i in range(0, number):
        start = lst1[i]
        end = start + timedelta(days=random.randint(6, 62))
        delta = end - start
        int_delta = (delta.days * 24 * 60 * 60) + delta.seconds
        random_second = random.randrange(int_delta)
        lst2.append(start + timedelta(seconds=random_second))
        if datetime.now() > lst2[i]:
            lst3.append("FINISHED")
        elif lst1[1] < datetime.now() < lst2[i]:
            lst3.append("ONGOING")
        else:
            lst3.append("UPCOMING")

    lst1 = [x.strftime('%Y-%m-%d %H:%M:%S') for x in lst1]
    lst2 = [x.strftime('%Y-%m-%d %H:%M:%S') for x in lst2]
    return lst1, lst2, lst3


def generateRandomFormat(number):
    lst1 = []
    lst2 = []
    formats = ['Single Elimination', 'Double Elimination', 'Multilevel', 'Round Robin', 'Swiss System']

    for i in range(0, number):
        _format = random.choice(formats)
        lst1.append(_format)
        if _format == 'Round Robin':
            decider = random.randint(0, 100)
            if decider > 30:
                lst2.append(random.choice(range(8, 14, 2)))
            else:
                lst2.append(random.choice(range(8, 14)))
        else:
            lst2.append(random.choice(range(8, 14, 2)))

    return lst1, lst2


def addTeams(region, game, teams, nTeams, status, event):
    tup = (region, game)
    pos_teams = teams[tup]
    lenteams = len(pos_teams)
    print(nTeams, region, game)
    toRet = []
    if status == "FINISHED":
        lst = random.sample(pos_teams, nTeams)
        placements = range(1, nTeams + 1)
        for i in range(0, len(lst)):
            toRet.append([lst[i], event, placements[i]])
    elif status == "ONGOING":
        lst = random.sample(pos_teams, nTeams)
        places = []
        placements = random.randint(0, random.randint(0, nTeams - 2))
        for i in range(nTeams, 0, -1):
            if i >= nTeams - placements:
                places.append(i)
            else:
                places.append(None)
        for i in range(0, len(lst)):
            toRet.append([lst[i], event, places[i]])
    elif status == "UPCOMING":
        lst = random.sample(pos_teams, random.randint(0, nTeams))
        for i in range(0, len(lst)):
            toRet.append([lst[i], event, None])

    return toRet


def generateRandomEvents(number):
    events = []
    participating = []
    teamWorkableDict = getTeamsList()
    orgs = getORGSList(number)
    formats, nTeams = generateRandomFormat(number)
    start, end, status = generateRandomDate(number)
    games = generateRandomGame(number)
    regions = generateRandomRegion(number)
    names, prizes = generateEventNames(number)

    for i in range(0, number):
        event = [names[i], formats[i], start[i], end[i], regions[i], nTeams[i], games[i], orgs[i], status[i], prizes[i]]
        events.append(event)
        participating.extend(addTeams(regions[i], games[i], teamWorkableDict, nTeams[i], status[i], names[i]))

    return events, participating
