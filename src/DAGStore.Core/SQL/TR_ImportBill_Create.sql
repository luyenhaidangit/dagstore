ALTER TRIGGER Tr_ImportBill_CreateImportBillCode
ON ImportBill
AFTER INSERT AS
DECLARE @NumberRowImportBill int
SELECT @NumberRowImportBill = COUNT(*) + 1
	   FROM ImportBill WHERE CAST(CreateOn AS DATE) = CAST(GETDATE() AS DATE)
BEGIN
	UPDATE ImportBill SET CreateOn = GETDATE() FROM ImportBill
    UPDATE ImportBill
    SET ImportBillCode = 'HDN' + REPLACE(CONVERT(CHAR(10), GETDATE(), 103), '/', '')
                   + RIGHT( '000' + CAST(@NumberRowImportBill AS VARCHAR(4)), 4)
    FROM ImportBill
    JOIN inserted ON inserted.ID = ImportBill.ID;
END
GO