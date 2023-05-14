CREATE OR ALTER PROCEDURE EditCreateCompany (@NameCompany varchar(100), @Telephone varchar(100), @INN varchar(100), @AddressCompany varchar(100), @NameRegion varchar(100))
AS
DECLARE @NullCompany varchar(100);
DECLARE @IdRegion varchar(100);
BEGIN
	
	  Select @NullCompany = Company.NameCompany FROM Company WHERE Company.NameCompany = @NameCompany
	  Select @IdRegion = Region.Id From Region Where Region.NameRegion = @NameRegion


	  If (@NullCompany is null OR @NullCompany = '')
	  INSERT Company (NameCompany, Telephone, INN, AddressCompany, FK_Region) VALUES (@NameCompany, @Telephone, @INN, @AddressCompany, @IdRegion);
	  else
	  UPDATE Company
	  SET Telephone = @Telephone, 
	  INN = @INN,
	  AddressCompany = @AddressCompany,
	  FK_Region = @IdRegion
	  WHERE NameCompany = @NameCompany



END;
GO