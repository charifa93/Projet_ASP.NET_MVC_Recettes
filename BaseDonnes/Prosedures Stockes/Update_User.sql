
CREATE PROCEDURE Update_User
    @UserId INT,
    @Username NVARCHAR(50),
    @Email NVARCHAR(100),
    @Password VARBINARY(64),
    @Salt UNIQUEIDENTIFIER,
    @RoleName NVARCHAR(8)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [dbo].[User]
    SET Username = @Username,
        Email = @Email,
        Password = @Password,
        Salt = @Salt,
        RoleName = @RoleName
    WHERE UserId = @UserId;
END;