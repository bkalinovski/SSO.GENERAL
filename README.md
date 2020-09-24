# SSO.GENERAL
Authentication Microservice

--=================== Users ===================
CREATE TABLE Users(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Age INT,
	Phone VARCHAR(12),
	Username VARCHAR(20),
	Password VARCHAR(MAX)
);

INSERT INTO Users(FirstName, LastName, Age, Phone, Username, Password)
VALUES ('Bogdan', 'Kalinovski', 22, '+37369381472', 'bogdan', '1234'),
	   ('Test', 'User', NULL, NULL, 'test', 'test');

SELECT
	*
FROM Users;
--=================== Users ===================

--=================== Roles ===================
CREATE TABLE Roles(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL
);

INSERT INTO Roles(Name)
VALUES ('Admin'),
	   ('Manager'),
	   ('Developer');

SELECT
	*
FROM Roles;
--=================== Roles ===================

--=================== UserRoles ===================
CREATE TABLE UserRoles(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	UserId INT NOT NULL,
	RoleId INT NOT NULL,
	InsertDate DATETIME NOT NULL DEFAULT GETDATE(),
	DueDate DATETIME NULL DEFAULT NULL,
	FOREIGN KEY(UserId) REFERENCES Users(Id),
	FOREIGN KEY(RoleId) REFERENCES Roles(Id)
);

INSERT INTO UserRoles(UserId, RoleId, DueDate)
VALUES (1, 1, NULL),
	   (1, 3, NULL),
	   (2, 2, NULL);

SELECT
	*
FROM UserRoles;
--=================== UserRoles ===================

--=================== SELECT Roles by UserId ===================
SELECT
	R.Name
FROM Users AS U
INNER JOIN UserRoles AS UR ON UR.UserId = U.Id
INNER JOIN Roles AS R ON R.Id = UR.RoleId
WHERE U.Id = 1;
--=================== SELECT Roles by UserId ===================

"JWTOptions:ValidIssuer": "bk-authority",
"JWTOptions:IssuerSigningKeyString": "superImportantKey#98",
"ConnectionStrings:AuthDBContext": "Data Source=localhost,1433;Initial Catalog=SSO;User ID=SA;Password=PASSWORD98;"