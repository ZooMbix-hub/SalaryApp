CREATE TRIGGER CalcVacation
ON Vacation
FOR INSERT, UPDATE
AS
UPDATE Vacation
SET CalcVacation = (DATEDIFF(day, StartDate, EndDate) *
(SELECT (Salary / WorkingDays) FROM Employee
JOIN Post ON Post.Id = Employee.FK_Post
WHERE Vacation.FK_TableNumber = Employee.TableNumber))