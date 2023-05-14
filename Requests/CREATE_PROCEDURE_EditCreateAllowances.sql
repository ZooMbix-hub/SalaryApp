CREATE OR ALTER PROCEDURE EditCreateAllowances (@NameAllowances varchar(100), @Cost varchar(100))
AS
DECLARE @NullAllowances varchar(100);
BEGIN
	
	  Select @NullAllowances = Type�fAllowances.NameAllowances FROM Type�fAllowances WHERE NameAllowances = @NameAllowances


	  If (@NullAllowances is null OR @NullAllowances = '')
	  INSERT Type�fAllowances(NameAllowances, Cost) VALUES (@NameAllowances, @Cost);
	  else
	  UPDATE Type�fAllowances
	  SET Cost = @Cost
	  WHERE NameAllowances = @NameAllowances

END;
GO