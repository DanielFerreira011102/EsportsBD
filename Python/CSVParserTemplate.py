with open('users.txt', 'a', encoding='utf8') as ft:
    with open('users1.txt', 'r', encoding='utf8') as f:
        for team in f:
            data = team.strip().replace('\n', '').split(',')
            ft.write(data[0] + "\n")