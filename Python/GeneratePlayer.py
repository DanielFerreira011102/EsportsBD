import random
from datetime import datetime, timedelta
from GetSQLData import *

def getUsersNotPlayers(number):

    query = "SELECT * FROM getUsersNotPlayers()"

    return random.sample(GetSQLDataStandard(query), number)

def getTeamsList(number):
    games = ['CS:GO', 'Apex Legends', 'Rocket League', 'League of Legends', 'Valorant', 'Overwatch']
    dict_ = {}

    query = "SELECT * FROM getTeams(?)"

    for game in games:
        lst = GetSQLDataStandard(query, [game])

        dict_[game] = random.choices(lst, k=number)

    return dict_


def generateURL(number):
    twitchlst = []
    twitterlst = []
    profilelst = []

    twitch = [
        'https://www.twitch.tv/sliggytv', 'https://www.twitch.tv/moistcr1tikal', 'https://www.twitch.tv/xqc',
        'https://www.twitch.tv/shroud', 'https://www.twitch.tv/simgamernerd', 'https://www.twitch.tv/wernope',
        'https://www.twitch.tv/dottrevv', 'https://www.twitch.tv/rapperr', 'https://www.twitch.tv/s3aparty',
        'https://www.twitch.tv/flo4life4real', 'https://www.twitch.tv/magnetron', 'https://www.twitch.tv/pearlsayah',
        'https://www.twitch.tv/pokelawls', 'https://www.twitch.tv/liminhag0d', 'https://www.twitch.tv/shanks_ttv',
        'https://www.twitch.tv/gaules', 'https://www.twitch.tv/zorlakoka', 'https://www.twitch.tv/kephrii', 'https://www.twitch.tv/impakt',
        'https://www.twitch.tv/wpghd321', 'https://www.twitch.tv/nuuhfps', 'https://www.twitch.tv/greekgodx',
        'https://www.twitch.tv/babyj', 'https://www.twitch.tv/moraishd', 'https://www.twitch.tv/somjuu',
        'https://www.twitch.tv/l1nk_', 'https://www.twitch.tv/muchapt', 'https://www.twitch.tv/zexrow'
    ]

    twitter = [
        'https://twitter.com/dafran', 'https://twitter.com/fap', 'https://twitter.com/looool', 'https://twitter.com/maboi',
        'https://twitter.com/obama', 'https://twitter.com/king', 'https://twitter.com/therealme', 'https://twitter.com/cock',
        'https://twitter.com/venus', 'https://twitter.com/god', 'https://twitter.com/fpsplayer', 'https://twitter.com/twitter',
        'https://twitter.com/fnatic', 'https://twitter.com/derke', 'https://twitter.com/me', 'https://twitter.com/account',
        'https://twitter.com/questionable', 'https://twitter.com/duno', 'https://twitter.com/moist', 'https://twitter.com/csgo',
        'https://twitter.com/esports', 'https://twitter.com/random', 'https://twitter.com/tits', 'https://twitter.com/monkey',
        'https://twitter.com/rich', 'https://twitter.com/project', 'https://twitter.com/elena', 'https://twitter.com/stan'
    ]

    profile = [
        'https://pbs.twimg.com/profile_images/1057215835931115521/I3ktulFJ_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1188911868863221772/fpcyKuIW_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1386897439899127811/X92asQNU_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1516358882620329984/Lo2kqwSp_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1508142463524945931/f1Bp_0gy_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1516214727323664387/f-V-0oIg_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1522434917342318594/rktBLGY-_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1535815817706844161/TQ7NE9sf_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1258779798584938498/VmStYaUt_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1388667618932920325/-tjCvvbj_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1275396462076022786/ZsFFlLrH_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1535392007752806401/i9OIwetE_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1534386346990505984/Bw3n7ILk_400x400.jpg',
        'https://pbs.twimg.com/profile_images/994592419705274369/RLplF55e_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1293953525827997696/NFEkb27y_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1514052372007370761/bI7g4-dJ_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1428516639167942660/2gddVwRg_400x400.png',
        'https://pbs.twimg.com/profile_images/1427499279518683136/xMWXqIwE_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1504239733974601730/Fd7iJiw7_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1535998666795671553/NoOfZIA4_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1447066035199356930/tWBTjxsd_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1452069458122616834/RtdupTgt_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1518731800620814337/4uanV2fr_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1482509652654964739/LMIC_LIO_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1534362873366986756/fx_MyAUQ_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1535499794482872321/4foXVSt2_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1516487097179414529/w3gPKo5B_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1474129856300466176/k47Xx02C_400x400.jpg',
        'https://pbs.twimg.com/profile_images/1515402758534410240/0GGIkoza_400x400.jpg',
    ]

    for i in range(0, number):
        decider = random.randint(0, 100)
        choice = random.choice(twitch)
        if decider > 45 or len(choice) > 500:
            twitchlst.append(None)
        else:
            twitchlst.append(choice)

        decider = random.randint(0, 100)
        choice = random.choice(twitter)
        if decider > 45 or len(choice) > 500:
            twitterlst.append(None)
        else:
            twitterlst.append(choice)

        decider = random.randint(0, 100)
        choice = random.choice(profile)
        if decider > 45 or len(choice) > 500:
            profilelst.append(None)
        else:
            profilelst.append(choice)

    return profilelst, twitterlst, twitchlst

def generateRandomGame(number) -> list:
    lst = []
    games = ['CS:GO', 'Apex Legends', 'Rocket League', 'League of Legends', 'Valorant', 'Overwatch']

    for i in range(0, number):
        lst.append(random.choice(games))

    return lst

def generatePlayerNames(number):
    igns = []
    realnames = []
    countrycodes = []
    count = 1
    with open('players.txt', 'r', encoding='utf8') as f:
        for player in f:
            data = player.strip().replace('\n', '').split(',')
            if len(data[0]) > 25:
                igns.append("SecretAgent" + str(count))
                count += 1
            else:
                igns.append(data[0])
            if data[1] == "- -" or len(data[1]) > 30:
                realnames.append(None)
            else:
                realnames.append(data[1])

            if len(data[2]) <= 10:
                countrycodes.append(data[2])
            else:
                countrycodes.append(None)

    return random.sample(list(set(igns)), number), random.sample(realnames, number), random.sample(countrycodes, number)

def generateRandomDate(number, min_year=2017) -> list:
    max_year = datetime.now().year
    lst = []

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
        lst.append(date)

    return lst

def generateRandomPlayers(number):

    players = []
    users = getUsersNotPlayers(number)
    igns, realnames, countrycode = generatePlayerNames(number)
    games = generateRandomGame(number)
    profiles, twitter, twitch = generateURL(number)
    dates = generateRandomDate(number)
    teams = getTeamsList(number)

    ranks = {'CS:GO': 1, 'Apex Legends': 1, 'Rocket League': 1, 'League of Legends': 1, 'Valorant': 1, 'Overwatch': 1}
    for i in range(0, number):
        player = [users[i], random.choice(teams[games[i]]), ranks[games[i]], igns[i], realnames[i],
                  dates[i], profiles[i], twitter[i], twitch[i], games[i], countrycode[i]]
        ranks[games[i]] += 1
        players.append(player)

    return players
