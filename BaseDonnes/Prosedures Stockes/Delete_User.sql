CREATE PROCEDURE Delete_User
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM [dbo].[User] WHERE UserId = @UserId;
END;