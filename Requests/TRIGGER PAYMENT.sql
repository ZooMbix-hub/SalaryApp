CREATE TRIGGER CalcAccrued ON Payment
FOR INSERT, UPDATE
AS
UPDATE Payment
SET TotalAccrued =
(SELECT NumberDaysWorked FROM TimeSheet WHERE TimeSheet.Id = Payment.FK_TableList)
* ((SELECT Post.Salary FROM Post, Employee WHERE Post.Id = Employee.FK_Post AND Employee.TableNumber = Payment.FK_TableNumber) 
/ (SELECT Post.WorkingDays FROM Post, Employee WHERE Post.Id = Employee.FK_Post AND Employee.TableNumber = Payment.FK_TableNumber))
* (SELECT Region.Coeff FROM Region, Company, Employee WHERE Region.Id = Company.FK_Region AND Company.Id = Employee.FK_Company AND Employee.TableNumber = Payment.FK_TableNumber) + 
((SELECT ProfLevel FROM Employee WHERE Employee.TableNumber = Payment.FK_TableNumber) / 100 * 
(SELECT Post.Salary FROM Post, Employee WHERE Post.Id = Employee.FK_Post AND Employee.TableNumber = Payment.FK_TableNumber))
+ (SELECT Surcharge FROM TimeSheet WHERE TimeSheet.Id = Payment.FK_TableList)
+ (CASE
WHEN isnull(FK_Medical, 0) = 0
THEN 0
ELSE (select CalcMedical FROM Medical WHERE Medical.Id = Payment.FK_Medical)
end)
+ (CASE
WHEN isnull(FK_Vacation, 0) = 0
THEN 0
ELSE (select CalcVacation FROM Vacation WHERE Vacation.Id = Payment.FK_Vacation)
end)
+ (CASE
WHEN isnull(FK_Award, 0) = 0
THEN 0
ELSE (select Cost FROM TypeÎfAward WHERE TypeÎfAward.Id = Payment.FK_Award)
end)
+ (CASE
WHEN isnull(FK_Allowances, 0) = 0
THEN 0
ELSE (select Cost FROM TypeÎfAllowances WHERE TypeÎfAllowances.Id = Payment.FK_Allowances)
end)
UPDATE Payment
SET UnionDues = (TotalAccrued * 2 / 100) WHERE (SELECT IsUnion FROM Employee WHERE Employee.TableNumber = Payment.FK_TableNumber) = 1;