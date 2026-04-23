USE [CinemaDB]
GO

/****** Object:  StoredProcedure [dbo].[RegisterUser]    Script Date: 4/23/2026 8:24:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegisterUser]
@name VARCHAR(100),
@email VARCHAR(100),
@password VARCHAR(255),
@phoneNumber VARCHAR(20)
AS
BEGIN
IF EXISTS (
    SELECT 1 FROM [User]
    WHERE email = @email
)
BEGIN
    RAISERROR('Email already exists.', 16, 1);
    RETURN;
END
DECLARE @userId INT 
    BEGIN TRANSACTION;
    BEGIN TRY
INSERT INTO [User] (name, email, password)
VALUES (@name,@email,@password)
SET  @userId=SCOPE_IDENTITY() 
INSERT INTO User_Phone (userId, phoneNumber)
VALUES (@userId,@phoneNumber)
        COMMIT TRANSACTION;
        PRINT 'User registered successfully.';

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

