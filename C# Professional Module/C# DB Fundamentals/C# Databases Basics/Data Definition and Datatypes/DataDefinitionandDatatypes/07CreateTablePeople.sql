CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture IMAGE,
	Height DECIMAL(15, 2),
	[Weight] DECIMAL(15, 2),
	Gender CHAR(1) CHECK (Gender = 'm' OR Gender = 'f') NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Pesho Peshov', NULL, 1.85, 85, 'm', '1997-01-02', 'ogromen'),
('Ivan Ivanov', NULL, 1.75, 75, 'm', '1999-11-05', 'guba'),
('Gosho Goshov', NULL, 1.92, 100, 'm', '1995-07-07', 'riba'),
('Ceca Cecova', NULL, 1.62, 48, 'f', '1996-10-25', 'gnida'),
('Macinka Cacinkova', NULL, 1.60, 44, 'f', '1994-08-12', 'caca')