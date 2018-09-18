CREATE DATABASE Hotel

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(200)
)

INSERT INTO Employees VALUES
('Pesho', 'Peshov', NULL, NULL),
('Gosho', 'Goshov', 'guba', NULL),
('Toncho', 'Poncho' , NULL, 'nesh')

CREATE TABLE Customers (
	AccountNumber INT UNIQUE NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber INT NOT NULL,
	EmergencyName NVARCHAR(50),
	EmergencyNumber INT,
	Notes NVARCHAR(200)
)

INSERT INTO Customers VALUES
(7635, 'Maiki', 'Lqkov', 3253456, NULL, NULL, NULL),
(7673, 'Besniq', 'Gogo', 7436722, NULL, NULL, NULL),
(1234, 'Ogi', 'Ogov', 9888844, NULL, NULL, NULL)

CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(150)
)

INSERT INTO RoomStatus VALUES
('available', NULL),
('busy', NULL),
('occupied', NULL)

CREATE TABLE RoomTypes (
	RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(150)
)

INSERT INTO RoomTypes VALUES
('suite', NULL),
('studio', NULL),
('apartment', NULL)

CREATE TABLE BedTypes (
	BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(150)
)

INSERT INTO BedTypes VALUES
('solo', NULL),
('duo', NULL),
('trio', NULL)

CREATE TABLE Rooms (
	RoomNumber INT UNIQUE NOT NULL,
	RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate INT NOT NULL,
	RoomStatus NVARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NVARCHAR(150)
)

INSERT INTO Rooms
VALUES
(777, 'suite', 'trio', 10, 'available', NULL),
(20,'studio', 'solo', 5, 'busy', NULL),
(435, 'apartment', 'duo', 7, 'occupied', NULL)

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL(15, 2) NOT NULL,
	TaxRate DECIMAL(15, 2),
	TaxAmount DECIMAL(15, 2),
	PaymentTotal DECIMAL(15, 2),
	Notes NVARCHAR(150)
)

INSERT INTO Payments VALUES
(1, '2018-07-25', 7635, '2018-08-01', '2018-08-20', 100, NULL, NULL, 3500, NULL),
(2, '2018-08-15', 7673, '2018-08-02', '2018-08-22', 200, NULL, NULL, 7500, NULL),
(3, '2018-07-30', 1234, '2018-08-03', '2018-08-23', 300, NULL, NULL, 10000, NULL)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL(15, 2),
	PhoneCharge DECIMAL(15, 2),
	Notes NVARCHAR(150)
)

INSERT INTO Occupancies VALUES
(1, '2018-08-01', 7635, 777, NULL, NULL, NULL),
(2, '2018-08-02', 7673, 20, NULL, NULL, NULL),
(3, '2018-08-03', 1234, 435, NULL, NULL, NULL)

UPDATE Payments
SET TaxRate -= TaxRate * 3 / 100
SELECT TaxRate FROM Payments

TRUNCATE TABLE Occupancies