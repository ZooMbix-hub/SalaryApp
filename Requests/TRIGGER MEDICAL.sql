CREATE TRIGGER CalcMedical
ON Medical
FOR INSERT, UPDATE
AS
UPDATE Medical
SET CalcMedical = (DATEDIFF(day, StartDate, EndDate) *
(SELECT (Salary / WorkingDays) FROM Employee
JOIN Post ON Post.Id = Employee.FK_Post
WHERE Medical.FK_TableNumber = Employee.TableNumber
)) 