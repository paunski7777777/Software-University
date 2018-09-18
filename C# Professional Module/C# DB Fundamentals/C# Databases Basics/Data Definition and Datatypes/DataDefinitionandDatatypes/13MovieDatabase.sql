CREATE DATABASE Movies

CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATE NOT NULL,
	[Length] INT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating INT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName, Notes)
VALUES
('Pesho', NULL),
('Gosho', 'velik gosho'),
('Ceco', 'velik ceco'),
('Vanio', NULL),
('Tosho', 'velik tosho')

INSERT INTO Genres (GenreName, Notes)
VALUES
('ekshun', 'qko'),
('drama', 'nqma'),
('komediq', NULL),
('ujas', 'verno ujas'),
('boza', 'e nema takava boza')

INSERT INTO Categories (CategoryName, Notes)
VALUES
('losha', NULL),
('dobra', 'dobra'),
('typa', NULL),
('staa', NULL),
('got', 'ye')

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES
('vodopadi', 1, CONVERT(datetime2,'11-05-2018', 103), 120, 3, 2, 9, NULL),
('chochinki', 2, CONVERT(datetime2,'03-12-2012', 103), 100, 1, 5, 10, 'qko'),
('palachinki', 3, CONVERT(datetime2,'30-07-2015', 103), 130, 2, 5, 7, NULL),
('semki pred ndk', 4, CONVERT(datetime2,'15-09-2010', 103), 200, 4, 5, 6, 'skuchno'),
('oligofreni', 5, CONVERT(datetime2,'07-04-2017', 103), 140, 1, 3, 8, NULL)