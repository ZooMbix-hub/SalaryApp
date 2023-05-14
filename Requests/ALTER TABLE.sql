ALTER TABLE PersonalData
	ADD CONSTRAINT FK_PersonalData_Employee FOREIGN KEY (FK_TableNumber) REFERENCES Employee (TableNumber);
ALTER TABLE Vacation
	ADD CONSTRAINT FK_Vacation_Employee FOREIGN KEY (FK_TableNumber) REFERENCES Employee (TableNumber);
ALTER TABLE Medical
	ADD CONSTRAINT FK_Medical_Employee FOREIGN KEY (FK_TableNumber) REFERENCES Employee (TableNumber);
ALTER TABLE Subdivision
	ADD CONSTRAINT FK_Subdivision_TypeSub FOREIGN KEY (FK_Type) REFERENCES TypeSubdivision (Id);
ALTER TABLE Post
	ADD CONSTRAINT FK_Post_Subdivision FOREIGN KEY (FK_Sub) REFERENCES Subdivision (Id);
ALTER TABLE Company
	ADD CONSTRAINT FK_Company_Region FOREIGN KEY (FK_Region) REFERENCES Region (Id);
ALTER TABLE UserData
	ADD CONSTRAINT FK_UserData_RoleUser FOREIGN KEY (FK_Role) REFERENCES RoleUser (Id);
ALTER TABLE Employee
	ADD CONSTRAINT FK_Employee_Company FOREIGN KEY (FK_Company) REFERENCES Company (Id);
ALTER TABLE Employee
	ADD CONSTRAINT FK_Employee_Post FOREIGN KEY (FK_Post) REFERENCES Post (Id);
ALTER TABLE Employee
	ADD CONSTRAINT FK_Employee_UserData FOREIGN KEY (FK_UserData) REFERENCES UserData (Id);
ALTER TABLE Payment
	ADD CONSTRAINT FK_Payment_TableNumber FOREIGN KEY (FK_TableNumber) REFERENCES Employee (TableNumber);
ALTER TABLE Payment
	ADD CONSTRAINT FK_Payment_TableList FOREIGN KEY (FK_TableList) REFERENCES TimeSheet (Id);
ALTER TABLE Payment
	ADD CONSTRAINT FK_Payment_Medical FOREIGN KEY (FK_Medical) REFERENCES Medical (Id);
ALTER TABLE Payment
	ADD CONSTRAINT FK_Payment_Vacation FOREIGN KEY (FK_Vacation) REFERENCES Vacation (Id);
ALTER TABLE Payment
	ADD CONSTRAINT FK_Payment_Award FOREIGN KEY (FK_Award) REFERENCES TypeÎfAward (Id);
ALTER TABLE Payment
	ADD CONSTRAINT FK_Payment_Allowances FOREIGN KEY (FK_Allowances) REFERENCES TypeÎfAllowances (Id);
ALTER TABLE TimeSheet
	ADD CONSTRAINT FK_TimeSheet_Employee FOREIGN KEY (FK_TableNumber) REFERENCES Employee (TableNumber);

ALTER TABLE TimeSheet ADD PaymentNight AS (NumberNightWorked * 2000);
ALTER TABLE TimeSheet ADD PaymentRVD AS (NumberRVD * 4000);
ALTER TABLE TimeSheet ADD Surcharge AS (NumberNightWorked * 2000 + NumberRVD * 4000);

ALTER TABLE Payment ADD NDFL AS (TotalAccrued * 13 / 100);
ALTER TABLE Payment ADD TotalWithheld AS  (TotalAccrued * 13 / 100) + (TotalAccrued * 2 / 100);
ALTER TABLE Payment ADD TotalPaid AS (TotalAccrued - ((TotalAccrued * 13 / 100) + (TotalAccrued * 2 / 100)));



