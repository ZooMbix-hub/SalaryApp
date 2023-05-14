CREATE OR ALTER PROCEDURE EditCreateAward (@NameAward varchar(100), @Cost varchar(100))
AS
DECLARE @NullAward varchar(100);
BEGIN
	
	  Select @NullAward = TypeÎfAward.NameAward FROM TypeÎfAward WHERE TypeÎfAward.NameAward = @NameAward


	  If (@NullAward is null OR @NullAward = '')
	  INSERT TypeÎfAward(NameAward, Cost) VALUES (@NameAward, @Cost);
	  else
	  UPDATE TypeÎfAward
	  SET Cost = @Cost
	  WHERE NameAward = @NameAward

END;
GO