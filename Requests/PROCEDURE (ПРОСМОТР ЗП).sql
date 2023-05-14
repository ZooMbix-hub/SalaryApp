CREATE OR ALTER PROCEDURE salaryView (@date DATE, @table_number INT)
AS
BEGIN
	SELECT 
	Employee.FullName, Employee.WorkExperience, Employee.ProfLevel, Employee.IsUnion,
	Post.NamePost, Post.Salary, Post.WorkingDays, Subdivision.NameSub, 
	Company.NameCompany, Company.Telephone, Company.AddressCompany,Region.Coeff, 
	TimeSheet.NumberDaysWorked, TimeSheet.NumberNightWorked, TimeSheet.NumberRVD, TimeSheet.PaymentNight, TimeSheet.PaymentRVD, TimeSheet.Surcharge, 
	Payment.TotalAccrued, Payment.UnionDues, Payment.NDFL, Payment.TotalWithheld, Payment.TotalPaid
	FROM Employee, Post, Subdivision, Company, Region, TimeSheet, Payment
	WHERE Employee.TableNumber = @table_number
	AND Employee.FK_Post = Post.Id
	AND Post.FK_Sub = Subdivision.Id
	AND Employee.FK_Company = Company.Id
	AND Company.FK_Region = Region.Id
	AND TimeSheet.FK_TableNumber = @table_number
	AND TimeSheet.DateTimeSheet = @date
	AND Payment.FK_TableList = TimeSheet.Id
	RETURN;
END;
GO

GO
CREATE OR ALTER PROCEDURE madicalView (@date DATE, @table_number INT)
AS
BEGIN
	SELECT Medical.CalcMedical
	FROM TimeSheet, Payment, Medical
	WHERE Payment.FK_TableList = TimeSheet.Id
	AND Payment.FK_Medical = Medical.Id
	AND TimeSheet.FK_TableNumber = @table_number
	RETURN;
END;
GO

GO
CREATE OR ALTER PROCEDURE vacationView (@date DATE, @table_number INT)
AS
BEGIN
	SELECT Vacation.CalcVacation
	FROM TimeSheet, Payment, Vacation
	WHERE Payment.FK_TableList = TimeSheet.Id
	AND Payment.FK_Vacation = Vacation.Id
	AND TimeSheet.FK_TableNumber = @table_number
	RETURN;
END;
GO

GO
CREATE OR ALTER PROCEDURE allowancesView (@date DATE, @table_number INT)
AS
BEGIN
	SELECT TypeÎfAllowances.NameAllowances, TypeÎfAllowances.Cost
	FROM TimeSheet, Payment, TypeÎfAllowances
	WHERE Payment.FK_TableList = TimeSheet.Id
	AND Payment.FK_Allowances = TypeÎfAllowances.Id
	AND TimeSheet.FK_TableNumber = @table_number
	RETURN;
END;
GO

GO
CREATE OR ALTER PROCEDURE awardView (@date DATE, @table_number INT)
AS
BEGIN
	
	SELECT TypeÎfAward.NameAward, TypeÎfAward.Cost
	FROM TimeSheet, Payment, TypeÎfAward
	WHERE Payment.FK_TableList = TimeSheet.Id
	AND Payment.FK_Award = TypeÎfAward.Id
	AND TimeSheet.FK_TableNumber = @table_number
	RETURN;
END;
GO
