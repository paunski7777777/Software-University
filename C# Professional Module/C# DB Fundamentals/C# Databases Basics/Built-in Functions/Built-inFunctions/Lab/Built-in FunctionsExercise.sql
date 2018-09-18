--01. Find Names of All Employees by First Name
SELECT FirstName, LastName
FROM Employees
WHERE LEFT(FirstName, 2) = 'Sa'

--02. Find Names of All Employees by Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--03. Find First Names of All Employess
SELECT FirstName
FROM Employees
WHERE DepartmentID = 3 OR DepartmentID = 10
AND (SELECT YEAR(HireDate)) >= 1995 AND (SELECT YEAR(HireDate)) <= 2005

--04. Find All Employees Except Engineers
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--05. Find Towns with Name Length
SELECT [Name]
FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]

--06. Find Towns Starting With
SELECT TownId, [Name]
FROM Towns
WHERE LEFT([Name], 1) = 'M' OR LEFT([Name], 1) = 'K' OR LEFT([Name], 1) = 'B' OR LEFT([Name], 1) = 'E'
ORDER BY [Name]

--07. Find Towns Not Starting With
SELECT TownId, [Name]
FROM Towns
WHERE LEFT([Name], 1) != 'R' AND LEFT([Name], 1) != 'B' AND LEFT([Name], 1) != 'D'
ORDER BY [Name]

--08. Create View Employees Hired After
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE (SELECT YEAR(HireDate)) > 2000

--09. Length of Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--10. Countries Holding 'A'
SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--11. Mix of Peak and River Names
SELECT PeakName, RiverName,
LOWER(PeakName + RIGHT(RiverName, LEN(RiverName) - 1)) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

--12. Games From 2011 and 2012 Year
SELECT TOP(50) [Name], FORMAT([Start],' yyyy-MM-dd') AS [Start]
FROM Games
WHERE (SELECT YEAR([Start])) >= 2011 AND (SELECT YEAR([Start])) <= 2012
ORDER BY [Start],
[Name]

--13. User Email Providers
SELECT Username, RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider],
Username

--14. Get Users with IPAddress Like Pattern
SELECT UserName, IpAddress
FROM Users
WHERE IpAddress LIKE '%___.1%.%.___%'
ORDER BY Username

--15. Show All Games with Duration
SELECT [Name],
CASE
WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning' 
WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 23 THEN 'Evening' 
END AS [Part of the day],
CASE
WHEN Duration <= 3 THEN 'Extra Short'
WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
WHEN Duration > 6 THEN 'Long'
ELSE 'Extra Long'
END AS [Duration]
FROM Games
ORDER BY [Name],
Duration,
[Part of the day]

--16. Orders Table
SELECT ProductName, OrderDate,
DATEADD(DAY, 3, OrderDate) AS [Pay Due],
DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

--Problem 17. People Table
CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Birthdate DATETIME2
)

INSERT INTO People VALUES
('Victor', '2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '2010-01-06')

SELECT [Name],
DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People