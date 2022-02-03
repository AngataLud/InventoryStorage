CREATE TRIGGER History_UPDATE ON Items
	AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int
	DECLARE @ItemName nvarchar(MAX)
	DECLARE @Description nvarchar(MAX)
	DECLARE @OldLocation int
	DECLARE @Location int
	DECLARE @DateTime datetime
	SELECT @Id = inserted.Id
	FROM inserted
	SELECT @ItemName = inserted.ItemName
	from inserted
	SELECT @Description = inserted.Description
	from inserted
	SELECT @OldLocation = Location
	from inserted
	SELECT @Location = inserted.Location
	from inserted
	SELECT @DateTime = getdate()
	FROM INSERTED

	INSERT INTO Histories
	VALUES(@Id,@ItemName,@Description,@Location,@OldLocation,@DateTime)
END


