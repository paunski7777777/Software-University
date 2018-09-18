--20. Categories Revision

SELECT c.[Name],
	   COUNT(r.Id) AS [Reports Number],
	   CASE
			WHEN SUM(CASE WHEN r.StatusId = 2 THEN 1 ELSE 0 END) >
				 SUM(CASE WHEN r.StatusId = 1 THEN 1 ELSE 0 END) THEN 'in progress'

			WHEN SUM(CASE WHEN r.StatusId = 2 THEN 1 ELSE 0 END) <
				 SUM(CASE WHEN r.StatusId = 1 THEN 1 ELSE 0 END) THEN 'waiting'

			ELSE 'equal'
	   END AS [MainStatus]
FROM Reports AS r
JOIN Categories AS c
	ON c.Id = r.CategoryId
WHERE r.StatusId IN (1, 2)
GROUP BY c.[Name]
ORDER BY c.[Name] ASC,
		 [Reports Number] ASC,
		 [MainStatus] ASC