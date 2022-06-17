import re
def append(file1, file2):
    toremove = [str(x) for x in range(1970, 2020)]
    with open(file1 + '.txt', 'a', encoding='utf8') as ft:
        with open(file2 + '.txt', 'r', encoding='utf8') as f:
            for team in f:
                data = team.strip().replace('\n', '').replace("\"",'').split(',')
                ft.write(re.sub('|'.join(toremove), '', data[1]) + "\n")

append('tournaments', 'tier2_tournament')