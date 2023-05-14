CREATE OR ALTER PROCEDURE tableView (@table_number INT)
AS
BEGIN
	SELECT 
	Employee.FullName, Employee.WorkExperience, Employee.ProfLevel, Employee.IsUnion,
	Post.NamePost, Post.Salary, Post.WorkingDays, Subdivision.NameSub, 
	Company.NameCompany, Company.Telephone, Company.AddressCompany,Region.Coeff
	FROM Employee, Post, Subdivision, Company, Region
	WHERE Employee.TableNumber = @table_number
	AND Employee.FK_Post = Post.Id
	AND Post.FK_Sub = Subdivision.Id
	AND Employee.FK_Company = Company.Id
	AND Company.FK_Region = Region.Id
	RETURN;
END;
GO

