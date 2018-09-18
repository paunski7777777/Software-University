--1. Number of Users for Email Provider 

SELECT RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [EmailProvider],
	   COUNT(*) AS [Number Of Users]
FROM Users
GROUP BY RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))
ORDER BY [Number Of Users] DESC, [EmailProvider] ASC

--02. All Users in Games

SELECT g.[Name] AS [Game],
	   gt.[Name] AS [Game Type],
	   u.Username,
	   ug.[Level],
	   ug.Cash,
	   c.[Name] AS [Character]
FROM UsersGames AS ug
JOIN Games AS g
	ON g.Id = ug.GameId
JOIN GameTypes  AS gt
	ON gt.Id = g.GameTypeId
JOIN Users AS u
	ON u.Id = ug.UserId
JOIN Characters AS c
	ON c.Id = ug.CharacterId
ORDER BY ug.[Level] DESC,
	   	 u.Username ASC,
		 [Game] ASC

--03. Users in Games with Their Items

SELECT u.Username,
	   g.[Name] AS [Game],
	   COUNT(ugi.ItemId) AS [Items Count],
	   SUM(i.Price) AS [Items Price]
FROM Users AS u 
JOIN UsersGames AS ug
	ON ug.UserId = u.Id
JOIN Games AS g
	ON g.Id = ug.GameId
JOIN UserGameItems AS ugi
	ON ugi.UserGameId = ug.Id
JOIN Items AS i
	ON i.Id = ugi.ItemId
GROUP BY u.Username, g.[Name]
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY [Items Count] DESC,
		 [Items Price] DESC,
		 u.Username ASC

--04. * User in Games with Their Statistics

SELECT u.Username,
	   g.[Name] AS [Game],
	   MAX(c.[Name]) AS [Character],
	   MAX(cs.Strength) + MAX(gts.Strength) + SUM(gis.Strength) AS [Strength],
	   MAX(cs.Defence) + MAX(gts.Defence) + SUM(gis.Defence) AS [Defence],
	   MAX(cs.Speed) + MAX(gts.Speed) + SUM(gis.Speed) AS [Speed],
	   MAX(cs.Mind) + MAX(gts.Mind) + SUM(gis.Mind) AS [Mind],
	   MAX(cs.Luck) + MAX(gts.Luck) + SUM(gis.Luck) AS [Luck]
FROM Users AS u
JOIN UsersGames AS ug
	ON ug.UserId = u.Id
JOIN Games AS g
	ON g.Id = ug.GameId
JOIN Characters AS c
	ON c.Id = ug.CharacterId
JOIN [Statistics] AS cs
	ON cs.Id = c.StatisticId
JOIN GameTypes AS gt
	ON gt.Id = g.GameTypeId
JOIN [Statistics] AS gts
	ON gts.Id = gt.BonusStatsId
JOIN UserGameItems AS ugi
	ON ugi.UserGameId = ug.Id
JOIN Items AS i
	ON i.Id = ugi.ItemId
JOIN [Statistics] AS gis
	ON gis.Id = i.StatisticId
GROUP BY u.Username, g.[Name]
ORDER BY [Strength] DESC,
		 [Defence] DESC,
		 [Speed] DESC,
		 [Mind] DESC,
		 [Luck] DESC

--05. All Items with Greater than Average Statistics

SELECT i.[Name],
	   i.Price,
	   i.MinLevel,
	   s.Strength,
	   s.Defence,
	   s.Speed,
	   s.Luck,
	   s.Mind
FROM
(
SELECT Id 
FROM [Statistics]
WHERE Mind > (SELECT AVG(Mind * 1.0) FROM [Statistics]) AND
	  Luck > (SELECT AVG(Luck * 1.0) FROM [Statistics]) AND
	  Speed > (SELECT AVG(Speed * 1.0) FROM [Statistics])
) AS avgs
JOIN [Statistics] AS s
	ON s.Id = avgs.Id
JOIN Items AS i
	ON i.StatisticId = s.Id
ORDER BY i.[Name] ASC

--06. Display All Items about Forbidden Game Type

SELECT i.[Name] AS [Item],
	   i.Price,
	   i.MinLevel,
	   gt.[Name] AS [Forbidden Game Type] 
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS gtfi
	ON gtfi.ItemId = i.Id
LEFT JOIN GameTypes AS gt
	ON gt.Id = gtfi.GameTypeId
ORDER BY [Forbidden Game Type] DESC,
		 [Item] ASC

--07. Buy Items for User in Game

DECLARE @Username VARCHAR(50) = 'Alex';
DECLARE @GameName VARCHAR(50) = 'Edinburgh';

DECLARE @UserGameId INT = (SELECT ug.Id
							FROM Users AS u
							JOIN UsersGames AS ug
								ON ug.UserId = u.Id
							JOIN Games AS g
								ON g.Id = ug.GameId
							WHERE u.Username = @Username AND
								  g.[Name] = @GameName);

DECLARE @AvailableCash DECIMAL(15, 4) = (SELECT Cash
										 FROM UsersGames
										 WHERE Id = @UserGameId);

DECLARE @PurchasePrice DECIMAL(15, 4) = (SELECT SUM(Price)
										 FROM Items
										 WHERE [Name] IN 
('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 
'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'));

IF (@AvailableCash  >= @PurchasePrice)
BEGIN
	BEGIN TRAN
		UPDATE UsersGames
			SET Cash -= @PurchasePrice
			WHERE Id = @UserGameId

		IF (@@ROWCOUNT <> 1)
			BEGIN
				ROLLBACK;
				RAISERROR('Could not make payment!', 16, 1);
				RETURN;
			END

		INSERT INTO UserGameItems (ItemId, UserGameId)
		(SELECT Id, @UserGameId
		 FROM Items
		 WHERE [Name] IN  
		('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
		'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'))

		IF ((SELECT COUNT(*) 
			 FROM Items
			 WHERE [Name] IN
		    ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
			'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet')) <> @@ROWCOUNT)
		BEGIN
			ROLLBACK;
			RAISERROR('Could not buy items!', 16, 2);
			RETURN;
		END
COMMIT
END

SELECT u.Username,
	   g.[Name],
	   ug.Cash,
	   i.[Name] AS [Item Name]
FROM Users AS u
JOIN UsersGames AS ug
	ON ug.UserId = u.Id
JOIN Games AS g
	ON g.Id = ug.GameId
JOIN UserGameItems AS ugi
	ON ugi.UserGameId = ug.Id
JOIN Items AS i
	ON i.Id = ugi.ItemId
WHERE g.[Name] = @GameName
ORDER BY i.[Name]

--08. Peaks and Mountains

SELECT p.PeakName,
	   m.MountainRange AS [Mountain],
	   p.Elevation
FROM Peaks AS p
JOIN Mountains AS m
	ON m.Id = p.MountainId
ORDER BY p.Elevation DESC,
		 p.PeakName ASC

--09. Peaks with Mountain, Country and Continent

SELECT p.PeakName,
	   m.MountainRange AS [Mountain], 
	   c.CountryName, 
	   cc.ContinentName
FROM Peaks AS p
JOIN Mountains AS m
	ON m.Id = p.MountainId
JOIN MountainsCountries AS mc
	ON mc.MountainId = m.Id
JOIN Countries AS c
	ON c.CountryCode = mc.CountryCode
JOIN Continents AS cc
	ON cc.ContinentCode = c.ContinentCode 
ORDER BY p.PeakName ASC,
		 c.CountryName ASC

--10. Rivers by Country

SELECT c.CountryName, 
	   cc.ContinentName,
	   COUNT(r.Id) AS [RiversCount],
	   ISNULL(SUM(r.[Length]), 0) AS [TotalLength]
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r
	ON r.Id = cr.RiverId
LEFT JOIN Continents AS cc
	ON cc.ContinentCode = c.ContinentCode
 GROUP BY c.CountryName, cc.ContinentName
 ORDER BY [RiversCount] DESC,
		  [TotalLength] DESC,
		  c.CountryName ASC

--11. Count of Countries by Currency

 SELECT cc.CurrencyCode,
		cc.[Description] AS [Currency],
		COUNT(c.CurrencyCode) AS [NumberOfCountries]
FROM Currencies AS cc
LEFT JOIN Countries AS c
		ON c.CurrencyCode = cc.CurrencyCode
GROUP BY cc.CurrencyCode, cc.[Description]
ORDER BY [NumberOfCountries] DESC,
		 [Description] ASC

--12. Population and Area by Continent

SELECT c.ContinentName,
	   SUM(cc.AreaInSqKm) AS [CountriesArea],
	   SUM(CAST(cc.[Population] AS FLOAT)) AS [CountriesPopulation]
FROM Continents AS c
LEFT JOIN Countries AS cc
	ON cc.ContinentCode = c.ContinentCode
GROUP BY c.ContinentName
ORDER BY [CountriesPopulation] DESC

--13. Monasteries by Country

CREATE TABLE Monasteries (
	Id INT IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	CountryCode CHAR(2) NOT NULL,

	CONSTRAINT PK_Monasteries
	PRIMARY KEY (Id),

	CONSTRAINT FK_Monasteries_Countries
	FOREIGN KEY (CountryCode)
	REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries ([Name], CountryCode) 
VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('S?mela Monastery', 'TR')

ALTER TABLE Countries
ADD IsDeleted BIT DEFAULT(0)

UPDATE Countries
	SET IsDeleted = 1
	WHERE CountryCode IN (SELECT r.Code
						 FROM
							  (SELECT c.CountryCode AS [Code],
									  COUNT(cr.RiverId) AS [RiversCount]
							  FROM Countries AS c
							  JOIN CountriesRivers AS cr
								 ON cr.CountryCode = c.CountryCode
							  GROUP BY c.CountryCode) AS r
						  WHERE r.RiversCount > 3)

SELECT m.[Name] AS [Monastery],
	   d.CountryName AS [Country]
FROM Monasteries AS m
JOIN (SELECT * 
	  FROM Countries
	  WHERE IsDeleted = 0) AS d
	  ON d.CountryCode = m.CountryCode
ORDER BY m.[Name]

--14. Monasteries by Continents and Countries

UPDATE Countries
	SET CountryName = 'Burma'
	WHERE CountryName = 'Myanmar' 

INSERT INTO Monasteries ([Name], CountryCode)
(SELECT 'Hanga Abbey', CountryCode
 FROM Countries
 WHERE CountryName = 'Tanzania')

 INSERT INTO Monasteries ([Name], CountryCode)
(SELECT 'Myin-Tin-Daik', CountryCode
 FROM Countries
 WHERE CountryName = 'Myanmar')

 SELECT c.ContinentName,
		cc.CountryName,
		COUNT(m.Id) AS [MonasteriesCount]
 FROM Continents AS c
 LEFT JOIN Countries AS cc
	ON cc.ContinentCode = c.ContinentCode
LEFT JOIN Monasteries AS m
	ON m.CountryCode = cc.CountryCode
WHERE cc.IsDeleted = 0
GROUP BY c.ContinentName, cc.CountryName
ORDER BY [MonasteriesCount] DESC,
		 cc.CountryName ASC