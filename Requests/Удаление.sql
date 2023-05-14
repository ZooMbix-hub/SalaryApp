CREATE OR ALTER PROCEDURE timeSheetDelete (@table_number INT, @date Date)
AS
DECLARE @id_timeSheet INT;
BEGIN
	SELECT @id_timeSheet = TimeSheet.Id FROM TimeSheet WHERE TimeSheet.FK_TableNumber = @table_number AND TimeSheet.DateTimeSheet = @date
	DELETE Payment
	WHERE Payment.FK_TableNumber = @table_number
	AND Payment.FK_TableList = @id_timeSheet
	DELETE TimeSheet
	WHERE FK_TableNumber = @table_number AND DateTimeSheet = @date
	
END;
GO
