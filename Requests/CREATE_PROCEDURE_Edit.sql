CREATE OR ALTER PROCEDURE Edit (@DateOfBirth DATE, @AddressEmployee VARCHAR(100), @Telephone VARCHAR(100), @Education VARCHAR(100), @INN VARCHAR(100),
	@PassportData VARCHAR(100), @Requisites VARCHAR(100), @Snils VARCHAR(100), @TableNumber INT, @FullName VARCHAR(100), @WorkExperience VARCHAR(100),
	@ProfLevel VARCHAR(100), @IsUnion BIT, @NameCompany VARCHAR(100), @NamePost VARCHAR(100), @LoginUser VARCHAR(100), @PasswordUser VARCHAR(100))
AS
BEGIN
	
	UPDATE PersonalData
	SET DateOfBirth = @DateOfBirth, 
	AddressEmployee = @AddressEmployee,
	Telephone = @Telephone,
	Education = @Education,
	INN = @INN,
	PassportData = @PassportData,
	Requisites = @Requisites,
	Snils = @Snils
	WHERE FK_TableNumber = @TableNumber
	
	UPDATE Employee
	SET FullName = @FullName,
	WorkExperience = @WorkExperience,
	ProfLevel = @ProfLevel,
	IsUnion = @IsUnion,
	FK_Company = (Select Company.Id FROM Company WHERE Company.NameCompany = @NameCompany),
	FK_Post = (Select Post.Id FROM Post WHERE Post.NamePost = @NamePost)
	WHERE TableNumber = @TableNumber

	UPDATE UserData
	SET LoginUser = @LoginUser,
	PasswordUser = @PasswordUser
	WHERE UserData.Id = (Select Employee.FK_UserData FROM Employee WHERE Employee.TableNumber = @TableNumber)

END;
GO
