CREATE PROCEDURE Get_All_Users
AS
BEGIN
    SET NOCOUNT ON;
    SELECT UserId, Username, Email, CreatedAt, RoleName
    FROM [dbo].[User]
    WHERE CreatedAt IS NOT NULL;
END;