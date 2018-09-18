CREATE OR ALTER PROC usp_TransferFunds (@AccountIdSource INT, @AccountIdDestination INT, @Amount DECIMAL(15, 2))
AS
	BEGIN TRANSACTION
		IF (@Amount <= 0)
			BEGIN
				RAISERROR('Zero or negative amount specified', 16, 1);
				RETURN
			END	
		
		UPDATE Accounts
		SET Balance -= @Amount
		WHERE Id = @AccountIdSource

		IF (@@ROWCOUNT <> 1)
			BEGIN
				RAISERROR('Invalid source account id', 16, 2);
				ROLLBACK
				RETURN
			END

		DECLARE @FinalAmount DECIMAL (15, 2);
		SET @FinalAmount = (SELECT Balance FROM Accounts WHERE Id = @AccountIdSource)

		IF (@FinalAmount < 0)
			BEGIN
				RAISERROR('Insufficient Funds', 16, 2);
				ROLLBACK;
				RETURN;
			END

		UPDATE Accounts
		SET Balance += @Amount
		WHERE Id = @AccountIdDestination

		IF (@@ROWCOUNT <> 1)
			BEGIN
				RAISERROR('Invalid destination account id', 16, 2);
				ROLLBACK
				RETURN
			END

COMMIT
GO

CREATE TRIGGER tr_ProccesTransaction
ON Accounts
FOR UPDATE
AS
	INSERT INTO Transactions (AccountId, OldBalance, NewBalance, [DateTime])
	SELECT deleted.Id,
		   deleted.Balance,
		   inserted.Balance,
		   GETDATE() 
	FROM inserted
	INNER JOIN deleted
		ON deleted.Id = inserted.Id
