CREATE OR ALTER PROCEDURE autorization (@login varchar(100), @password varchar(100))
AS
BEGIN
	SELECT RoleUser.NameRole, Employee.TableNumber 
	FROM RoleUser, UserData, Employee
	WHERE UserData.LoginUser = @login 
	AND UserData.PasswordUser = @password 
	AND  UserData.FK_Role = RoleUser.Id 
	AND Employee.FK_UserData = UserData.Id
	RETURN;
END;
GO




