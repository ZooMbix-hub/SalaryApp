CREATE OR ALTER PROCEDURE DeleteAward (@NameAward varchar(100))
AS
BEGIN
	
		DELETE Type�fAward
		WHERE Type�fAward.NameAward = @NameAward
	
END;
GO