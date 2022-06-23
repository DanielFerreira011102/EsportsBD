import os
import sys

HELP = \
    """
   Search and replace recursive
   Usage:
        ~$ python replace.py [searched_text] [replace_text]
"""

# tcp:mednat.ieeta.pt\SQLSERVER,8101
# LAPTOP-C8296JRI\SQLEXPRESS

remote = True


if len(sys.argv) <= 2:
    if remote:
        find = "data source=LAPTOP-C8296JRI\\SQLEXPRESS;Database=Esports;Trusted_Connection=True"
        replacement = "data source=LAPTOP-C8296JRI\\\\SQLEXPRESS;Database=Esports;Trusted_Connection=True"
    else:
        find = "data source=LAPTOP-C8296JRI\\\\SQLEXPRESS;Database=Esports;Trusted_Connection=True"
        replacement = "data source=tcp:mednat.ieeta.pt\\\\SQLSERVER,8101;Database=p5g5;Trusted_Connection=True;uid=p5g5;password=@Aveiro123"

else:
    find = sys.argv[1]
    replacement = sys.argv[2]

def replace(root='./Esports/Forms'):
    for root, subfolder, files in os.walk(root):

        for file in files:

            path = os.path.join(root, file)

            if not '.git' in file and not '.git' in root:
                print(path)
                try:
                    f = open(path, 'r')
                    c = f.read()
                    f.close()

                    f = open(path, 'w')
                    c = c.replace(find, replacement)
                    f.write(c)
                    f.close()

                except Exception as e:
                    print(e)

replace()