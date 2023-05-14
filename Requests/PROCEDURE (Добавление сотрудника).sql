CREATE OR ALTER PROCEDURE employeeEntry (@TableNumber INT, @fullName VARCHAR(100), @WorkExperience INT,
@ProfLevel INT, @IsUnion BIT, @NameCompany VARCHAR(100), @NamePost VARCHAR(100), @Login VARCHAR(100), 
@Password VARCHAR(100), @Role VARCHAR(100), @DateOfBirth Date, @AddressEmployee VARCHAR(100), 
@Telephone VARCHAR(100), @Education VARCHAR(100), @INN VARCHAR(100), @PassportData VARCHAR(100), 
@Requisites VARCHAR(100), @Snils VARCHAR(100))
AS
DECLARE @id_role INT;
DECLARE @id_user INT;
DECLARE @id_post INT;
DECLARE @id_company INT;
BEGIN
	SELECT @id_role = RoleUser.Id FROM RoleUser WHERE RoleUser.NameRole = @Role

	INSERT UserData (LoginUser, PasswordUser, FK_Role) 
	VALUES (@Login, @Password, @id_role);

	SELECT @id_user = UserData.Id FROM UserData WHERE UserData.LoginUser = @Login AND UserData.PasswordUser = @Password

	SELECT @id_post = Post.Id FROM Post WHERE Post.NamePost = @NamePost
	SELECT @id_company = Company.Id FROM Company WHERE Company.NameCompany = @NameCompany

	INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) 
	VALUES (@TableNumber, @fullName, @WorkExperience, @ProfLevel, @IsUnion, @id_company, @id_post, @id_user);

	INSERT PersonalData (DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) 
	VALUES (@DateOfBirth, @AddressEmployee, @Telephone, @Education, @INN, @PassportData, @Requisites, @Snils, @TableNumber);


END;
GO

