--05. Users by Age

SELECT Username, Age
FROM Users 
ORDER BY Age ASC,
		 Username DESC

--06. Unassigned Reports 

SELECT [Description], OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC,
		 [Description] ASC

--07. Employees & Reports 

SELECT e.FirstName, e.LastName, r.[Description], FORMAT(r.OpenDate, 'yyyy-MM-dd') AS [OpenDate]
FROM Reports AS r
JOIN Employees AS e
	ON  e.Id = r.EmployeeId
ORDER BY e.Id ASC,
		 r.OpenDate

--08. Most Reported Category

SELECT c.[Name], 
	   COUNT(r.Id) AS [ReportsNumber]
FROM Categories AS c
JOIN Reports AS r
	ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY [ReportsNumber] DESC,
		 c.[Name] ASC

--09. Employees in Category

SELECT c.[Name],
	   COUNT(e.Id) AS [Employees Number]
FROM Categories AS c
JOIN Departments AS d
	ON d.Id = c.DepartmentId
JOIN Employees AS e
	ON e.DepartmentId = d.Id
GROUP BY c.[Name]
ORDER BY c.[Name] ASC

--10. Users per Employee 

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Name],
	   COUNT(r.UserId) AS [Users Number]
FROM Reports AS r
RIGHT JOIN Employees AS e
	ON e.Id = r.EmployeeId
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY [Users Number] DESC,
		 [Name] ASC

--11. Emergency Patrol

SELECT r.OpenDate,
	   r.[Description],
	   u.Email AS [Reporter Email] 
FROM Reports AS r
JOIN Categories AS c
	ON c.Id = r.CategoryId
JOIN Users AS u
	ON u.Id = r.UserId
WHERE r.CloseDate IS NULL 
AND LEN(r.[Description]) > 20
AND r.[Description] LIKE '%str%'
AND c.DepartmentId IN (1, 4, 5)
ORDER BY r.OpenDate ASC,
		 [Reporter Email] ASC,
		 r.Id ASC

 --12. Birthday Report

 SELECT DISTINCT c.[Name] AS [Category Name]
 FROM Categories AS c
 JOIN Reports AS r
	ON r.CategoryId = c.Id
JOIN Users AS u
	ON u.Id = r.UserId
WHERE DAY(u.BirthDate) = DAY(r.OpenDate) AND MONTH(u.BirthDate) = MONTH(r.OpenDate)
ORDER BY [Category Name] ASC

--13. Numbers Coincidence
 
SELECT DISTINCT u.Username 
FROM Reports AS r
JOIN Categories AS c
	ON c.Id = r.CategoryId
JOIN Users AS u
	ON u.Id = r.UserId
WHERE LEFT(u.Username, 1) LIKE '[0-9]'
AND CONVERT(VARCHAR(10), c.Id) = LEFT(u.Username, 1)
OR RIGHT(u.Username, 1) LIKE '[0-9]'
AND CONVERT(VARCHAR(10), c.Id) = RIGHT(u.Username, 1)
ORDER BY u.Username ASC

--14. Open/Closed Statistics
 
SELECT [Name],
	   CONCAT(Closed, '/', Opened) AS [Closed Open Reports]
FROM
(
	SELECT e.Id AS [EmployeeId],
		   CONCAT(e.FirstName, ' ', e.LastName) AS [Name],
		   COUNT(r.OpenDate) AS [Opened],
		   COUNT(r.CloseDate) AS [Closed]
	FROM Employees AS e
	JOIN Reports AS r
		ON r.EmployeeId = e.Id
	WHERE DATEPART(YEAR, r.OpenDate) = 2016
	OR DATEPART(YEAR, r.CloseDate) = 2016
	GROUP BY CONCAT(e.FirstName, ' ', e.LastName), e.Id
) AS ocr
JOIN Employees AS e
	ON e.Id = ocr.EmployeeId
ORDER BY [Name] ASC,
		 e.Id ASC 

--15. Average Closing Time

 SELECT d.[Name] AS [Department Name],
		ISNULL(CONVERT(VARCHAR(10), AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate))), 'no info') 
		AS [Average Duration]
 FROM Departments AS d
 JOIN Categories AS c
	ON c.DepartmentId = d.Id
JOIN Reports AS r
	ON r.CategoryId = c.Id
GROUP BY d.[Name]
ORDER BY [Department Name]

--16. Favorite Categories 

SELECT d.[Name] AS [Department Name],
	   c.[Name] AS [Category Name],
	   CONVERT(INT, ROUND(CountPerCategory.[Count] * 100.00 / CountPerDepartment.[Count], 0)) AS [Percentage]
FROM Departments AS d
JOIN Categories AS c
	ON c.DepartmentId = d.Id
JOIN (SELECT CategoryId,
			 COUNT(1) AS [Count]
	  FROM Reports
	  GROUP BY CategoryId) AS CountPerCategory
	ON CountPerCategory.CategoryId = c.Id
JOIN (SELECT c.DepartmentId,
			 COUNT(1) AS [Count]
	  FROM Reports AS r
	  JOIN Categories AS c
		ON c.Id = r.CategoryId
	  GROUP BY c.DepartmentId) AS CountPerDepartment
	ON CountPerDepartment.DepartmentId = d.Id
ORDER BY d.[Name] ASC,
		 c.[Name] ASC