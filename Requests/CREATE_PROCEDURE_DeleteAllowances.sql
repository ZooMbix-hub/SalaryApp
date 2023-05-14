CREATE OR ALTER PROCEDURE DeleteAllowances (@NameAllowances varchar(100))
AS
BEGIN
	
		DELETE TypeÎfAllowances
		WHERE TypeÎfAllowances.NameAllowances = @NameAllowances
	
END;
GO