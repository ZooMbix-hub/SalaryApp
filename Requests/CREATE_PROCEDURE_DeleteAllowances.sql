CREATE OR ALTER PROCEDURE DeleteAllowances (@NameAllowances varchar(100))
AS
BEGIN
	
		DELETE Type�fAllowances
		WHERE Type�fAllowances.NameAllowances = @NameAllowances
	
END;
GO