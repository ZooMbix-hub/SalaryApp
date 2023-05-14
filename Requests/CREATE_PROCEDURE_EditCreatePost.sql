CREATE OR ALTER PROCEDURE EditCreatePost (@NamePost varchar(100), @Salary varchar(100), @WorkingDays varchar(100), @NameSub varchar(100))
AS
DECLARE @NullPost varchar(100);
DECLARE @IdSub varchar(100);
BEGIN
	
	  Select @NullPost = Post.NamePost FROM Post WHERE Post.NamePost = @NamePost
	  Select @IdSub = Subdivision.Id From Subdivision Where Subdivision.NameSub = @NameSub


	  If (@NullPost is null OR @NullPost = '')
	  INSERT Post(NamePost, Salary, WorkingDays, FK_Sub) VALUES (@NamePost, @Salary, @WorkingDays, @IdSub);
	  else
	  UPDATE Post
	  SET Salary = @Salary, 
	  WorkingDays = @WorkingDays,
	  FK_Sub = @IdSub
	  WHERE NamePost = @NamePost



END;
GO