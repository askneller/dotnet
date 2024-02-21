import pyodbc


# Script
SERVER = '.\\mssqlserver01'
DATABASE = 'airline'
USERNAME = 'AirlineUser'
PASSWORD = 'pword123'

connectionString = f'DRIVER={{ODBC Driver 17 for SQL Server}};SERVER={SERVER};DATABASE={DATABASE};UID={USERNAME};PWD={PASSWORD}'

conn = pyodbc.connect(connectionString)


def printTable(table):
    QUERY = f'SELECT * FROM {table};'

    cursor = conn.cursor()
    cursor.execute(QUERY)

    records = cursor.fetchall()
    print(f'Entries for {table}')
    for r in records:
        print(r)


def emptyTable(table):
    if table == 'airline' or table == 'airport':
        print('Cannot empty database "airline" or "airport"')
        return
    print(f'Removing emtries from {table}')
    QUERY = f'DELETE FROM {table};'
    cursor = conn.cursor()
    cursor.execute(QUERY)


