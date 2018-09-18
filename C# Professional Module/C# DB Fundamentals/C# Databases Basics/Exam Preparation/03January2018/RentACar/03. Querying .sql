--05. Showroom

SELECT Manufacturer, 
	   Model 
FROM Models 
ORDER BY Manufacturer ASC,
		 Id DESC

--06. Y Generation 

SELECT FirstName,
	   LastName
FROM Clients
WHERE DATEPART(YEAR, BirthDate) BETWEEN 1977 AND 1994
ORDER BY FirstName ASC,
		 LastName ASC,
		 Id ASC

--07. Spacious Office 

SELECT t.[Name] AS [TownName],
	   o.[Name] AS [OfficeName],
	   o.ParkingPlaces
FROM Offices AS o
JOIN Towns AS t
	ON t.Id = o.TownId
WHERE ParkingPlaces > 25
ORDER BY t.[Name] ASC,
		 o.Id ASC

--08. Available Vehicles 

WITH CTE_NotReturned (ReturnDate)
AS
(
	SELECT VehicleId
	FROM Orders
	WHERE ReturnDate IS NULL
)

SELECT m.Model,
	   m.Seats,
	   v.Mileage
FROM Vehicles AS v
JOIN Models AS m
	ON m.Id = v.ModelId
WHERE v.Id <> ALL (SELECT * FROM CTE_NotReturned)
ORDER BY v.Mileage ASC,
		 m.Seats DESC,
		 m.Id ASC

--09. Offices per Town 

SELECT t.[Name] AS [TownName],
	   COUNT(o.Id) AS [OfficesNumber]
FROM Towns AS t
JOIN Offices AS o
	ON o.TownId = t.Id
GROUP BY t.[Name]
ORDER BY [OfficesNumber] DESC,
		 [TownName] ASC

--10. Buyers Best Choice 

SELECT m.Manufacturer,
	   m.Model,
	   COUNT(o.VehicleId) AS [TimesOrdered]
FROM Models AS m
JOIN Vehicles AS v
	ON v.ModelId = m.Id
FULL JOIN Orders AS o
	ON o.VehicleId = v.Id
GROUP BY m.Manufacturer,
		 m.Model
ORDER BY [TimesOrdered] DESC,
		 m.Manufacturer DESC,
		 m.Model ASC

--11. Kinda Person 

SELECT Names,
	   Class
FROM
(
	SELECT c.Id,
		   CONCAT(c.FirstName, ' ', c.LastName) AS [Names],
		   DENSE_RANK() OVER (PARTITION BY c.Id ORDER BY COUNT(m.Class) DESC) AS [Rank],
		   m.Class
	FROM Clients AS c
	JOIN Orders AS o
		ON o.ClientId = c.Id
	JOIN Vehicles AS v
		ON o.VehicleId = v.Id
	JOIN Models AS m
		ON m.Id = v.ModelId
	GROUP BY CONCAT(c.FirstName, ' ', c.LastName),
			 m.Class,
			 c.Id
) AS ordered
WHERE ordered.[Rank] = 1
ORDER BY Names ASC,
		 Class ASC,
		 ordered.Id ASC

--12. Age Groups Revenue

SELECT CASE
			WHEN DATEPART(YEAR, c.BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
			WHEN DATEPART(YEAR, c.BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
			WHEN DATEPART(YEAR, c.BirthDate) BETWEEN 1990 AND 1999 THEN '90''s'
			ELSE 'Others'
		END AS [AgeGroup],
		SUM(o.Bill) AS [Revenue],
		AVG(o.TotalMileage) AS [AverageMileage]
FROM Clients AS c
JOIN Orders AS o
	ON o.ClientId = c.Id
GROUP BY CASE
			WHEN DATEPART(YEAR, c.BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
			WHEN DATEPART(YEAR, c.BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
			WHEN DATEPART(YEAR, c.BirthDate) BETWEEN 1990 AND 1999 THEN '90''s'
			ELSE 'Others'
		 END
ORDER BY [AgeGroup]  ASC



SELECT AgeGroup,
	   SUM(Bill) AS [Revenue],
	   AVG(TotalMileage) AS [AverageMileage]
FROM
(
	SELECT CASE
				WHEN DATEPART(YEAR, c.BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
				WHEN DATEPART(YEAR, c.BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
				WHEN DATEPART(YEAR, c.BirthDate) BETWEEN 1990 AND 1999 THEN '90''s'
				ELSE 'Others'
			END AS [AgeGroup],
			SUM(o.Bill) AS [Bill],
			o.TotalMileage
	FROM Clients AS c
	JOIN Orders AS o
		ON o.ClientId = c.Id
	GROUP BY c.BirthDate,
			 o.TotalMileage
) AS result
GROUP BY result.AgeGroup
ORDER BY [AgeGroup]  ASC

--13. Consumption in Mind

SELECT Manufacturer,
	   AVG(Consumption) AS [AverageConsumption]
FROM Models
WHERE Consumption BETWEEN 5 AND 15 
AND Id IN 
(
	SELECT TOP(7) m.Id
	FROM Orders AS o
	JOIN Vehicles AS v
		ON v.Id = o.VehicleId
	JOIN Models AS m
		ON m.Id = v.ModelId
	GROUP BY m.Id
	ORDER BY COUNT(o.VehicleId) DESC
)
GROUP BY Manufacturer
ORDER BY Manufacturer ASC,
		 AverageConsumption ASC

--14. Debt Hunter

SELECT [Category Name],
	   Email,
	   Bill,
	   [Town Name]
FROM
(
	SELECT ROW_NUMBER() OVER (PARTITION BY t.[Name] ORDER BY o.Bill DESC) AS [OrderedByHighestBill],
		   CONCAT(c.FirstName, ' ', c.LastName) AS [Category Name],
		   c.Email AS [Email],
		   o.Bill,
		   t.[Name] AS [Town Name],
		   c.Id AS [Client Id]
	FROM Orders AS o
	JOIN Clients AS c
		ON c.Id = o.ClientId
	JOIN Towns AS t
		ON t.Id = o.TownId
	WHERE o.CollectionDate > c.CardValidity
	AND o.Bill IS NOT NULL
) AS ordered
WHERE [OrderedByHighestBill] IN (1, 2)
ORDER BY [Town Name] ASC,
		 Bill ASC,
		 [Client Id] ASC

--15. Town Statistics

SELECT t.[Name] AS [TownName],
	   (SUM(result.Male) * 100) / (ISNULL(SUM(result.Male), 0) + ISNULL(SUM(result.Female), 0)) AS [MalePercent],
	   (SUM(result.Female) * 100) / (ISNULL(SUM(result.Male), 0) + ISNULL(SUM(result.Female), 0)) AS [FemalePercent]
FROM
(
	SELECT o.TownId,
		   CASE WHEN (Gender = 'M') THEN COUNT(o.Id) END AS Male,
		   CASE WHEN (Gender = 'F') THEN COUNT(o.Id) END AS Female
	FROM Orders AS o
	JOIN Clients AS c
		ON c.Id = o.ClientId
	GROUP BY c.Gender,
			 o.TownId
) AS result
JOIN Towns AS t
	ON t.Id = result.TownId
GROUP BY t.[Name]

--16. Home Sweet Home 

WITH CTE_Ranks (ReturnOfficeId, OfficeId, Id, Manufacturer, Model)
AS
(
	SELECT RankedByDateDesc.ReturnOfficeId,
		   RankedByDateDesc.OfficeId,
		   RankedByDateDesc.Id,
		   RankedByDateDesc.Manufacturer,
		   RankedByDateDesc.Model
	FROM
	(
		SELECT DENSE_RANK() OVER (PARTITION BY v.Id ORDER BY o.CollectionDate DESC) AS [LatestRentCarsRank],
			   o.ReturnOfficeId,
			   v.OfficeId,
			   m.Manufacturer,
			   m.Model,
			   v.Id
		FROM Orders AS o
		RIGHT JOIN Vehicles AS v
			ON v.Id = o.VehicleId
		JOIN Models AS m
			ON m.Id = v.ModelId
	) AS RankedByDateDesc
	WHERE [LatestRentCarsRank] = 1
)

SELECT CONCAT(Manufacturer, ' - ', Model) AS Vehicle,
	   [Location] = 
	   CASE
			WHEN (SELECT COUNT(*) AS [Orders]
				  FROM Orders AS o
				  WHERE o.VehicleId = CTE_Ranks.Id) = 0
			THEN 'home'

			WHEN (CTE_Ranks.ReturnOfficeId IS NULL)
			THEN 'on a rent'

			WHEN (CTE_Ranks.OfficeId <> CTE_Ranks.ReturnOfficeId)
			THEN (SELECT CONCAT(t.[Name], ' - ', o.[Name])
				  FROM Towns AS t
				  JOIN Offices AS o
					ON o.TownId = t.Id
					WHERE o.Id = CTE_Ranks.ReturnOfficeId)
	   END
FROM CTE_Ranks
ORDER BY Vehicle ASC,
		 CTE_Ranks.Id ASC