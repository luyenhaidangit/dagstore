ALTER  TRIGGER TR_Categoy_Detele ON Category
INSTEAD OF Delete
AS
BEGIN
	IF (Select count(*) from Product inner join Deleted d
	ON Product.CategoryID=d.ID)>0
		BEGIN
			RAISERROR ('That bai,chi xoa được nhung nhom hang khong chua hang hoa nao', 16, 1)
			ROLLBACK
		END
	ELSE IF (Select count(*) from Category inner join Deleted d ON Category.ParentCategoryID=d.ID)>0
		BEGIN
			RAISERROR ('That bai,chi xoa được nhung nhom hang khong chua nhom hang con', 16, 1)
			ROLLBACK
		END
	ELSE
		BEGIN
			DELETE FROM Category WHERE
			ID IN(SELECT ID FROM Deleted)
		END
END