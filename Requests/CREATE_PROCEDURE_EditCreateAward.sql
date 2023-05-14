CREATE OR ALTER PROCEDURE EditCreateAward (@NameAward varchar(100), @Cost varchar(100))
AS
DECLARE @NullAward varchar(100);
BEGIN
	
	  Select @NullAward = Type�fAward.NameAward FROM Type�fAward WHERE Type�fAward.NameAward = @NameAward


	  If (@NullAward is null OR @NullAward = '')
	  INSERT Type�fAward(NameAward, Cost) VALUES (@NameAward, @Cost);
	  else
	  UPDATE Type�fAward
	  SET Cost = @Cost
	  WHERE NameAward = @NameAward

END;
GO