CREATE OR ALTER PROCEDURE timesheet_entry (@table_number INT, @date DATE, @number_days_worked INT, @number_night_worked INT, @number_RVD INT)
AS
BEGIN
	INSERT TimeSheet (FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) 
	VALUES (@table_number, @date, @number_days_worked, @number_night_worked, @number_RVD);
END;
GO

