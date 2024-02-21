import pyodbc
import random

import util


def createFlight(airlineId, code, sourceId, departure, destinationId, arrival):
    QUERY = f'INSERT INTO flight(Airline, Code, Source, Departure, Destination, Arrival) VALUES ({airlineId}, \'{code}\', {sourceId}, \'{departure}\', {destinationId}, \'{arrival}\');'
    print(QUERY)
    cursor = util.conn.cursor()
    cursor.execute(QUERY)
    rows = cursor.rowcount
    print(f'rows {rows}')


def createFlightsForDay(airlineId, airlineCode, sourceId, destinationId, nextFlightNum):
    departureHour = [5, 6, 7, 8, 9, 13, 15, 17, 18]
    flightNum = nextFlightNum
    for dt in departureHour:
        depTime = f'{dt:02}:00:00'
        flightTimeHr = random.randint(1, 3)
        flightTimeMin = random.randint(10, 55)
        arrvTime = f'{(dt + flightTimeHr):02}:{flightTimeMin:02}:00'
        print(f'"{depTime}" -> {arrvTime}')
        flightCode = f'{airlineCode}{flightNum:02}'
        flightNum += 1
        createFlight(airlineId, flightCode, sourceId, depTime, destinationId, arrvTime)
    return flightNum



def createFlights():
    AIRLINE_QUERY = f'SELECT * FROM airlines;'
    cursor = util.conn.cursor()
    cursor.execute(AIRLINE_QUERY)
    airlines = cursor.fetchall()

    AIRLINE_QUERY = f'SELECT * FROM airport;'
    cursor = util.conn.cursor()
    cursor.execute(AIRLINE_QUERY)
    airports = cursor.fetchall()

    sourceAirport = airports[0]
    print(f'Source: {sourceAirport}')
    
    for a in airlines:
        airlineId = a.Id
        print(f'Creating routes for {airlineId}')
        flightNum = 1
        for dest in airports:
            if dest.Id != sourceAirport.Id:
                print(f'Creating route from {sourceAirport.Name} to {dest.Name}')
                flightNum = createFlightsForDay(airlineId, a.Code, sourceAirport.Id, dest.Id, flightNum)
        break
    cursor.commit()

    
def createDayFlight(flightId, day):
    QUERY = f'INSERT INTO day_flight(Flight, Day) VALUES ({flightId}, \'{day}\');'
    print(QUERY)
    cursor = util.conn.cursor()
    cursor.execute(QUERY)
    rows = cursor.rowcount
    print(f'rows {rows}')

    
def createDayFlights(airlineId, date):

    FLIGHT_QUERY = f'SELECT * FROM flight WHERE airline = {airlineId};'
    cursor = util.conn.cursor()
    cursor.execute(FLIGHT_QUERY)
    flights = cursor.fetchall()
    

    for f in flights:
        print(f)
        
        createDayFlight(f.Id, date)
    cursor.commit()

