CREATE OR ALTER PROCEDURE EditTimeSheet (@tableNumber INT, @date Date, @days INT, @night INT, @RVD INT)
AS
BEGIN
	UPDATE TimeSheet
	SET NumberDaysWorked = @days,
	NumberNightWorked = @night,
	NumberRVD = @RVD
	WHERE FK_TableNumber = @tableNumber AND DateTimeSheet = @date
END;
GO