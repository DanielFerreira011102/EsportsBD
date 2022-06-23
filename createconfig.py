import configparser
config = configparser.ConfigParser()
# Add the structure to the file we will create
config.add_section('CONN_STRING_CS')
config.set('CONN_STRING_CS', 'local', "data source=LAPTOP-C8296JRI\\\\SQLEXPRESS;Database=Esports;Trusted_Connection=True")
config.set('CONN_STRING_CS', 'remote', "data source=mednat.ieeta.pt\\\\SQLSERVER,8101; initial catalog=p5g5;User id=p5g5;password=@Aveiro123")

config.add_section('CONN_STRING_PY')
config.set('CONN_STRING_PY', 'local', 'LAPTOP-C8296JRI\\\\SQLEXPRESS')
config.set('CONN_STRING_PY', 'remote', "mednat.ieeta.pt\\\\SQLSERVER,8101")

config.add_section('CURRENT_CONTEXT')
config.set('CURRENT_CONTEXT', 'context', 'local')

with open(r"./serverconfig.ini", 'w') as configfile:
    config.write(configfile)

