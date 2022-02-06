CREATE TRIGGER [TR_Employee_Insert]
	ON [dbo].[Employee]
	AFTER INSERT
	AS
	BEGIN
		INSERT INTO Company (Name, AddressId)
		SELECT CompanyName, AddressId FROM INSERTED
	END
