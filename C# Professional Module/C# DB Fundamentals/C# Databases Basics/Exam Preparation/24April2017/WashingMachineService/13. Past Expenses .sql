SELECT jo.JobId,
	   (SELECT ISNULL(SUM(p.Price * op.Quantity), 0)
		FROM Parts AS p
		JOIN OrderParts AS op
			ON op.PartId = p.PartId
		JOIN Orders AS o
			ON o.OrderId = op.OrderId
		JOIN Jobs AS j
			ON j.JobId = o.JobId
		WHERE j.JobId = jo.JobId) AS [Total]
FROM Jobs AS jo
WHERE jo.[Status] = 'Finished'
ORDER BY [Total] DESC,
		 jo.JobId