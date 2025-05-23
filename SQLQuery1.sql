-- DATABASE CREATION
USE master;

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'EVENTEASE')
DROP DATABASE EVENTEASE;
CREATE DATABASE EVENTEASE;


USE EVENTEASE;

-- TABLE CREATION
CREATE TABLE VENUES (
	VENUES_ID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	VENUES_NAME NVARCHAR(250) NOT NULL,
	LOCATIONS NVARCHAR(250) NOT NULL,
	CAPACITY INT NOT NULL,
	IMAGEURL NVARCHAR(500) NULL
	);

	CREATE TABLE EVENTS (
		EVENTS_ID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
		EVENTS_NAME NVARCHAR(250) NOT NULL,
		EVENT_DATE DATETIME NOT NULL,
		DESCRIPTIONS NVARCHAR(MAX) NOT NULL,
		VENUES_ID INT NULL,
		CONSTRAINT FK_EVENT_VENUE FOREIGN KEY (VENUES_ID)
		REFERENCES VENUES (VENUES_ID) ON DELETE SET NULL
		);

		-- Create Booking table with composite unique constraint
		CREATE TABLE BOOKINGS(
			BOOKINGS_ID INT PRIMARY KEY IDENTITY (1,1),
			EVENTS_ID INT NOT NULL,
			VENUES_ID INT NOT NULL,
			BOOKING_DATE DATETIME2 NOT NULL DEFAULT GETDATE(),
			CONSTRAINT FK_BOOKING_VENUE FOREIGN KEY (VENUES_ID)
			REFERENCES EVENTS (EVENTS_ID) ON DELETE CASCADE,
			CONSTRAINT UQ_EVENT_VENUE_DATE UNIQUE (EVENTS_ID,VENUES_ID, BOOKING_DATE)
			);

			-- Sample data insertion
			INSERT INTO VENUES (VENUES_NAME, LOCATIONS, CAPACITY, IMAGEURL)
			VALUES
				('Hall Center', '674 Look St', 500, 'https://www.google.com/imgres?q=PARIS&imgurl=https%3A%2F%2Fmedia-cdn.tripadvisor.com%2Fmedia%2Fphoto-c%2F1280x250%2F17%2F15%2F6d%2Fd6%2Fparis.jpg&imgrefurl=https%3A%2F%2Fwww.tripadvisor.com%2FTourism-g187147-Paris_Ile_de_France-Vacations.html&docid=p_6FUA-4Qj1uKM&tbnid=ErZleXK753LjBM&vet=12ahUKEwiL8LO95MWMAxWfgf0HHYX-HysQM3oECBkQAA..i&w=1280&h=931&hcb=2&ved=2ahUKEwiL8LO95MWMAxWfgf0HHYX-HysQM3oECBkQAA');

			INSERT INTO EVENTS (EVENTS_NAME, EVENT_DATE, DESCRIPTIONS, VENUES_ID)
			VALUES
			('Tech conference', '2025-02-13', 'Tech Seminar', 1);
		

			INSERT INTO BOOKINGS (EVENTS_ID, VENUES_ID, BOOKING_DATE)
			VALUES
			(1, 1, '2025-06-01');
			

			--Fetch data
			SELECT * FROM VENUES;
			SELECT * FROM EVENTS;
			SELECT * FROM BOOKINGS;




