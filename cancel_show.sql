USE [CinemaDB]
GO

/****** Object:  StoredProcedure [dbo].[CancelShow]    Script Date: 4/23/2026 8:22:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CancelShow]
    @showId INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Show WHERE showId = @showId)
    BEGIN
        RAISERROR('Invalid showId.', 16, 1);
        RETURN;
    END

    DECLARE @deletedBookings TABLE (
        bookingId  INT,
        userId     INT,
        totalPrice MONEY
    );

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO @deletedBookings (bookingId, userId, totalPrice)
        SELECT B.bookingId, B.userId, ISNULL(SUM(S.price), 0)
        FROM Booking B
        LEFT JOIN Has H ON H.bookingId = B.bookingId
        LEFT JOIN Seat S ON S.seatNumber = H.seatNumber AND S.hallId = H.hallId
        WHERE B.showId = @showId
        GROUP BY B.bookingId, B.userId;

        INSERT INTO Payment (bookingId, paymentMethod, date, amount, status)
        SELECT bookingId, 'Refund', GETDATE(), totalPrice, 'Processed'
        FROM @deletedBookings;

        DELETE FROM Includes
        WHERE showId = @showId;

        DELETE FROM Has
        WHERE bookingId IN (SELECT bookingId FROM @deletedBookings);

        DELETE FROM Booking WHERE showId = @showId;

        DELETE FROM Show WHERE showId = @showId;

        SELECT bookingId, userId, totalPrice AS refundAmount
        FROM @deletedBookings;

        COMMIT TRANSACTION;
        PRINT 'Show and all related records deleted successfully.';

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

