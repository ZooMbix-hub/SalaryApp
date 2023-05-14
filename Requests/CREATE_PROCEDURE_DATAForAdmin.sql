CREATE OR ALTER PROCEDURE DataForAdmin (@table_number INT)
AS
BEGIN
	SELECT 
	PersonalData.DateOfBirth, PersonalData.AddressEmployee, PersonalData.Telephone, PersonalData.Education, PersonalData.INN,
	PersonalData.PassportData, PersonalData.Requisites, PersonalData.Snils, Employee.TableNumber, Employee.FullName, Employee.WorkExperience,
	Employee.ProfLevel, Employee.IsUnion, Company.NameCompany,Company.INN, Post.NamePost, Subdivision.NameSub, UserData.LoginUser, UserData.PasswordUser
	FROM PersonalData, Employee, Company, Post, Subdivision, UserData
	WHERE Employee.TableNumber = @table_number
	AND Employee.FK_Post = Post.Id
	AND Post.FK_Sub = Subdivision.Id
	AND Employee.FK_Company = Company.Id
	AND PersonalData.FK_TableNumber = Employee.TableNumber
	AND Employee.FK_UserData = UserData.Id
	RETURN
END;
GO



