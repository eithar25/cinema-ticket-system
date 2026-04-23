USE [CinemaDB]
GO

/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 4/23/2026 8:23:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser]
@userId INT
AS
BEGIN
IF NOT EXISTS(
SELECT 1 FROM [User]  where userId=@userId
)
BEGIN 
        RAISERROR('INVALID USERID.', 16, 1);
        RETURN;
END
BEGIN TRANSACTION;
BEGIN TRY
DELETE FROM Has WHERE bookingId IN (SELECT bookingId FROM Booking WHERE userId=@userId )
DELETE FROM Booking WHERE userId=@userId
DELETE FROM User_Phone WHERE userId=@userId
DELETE FROM [User] WHERE userId=@userId
    COMMIT TRANSACTION;
PRINT 'User deleted successfully.';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    THROW;
END CATCH
END
GO

