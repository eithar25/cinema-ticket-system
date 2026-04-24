CREATE PROCEDURE [dbo].[BOOK_TICKET]
    @userId INT,
    @showId INT,
    @Seats SeatTableType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @hallId INT;
        DECLARE @bookingId INT;

        SELECT @hallId = HallID FROM Show WHERE ShowID = @showId;
        IF @hallId IS NULL THROW 50002, 'Show does not exist.', 1;

        INSERT INTO Booking (ShowID, UserID, Status, Booking_date)
        VALUES (@showId, @userId, 'Pending', GETDATE());
        SET @bookingId = SCOPE_IDENTITY();

        INSERT INTO Has (BookingID, SeatNumber, HallID)
        SELECT @bookingId, seatNumber, @hallId FROM @Seats;

        UPDATE i SET Status = 'Reserved'
        FROM Includes i JOIN @Seats s ON i.SeatNumber = s.seatNumber
        WHERE i.ShowID = @showId AND i.HallID = @hallId;

        EXEC dbo.ProcessBalancePayment @bookingId = @bookingId, @userId = @userId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
