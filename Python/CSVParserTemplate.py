def append(file1, file2):
    with open(file1 + '.txt', 'a', encoding='utf8') as ft:
        with open(file2 + '.txt', 'r', encoding='utf8') as f:
            for team in f:
                data = team.strip().replace('\n', '').split(',')
                ft.write(data[0].split('[')[0] + "\n")

append('orgs', 'indie')
append('orgs', 'notindie')
