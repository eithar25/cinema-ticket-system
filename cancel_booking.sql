USE [CinemaDB]
GO

/****** Object:  StoredProcedure [dbo].[CancelBooking]    Script Date: 4/23/2026 8:21:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CancelBooking]
@bookingId INT,
@userId INT,
@refundAmount MONEY OUTPUT
AS 
BEGIN
DECLARE @showId INT
DECLARE @TotalPrice  MONEY 
DECLARE @ShowDateTime  DATETIME
SELECT @TotalPrice = ISNULL(SUM(S.price), 0)
FROM Has H
JOIN Seat S ON H.seatNumber = S.seatNumber AND H.hallId = S.hallId
WHERE H.bookingId = @bookingId;
SELECT
@showId=B.showId,
@ShowDateTime = DATEADD(MINUTE, DATEDIFF(MINUTE, 0, CAST(S.startTime AS DATETIME)), CAST(S.date AS DATETIME))
FROM Booking B INNER JOIN Show S
ON S.showId=B.showId
WHERE B.bookingId=@bookingId
AND
B.userId=@userId
IF @showId IS NULL
    BEGIN
        RAISERROR('Booking not found or does not belong to this user.', 16, 1);
        RETURN;
    END
IF EXISTS (
    SELECT 1 FROM Booking WHERE bookingId=@bookingId AND status='Cancelled'
    )
    BEGIN
        RAISERROR('Booking is already cancelled.', 16, 1);
        RETURN;
    END
IF @ShowDateTime< DATEADD(HOUR, 24, GETDATE())
    BEGIN
        RAISERROR('Cannot cancel a booking within 24 hours of showtime.', 16, 1);
        RETURN;
    END
BEGIN TRY
    BEGIN TRANSACTION;
    UPDATE I
    SET I.status='Available'
    FROM Includes I INNER JOIN HAS H
    ON I.seatNumber=H.seatNumber
    AND I.hallId=H.hallId
       WHERE I.showId=@showId
       AND   H.bookingId = @bookingId
    UPDATE Booking
    SET status= 'Cancelled'
    WHERE bookingId=@bookingId
    INSERT INTO Payment (bookingId, paymentMethod, date, amount, status)
    VALUES (@bookingId, 'Refund', GETDATE(), @totalPrice, 'Processed');
    SET @refundAmount=@TotalPrice
    COMMIT TRANSACTION;
        PRINT 'Booking cancelled. Refund of ' + CAST(@totalPrice AS VARCHAR) + ' will be processed.'
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH

END
GO

