CREATE OR ALTER PROCEDURE payment_entry 
(@table_number INT, @date DATE,  @startdate_vacation DATE, @enddate_vacation DATE, @startdate_medical DATE, @enddate_medical DATE,
@name_award VARCHAR(100), @name_allowances VARCHAR(100))
AS
DECLARE @id_medical INT;
DECLARE @id_vacation INT;
DECLARE @id_timesheet INT;
DECLARE @id_award INT;
DECLARE @id_allowances INT;
BEGIN
	IF @startdate_medical IS NOT NULL AND @enddate_medical IS NOT NULL
		INSERT Medical (StartDate, EndDate, FK_TableNumber) VALUES (@startdate_medical, @enddate_medical, @table_number);

		SELECT @id_medical = Medical.Id FROM Medical 
		WHERE Medical.StartDate = @startdate_medical AND Medical.EndDate = @enddate_medical AND Medical.FK_TableNumber = @table_number

	IF @startdate_vacation IS NOT NULL AND @startdate_vacation IS NOT NULL
		INSERT Vacation (StartDate, EndDate, FK_TableNumber) VALUES (@startdate_vacation, @enddate_vacation, @table_number);

		SELECT @id_vacation = Vacation.Id FROM Vacation
		WHERE Vacation.StartDate = @startdate_vacation AND Vacation.EndDate = @enddate_vacation AND Vacation.FK_TableNumber = @table_number

	SELECT @id_timesheet = TimeSheet.Id FROM TimeSheet 
	WHERE TimeSheet.FK_TableNumber = @table_number AND TimeSheet.DateTimeSheet = @date 

	IF @name_award IS NOT NULL 
		SELECT @id_award = TypeÎfAward.Id FROM TypeÎfAward 
		WHERE TypeÎfAward.NameAward = @name_award 

	IF @name_allowances IS NOT NULL 
		SELECT @id_allowances = TypeÎfAllowances.Id FROM TypeÎfAllowances 
		WHERE TypeÎfAllowances.NameAllowances = @name_allowances 

	INSERT Payment (FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) 
	VALUES (@table_number, @id_timesheet, @id_medical, @id_vacation, @id_award, @id_allowances);
END;
GO

