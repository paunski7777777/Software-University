CREATE DATABASE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(15, 2),
	WeeklyRate DECIMAL(15, 2),
	MonthlyRate DECIMAL(15, 2),
	WeekendRate DECIMAL(15, 2)
)

INSERT INTO Categories VALUES
('Family', 3.48, 250, 400, 100),
('Duo', 3.80, 280, 430, 120),
('Solo', 4.00, 300, 460, 140)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(50) UNIQUE NOT NULL,
	Manufacturer VARCHAR(50) NOT NULL,
	Model VARCHAR(50) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT NOT NULL,
	Picture IMAGE,
	Condition NVARCHAR(100),
	Available BIT NOT NULL
)

INSERT INTO Cars
VALUES
('CB 1234 AA', 'Mercedes-Benz', 'S500', 2018, 1, 4, NULL, 'Perfect', 0),
('CB 777777', 'Audi', 'S8', 2017, 2, 4, NULL, 'Stunning', 1),
('CB 5555 BB', 'BMW', 'M4', 2016, 3, 2, NULL, 'Extreme', 0)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(200)
)

INSERT INTO Employees
VALUES
('Pesho', 'Peshov', 'Ogromen', NULL),
('Gosho', 'Goshov', 'Guba', NULL),
('Chochi', 'Chocheva', 'Maimuna', 'ma verno')

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT UNIQUE NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(200) NOT NULL,
	City VARCHAR(50) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Customers
VALUES
('123234', 'Petrak Michov', 'kv. Luxozenec', 'Sofia', 1407, 'ogromen'),
('325345', 'Chicho Vanio', 'kv. Glarus', 'Burgas', 1650, NULL),
('456464', 'Tinka Minka', 'kv. Maina', 'Plovdiv', 1100, NULL)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel DECIMAL(15, 2) NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage AS (KilometrageEnd - KilometrageStart),
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied DECIMAL(15, 2),
	TaxRate DECIMAL(15, 2),
	OrderStatus VARCHAR(50),
	Notes NVARCHAR(200)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart,KilometrageEnd,
StartDate, EndDate)
VALUES
(1, 1, 1, 70, 2, 100, '2018-11-05', '2018-11-06'),
(2, 2, 2, 50, 0, 50, '2018-01-06', '2018-01-10'),
(3, 3, 3, 45, 10, 35, '2018-10-10', '2018-10-21')