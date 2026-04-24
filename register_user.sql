CREATE PROCEDURE [dbo].[RegisterUser]
    @name VARCHAR(255), 
    @email VARCHAR(255),
    @password VARCHAR(255),
    @phoneNumber VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1 FROM [User]
        WHERE Email = @email
    )
    BEGIN
        RAISERROR('Email already exists.', 16, 1);
        RETURN;
    END

    DECLARE @userId INT;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [User] (Name, Email, Password, balance)
        VALUES (@name, @email, @password, 0.00);

        SET @userId = SCOPE_IDENTITY();

        INSERT INTO user_phone (UserID, PhoneNumber)
        VALUES (@userId, @phoneNumber);

        COMMIT TRANSACTION;
        PRINT 'User registered successfully with UserID: ' + CAST(@userId AS VARCHAR);

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
