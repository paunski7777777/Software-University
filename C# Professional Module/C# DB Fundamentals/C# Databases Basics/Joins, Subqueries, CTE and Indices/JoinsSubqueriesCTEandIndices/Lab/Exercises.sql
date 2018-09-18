--01. Employee Address
SELECT TOP (5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
	JOIN Addresses AS a
		ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC

--02. Addresses with Towns
SELECT TOP (50) e.FirstName, e.LastName, t.Name AS [Town], a.AddressText
FROM Employees AS e
	JOIN Addresses AS a
		ON e.AddressID = a.AddressID
	JOIN Towns AS t
		ON t.TownID = a.TownID
ORDER BY e.FirstName ASC, e.LastName ASC

--03. Sales Employees
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS [DepartmentName]
FROM Employees AS e
	INNER JOIN Departments AS d
		ON e.DepartmentID = d.DepartmentID AND d.[Name] = 'Sales'
ORDER BY e.EmployeeID ASC
		
--04. Employee Departments
SELECT TOP (5) e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS [DepartmentName]
FROM Employees AS e
	JOIN Departments AS d
		ON e.DepartmentID = d.DepartmentID AND e.Salary > 15000
ORDER BY e.DepartmentID ASC

--05. Employees Without Projects
SELECT TOP (3) e.EmployeeID, e.FirstName
FROM Employees AS e
	LEFT OUTER JOIN EmployeesProjects AS ep
		ON ep.EmployeeID = e.EmployeeID
WHERE  ep.ProjectID IS NULL
ORDER BY e.EmployeeID ASC
		
--06. Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS [DeptName]
FROM Employees AS e
	JOIN Departments AS d
		ON (e.DepartmentID = d.DepartmentID
		 AND e.HireDate > '1/1/1999' 
		 AND d.[Name] IN ('Sales', 'Finance'))
ORDER BY e.HireDate ASC

--07. Employees With Project
SELECT TOP (5) e.EmployeeID, e.FirstName, p.[Name]
FROM Employees AS e
	JOIN EmployeesProjects AS ep
		ON (e.EmployeeID = ep.EmployeeID AND ep.ProjectID IS NOT NULL)
	JOIN Projects AS p
		ON (ep.ProjectID = p.ProjectID AND p.StartDate > '02/13/2002' AND p.EndDate IS NULL)
ORDER BY e.EmployeeID ASC

--08. Employee 24
SELECT e.EmployeeID, e.FirstName,
CASE
	WHEN p.StartDate > '01/01/2005' THEN NULL
	ELSE p.[Name]
END AS [ProjectName]
FROM Employees AS e
	JOIN EmployeesProjects AS ep
		ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p
		ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

--09. Employee Manager
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName
FROM Employees AS e
	JOIN Employees AS m
		ON (m.EmployeeID = e.ManagerID AND e.ManagerID IN (3, 7))
ORDER BY e.EmployeeID

--10. Employees Summary
SELECT TOP (50) 
				e.EmployeeID,
			    e.FirstName + ' ' + e.LastName AS [EmployeeName],
				m.FirstName + ' ' + m.LastName AS [ManagerName],
				d.[Name] AS DepartmentName
FROM Employees AS e
	JOIN Employees AS m
		ON m.EmployeeID = e.ManagerID
	JOIN Departments AS d
		ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--11. Min Average Salary
SELECT MIN(a.AverageSalary) AS [MinAverageSalary]
FROM 
(
	SELECT e.DepartmentID, AVG(e.Salary) AS AverageSalary
	FROM Employees AS e
	GROUP BY e.DepartmentID
) AS a

--12. Highest Peaks in Bulgaria
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
	JOIN Peaks AS p
		ON (m.Id = p.MountainId AND p.Elevation > 2835)
	JOIN MountainsCountries AS mc
		ON (mc.MountainId = m.Id AND mc.CountryCode = 'BG')
ORDER BY p.Elevation DESC

--13. Count Mountain Ranges
SELECT mc.CountryCode, COUNT(mc.CountryCode) AS [MountainRanges]
FROM Mountains AS m
	JOIN MountainsCountries AS mc
		ON (mc.MountainId = m.Id AND mc.CountryCode IN ('US', 'BG', 'RU'))
GROUP BY mc.CountryCode

--14. Countries With or Without Rivers
SELECT TOP (5) c.CountryName, r.RiverName
FROM Countries AS c
	 LEFT JOIN CountriesRivers AS cr
		ON cr.CountryCode = c.CountryCode
     LEFT JOIN Rivers AS r
		ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC

--15. *Continents and Currencies
SELECT ContinentCode, CurrencyCode, CurrencyUsage
	FROM
		(
		SELECT ContinentCode, CurrencyCode, CurrencyUsage,
				DENSE_RANK() OVER (PARTITION BY(ContinentCode) ORDER BY CurrencyUsage DESC) AS [Rank]
	FROM
		(
		SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS [CurrencyUsage]
FROM Countries
GROUP BY CurrencyCode, ContinentCode) AS cc 
) AS ccc
WHERE [Rank] = 1 AND CurrencyUsage > 1
ORDER BY ContinentCode

--16. Countries Without any Mountains
SELECT COUNT(CountryCode) AS [CountryCode]
FROM Countries
	WHERE CountryCode NOT IN (SELECT CountryCode FROM MountainsCountries)

SELECT COUNT(c.CountryCode) AS [CountryCode]
FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL

--17. Highest Peak and Longest River by Country
SELECT TOP (5) c.CountryName,
			   MAX(p.Elevation) AS [HighestPeakElevation],
			   MAX(r.[Length]) AS [LongestRiverLength]
FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON c.CountryCode = mc.CountryCode
	LEFT JOIN Peaks AS p
		ON p.MountainId = mc.MountainId
	LEFT JOIN CountriesRivers AS cr
		ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r
		ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC,
		 [LongestRiverLength] DESC,
		 CountryName

--18. *Highest Peak Name and Elevation by Country
SELECT TOP (5) CountryName,

	   CASE 
			WHEN PeakName IS NULL THEN '(no highest peak)'
			ELSE PeakName
		END AS [Highest Peak Name],

       CASE 
			WHEN Elevation IS NULL THEN 0
			ELSE Elevation
		END AS [Highest Peak Elevation],

       CASE 
			WHEN MountainRange IS NULL THEN '(no mountain)'
			ELSE MountainRange
		END AS [Mountain]
FROM
(
	SELECT CountryName, PeakName, Elevation, MountainRange,
		   DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY Elevation DESC) AS [Rank]
	FROM
	(
		SELECT c.CountryName, p.PeakName, p.Elevation, m.MountainRange
		FROM Countries AS c
			LEFT JOIN MountainsCountries AS mc
				ON mc.CountryCode = c.CountryCode
			LEFT JOIN Mountains AS m
				ON m.Id = mc.MountainId
			LEFT JOIN Peaks AS p
				ON p.MountainId = m.Id
	) AS allPeaks 
) AS rankedPeaks
WHERE [Rank] = 1
ORDER BY CountryName, [Highest Peak Name]