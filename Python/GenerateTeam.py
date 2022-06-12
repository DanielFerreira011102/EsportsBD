# generate name
# fetch captain
# fetch logo url
# generate game
import random


def generateRandomLogo(number) -> list:
    lst = []
    logos = ['https://cdn.freebiesupply.com/logos/large/2x/cloud-9-logo-png-transparent.png',
             'https://majorleaguelogos.com/wp-content/uploads/2020/04/Sports_Logos_004.png',
             'https://www.logolynx.com/images/logolynx/8d/8d57630536cdee827a3339587f3783ad.png',
             'https://logos-download.com/wp-content/uploads/2016/11/EA_Sports_logo_logotype.png',
             'https://media1.thehungryjpeg.com/thumbs2/ori_3652400_4delxs5yi86abp96y70814nutcfeoylcxpzvqmm0_fire-wolf-esport-logo-design.png',
             'https://media1.thehungryjpeg.com/thumbs2/ori_3692487_cv7lddp7saf4qeta5xmh74nt29yk2duju2g7i3yx_red-dragon-esports-logo-design.png',
             'https://media1.thehungryjpeg.com/thumbs2/ori_3680945_5py77v8jc0joqv3sy3syb3wtnxf0ls81w5i9ha8l_ninja-turtle-esport-logo.png',
             'https://mufasa.space/gamer/gamer.png',
             'https://upload.wikimedia.org/wikipedia/commons/thumb/c/c7/TSM_Logo.svg/1200px-TSM_Logo.svg.png',
             'https://assets-global.website-files.com/605e2c8c6b591c8ec12559d4/60ae6b4f80db859802c5b74e_GoldMono.png',
             'https://leviatan.gg/img/logo.png',
             'https://www.freepnglogos.com/uploads/discord-logo-png/discord-logo-logodownload-download-logotipos-1.png',
             'https://www.pngmart.com/files/Anime-Logo-PNG-Transparent.png',
             'https://www.pngarts.com/files/8/Sad-Anime-Girl-PNG-Image-Background.png',
             'http://assets.stickpng.com/images/5ede4a3fb760540004f2c5e9.png',
             'https://i.pinimg.com/originals/81/31/be/8131beb7c7c360af683847bcb7d7e508.png',
             'https://i.imgur.com/AiB97S0.png',
             'https://imagepng.org/wp-content/uploads/2017/08/minecraft-icone-icon.png',
             'https://upload.wikimedia.org/wikipedia/en/thumb/4/43/Esports_organization_Fnatic_logo.svg/1200px-Esports_organization_Fnatic_logo.svg.png',
             'https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Faze_Clan.svg/2560px-Faze_Clan.svg.png',
             'https://toppng.com/uploads/preview/team-liquid-logo-1156299705466wcgujrbw.png',
             'https://liquipedia.net/commons/images/2/20/FunPlus_Phoenix_2021_allmode.png',
             'https://liquipedia.net/commons/images/thumb/d/df/Acend_allmode_full.png/600px-Acend_allmode_full.png',
             'https://liquipedia.net/commons/images/thumb/c/cb/Heroic_2019_full_lightmode.png/900px-Heroic_2019_full_lightmode.png',
             'https://liquipedia.net/commons/images/thumb/d/dc/Copenhagen_Flames_2018_full_lightmode.png/900px-Copenhagen_Flames_2018_full_lightmode.png',
             'https://liquipedia.net/commons/images/thumb/4/4c/BIG_2020_lightmode.png/900px-BIG_2020_lightmode.png',
             'https://liquipedia.net/commons/images/thumb/0/01/Cloud9_full_lightmode.png/900px-Cloud9_full_lightmode.png',
             'https://liquipedia.net/commons/images/thumb/b/bd/FURIA_Esports_full_lightmode.png/900px-FURIA_Esports_full_lightmode.png',
             'https://liquipedia.net/commons/images/thumb/4/42/Ninjas_in_Pyjamas_2021_full_lightmode.png/900px-Ninjas_in_Pyjamas_2021_full_lightmode.png',
             'https://liquipedia.net/commons/images/thumb/3/3f/Natus_Vincere_2021_lightmode.png/900px-Natus_Vincere_2021_lightmode.png',
             'https://liquipedia.net/commons/images/thumb/b/ba/ENCE_2020_full_lightmode.png/900px-ENCE_2020_full_lightmode.png',
             'https://liquipedia.net/commons/images/thumb/d/d5/ForZe_2019_allmode.png/900px-ForZe_2019_allmode.png',
             'https://liquipedia.net/commons/images/thumb/b/b5/Astralis_2020_full_allmode.png/900px-Astralis_2020_full_allmode.png',
             'https://liquipedia.net/commons/images/thumb/5/55/Team_Vitality_2021_allmode.png/900px-Team_Vitality_2021_allmode.png',
             'https://liquipedia.net/commons/images/thumb/8/85/MIBR_2018_lightmode.png/900px-MIBR_2018_lightmode.png',
             'https://liquipedia.net/commons/images/thumb/d/df/Imperial_Esports_2022_full_lightmode.png/900px-Imperial_Esports_2022_full_lightmode.png',
             'https://liquipedia.net/commons/images/9/93/Bad_News_Eagles_allmode.png',
             'https://liquipedia.net/commons/images/thumb/2/20/Eternal_Fire_allmode_full.png/900px-Eternal_Fire_allmode_full.png',
             'https://liquipedia.net/commons/images/9/9b/Outsiders_CSGO_allmode.png',
             'https://liquipedia.net/commons/images/thumb/2/21/Complexity_Gaming_2019_lightmode_full.png/900px-Complexity_Gaming_2019_lightmode_full.png',
             'https://liquipedia.net/commons/images/thumb/9/9a/IHC_ESPORTS_allmode_full.png/900px-IHC_ESPORTS_allmode_full.png',
             'https://liquipedia.net/commons/images/thumb/6/68/Renegades_2019_allmode_full.png/900px-Renegades_2019_allmode_full.png',
             'https://liquipedia.net/commons/images/e/ee/Team_Liquid_2020_full_lightmode.png',
             'https://liquipedia.net/commons/images/thumb/6/62/9z_Team_allmode.png/900px-9z_Team_allmode.png',
             'https://upload.wikimedia.org/wikipedia/en/thumb/1/12/Esports_organization_G2_Esports_logo.svg/1200px-Esports_organization_G2_Esports_logo.svg.png',
             'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Gambit_Esports_2020_logo.svg/800px-Gambit_Esports_2020_logo.svg.png',
             'https://liquipedia.net/commons/images/thumb/6/66/Team_Spirit_2022_lightmode.png/600px-Team_Spirit_2022_lightmode.png'
             ]

    for i in range(0, number):
        decider = random.randint(0, 100)
        choice = random.choice(logos)
        if decider > 45 or len(choice) > 500:
            lst.append(
                'https://liquipedia.net/commons/images/thumb/4/45/Team_Secret_full_lightmode.png/600px-Team_Secret_full_lightmode.png')
        else:
            lst.append(choice)

    return lst


def generateRandomGame(number) -> list:
    lst = []
    games = ['CS:GO', 'Apex Legends', 'Rocket League', 'League of Legends', 'Valorant', 'Overwatch']

    for i in range(0, number):
        lst.append(random.choice(games))

    return lst


def generateRandomResults(number):
    wins = []
    losses = []
    ties = []

    for i in range(0, number):
        wins.append(random.randint(0, 3000))
        losses.append(random.randint(0, 3000))
        ties.append(random.randint(0, 100))

    return wins, losses, ties


def generateTeamNames(number):
    teams = []
    earnings = []
    with open('teams.txt', 'r', encoding='utf8') as f:
        for team in f:
            data = team.strip().replace('\n', '').split(',')
            if len(data[0]) <= 25:
                teams.append(data[0])
                earnings.append(data[1])
    return random.sample(list(set(teams)), number), random.sample(list(set(earnings)), number)


def generateRandomTeams(number) -> list[list]:

    names, earnings = generateTeamNames(number)
    logos = generateRandomLogo(number)
    wins, losses, ties = generateRandomResults(number)
    games = generateRandomGame(number)

    teams = {}

    # whatever
    def get_score(x):
        return 2*x[3] - 1.5*x[5] + x[4]

    for i in range(0, number):
        team = [names[i], logos[i], earnings[i], wins[i], ties[i], losses[i], games[i]]
        if games[i] not in teams:
            teams[games[i]] = []
        teams[games[i]].append(team)

    lst = []
    for k, v in teams.items():
        teams[k] = sorted(teams.get(k), key=get_score, reverse=True)
        rank = 1
        for v in teams[k]:
            v.insert(1, rank)
            rank += 1
        lst.extend(teams[k])

    return lst
