from glob import glob
import sys
from configparser import ConfigParser

configFile = './serverconfig.ini'

def getValueFromConfigFile(section, option):
    # open file
    parser = ConfigParser()
    parser.read(configFile)
    value = parser.get(section, option)
    return value


def updateConfigFile(section, option, value):
    parser = ConfigParser()
    parser.read(configFile)  # Add this line
    cnfFile = open(configFile, "w")
    parser.set(section, option, value)
    parser.write(cnfFile)
    cnfFile.close()


HELP = \
    """
   Search and replace recursive
   Usage:
        ~$ python switchServer.py [old_conn_string] [new_conn_string] [path]
    Or just run it with no arguments it will switch between local and remote context
"""


# mednat.ieeta.pt\SQLSERVER,8101
# LAPTOP-C8296JRI\\SQLEXPRESS

def replace(find, replacement, path):
    for name in glob(path):

        if '.git' not in path:
            try:
                print('Successfuly refactored: ', name)
                f = open(name, 'r')
                c = f.read()
                f.close()

                f = open(name, 'w')
                c = c.replace(find, replacement)
                f.write(c)
                f.close()

            except Exception as e:
                print(e)


if len(sys.argv) <= 3:
    context = getValueFromConfigFile('CURRENT_CONTEXT', 'context')

    if context == 'local':
        findCS = getValueFromConfigFile('CONN_STRING_CS', 'local')
        replacementCS = getValueFromConfigFile('CONN_STRING_CS', 'remote')
        findPY = getValueFromConfigFile('CONN_STRING_PY', 'local')
        replacementPY = getValueFromConfigFile('CONN_STRING_PY', 'remote')
        updateConfigFile('CURRENT_CONTEXT', 'context', 'remote')
        print(findPY)
        replace(findCS, replacementCS, './Esports/Forms/*Form.cs')
        replace(findPY, replacementPY, './Python/*.py')
    elif context == 'remote':
        findCS = getValueFromConfigFile('CONN_STRING_CS', 'remote')
        replacementCS = getValueFromConfigFile('CONN_STRING_CS', 'local')
        findPY = getValueFromConfigFile('CONN_STRING_PY', 'remote')
        replacementPY = getValueFromConfigFile('CONN_STRING_PY', 'local')
        updateConfigFile('CURRENT_CONTEXT', 'context', 'local')
        replace(findCS, replacementCS, './Esports/Forms/*Form.cs')
        replace(findPY, replacementPY, './Python/*.py')

else:
    find_ = sys.argv[1]
    replacement_ = sys.argv[2]
    path_ = sys.argv[3]
    replace(find_, replacement_, path_)
