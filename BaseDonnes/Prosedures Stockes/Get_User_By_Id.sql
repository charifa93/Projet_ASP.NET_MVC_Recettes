CREATE PROCEDURE Get_User_By_Id
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT UserId, Username, Email, CreatedAt, RoleName
    FROM [dbo].[User]
    WHERE UserId = @UserId;
END;