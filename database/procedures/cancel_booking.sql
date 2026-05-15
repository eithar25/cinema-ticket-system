CREATE PROCEDURE [dbo].[CancelBooking]
    @bookingId INT,
    @userId INT,
    @refundAmount DECIMAL(10,2) OUTPUT
AS 
BEGIN
    SET NOCOUNT ON;
    DECLARE @showId INT;
    DECLARE @TotalPrice DECIMAL(10,2);
    DECLARE @ShowDateTime DATETIME;

    SET @TotalPrice = dbo.fn_CalculateTotalPrice(@bookingId, 0);

    SELECT
        @showId = B.ShowID,
        @ShowDateTime = CAST(S.Date AS DATETIME) + CAST(S.start_time AS DATETIME)
    FROM Booking B 
    INNER JOIN Show S ON S.ShowID = B.ShowID
    WHERE B.BookingID = @bookingId AND B.UserID = @userId;

    IF @showId IS NULL
    BEGIN
        RAISERROR('Booking not found or does not belong to this user.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Booking WHERE BookingID = @bookingId AND Status = 'Cancelled')
    BEGIN
        RAISERROR('Booking is already cancelled.', 16, 1);
        RETURN;
    END

    IF @ShowDateTime < DATEADD(HOUR, 24, GETDATE())
    BEGIN
        RAISERROR('Cannot cancel a booking within 24 hours of showtime.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE I
        SET I.Status = 'Available'
        FROM Includes I 
        INNER JOIN Has H ON I.SeatNumber = H.SeatNumber AND I.HallID = H.HallID
        WHERE I.ShowID = @showId AND H.BookingID = @bookingId;

        UPDATE Booking
        SET Status = 'Cancelled'
        WHERE BookingID = @bookingId;

        UPDATE [User]
        SET balance = balance + @TotalPrice
        WHERE UserID = @userId;

        INSERT INTO Payment (BookingID, Status, Date)
        VALUES (@bookingId, 'Refunded', GETDATE());

        SET @refundAmount = @TotalPrice;

        COMMIT TRANSACTION;
        PRINT 'Booking cancelled successfully. Amount ' + CAST(@TotalPrice AS VARCHAR) + ' returned to your balance.';
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
