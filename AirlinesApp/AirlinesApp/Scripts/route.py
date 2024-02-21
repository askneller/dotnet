import pyodbc


def createRoute(airlineId, sourceId, destinationId):
    QUERY = f'INSERT INTO route(Airline, Source, Destination) VALUES ({airlineId}, {sourceId}, {destinationId});'
    cursor = conn.cursor()
    cursor.execute(QUERY)


def createRoutes():
    AIRLINE_QUERY = f'SELECT * FROM airlines;'
    cursor = conn.cursor()
    cursor.execute(AIRLINE_QUERY)
    airlines = cursor.fetchall()

    AIRLINE_QUERY = f'SELECT * FROM airport;'
    cursor = conn.cursor()
    cursor.execute(AIRLINE_QUERY)
    airports = cursor.fetchall()

    sourceAirport = airports[0]
    print(f'Source: {sourceAirport}')
    
    for a in airlines:
        airlineId = a.Id
        print(f'Creating routes for {airlineId}')
        for p in airports:
            if p.Id != sourceAirport.Id:
                print(f'Creating route from {sourceAirport.Name} to {p.Name}')
                ROUTE_QUERY = f'INSERT INTO route (Airline, Source, Destination) VALUES ({airlineId}, {sourceAirport.Id}, {p.Id});'
                cursor = conn.cursor()
                cursor.execute(ROUTE_QUERY)
        break

