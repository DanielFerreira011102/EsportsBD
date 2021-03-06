import pypyodbc as odbc
import sys

def GetSQLDataStandard(query, argument=False, asList=True, newSetup=False):
    DRIVER = 'SQL Server'
    SERVER_NAME = 'LAPTOP-C8296JRI\\SQLEXPRESS'
    DATABASE_NAME = 'Esports'

    conn_string = f"""Driver={{{DRIVER}}};Server=mednat.ieeta.pt\\SQLSERVER,8101;Database=p5g5;uid=p5g5;pwd=@Aveiro123;"""

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
    if newSetup:
        results = []
        for tuple_ in cursor.fetchall():
            results.append(tuple_)
        return results
    if asList:
        results = [item for tuple_ in cursor.fetchall() for item in tuple_]
    else:
        results = [dict(zip(columns, item)) for tuple_ in cursor.fetchall() for item in tuple_]

    return results
