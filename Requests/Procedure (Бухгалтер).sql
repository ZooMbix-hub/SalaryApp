CREATE OR ALTER PROCEDURE paymentDate (@tableNumber INT)
AS
BEGIN
	SELECT TimeSheet.DateTimeSheet FROM TimeSheet, Payment WHERE Payment.FK_TableNumber = @tableNumber
	AND Payment.FK_TableList = TimeSheet.Id 
	RETURN;
END;
GO

CREATE OR ALTER PROCEDURE paymentVacation (@tableNumber INT)
AS
BEGIN
	SELECT Vacation.StartDate, Vacation.EndDate FROM Payment, Vacation WHERE Payment.FK_TableNumber = @tableNumber
	AND Payment.FK_Vacation = Vacation.Id
	RETURN;
END;
GO

CREATE OR ALTER PROCEDURE paymentMedical (@tableNumber INT)
AS
BEGIN
	SELECT Medical.StartDate, Medical.EndDate FROM Payment, Medical WHERE Payment.FK_TableNumber = @tableNumber 
	AND Payment.FK_Medical = Medical.Id
	RETURN;
END;
GO

CREATE OR ALTER PROCEDURE paymentAward (@tableNumber INT)
AS
BEGIN
	SELECT TypeÎfAward.NameAward FROM Payment, TypeÎfAward WHERE Payment.FK_TableNumber = @tableNumber
	AND Payment.FK_Award = TypeÎfAward.Id
	RETURN;
END;
GO

CREATE OR ALTER PROCEDURE paymentAllowances (@tableNumber INT)
AS
BEGIN
	SELECT TypeÎfAllowances.NameAllowances FROM Payment, TypeÎfAllowances WHERE Payment.FK_TableNumber = @tableNumber
	AND Payment.FK_Allowances = TypeÎfAllowances.Id
	RETURN;
END;
GO

CREATE OR ALTER PROCEDURE paymentDelete (@tableNumber INT, @Date Date)
AS
DECLARE @id_timeSheet INT;
BEGIN
	SELECT @id_timeSheet = TimeSheet.Id FROM TimeSheet WHERE TimeSheet.FK_TableNumber = @tableNumber AND TimeSheet.DateTimeSheet = @date
	DELETE Payment
	WHERE Payment.FK_TableNumber = @tableNumber
	AND Payment.FK_TableList = @id_timeSheet
END;
GO

CREATE OR ALTER PROCEDURE paymentChange (@tableNumber INT, @Date Date, @startdate_vacation DATE, @enddate_vacation DATE, @startdate_medical DATE, @enddate_medical DATE,
@name_award VARCHAR(100), @name_allowances VARCHAR(100))
AS
DECLARE @id_medical INT;
DECLARE @id_vacation INT;
DECLARE @id_timesheet INT;
DECLARE @id_award INT;
DECLARE @id_allowances INT;
BEGIN
	SELECT @id_timeSheet = TimeSheet.Id FROM TimeSheet WHERE TimeSheet.FK_TableNumber = @tableNumber AND TimeSheet.DateTimeSheet = @date
	SELECT @id_medical = Payment.FK_Medical FROM Payment WHERE Payment.FK_TableNumber = @tableNumber AND Payment.FK_TableList = @id_timeSheet
	SELECT @id_vacation = Payment.FK_Vacation FROM Payment WHERE Payment.FK_TableNumber = @tableNumber AND Payment.FK_TableList = @id_timeSheet
	SELECT @id_award = TypeÎfAward.Id FROM TypeÎfAward WHERE TypeÎfAward.NameAward = @name_award
	SELECT @id_allowances = TypeÎfAllowances.Id FROM TypeÎfAllowances WHERE TypeÎfAllowances.NameAllowances = @name_allowances

	IF @id_medical IS NOT NULL
		UPDATE Medical
		SET StartDate = @startdate_medical, EndDate = @enddate_medical
		WHERE Id = @id_medical
	IF @id_vacation IS NOT NULL
		UPDATE Vacation
		SET StartDate = @startdate_vacation, EndDate = @enddate_vacation
		WHERE Id = @id_vacation
	IF @id_award IS NOT NULL
		UPDATE Payment
		SET FK_Award = @id_award
		WHERE Payment.FK_TableNumber = @tableNumber
		AND Payment.FK_TableList = @id_timeSheet

	IF @id_allowances IS NOT NULL
		UPDATE Payment
		SET FK_Allowances = @id_allowances
		WHERE Payment.FK_TableNumber = @tableNumber
		AND Payment.FK_TableList = @id_timeSheet
END;
GO

