
CREATE OR ALTER FUNCTION salaryAVG()
RETURNS TABLE 
AS
RETURN
(
	SELECT Payment.FK_TableNumber, Employee.FullName, Post.NamePost, AVG(Payment.TotalPaid) as salaryAVG FROM Payment, TimeSheet, Employee, Post
	WHERE Payment.FK_TableNumber = TimeSheet.FK_TableNumber
	AND TimeSheet.FK_TableNumber = Employee.TableNumber
	AND Employee.FK_Post = Post.Id
	GROUP BY Payment.FK_TableNumber, Employee.FullName, Post.NamePost
);

GOGOCREATE OR ALTER FUNCTION employeeCount()
RETURNS TABLE 
AS

RETURN
(
	SELECT Company.NameCompany, Count(Employee.TableNumber) as countEmployee FROM Company, Employee 
	WHERE Employee.FK_Company = Company.Id
	GROUP BY Company.NameCompany
);

GO
