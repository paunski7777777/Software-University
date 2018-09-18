--01. Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE e.Salary > 35000
GO

EXEC [dbo].usp_GetEmployeesSalaryAbove35000
GO

--02. Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@level DECIMAL(18, 4))
AS
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE e.Salary >= @level
GO

EXEC [dbo].usp_GetEmployeesSalaryAboveNumber 48100
GO
--03. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith(@input NVARCHAR(MAX))
AS
	SELECT t.[Name] AS [Town]
	FROM Towns AS t
	WHERE t.[Name] LIKE @input + '%'
GO

EXEC [dbo].usp_GetTownsStartingWith 'b'
GO

--04. Employees from Town
CREATE PROC usp_GetEmployeesFromTown(@townName NVARCHAR(MAX))
AS
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	JOIN Addresses AS a 
		ON a.AddressID = e.AddressID
	JOIN Towns AS t
		ON t.TownID = a.TownID
	WHERE t.[Name] = @townName
GO

EXEC usp_GetEmployeesFromTown 'Sofia'
GO

--05. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
BEGIN
	DECLARE @level VARCHAR(7);

	IF (@salary < 30000)
		SET @level = 'Low'

	ELSE IF (@salary >= 30000 AND @salary <= 50000)
		SET @level = 'Average'

	ELSE IF (@salary > 50000)
		SET @level = 'High'

	RETURN @level;
END
GO

SELECT e.Salary,
	   [dbo].ufn_GetSalaryLevel(e.Salary) AS [SalaryLevel]
FROM Employees AS e
GO

--06. Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel(@level VARCHAR(7))
AS
	SELECT e.FirstName,
		   e.LastName
	FROM Employees AS e
	WHERE [dbo].ufn_GetSalaryLevel(e.Salary) = @level
GO

EXEC usp_EmployeesBySalaryLevel 'High'
GO

--07. Define Function
CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
BEGIN
	DECLARE @isComprised BIT = 0;
	DECLARE @currentIndex INT = 1;
	DECLARE @currentChar CHAR(1);

	WHILE (@currentIndex <= LEN(@word))
		BEGIN
			SET @currentChar = SUBSTRING(@word, @currentIndex, 1);

			IF (CHARINDEX(@currentChar, @setOfLetters) = 0)
				RETURN @isComprised;
			
			ELSE
				SET @currentIndex += 1
		END
	RETURN @isComprised + 1;
END
GO

CREATE TABLE TestIsWordComprised (
	SetOfLetters VARCHAR(MAX),
	Word VARCHAR(MAX)
)
GO

INSERT INTO TestIsWordComprised VALUES 
('oistmiahf', 'Sofia'),
('oistmiahf', 'halves'),
('bobr', 'Rob'), 
('pppp', 'Guy')
GO

SELECT SetOfLetters,
	   Word,
	   dbo.ufn_IsWordComprised(SetOfLetters, Word) AS Result
FROM TestIsWordComprised
GO

--08. Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS

DECLARE @deletedEmployees TABLE
(
Id int
)

INSERT INTO @deletedEmployees
SELECT e.EmployeeID
FROM Employees AS e
WHERE e.DepartmentID = @departmentId

ALTER TABLE Departments
ALTER COLUMN ManagerID int NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT Id FROM @deletedEmployees)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @deletedEmployees)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @deletedEmployees)

DELETE FROM Employees
WHERE EmployeeID IN (SELECT Id FROM @deletedEmployees)

DELETE FROM Departments
WHERE DepartmentID = @departmentId 

SELECT COUNT(*) AS [Employees Count]
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.DepartmentID = @departmentId

--09. Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
	SELECT ah.FirstName + ' ' + ah.LastName AS [Full Name]
	FROM AccountHolders AS ah
GO

EXEC [dbo].usp_GetHoldersFullName
GO

--10. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@amount DECIMAL(15, 2))
AS
	SELECT FirstName, LastName
	FROM AccountHolders AS ah
		JOIN Accounts AS a
		ON ah.Id = a.AccountHolderId
	GROUP BY FirstName, LastName
	HAVING SUM(a.Balance) > @amount
GO

--11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(15, 2), @yearlyInterestRate FLOAT, @numberOfyears INT)
RETURNS DECIMAL(15, 4)
BEGIN
	RETURN @sum * POWER(1 + @yearlyInterestRate, @numberOfyears)
END
GO

SELECT [dbo].ufn_CalculateFutureValue(1000, 0.1, 5)
GO

--12. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT)
AS
	SELECT ah.Id,
		   ah.FirstName,
		   ah.LastName, 
		   a.Balance AS [Current Balance],
		   [dbo].ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
		JOIN Accounts AS a
			ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountId
GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1
GO

--13. *Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS TABLE
AS 
RETURN 
(
	SELECT SUM(e.Cash) AS [SumCash]
	FROM 
	(
		SELECT g.Id, 
			   ug.Cash,
			   ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS [RowNumber]
		FROM Games AS g
		JOIN UsersGames AS ug
			ON ug.GameId = g.Id
		WHERE g.[Name] = @gameName
	) AS e
	WHERE e.RowNumber % 2 = 1
)
GO

--14. Create Table Logs
CREATE TABLE Logs (
	LogId INT IDENTITY NOT NULL,
	AccountId INT NOT NULL,
	OldSum DECIMAL(15, 2) NOT NULL,
	NewSum DECIMAL(15, 2) NOT NULL

	CONSTRAINT PK_Logs
	PRIMARY KEY (LogId),

	CONSTRAINT FK_Logs_Accounts
	FOREIGN KEY (AccountId)
	REFERENCES Accounts(Id)
)
GO

CREATE TRIGGER tr_SumOfAccountChanges
ON Accounts
AFTER UPDATE
AS
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM inserted AS i
	INNER JOIN deleted AS d
		ON i.Id = d.Id

--15. Create Table Emails
CREATE TABLE NotificationEmails (
	Id INT IDENTITY NOT NULL,
	Recipient INT NOT NULL,
	[Subject] NVARCHAR(50),
	Body NVARCHAR(MAX),

	CONSTRAINT PK_NotificationEmails
	PRIMARY KEY (Id),

	CONSTRAINT FK_NotificationEmails_Accounts
	FOREIGN KEY (Recipient)
	REFERENCES Accounts(Id)
)
GO

CREATE TRIGGER tr_NotificationEmailsAfterInsert
ON Logs
AFTER INSERT
AS
	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	SELECT i.AccountId,
		   CONCAT('Balance change for account: ', i.AccountId),
		   CONCAT('On ', GETDATE(), ' your balance was changed from ', i.OldSum, 'to ', i.NewSum, '.')
	FROM inserted AS i
GO

--16. Deposit Money
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
	BEGIN TRANSACTION
		UPDATE Accounts
			SET Balance += @MoneyAmount
			WHERE Id = @AccountId

	COMMIT
GO

--17. Withdraw Money Procedure
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
	BEGIN TRANSACTION
		UPDATE Accounts
			SET Balance -= @MoneyAmount
			WHERE Id = @AccountId

		DECLARE @FinalAmount DECIMAL (15, 4);
		SET @FinalAmount = (SELECT Balance FROM Accounts WHERE Id = @AccountId)

		IF (@FinalAmount < 0)
			BEGIN
				RAISERROR('Insufficient Funds', 16, 1);
				ROLLBACK;
				RETURN;
			END

	COMMIT
GO

--18. Money Transfer
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15, 4))
AS
	BEGIN TRANSACTION
		EXEC usp_DepositMoney @ReceiverId, @Amount
		EXEC usp_WithdrawMoney @SenderId, @Amount
	COMMIT
GO

--Problem 19. Trigger

--20. *Massive Shopping
DECLARE @StamatId INT = (SELECT Id 
						 FROM Users
						 WHERE Username = 'Stamat')

DECLARE @GameId INT = (SELECT Id 
						 FROM Games
						 WHERE [Name] = 'Safflower')

DECLARE @UserGameId INT = (SELECT Id
						   FROM UsersGames
						   WHERE UserId = @StamatId AND GameId = @GameId)
BEGIN TRY
	BEGIN TRAN
		UPDATE UsersGames
			SET Cash -= (SELECT SUM(Price) 
						 FROM Items 
						 WHERE MinLevel IN (11, 12))
			WHERE Id = @UserGameId

		DECLARE @UserBalance DECIMAL(15, 4) = (SELECT Cash
								FROM UsersGames
								WHERE Id = @UserGameId)
	
		IF (@UserBalance < 0)
			BEGIN
				ROLLBACK
				RETURN
			END

		INSERT INTO UserGameItems
		SELECT Id, @UserGameId
		FROM Items
		WHERE MinLevel IN (11, 12)
	COMMIT
END TRY

BEGIN CATCH
	ROLLBACK
END CATCH

BEGIN TRY
	BEGIN TRAN
		UPDATE UsersGames
			SET Cash -= (SELECT SUM(Price) 
						 FROM Items 
						 WHERE MinLevel BETWEEN 19 AND 21)
			WHERE Id = @UserGameId

		SET @UserBalance = (SELECT Cash
								FROM UsersGames
								WHERE Id = @UserGameId)
	
		IF (@UserBalance < 0)
			BEGIN
				ROLLBACK
				RETURN
			END

		INSERT INTO UserGameItems
		SELECT Id, @UserGameId
		FROM Items
		WHERE MinLevel BETWEEN 19 AND 21
	COMMIT
END TRY

BEGIN CATCH
	ROLLBACK
END CATCH

SELECT i.[Name] AS [Item Name]
FROM Items AS i
JOIN UserGameItems AS ugi
	ON i.Id = ugi.ItemId
WHERE ugi.UserGameId = @UserGameId
ORDER BY [Item Name]
GO

--21. Employees with Three Projects
CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRAN
	INSERT INTO EmployeesProjects 
	VALUES
	(@emloyeeId, @projectID)

	DECLARE @EmployeeProjectCount INT = (SELECT COUNT(*)
										 FROM EmployeesProjects
										 WHERE EmployeeID = @emloyeeId)
	
	IF (@EmployeeProjectCount > 3)
		BEGIN
			ROLLBACK
			RAISERROR('The employee has too many projects!', 16, 1)
			RETURN
		END
COMMIT

--22. Delete Employees
CREATE TABLE Deleted_Employees (
EmployeeId INT NOT NULL IDENTITY, 
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(50),
JobTitle VARCHAR(50) NOT NULL,
DepartmentId INT NOT NULL,
Salary DECIMAL(15, 4),

CONSTRAINT PK_Deleted_Employees
PRIMARY KEY (EmployeeId),

CONSTRAINT FK_Deleted_Employees_Departments
FOREIGN KEY (DepartmentID)
REFERENCES Departments(DepartmentID)
)
GO

CREATE TRIGGER tr_FireEmployee
ON Employees
AFTER DELETE
AS
	INSERT INTO Deleted_Employees
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary
	FROM deleted AS d