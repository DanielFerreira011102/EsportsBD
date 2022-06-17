import math
import random
from datetime import datetime, timedelta

from GetSQLData import GetSQLDataStandard


def getTournamentList():
    query = "SELECT [name], start_date, end_date, [status], number_teams, [format] FROM TOURNAMENT"

    return GetSQLDataStandard(query, newSetup=True)


def getTeams(tournaments):
    lst = []
    query = "SELECT team_id FROM PARTICIPATES_IN WHERE tournament=?"

    for i in range(0, len(tournaments)):
        name = tournaments[i][0]
        lst.append(GetSQLDataStandard(query, [name]))

    return lst


def getNumberOfMatches(format_, nTeams):
    formats = ['Single Elimination', 'Double Elimination', 'Multilevel', 'Round Robin', 'Swiss System']
    if format_ == formats[3]:
        return math.floor(nTeams * (nTeams - 1) / 2)
    if format_ == formats[0]:
        return nTeams - 1
    if format_ == formats[1]:
        return 2 * nTeams - 1
    if format_ == formats[2]:
        return 3 * nTeams - 1
    if format_ == formats[4]:
        return math.ceil(math.log2(nTeams)) * math.floor(nTeams / 2)

def getPossibleMatchups(teams):
    return [(team1, team2) for team1 in teams for team2 in teams if team1!=team2]

def generateRandomDate(tournaments):
    lst = []
    for group in tournaments:
        mat = []
        for i in range(0, getNumberOfMatches(group[5], group[4])):
            start_date = group[1]
            end_date = group[2]

            time_between_dates = end_date - start_date
            days_between_dates = time_between_dates.days
            if days_between_dates == 0:
                random_date = start_date
            else:
                random_number_of_days = random.randrange(days_between_dates)
                random_date = start_date + timedelta(days=random_number_of_days)
            mat.append(datetime.strftime(random_date, '%Y-%m-%d %H:%M:%S'))
        lst.append(mat)
    return lst


def generateRandomMatches():
    tours = getTournamentList()  # [tour1, tour2, ...]
    tour_teams = getTeams(tours)  # [[team1, teams2, ...], [team4, team26, ...], ...]
    tour_dates = generateRandomDate(tours)  # [[date1, date2, ...], [date1, date2, ...], ...]

    team_plays = []
    matchesInfo = []
    results = []
    count = 0
    for i in range(0, len(tours)):
        matchups = getPossibleMatchups(tour_teams[i])
        if len(matchups) > 0:
            best_of = random.choice([1, 3, 5, 7])
            tour_status = tours[i][3]
            for date in tour_dates[i]:
                if tour_status == "FINISHED":
                    this_status = "FINISHED"
                elif tour_status == "ONGOING":
                    start_date = tours[i][1]
                    end_date = tours[i][2]
                    delta = (end_date - start_date).days
                    if delta < 2:
                        delta = 2
                    delta = delta / random.randint(1, delta - 1)
                    compareThis = (start_date + timedelta(days=delta)).date()
                    this_date = datetime.strptime(date, '%Y-%m-%d %H:%M:%S').date()
                    if this_date == compareThis:
                        this_status = "ONGOING"
                    elif this_date < compareThis:
                        this_status = "UPCOMING"
                    else:
                        this_status = "FINISHED"
                else:
                    this_status = "UPCOMING"
                count += 1
                match = random.choice(matchups)
                team_plays.append([count, match[0]])
                team_plays.append([count, match[1]])
                matchInfo = [count, date, best_of, tours[i][0], this_status]
                if this_status == "FINISHED":
                    pos = None
                    if best_of == 1:
                        pos = [0, 1]
                    if best_of == 3:
                        pos = [2, random.choice([0, 1])]
                    if best_of == 5:
                        pos = [3, random.choice([0, 1, 2])]
                    if best_of == 7:
                        pos = [4, random.choice([0, 1, 2, 3])]
                    random.shuffle(pos)
                    results.append([count, match[random.choice([0, 1])], pos[0], pos[1]])
                elif this_status == "ONGOING":
                    pos = None
                    if best_of == 1:
                        pos = [0, 0]
                    if best_of == 3:
                        pos = [random.choice([0, 1]), random.choice([0, 1])]
                    if best_of == 5:
                        pos = [random.choice([0, 1, 2]), random.choice([0, 1, 2])]
                    if best_of == 7:
                        pos = [random.choice([0, 1, 2, 3]), random.choice([0, 1, 2, 3])]
                    random.shuffle(pos)
                    results.append([count, None, pos[0], pos[1]])
                else:
                    results.append([count, None, 0, 0])
                matchesInfo.append(matchInfo[1:])

    return matchesInfo, team_plays, results


