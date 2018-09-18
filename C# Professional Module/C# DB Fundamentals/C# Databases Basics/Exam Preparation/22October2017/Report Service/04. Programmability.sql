--17. Employee's Load

CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT) 
RETURNS INT
AS
BEGIN
	DECLARE @Result INT = (SELECT COUNT(*) 
						   FROM Reports
						   WHERE EmployeeId = @employeeId AND StatusId = @statusId)

	RETURN @Result
END
GO

SELECT Id,
	   FirstName,
	   Lastname, 
	   dbo.udf_GetReportsCount(Id, 2) AS ReportsCount
FROM Employees
ORDER BY Id
GO

--18. Assign Employee
 
CREATE PROC usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN 
	DECLARE @EmployeeDepartmentId INT = (SELECT DepartmentId 
										 FROM Employees 
										 WHERE Id = @employeeId)

	DECLARE @ReportDepartmentId INT = (SELECT c.DepartmentId
										 FROM Reports AS r
										 JOIN Categories AS c
											ON c.Id = r.CategoryId
										 WHERE r.Id = @reportId)

	IF (@EmployeeDepartmentId = @ReportDepartmentId)
		BEGIN
			UPDATE Reports
				SET EmployeeId = @employeeId
				WHERE Id = @reportId
		END

	ELSE
		BEGIN
			RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1);
		END
END 
GO

EXEC usp_AssignEmployeeToReport 17, 2;
SELECT EmployeeId FROM Reports WHERE id = 2
GO

 --19. Close Reports 

CREATE TRIGGER tr_ChangesStatusId
ON Reports
AFTER UPDATE
AS
	DECLARE @CompletedStatusId INT = (SELECT Id
									  FROM [Status]
									  WHERE Label = 'completed')

	UPDATE Reports
		SET StatusId = @CompletedStatusId
		WHERE Id = (SELECT Id
					FROM inserted
					WHERE CloseDate IS NOT NULL)
GO

UPDATE Reports
SET CloseDate = GETDATE()
WHERE EmployeeId = 5;
GO