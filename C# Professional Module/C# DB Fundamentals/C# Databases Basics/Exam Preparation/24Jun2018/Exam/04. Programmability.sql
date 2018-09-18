--18. Available Room

CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @TotalRoomPrice DECIMAL(15, 2);
	DECLARE @Result NVARCHAR(MAX);
	DECLARE @RoomId INT;

	SET @RoomId = (SELECT TOP(1) r.Id
				   FROM Hotels AS h
				   JOIN Rooms AS r
		      	   	ON h.Id = r.HotelId
				   JOIN Trips AS t
		      	   	ON t.RoomId = r.Id
				   WHERE h.Id = @HotelId 
				   AND @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate
				   AND r.Beds >= @People
				   AND t.CancelDate IS NULL
				   GROUP BY r.Id, r.[Type], r.Beds, r.Price
				   ORDER BY r.Price DESC)

	IF (@RoomId IS NOT NULL)
		BEGIN
			DECLARE @RoomPrice DECIMAL(15, 2) = (SELECT TOP(1) Price
												 FROM Rooms
												 WHERE Id = @RoomId
												 ORDER BY Price DESC)

			DECLARE @HotelBaseRate DECIMAL(15, 2) = (SELECT BaseRate
													 FROM Hotels AS h
													 JOIN Rooms AS r
														ON r.HotelId = h.Id
													 WHERE r.Id = @RoomId)

			DECLARE @Beds INT = (SELECT Beds
								 FROM Rooms
								 WHERE Id = @RoomId)

			DECLARE @RoomType VARCHAR(20) = (SELECT [Type]
											 FROM Rooms
											 WHERE Id = @RoomId)

			SET @TotalRoomPrice = (@HotelBaseRate + @RoomPrice) * @People

			SET @Result = CONCAT('Room ', @RoomId,': ', @RoomType, ' (', @Beds, ' beds) - $', @TotalRoomPrice)
		END
	ELSE
		BEGIN
			SET @Result = 'No rooms available'
		END

	RETURN @Result;
END
GO

--NOT DONE 5/7

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

SELECT  r.Id,
			  r.[Type],
			  r.Beds,
			  t.ArrivalDate,
			  t.ReturnDate,
			  t.CancelDate,
			  SUM(h.BaseRate + r.Price) * 2 AS [Total]
FROM Hotels AS h
JOIN Rooms AS r
	ON h.Id = r.HotelId
JOIN Trips AS t
	ON t.RoomId = r.Id
WHERE h.Id = 94 
AND '2015-07-26' NOT BETWEEN t.ArrivalDate AND t.ReturnDate
AND r.Beds >= 3
AND t.CancelDate IS NULL
GROUP BY r.Id, r.[Type], r.Beds, t.ArrivalDate, t.ReturnDate, t.CancelDate
ORDER BY Total DESC

