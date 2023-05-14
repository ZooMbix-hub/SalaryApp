DELETE FROM Subdivision 
DELETE FROM TypeSubdivision 
DELETE FROM RoleUser 
DELETE FROM UserData 
DELETE FROM Employee 
DELETE FROM Region
DELETE FROM Company
DELETE FROM PersonalData
DELETE FROM TimeSheet
DELETE FROM Vacation
DELETE FROM Medical
DELETE FROM Type�fAward
DELETE FROM Type�fAllowances
DELETE FROM Payment

SET IDENTITY_INSERT TypeSubdivision ON
INSERT TypeSubdivision (Id, NameType) VALUES (1, '�����');
INSERT TypeSubdivision (Id, NameType) VALUES (2, '������');
INSERT TypeSubdivision (Id, NameType) VALUES (3, '���');
SET IDENTITY_INSERT TypeSubdivision OFF


SET IDENTITY_INSERT Subdivision ON
INSERT Subdivision (Id, NameSub, FK_Type) VALUES (1, '����� ������', 1);
INSERT Subdivision (Id, NameSub, FK_Type) VALUES (2, '����� ������������ ��������', 1);
INSERT Subdivision (Id, NameSub, FK_Type) VALUES (3, '����� ������������� (�����������)', 1);
INSERT Subdivision (Id, NameSub, FK_Type) VALUES (4, '���������������-������������� �����', 1);
INSERT Subdivision (Id, NameSub, FK_Type) VALUES (5, '������ ������������', 2);
INSERT Subdivision (Id, NameSub, FK_Type) VALUES (6, '������ ������ �����', 2);
INSERT Subdivision (Id, NameSub, FK_Type) VALUES (7, '������ ��������������', 2);
INSERT Subdivision (Id, NameSub, FK_Type) VALUES (8, '��� ����������� �����', 3);
INSERT Subdivision (Id, NameSub, FK_Type) VALUES (9, '������������ ���', 3);
INSERT Subdivision (Id, NameSub, FK_Type) VALUES (10, '��������-������������ ���', 3);
SET IDENTITY_INSERT Subdivision OFF

SET IDENTITY_INSERT Post ON
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (1, '���������', 35000, 20, 1);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (2, '�������������', 20000, 20, 1);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (3, '���������', 40000, 15, 1);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (4, '������� �� ������������ ��������', 50000, 20, 2);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (5, '���������� ������ ������������� (�����������)', 70000, 20, 3);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (6, '���������� ���������������-�������������� ������', 65000, 20, 4);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (7, '��������� ������ ������������', 60000, 20, 5);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (8, '������� ������������ ����������� ������ ������������', 50000, 20, 5);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (9, '���������� �� ������ �����', 40000, 20, 6);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (10, '������� �� ��������������', 80000, 20, 7);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (11, '���������� �� ���������� ����������� �����', 50000, 20, 8);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (12, '��������� ���� ����������� �����', 50000, 20, 8);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (13, '��������� ������������� ����', 50000, 20, 9);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (14, '��������� ��������-������������� ����', 50000, 20, 10);
INSERT Post (Id, NamePost, Salary, WorkingDays, FK_Sub) VALUES (15, '���������� �� ������� ������������', 50000, 20, 10);
SET IDENTITY_INSERT Post OFF

SET IDENTITY_INSERT RoleUser ON
INSERT RoleUser (Id, NameRole) VALUES (1, '���������');
INSERT RoleUser (Id, NameRole) VALUES (2, '�������������');
INSERT RoleUser (Id, NameRole) VALUES (3, '��������');
INSERT RoleUser (Id, NameRole) VALUES (4, '������������� �� ������');
SET IDENTITY_INSERT RoleUser OFF

SET IDENTITY_INSERT UserData ON
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (1, 'holopov@yandex.ru', '2cf24dba5fb0a30e26', 4);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (2, 'avrianova@yandex.ru', 'ofdsa12fds5470fsw54', 2);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (3, 'kirilenko@yandex.ru', 'yu12sdgsfd43521wl1', 3);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (4, 'sherkov@yandex.ru', 'blwsptt5dkq4rnhkfe', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (5, 'belyakov@yandex.ru', 'y76vdjn5ckli5klocp', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (6, 'dubinkin@yandex.ru', '9hxmzwd5y7iaygx90w', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (7, 'mishurinski@yandex.ru', 'i55y6hi2vi8hyqfvlj', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (8, 'kolocov@yandex.ru', 'l1w0mp6k6vmej411wr', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (9, 'barinov@yandex.ru', 'mb3m8e3sqfzi0nhd7i', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (10, 'gavrilenko@yandex.ru', 'vyioswomyxwx6kbswy', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (11, 'zubov@yandex.ru', 'die5v95ept9yx7bdx9', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (12, 'dubinia@yandex.ru', 'fobwxicyr8ljee6m8t', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (13, 'vaselkov@yandex.ru', '0p7pzznixkxe655zbe', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (14, 'mitrokhin@yandex.ru', '5bg2b4ghqanjhbzqfl', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (15, 'karpencev@yandex.ru', 'ajjixdahghkldt2933', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (16, 'eleshev@yandex.ru', 'zgfbw0cyj5udmykrjz', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (17, 'korchagin@yandex.ru', 'l87i0du6h5bc22v2ff', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (18, 'yakovcov@yandex.ru', 'knlvxpzipwo7qm29ay', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (19, 'chumakov@yandex.ru', 'geu0wl947weecyeaf4', 1);
INSERT UserData (Id, LoginUser, PasswordUser, FK_Role) VALUES (20, 'kosinov@yandex.ru', 'nfu1s7lmt35wrppog5', 1);
SET IDENTITY_INSERT UserData OFF

SET IDENTITY_INSERT Region ON
INSERT Region (Id, NameRegion, Coeff) VALUES (1, '����', 1.8);
INSERT Region (Id, NameRegion, Coeff) VALUES (2, '����', 1.7);
INSERT Region (Id, NameRegion, Coeff) VALUES (3, '���������� ����', 1.3);
INSERT Region (Id, NameRegion, Coeff) VALUES (4, '���������� ����������', 1.5);
INSERT Region (Id, NameRegion, Coeff) VALUES (5, '���������� ���������', 1.5);
INSERT Region (Id, NameRegion, Coeff) VALUES (6, '���������� �������', 1.2);
INSERT Region (Id, NameRegion, Coeff) VALUES (7, '������� �������', 1.5);
INSERT Region (Id, NameRegion, Coeff) VALUES (8, '���������� ������������', 1.5);
INSERT Region (Id, NameRegion, Coeff) VALUES (9, '����������� �������', 1.5);
INSERT Region (Id, NameRegion, Coeff) VALUES (10, '������ �������', 1.5);
SET IDENTITY_INSERT Region OFF

SET IDENTITY_INSERT Company ON
INSERT Company (Id, NameCompany, Telephone, INN, AddressCompany, FK_Region) VALUES (1, '���������� ���', '+7 (906) 288-37-55', '546041870613', '�. ����������, ����� ����������, 44', 1);
INSERT Company (Id, NameCompany, Telephone, INN, AddressCompany, FK_Region) VALUES (2, '���������� ���', '+7 (949) 723-67-74', '065881488365', '�. ������, ����� �����������, 27', 2);
INSERT Company (Id, NameCompany, Telephone, INN, AddressCompany, FK_Region) VALUES (3, '��������� ���', '+7 (910) 440-47-80', '035717324840', '�. ����, ����� ������, 35', 3);
INSERT Company (Id, NameCompany, Telephone, INN, AddressCompany, FK_Region) VALUES (4, '�������� ���', '+7 (938) 537-10-52', '737759628828', '�. ������, ����� �����������, 8', 4);
INSERT Company (Id, NameCompany, Telephone, INN, AddressCompany, FK_Region) VALUES (5, '������������ ���', '+7 (984) 508-55-35', '599668358835', '�. ����������, ����� �������, 6', 5);
INSERT Company (Id, NameCompany, Telephone, INN, AddressCompany, FK_Region) VALUES (6, '���������� ���', '+7 (922) 658-42-64', '639940409193', '�. ������, ����� �����������, 102', 6);
INSERT Company (Id, NameCompany, Telephone, INN, AddressCompany, FK_Region) VALUES (7, '������� ���', '+7 (962) 620-49-86', '483198614774', '�. �����, ����� ����������, 74', 7);
INSERT Company (Id, NameCompany, Telephone, INN, AddressCompany, FK_Region) VALUES (8, '�������� ���', '+7 (962) 107-57-51', '206655920213', '�. ���, ����� ������, 56', 8);
INSERT Company (Id, NameCompany, Telephone, INN, AddressCompany, FK_Region) VALUES (9, '����������� ���', '+7 (973) 560-34-57', '561477398907', '�. ���������, ����� ��������, 7', 9);
INSERT Company (Id, NameCompany, Telephone, INN, AddressCompany, FK_Region) VALUES (10, '������ ���', '+7 (932) 490-19-72', '305210074454', '�. ����, ����� ���������, 14', 10);
SET IDENTITY_INSERT Company OFF

INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1001, '������� ������� �����������', 5, 0, 1, 1, 1, 1);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1002, '���������� ���� ����������', 10, 10, 1, 1, 2, 2);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1003, '��������� ������ �����������', 12, 10, 0, 2, 3, 3);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1004, '������ ������ ������������', 6, 0, 1, 2, 4, 4);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1005, '������� ������� ���������', 10, 10, 1, 3, 5, 5);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1006, '�������� ������ ���������', 16, 20, 0, 3, 6, 6);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1007, '����������� ����� ������������', 20, 20, 1, 4, 7, 7);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1008, '������� ������ ��������������', 2, 0, 0, 4, 8, 8);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1009, '������� ������ �����������', 6, 0, 1, 5, 9, 9);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1010, '���������� ����� ����������', 7, 10, 1, 5, 10, 10);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1011, '����� ���������� ����������', 18, 10, 1, 6, 11, 11);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1012, '������� ����� ��������', 30, 35, 0, 6, 12, 12);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1013, '�������� ������ ���������', 25, 35, 0, 7, 13, 13);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1014, '�������� ������� ������������', 35, 35, 1, 7, 14, 14);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1015, '��������� ��������� ���������', 13, 20, 0, 8, 3, 15);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1016, '������ ������� ���������', 5, 10, 0, 8, 4, 16);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1017, '�������� ���������� ����������', 1, 1, 1, 9, 8, 17);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1018, '������� ������� ����������', 10, 20, 1, 9, 5, 18);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1019, '������� ������ �����������', 3, 0, 0, 10, 6, 19);
INSERT Employee (TableNumber, FullName, WorkExperience, ProfLevel, IsUnion, FK_Company, FK_Post, FK_UserData) VALUES (1020, '������� ����� ���������', 19, 35, 1, 10, 2, 20);

SET IDENTITY_INSERT PersonalData ON
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (1, '12-05-1965', '�. ����������, ����������� ��., �. 20 ��.208', '+7 (956) 198-88-75', '������', '732595391423', '7115698745', '1100123768943352', '45119959708', 1001);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (2, '19-09-1995', '�. ����������, �������� ���., �. 2 ��.11', '+7 (964) 156-66-21', '�������', '290966453102', '7117236548', '2100123768943352', '27956884867', 1002);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (3, '15-01-1986', '�. ������, ���������� ��., �. 25 ��.66', '+7 (989) 868-10-75', '�������', '470274964725', '7121256984', '3100123768943352', '56207667300', 1003);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (4, '16-11-1978', '�. ������, ��������� ��., �. 19 ��.89', '+7 (923) 697-32-91', '������', '351106561463', '7110547856', '4100123768943352', '80563684214', 1004);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (5, '26-08-1980', '�. ����, ���������� ��., �. 22 ��.88', '+7 (959) 637-32-78', '�������', '565627790990', '7108265478', '5100123768943352', '84382190921', 1005);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (6, '15-10-1989', '�. ����, ������� ���., �. 21 ��.142', '+7 (935) 537-29-32', '�������', '631425975628', '7113214569', '6100123768943352', '64232657888', 1006);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (7, '26-12-1984', '�. ������, �������� ��., �. 15 ��.141', '+7 (925) 756-20-40', '������', '757079958370', '7118475698', '7100123768943352', '89921568177', 1007);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (8, '03-08-1987', '�. ������, ���������������� ��., �. 20 ��.98', '+7 (930) 410-19-45', '�������', '075687165602', '7112369852', '8100123768943352', '13551305226', 1008);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (9, '10-05-1980', '�. ����������, ������� ���., �. 14 ��.175', '+7 (933) 485-94-73', '�������', '444474416259', '7110258741', '9100123768943352', '61227290057', 1009);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (10, '12-12-1992', '�. ����������, ��������� ��., �. 4 ��.208', '+7 (936) 117-12-45', '������', '558525631006', '7116025987', '1200123768943352', '31805627665', 1010);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (11, '12-06-1993', '�. ������, �������� ���., �. 1 ��.146', '+7 (941) 334-29-95', '�������', '469209356685', '7117523698', '8800123768943352', '42653578600', 1011);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (12, '04-01-1983', '�. ������, ������ ��., �. 23 ��.2', '+7 (963) 537-17-24', '�������', '433191900044', '7117523698', '1400123768943352', '94323515598', 1012);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (13, '20-09-1988', '�. �����, ������������ ���., �. 3 ��.98', '+7 (915) 454-32-96', '������', '596318498380', '7115147147', '1800123768943352', '69659678910', 1013);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (14, '21-09-1978', '�. �����, ������� ��., �. 14 ��.149', '+7 (998) 691-51-81', '�������', '136908049130', '7108785234', '9900123768943352', '69242269016', 1014);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (15, '28-04-1983', '�. ���, �������� ��., �. 15 ��.132', '+7 (990) 734-21-57', '�������', '484554723740', '7112349876', '1000123768943352', '33556339791', 1015);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (16, '02-11-1989', '�. ���, ������� ��., �. 10 ��.43', '+7 (981) 418-87-12', '������', '284292303839', '7113759168', '4400123768943352', '10255855842', 1016);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (17, '12-05-1989', '�. ���������, ��������� ���., �. 14 ��.47', '+7 (976) 435-36-57', '�������', '067607744851', '7113759168', '4500123768943352', '94974925593', 1017);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (18, '25-09-1989', '�. ���������, ������� ��., �. 25 ��.118', '+7 (978) 648-63-74', '�������', '769979415049', '7114856985', '5500123768943352', '49683234642', 1018);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (19, '12-03-1996', '�. ����, ����� ��., �. 9 ��.94', '+7 (946) 242-82-35', '������', '268536123605', '7108786245', '8700123768943352', '24779714427', 1019);
INSERT PersonalData (Id, DateOfBirth, AddressEmployee, Telephone, Education, INN, PassportData, Requisites, Snils, FK_TableNumber) VALUES (20, '05-11-1967', '�. ����, ����� ��., �. 12 ��.41', '+7 (982) 154-56-60', '�������', '268536123605', '7116954823', '7600123768943352', '34182199476', 1020);
SET IDENTITY_INSERT PersonalData OFF

SET IDENTITY_INSERT TimeSheet ON
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (1, 1001, '01-05-2020', 20, 0, 0);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (2, 1002, '01-05-2020', 20, 0, 0);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (3, 1003, '01-05-2020', 15, 0, 0);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (4, 1004, '01-05-2020', 7, 7, 1);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (5, 1005, '01-05-2020', 10, 10, 0);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (6, 1006, '01-06-2020', 12, 14, 2);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (7, 1007, '01-06-2020', 7, 7, 1);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (8, 1008, '01-06-2020', 10, 10, 3);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (9, 1009, '01-06-2020', 12, 14, 2);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (10, 1010, '01-06-2020', 7, 7, 1);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (11, 1011, '01-07-2020', 10, 10, 0);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (12, 1012, '01-07-2020', 12, 14, 4);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (13, 1013, '01-07-2020', 7, 7, 1);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (14, 1014, '01-07-2020', 10, 10, 0);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (15, 1015, '01-07-2020', 12, 14, 4);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (16, 1016, '01-08-2020', 7, 7, 5);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (17, 1017, '01-08-2020', 10, 10, 1);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (18, 1018, '01-08-2020', 12, 14, 6);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (19, 1019, '01-08-2020', 7, 7, 1);
INSERT TimeSheet (Id, FK_TableNumber, DateTimeSheet, NumberDaysWorked, NumberNightWorked, NumberRVD) VALUES (20, 1020, '01-08-2020', 10, 10, 0);
SET IDENTITY_INSERT TimeSheet OFF

SET IDENTITY_INSERT Vacation ON
INSERT Vacation (Id, StartDate, EndDate, FK_TableNumber) VALUES (1, '30-05-2020', '30-06-2020', 1004);
INSERT Vacation (Id, StartDate, EndDate, FK_TableNumber) VALUES (2, '10-06-2020', '10-07-2020', 1007);
INSERT Vacation (Id, StartDate, EndDate, FK_TableNumber) VALUES (3, '15-06-2020', '15-07-2020', 1008);
INSERT Vacation (Id, StartDate, EndDate, FK_TableNumber) VALUES (4, '30-06-2020', '30-07-2020', 1010);
INSERT Vacation (Id, StartDate, EndDate, FK_TableNumber) VALUES (5, '10-03-2020', '10-04-2020', 1013);
INSERT Vacation (Id, StartDate, EndDate, FK_TableNumber) VALUES (6, '10-02-2020', '10-03-2020', 1014);
INSERT Vacation (Id, StartDate, EndDate, FK_TableNumber) VALUES (7, '10-08-2020', '10-09-2020', 1016);
INSERT Vacation (Id, StartDate, EndDate, FK_TableNumber) VALUES (8, '15-08-2020', '15-09-2020', 1017);
INSERT Vacation (Id, StartDate, EndDate, FK_TableNumber) VALUES (9, '10-01-2020', '10-02-2020', 1019);
INSERT Vacation (Id, StartDate, EndDate, FK_TableNumber) VALUES (10, '10-04-2020', '10-05-2020', 1020);
SET IDENTITY_INSERT Vacation OFF

SET IDENTITY_INSERT Medical ON
INSERT Medical (Id, StartDate, EndDate, FK_TableNumber) VALUES (1, '10-05-2020', '13-05-2020', 1001);
INSERT Medical (Id, StartDate, EndDate, FK_TableNumber) VALUES (2, '18-05-2020', '25-05-2020', 1003);
INSERT Medical (Id, StartDate, EndDate, FK_TableNumber) VALUES (3, '08-04-2020', '10-04-2020', 1005);
INSERT Medical (Id, StartDate, EndDate, FK_TableNumber) VALUES (4, '10-04-2020', '17-04-2020', 1007);
INSERT Medical (Id, StartDate, EndDate, FK_TableNumber) VALUES (5, '13-06-2020', '20-06-2020', 1009);
INSERT Medical (Id, StartDate, EndDate, FK_TableNumber) VALUES (6, '06-07-2020', '10-07-2020', 1011);
INSERT Medical (Id, StartDate, EndDate, FK_TableNumber) VALUES (7, '28-02-2020', '05-03-2020', 1013);
INSERT Medical (Id, StartDate, EndDate, FK_TableNumber) VALUES (8, '16-01-2020', '20-01-2020', 1015);
INSERT Medical (Id, StartDate, EndDate, FK_TableNumber) VALUES (9, '10-08-2020', '12-08-2020', 1017);
INSERT Medical (Id, StartDate, EndDate, FK_TableNumber) VALUES (10, '22-08-2020', '26-08-2020', 1019);
SET IDENTITY_INSERT Medical OFF

SET IDENTITY_INSERT Type�fAward ON
INSERT Type�fAward(Id, NameAward, Cost) VALUES (1, '���������� ����� ������� �����', 5000)
INSERT Type�fAward(Id, NameAward, Cost) VALUES (2, '���������� ����������������� ��������� �����', 3000)
INSERT Type�fAward(Id, NameAward, Cost) VALUES (3, '�������������� �����', 4000)
SET IDENTITY_INSERT Type�fAward OFF

SET IDENTITY_INSERT Type�fAllowances ON
INSERT Type�fAllowances(Id, NameAllowances, Cost) VALUES (1, '�� ������� ���', 10000)
INSERT Type�fAllowances(Id, NameAllowances, Cost) VALUES (2, '��������������', 5000)
INSERT Type�fAllowances(Id, NameAllowances, Cost) VALUES (3, '������������', 5000)
SET IDENTITY_INSERT Type�fAllowances OFF

SET IDENTITY_INSERT Payment ON
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (1, 1001, 1, 1, NULL, NULL, NULL);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (2, 1002, 2, NULL, NULL, NULL, 3);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (3, 1003, 3, 2, NULL, NULL, NULL);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (4, 1004, 4, NULL, 1, 1, 2);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (5, 1005, 5, NULL, NULL, 2, 2);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (6, 1006, 6, NULL, NULL, 3, 2);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (7, 1007, 7, NULL, 2, 2, 2);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (8, 1008, 8, NULL, 3, NULL, NULL);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (9, 1009, 9, 5, NULL, NULL, 2);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (10, 1010, 10, NULL, 4, 2, NULL);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (11, 1011, 11, NULL, NULL, 2, 2);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (12, 1012, 12, NULL, NULL, 1, 2);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (13, 1013, 13, NULL, NULL, NULL, 2);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (14, 1014, 14, NULL, NULL, 1, 1);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (15, 1015, 15, NULL, NULL, 3, 3);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (16, 1016, 16, NULL, 7, 3, 3);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (17, 1017, 17, 9, 8, 3, 3);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (18, 1018, 18, NULL, NULL, 3, 3);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (19, 1019, 19, 10, NULL, 3, 3);
INSERT Payment (Id, FK_TableNumber, FK_TableList, FK_Medical, FK_Vacation, FK_Award, FK_Allowances) VALUES (20, 1020, 20, NULL, NULL, 3, 3);
SET IDENTITY_INSERT Payment OFF