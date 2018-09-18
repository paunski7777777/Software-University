CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] BINARY(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users VALUES
('Stamat', HASHBYTES('SHA1', '123'), NULL, CONVERT(datetime2,'22-05-2018', 103), 1),
('Gosho', HASHBYTES('SHA1', '3254345'), NULL, CONVERT(datetime2,'03-12-2018', 103), 0),
('Pesho', HASHBYTES('SHA1', '345334'), NULL, CONVERT(datetime2,'15-10-2018', 103), 0),
('Vankata', HASHBYTES('SHA1', '23425'), NULL, CONVERT(datetime2,'06-01-2018', 103), 1),
('Kircata', HASHBYTES('SHA1', '23524'), NULL, CONVERT(datetime2,'30-08-2018', 103), 0)

ALTER TABLE Users
ADD CONSTRAINT CHK_ProfilePicture CHECK (DATALENGTH(ProfilePicture) <= 900 * 1024)

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07032A7026

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users  (Username, [Password], ProfilePicture, IsDeleted)
VALUES
('Ceco', HASHBYTES('SHA1', 'dhdhdfhg'), NULL, 0)

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameLength CHECK (LEN(Username) >= 3)

INSERT INTO Users  (Username, [Password], ProfilePicture, IsDeleted)
VALUES
('ab', HASHBYTES('SHA1', '345dfg'), NULL, 0)

