CREATE OR ALTER PROCEDURE EditCreateAllowances (@NameAllowances varchar(100), @Cost varchar(100))
AS
DECLARE @NullAllowances varchar(100);
BEGIN
	
	  Select @NullAllowances = TypeÎfAllowances.NameAllowances FROM TypeÎfAllowances WHERE NameAllowances = @NameAllowances


	  If (@NullAllowances is null OR @NullAllowances = '')
	  INSERT TypeÎfAllowances(NameAllowances, Cost) VALUES (@NameAllowances, @Cost);
	  else
	  UPDATE TypeÎfAllowances
	  SET Cost = @Cost
	  WHERE NameAllowances = @NameAllowances

END;
GO