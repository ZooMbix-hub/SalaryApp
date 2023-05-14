CREATE OR ALTER PROCEDURE DeleteAward (@NameAward varchar(100))
AS
BEGIN
	
		DELETE TypeÎfAward
		WHERE TypeÎfAward.NameAward = @NameAward
	
END;
GO