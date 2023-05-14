CREATE OR ALTER PROCEDURE DeletePost (@NamePost varchar(100))
AS
BEGIN
	
		DELETE Post
		WHERE Post.NamePost = @NamePost
	
END;
GO