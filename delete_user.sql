CREATE PROCEDURE [dbo].[DeleteUser]
    @userId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM [User] WHERE UserID = @userId)
    BEGIN 
        RAISERROR('INVALID USERID.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;
        UPDATE I
        SET I.Status = 'Available'
        FROM Includes I
        INNER JOIN Has H ON I.SeatNumber = H.SeatNumber AND I.HallID = H.HallID
        INNER JOIN Booking B ON H.BookingID = B.BookingID
        WHERE B.UserID = @userId AND B.Status <> 'Cancelled';

        DELETE FROM Payment 
        WHERE BookingID IN (SELECT BookingID FROM Booking WHERE UserID = @userId);

        DELETE FROM Has 
        WHERE BookingID IN (SELECT BookingID FROM Booking WHERE UserID = @userId);

        DELETE FROM Booking WHERE UserID = @userId;

        DELETE FROM user_phone WHERE UserID = @userId;

        DELETE FROM [User] WHERE UserID = @userId;

        COMMIT TRANSACTION;
        PRINT 'User and all related records (including freed seats) deleted successfully.';
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
