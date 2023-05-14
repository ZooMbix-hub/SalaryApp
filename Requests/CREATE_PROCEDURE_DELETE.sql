CREATE OR ALTER PROCEDURE Delet ( @table_number INT, @login_user varchar(100), @password_user varchar(100))
AS
BEGIN
	
	DELETE Payment
	WHERE Payment.FK_TableNumber = @table_number
	DELETE Medical
	WHERE Medical.FK_TableNumber = @table_number
	DELETE Vacation
	WHERE Vacation.FK_TableNumber = @table_number
	DELETE PersonalData 
	WHERE PersonalData.FK_TableNumber = @table_number
	DELETE TimeSheet
	WHERE TimeSheet.FK_TableNumber = @table_number
	DELETE Employee
	WHERE Employee.TableNumber = @table_number
	DELETE UserData
	WHERE UserData.LoginUser = @login_user 
	AND UserData.PasswordUser = @password_user
END;
GO
