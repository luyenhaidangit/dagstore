CREATE TRIGGER TR_Brand_Detele ON Brand
INSTEAD OF Delete
AS
BEGIN
	IF (Select count(*) from Product inner join Deleted d
	ON Product.BrandID=d.ID)>0
		BEGIN
			RAISERROR ('That bai,chi xoa được nhung hang hang khong chua hang hoa nao', 16, 1)
			ROLLBACK
		END
	ELSE
		BEGIN
			DELETE FROM Brand WHERE
			ID IN(SELECT ID FROM Deleted)
		END
END