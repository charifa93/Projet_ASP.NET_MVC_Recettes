CREATE PROCEDURE Create_User
    @Username NVARCHAR(50),
    @Email NVARCHAR(100),
    @Password VARBINARY(64),
    @Salt UNIQUEIDENTIFIER,
    @RoleName NVARCHAR(8) = 'User'
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [dbo].[User] (Username, Email, Password, Salt, RoleName)
    VALUES (@Username, @Email, @Password, @Salt, @RoleName);
END;
