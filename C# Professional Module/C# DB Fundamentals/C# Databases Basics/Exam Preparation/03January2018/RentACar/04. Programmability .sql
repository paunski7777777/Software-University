--17.Find My Ride

CREATE FUNCTION udf_CheckForVehicle(@townName NVARCHAR(20), @seatsNumber INT) 
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @Result NVARCHAR(MAX) = (SELECT TOP (1) CONCAT(o.[Name], ' - ', m.Model)
									 FROM Models AS m
									 JOIN Vehicles AS v
										ON v.ModelId = m.Id
									 JOIN Offices AS o
										ON o.Id = v.OfficeId
									 JOIN Towns AS t
										ON t.Id = o.TownId
									 WHERE t.[Name] = @townName
									 AND m.Seats = @seatsNumber
									 ORDER BY o.[Name] ASC)

	IF (@Result IS NULL)
		BEGIN
			RETURN 'NO SUCH VEHICLE FOUND'
		END

	RETURN @Result
END
GO

SELECT dbo.udf_CheckForVehicle ('La Escondida', 9) 
GO

--18. Move a Vehicle  

CREATE PROC usp_MoveVehicle(@vehicleId INT, @officeId INT)
AS
	BEGIN TRAN
		DECLARE @VehicleCount INT = (SELECT COUNT(v.Id)
											FROM Offices AS o
											JOIN Vehicles AS v
												ON v.OfficeId = o.Id
											WHERE o.Id = @officeId)

		DECLARE @ParkingPlaces INT = (SELECT ParkingPlaces
									  FROM Offices
									  WHERE Id = @officeId)

		IF (@VehicleCount >= @ParkingPlaces)
			BEGIN
				RAISERROR('Not enough room in this office!', 16, 1);
				ROLLBACK;
			END

		ELSE
			BEGIN
				UPDATE Vehicles
					SET OfficeId = @officeId
					WHERE Id = @vehicleId
			END
	COMMIT
GO

BEGIN TRAN
	EXEC usp_MoveVehicle 7, 32
	SELECT OfficeId FROM Vehicles WHERE Id = 7
ROLLBACK
GO
								 
--19. Move the Tally 

CREATE TRIGGER tr_AddMileage
ON Orders 
AFTER UPDATE
AS
	DECLARE @NewTotalMileage INT = (SELECT TotalMileage FROM inserted)
	DECLARE @OldTotalMileage INT = (SELECT TotalMileage FROM deleted)
	DECLARE @VehicleId INT = (SELECT VehicleId FROM inserted)

	IF (@OldTotalMileage IS NULL AND @VehicleId IS NOT NULL)
		BEGIN
			UPDATE Vehicles
				SET Mileage += @NewTotalMileage
				WHERE Id = @VehicleId
		END
GO

BEGIN TRAN
UPDATE Orders
SET
TotalMileage = 100
WHERE Id = 40;
ROLLBACK