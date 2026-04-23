USE [CinemaDB]
GO
/****** Object:  StoredProcedure [dbo].[BOOK_TICKET]    Script Date: 4/23/2026 8:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BOOK_TICKET]
@userId INT,
@showId INT,
@Seats SeatTableType READONLY,
@paymentMethod VARCHAR(50)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        DECLARE @hallId INT;
        DECLARE @totalPrice MONEY;
        DECLARE @bookingId INT;
        IF NOT EXISTS (SELECT 1 FROM [User] WHERE userId = @userId)
        BEGIN
            PRINT 'Invalid user';
            ROLLBACK;
            RETURN;
        END
        IF NOT EXISTS (SELECT 1 FROM @Seats)
        BEGIN
            PRINT 'No seats selected';
            ROLLBACK;
            RETURN;
        END
        IF NOT EXISTS (SELECT 1 FROM Show WHERE showId = @showId)
        BEGIN
            PRINT 'Invalid show';
            ROLLBACK;
            RETURN;
        END
        SELECT @hallId = hallId FROM Show WHERE showId = @showId;
         IF EXISTS (
            SELECT 1
            FROM (SELECT DISTINCT seatNumber FROM @Seats) s
            LEFT JOIN Includes i
                ON s.seatNumber = i.seatNumber
                AND i.showId = @showId
                AND i.hallId = @hallId
            WHERE i.seatNumber IS NULL
        )
        BEGIN
            PRINT 'Seat not in this show';
            ROLLBACK;
            RETURN;
        END
        IF EXISTS (
            SELECT 1
            FROM (SELECT DISTINCT seatNumber FROM @Seats) s
            JOIN Includes i WITH (UPDLOCK, HOLDLOCK)
                ON s.seatNumber = i.seatNumber
                WHERE i.status = 'Reserved'
                AND i.showId = @showId
                AND i.hallId = @hallId

        )
        BEGIN
            PRINT 'Seat already booked';
            ROLLBACK;
            RETURN;
        END

        INSERT INTO Booking (bookingDate, status, userId, showId)
        VALUES (GETDATE(), 'Pending', @userId, @showId);
        SET @bookingId = SCOPE_IDENTITY();
        INSERT INTO Has (seatNumber, hallId, bookingId)
        SELECT DISTINCT seatNumber, @hallId, @bookingId
        FROM @Seats;
        UPDATE i
        SET status = 'Reserved'
        FROM Includes i WITH (UPDLOCK, HOLDLOCK)
        JOIN @Seats s
           ON s.seatNumber = i.seatNumber
        WHERE i.showId = @showId
          AND i.hallId = @hallId
          AND i.status = 'Available';
        SELECT @totalPrice = ISNULL(SUM(S.price), 0)
        FROM Has H
        JOIN Seat S 
            ON H.seatNumber = S.seatNumber 
           AND H.hallId = S.hallId
        WHERE H.bookingId = @bookingId;
        INSERT INTO Payment (bookingId, paymentMethod, date, amount, status)
        VALUES (@bookingId, @paymentMethod, GETDATE(), @totalPrice, 'Success');
        UPDATE Booking
        SET status = 'Confirmed'
        WHERE bookingId = @bookingId;
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT ERROR_MESSAGE();
    END CATCH
END
GO
