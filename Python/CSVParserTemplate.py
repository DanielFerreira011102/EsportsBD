with open('players.txt', 'a', encoding='utf8') as ft:
    with open('highest_earning_players.txt', 'r', encoding='utf8') as f:
        for team in f:
            data = team.strip().replace('\n', '').split(',')
            ft.write(data[3] + "," + data[1] + " " + data[2] + "," + data[4] + "\n")