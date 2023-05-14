CREATE OR ALTER PROCEDURE DeleteCompany (@NameCompany varchar(100))
AS
BEGIN
	
		DELETE Company
		WHERE Company.NameCompany = @NameCompany
	
END;
GO