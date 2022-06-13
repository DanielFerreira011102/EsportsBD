def generateGames():
    games = ['CS:GO', 'Apex Legends', 'Rocket League', 'League of Legends', 'Valorant', 'Overwatch']
    developers = ['Valve', 'Respawn Entertainment', 'Psyonix', 'Riot', 'Riot', 'Blizzard Entertainment']
    platforms = ['PC'] * len(games)
    types = [['First-Person Shooter', 'Tactical Shooter'], ["Battle Royale", "Hero Shooter", "First-Person Shooter"],
             ['Acrobatic Soccer-Game', 'Flying cars', 'Third-Person'], ["Battle Arena", "MOBA", "Not Fun", "Bad"],
             ['First-Person Shooter', 'Hero Shooter'], ['First-Person Shooter', 'Hero Shooter']]

    lst1 = []
    lst2 = []
    for i in range(0, len(games)):
        lst1.append([games[i], developers[i], platforms[i]])
        for j in types[i]:
            lst2.append([games[i], j])

    return lst1, lst2
