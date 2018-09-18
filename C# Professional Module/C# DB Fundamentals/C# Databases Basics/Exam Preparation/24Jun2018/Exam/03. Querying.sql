--05. Bulgarian Cities

SELECT Id, [Name]
FROM Cities 
WHERE CountryCode = 'BG'
ORDER BY [Name]

--06. People Born After 1991

SELECT CONCAT(FirstName, COALESCE(' ' + MiddleName, ''), ' ', LastName) AS [Full Name],
DATEPART(YEAR, BirthDate) AS [BirthYear]
FROM Accounts 
WHERE DATEPART(YEAR, BirthDate) > 1991
ORDER BY BirthYear DESC, FirstName

--07. EEE-Mails

SELECT FirstName, 
	   LastName,
	   FORMAT(BirthDate, 'MM-dd-yyyy') AS [BirthDate],
	   c.[Name] AS [Hometown],
	   Email
FROM Accounts AS a
JOIN Cities AS c
	ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY Hometown DESC

--08. City Statistics

SELECT c.[Name] AS [City],
	   COUNT(h.Id) AS [Hotels]
FROM Cities AS c
LEFT JOIN Hotels AS h
	ON h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY Hotels DESC, c.[Name]

--09. Expensive First Class Rooms

SELECT r.Id,
	   r.Price,
	   h.[Name] AS [Hotel],
	   c.[Name] AS [City]
FROM Hotels AS h
JOIN Rooms AS r
	ON r.HotelId = h.Id
JOIN Cities AS c
	ON c.Id = h.CityId
WHERE r.[Type] = 'First Class'
ORDER BY r.Price DESC, r.Id

--10. Longest and Shortest Trips
SELECT  a.Id AS [AccountId],
		CONCAT(FirstName, ' ', LastName) AS [FullName],
		MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [LongestTrip],
		MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [ShortestTrip]
FROM Accounts AS a
JOIN AccountsTrips AS [at]
	ON [at].AccountId = a.Id
JOIN Trips AS t
	ON t.Id = [at].TripId
WHERE a.MiddleName IS NULL
AND t.CancelDate IS NULL
GROUP BY a.[Id],
CONCAT(FirstName, ' ', LastName)
ORDER BY [LongestTrip] DESC, a.Id
--NOT DONE

--11. Metropolis

SELECT TOP(5) c.Id,
			  c.[Name] AS [City],
			  c.CountryCode AS [Country],
			  COUNT(a.Id) AS [Accounts]
FROM Cities AS c
JOIN Accounts AS a
	ON a.CityId = c.Id
GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY [Accounts] DESC

--12. Romantic Getaways

SELECT a.Id,
	   a.Email,
	   c.[Name] AS City,
	   COUNT([at].TripId) AS [Trips]
FROM Accounts AS a
JOIN Cities AS c
	ON c.Id = a.CityId
JOIN Hotels AS h
	ON h.CityId = c.Id
JOIN AccountsTrips AS [at]
	ON [at].AccountId = a.Id
JOIN Trips AS t
	ON t.Id = [at].TripId
GROUP BY a.Id, a.Email, c.[Name]

--NOT DONE

--13. Lucrative Destinations

SELECT TOP (10) c.[Id],
				c.[Name],
				SUM(h.BaseRate + r.Price) AS [Total Revenue],
				COUNT(r.Id) AS [Trips]
FROM Cities AS c
JOIN Hotels AS h
	ON h.CityId = c.Id
JOIN Rooms AS r
	ON r.HotelId = h.Id
JOIN Trips AS t
	ON t.RoomId = r.Id
WHERE DATEPART(YEAR, t.BookDate) = 2016
GROUP BY c.[Id], c.[Name]
ORDER BY [Total Revenue] DESC, Trips DESC

--14. Trip Revenues

SELECT t.Id,
	   h.[Name] AS [HotelName],
	   r.[Type] AS [RoomType],
	   CASE
			WHEN t.CancelDate IS NOT NULL THEN 0
			ELSE SUM(h.BaseRate + r.Price)
	   END AS [Revenue]
FROM Trips AS t
JOIN Rooms AS r
	ON r.Id = t.RoomId
JOIN Hotels AS h
	ON h.Id = r.HotelId
GROUP BY t.Id, h.[Name], r.[Type], t.CancelDate
ORDER BY r.[Type], t.Id
--NOT DONE

--15. Top Travelers

SELECT a.Id AS [AccountId],
	   a.Email,
	   c.CountryCode,
	   COUNT(t.Id) AS [Trips]
FROM Accounts AS a
JOIN AccountsTrips AS [at]
	ON a.Id = [at].AccountId
JOIN Trips AS t
	ON t.Id = [at].TripId
JOIN Cities AS c
	ON c.Id = a.CityId
GROUP BY a.Id, a.Email, c.CountryCode
ORDER BY Trips DESC, a.Id

--NOT DONE

--16. Luggage Fees

SELECT t.Id AS [TripId],
	   SUM([at].Luggage) AS [Luggage],
	   CASE
			WHEN SUM([at].Luggage) > 5 THEN CONCAT('$',  SUM([at].Luggage) * 5)
			ELSE '$0'
	   END AS [Fee]
FROM Accounts AS a
JOIN AccountsTrips AS [at]
	ON [at].AccountId = a.Id
JOIN Trips AS t
	ON t.Id = [at].TripId
WHERE [at].Luggage > 0
GROUP BY t.Id
ORDER BY Luggage DESC

--17. GDPR Violation

SELECT t.Id,
	   CONCAT(FirstName, COALESCE(' ' + MiddleName, ''), ' ', LastName) AS [Full Name],
	   c.[Name] AS [From],
	   cc.[Name] AS [To],
	   [Duration] =
			CASE
				WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
				ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
			END
FROM Accounts AS a
JOIN AccountsTrips AS [at]
	ON [at].AccountId = a.Id
JOIN Trips AS t
	ON t.Id = [at].TripId
JOIN Rooms AS r
	ON t.RoomId = r.Id
JOIN Hotels AS h
	ON h.Id = r.HotelId
JOIN Cities AS c
	ON c.Id = a.CityId
JOIN Cities AS cc
	ON cc.Id = h.CityId
ORDER BY [Full Name], t.Id