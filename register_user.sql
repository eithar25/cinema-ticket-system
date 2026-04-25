CREATE PROCEDURE [dbo].[RegisterUser]
    @name VARCHAR(255), 
    @email VARCHAR(255),
    @password VARCHAR(255),
    @phoneNumber VARCHAR(20),
    @balance DECIMAL(10, 2) -- The new 5th parameter
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Check if the Email already exists in the database
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

        -- 2. Insert into the main [User] table using the balance from the form
        INSERT INTO [User] (Name, Email, Password, balance)
        VALUES (@name, @email, @password, @balance);

        -- Get the ID of the user we just created
        SET @userId = SCOPE_IDENTITY();

        -- 3. Insert into the separate phone table using the new UserID
        INSERT INTO user_phone (UserID, PhoneNumber)
        VALUES (@userId, @phoneNumber);

        COMMIT TRANSACTION;
        PRINT 'User registered successfully with UserID: ' + CAST(@userId AS VARCHAR);

    END TRY
    BEGIN CATCH
        -- If any step fails, undo everything to keep data consistent
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
