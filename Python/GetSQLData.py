import pypyodbc as odbc
import sys

def GetSQLDataStandard(query, argument=False, asList=True):
    DRIVER = 'SQL Server'
    SERVER_NAME = 'LAPTOP-C8296JRI\\SQLEXPRESS'
    DATABASE_NAME = 'Esports'

    conn_string = f"""
        Driver={{{DRIVER}}};
        Server={SERVER_NAME};
        Database={DATABASE_NAME};
        Trust_Connection=yes;
    """

    try:
        conn = odbc.connect(conn_string)
    except Exception as e:
        print(e)
        print('task is terminated')
        sys.exit()
    else:
        cursor = conn.cursor()

    if not argument:
        cursor.execute(query)
    else:
        cursor.execute(query, argument)

    columns = [item[0] for item in cursor.description]
    if asList:
        results = [item for tuple_ in cursor.fetchall() for item in tuple_]
    else:
        results = [dict(zip(columns, item)) for tuple_ in cursor.fetchall() for item in tuple_]

    return results
