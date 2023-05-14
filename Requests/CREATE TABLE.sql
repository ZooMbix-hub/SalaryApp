CREATE TABLE Employee (
	TableNumber INT PRIMARY KEY NOT NULL,
	FullName VARCHAR(100) NOT NULL,
	WorkExperience INT NOT NULL,
	ProfLevel INT NOT NULL,
	IsUnion BIT NOT NULL,
	FK_Company INT NOT NULL,
	FK_Post INT NOT NULL,
	FK_UserData INT NOT NULL
);
CREATE TABLE PersonalData (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DateOfBirth Date NOT NULL,
	AddressEmployee VARCHAR(100) NOT NULL,
	Telephone VARCHAR(100) NOT NULL,
	Education VARCHAR(100) NOT NULL,
	INN VARCHAR(100) NOT NULL,
	PassportData VARCHAR(100) NOT NULL,
	Requisites VARCHAR(100) NOT NULL,
	Snils VARCHAR(100) NOT NULL,
	FK_TableNumber INT NOT NULL
);
CREATE TABLE UserData (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	LoginUser VARCHAR(100) NOT NULL,
	PasswordUser VARCHAR(100) NOT NULL,
	FK_Role INT NOT NULL
);
CREATE TABLE RoleUser (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	NameRole VARCHAR(100) NOT NULL
);
CREATE TABLE Vacation (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	StartDate Date NOT NULL,
	EndDate Date NOT NULL,
	FK_TableNumber INT NOT NULL,
	CalcVacation MONEY 
);
CREATE TABLE Medical (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	StartDate Date NOT NULL,
	EndDate Date NOT NULL,
	FK_TableNumber INT NOT NULL,
	CalcMedical MONEY
);
CREATE TABLE Post (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	NamePost VARCHAR(100) NOT NULL,
	Salary MONEY NOT NULL,
	WorkingDays INT NOT NULL,
	FK_Sub INT NOT NULL
);
CREATE TABLE Subdivision (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	NameSub VARCHAR(100) NOT NULL,
	FK_Type INT NOT NULL
);
CREATE TABLE TypeSubdivision (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	NameType VARCHAR(100) NOT NULL
);
CREATE TABLE Company (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	NameCompany VARCHAR(100) NOT NULL,
	Telephone VARCHAR(100) NOT NULL,
	INN VARCHAR(100) NOT NULL,
	AddressCompany VARCHAR(100) NOT NULL,
	FK_Region INT NOT NULL
);
CREATE TABLE Region (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	NameRegion VARCHAR(100) NOT NULL,
	Coeff DECIMAL(2,1) NOT NULL
);
CREATE TABLE TimeSheet (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FK_TableNumber INT NOT NULL,
	DateTimeSheet DATE NOT NULL,
	NumberDaysWorked INT NOT NULL,
	NumberNightWorked INT NOT NULL,
	NumberRVD INT NOT NULL,
);

CREATE TABLE Payment (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FK_TableNumber INT NOT NULL,
	FK_TableList INT NOT NULL,
	FK_Medical INT,
	FK_Vacation INT,
	FK_Award INT,
	FK_Allowances INT,
	TotalAccrued MONEY,
	UnionDues MONEY
);
CREATE TABLE Type�fAward (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	NameAward VARCHAR(100) NOT NULL,
	Cost MONEY NOT NULL
);
CREATE TABLE Type�fAllowances (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	NameAllowances VARCHAR(100) NOT NULL,
	Cost MONEY NOT NULL
);

