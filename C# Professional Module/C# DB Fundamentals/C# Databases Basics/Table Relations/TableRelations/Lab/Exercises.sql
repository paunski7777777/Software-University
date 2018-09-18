--01. One-To-One Relationship
CREATE TABLE Persons (
	PersonID INT IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(15, 2),
	PassportID INT UNIQUE NOT NULL,

	CONSTRAINT PK_Persons
	PRIMARY KEY (PersonID),
)

CREATE TABLE Passports (
	PassportID INT UNIQUE NOT NULL,
	PassportNumber NVARCHAR(50) UNIQUE NOT NULL,

	CONSTRAINT PK_Passports
	PRIMARY KEY (PassportID),
)

INSERT INTO Persons
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

INSERT INTO Passports
VALUES 
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2') 

ALTER TABLE Persons
ADD CONSTRAINT
FK_Persons_Passports
FOREIGN KEY (PassportID)
REFERENCES Passports(PassportID)

--02. One-To-Many Relationship
CREATE TABLE Models (
	ModelID INT NOT NULL,
	[Name] NVARCHAR(32) NOT NULL,
	ManufacturerID INT NOT NULL,

	CONSTRAINT PK_Models
	PRIMARY KEY (ModelID)
)

CREATE TABLE Manufacturers (
	ManufacturerID INT IDENTITY NOT NULL,
	[Name] NVARCHAR(32) NOT NULL,
	EstablishedOn DATE NOT NULL,

	CONSTRAINT PK_Manufacturers
	PRIMARY KEY (ManufacturerID)
)

INSERT INTO Manufacturers
VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO Models
VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

ALTER TABLE Models
ADD CONSTRAINT
FK_Models_Manufacturers
FOREIGN KEY (ManufacturerID) 
REFERENCES Manufacturers(ManufacturerID)

--03. Many-To-Many Relationship
CREATE TABLE Students (
	StudentID INT IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,

	CONSTRAINT PK_Students
	PRIMARY KEY (StudentID)
)

INSERT INTO Students
VALUES
('Mila'),
('Toni'),
('Ron')

CREATE TABLE Exams (
	ExamID INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,

	CONSTRAINT PK_Exams
	PRIMARY KEY (ExamID)
)

INSERT INTO Exams
VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

CREATE TABLE StudentsExams (
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,

	CONSTRAINT PK_StudentsExams
	PRIMARY KEY (StudentID, ExamID),

	CONSTRAINT FK_StudentsExams_Students
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),

	CONSTRAINT FK_StudentsExams_Exams
	FOREIGN KEY (ExamID)
	REFERENCES Exams(ExamID)
)

INSERT INTO StudentsExams
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--04. Self-Referencing
CREATE TABLE Teachers (
	TeacherID INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	ManagerID INT,

	CONSTRAINT PK_Teachers
	PRIMARY KEY (TeacherID),

	CONSTRAINT FK_Teachers
	FOREIGN KEY (ManagerID)
	REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)

--05. Online Store Database
CREATE DATABASE OnlineStore

USE OnlineStore

CREATE TABLE Cities (
	CityID INT IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,

	CONSTRAINT PK_Cities
	PRIMARY KEY (CityID)
)

CREATE TABLE Customers (
	CustomerID INT IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT NOT NULL,

	CONSTRAINT PK_Customers
	PRIMARY KEY (CustomerID),

	CONSTRAINT FK_Customers_Cities
	FOREIGN KEY (CityID)
	REFERENCES Cities(CityID)
)

CREATE TABLE Orders (
	OrderID INT IDENTITY NOT NULL,
	CustomerID INT NOT NULL,

	CONSTRAINT PK_Orders
	PRIMARY KEY (OrderID),

	CONSTRAINT FK_Orders_Customers
	FOREIGN KEY (CustomerID)
	REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes (
	ItemTypeID INT IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,

	CONSTRAINT PK_ItemTypes
	PRIMARY KEY (ItemTypeID)
)

CREATE TABLE Items (
	ItemID INT IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT NOT NULL,

	CONSTRAINT PK_Items
	PRIMARY KEY (ItemID),

	CONSTRAINT FK_Items_ItemTypes
	FOREIGN KEY (ItemTypeID)
	REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems (
	OrderID INT NOT NULL,
	ItemID INT NOT NULL,

	CONSTRAINT PK_OrderItems
	PRIMARY KEY (OrderID, ItemID),

	CONSTRAINT FK_OrderItems_Orders
	FOREIGN KEY (OrderID)
	REFERENCES Orders(OrderID),

	CONSTRAINT FK_OrderItems_Items
	FOREIGN KEY (ItemID)
	REFERENCES Items(ItemID)
)

--06. University Database
CREATE DATABASE University

USE University

CREATE TABLE Majors (
	MajorID INT IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,

	CONSTRAINT PK_Majors
	PRIMARY KEY (MajorID)
)

CREATE TABLE Students (
	StudentID INT IDENTITY NOT NULL,
	StudentNumber INT UNIQUE NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT NOT NULL,

	CONSTRAINT PK_Students
	PRIMARY KEY (StudentID),

	CONSTRAINT FK_Students_Majors
	FOREIGN KEY (MajorID)
	REFERENCES Majors(MajorID)
)

CREATE TABLE Subjects (
	SubjectID INT IDENTITY NOT NULL,
	SubjectName NVARCHAR(50) NOT NULL,

	CONSTRAINT PK_Subjects
	PRIMARY KEY (SubjectID)
)

CREATE TABLE Agenda (
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL,

	CONSTRAINT PK_Agenda
	PRIMARY KEY (StudentID, SubjectID),

	CONSTRAINT FK_Agenda_Students
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),

	CONSTRAINT FK_Agenda_Subjects
	FOREIGN KEY (SubjectID)
	REFERENCES Subjects(SubjectID)
)

CREATE TABLE Payments (
	PaymentID INT IDENTITY NOT NULL,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(15, 2) NOT NULL,
	StudentID INT NOT NULL,

	CONSTRAINT PK_Payments
	PRIMARY KEY (PaymentID),

	CONSTRAINT FK_Payments_Students
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID)
)

--09. *Peaks in Rila
SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks AS p
ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC