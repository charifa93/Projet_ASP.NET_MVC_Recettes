CREATE PROCEDURE Change_Password_User
    @UserId INT,
    @Password NVARCHAR(32), -- On reçoit le mot de passe en clair (limité à 32 caractères)
    @NewSalt UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Générer un nouveau Salt
    SET @NewSalt = NEWID(); 

    -- Mettre à jour le mot de passe haché et le Salt
    UPDATE [dbo].[User]
    SET Password = dbo.SF_SaltAndHash(@Password, @NewSalt),
        Salt = @NewSalt
    WHERE UserId = @UserId;

    -- Retourner le nouveau Salt
    SELECT @NewSalt;
END;

