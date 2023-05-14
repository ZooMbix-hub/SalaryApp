CREATE VIEW EmployeePostSubCompany
AS
SELECT Employee.TableNumber, Employee.FullName, Post.NamePost, Subdivision.NameSub, Company.NameCompany
FROM Employee 
INNER JOIN Post ON Employee.FK_Post = Post.Id 
INNER JOIN Company ON Employee.FK_Company = Company.Id 
INNER JOIN Subdivision ON Post.FK_Sub = Subdivision.Id
GO
SELECT * FROM EmployeePostSubCompany