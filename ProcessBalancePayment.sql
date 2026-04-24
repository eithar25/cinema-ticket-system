CREATE PROCEDURE ProcessBalancePayment
    @bookingId INT,
    @userId INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @totalPrice DECIMAL(10,2);

    SET @totalPrice = dbo.fn_CalculateTotalPrice(@bookingId, 0);

    UPDATE [User] 
    SET balance = balance - @totalPrice 
    WHERE UserID = @userId AND balance >= @totalPrice;

    IF @@ROWCOUNT > 0
    BEGIN
        INSERT INTO Payment (BookingID, Status, Date) 
        VALUES (@bookingId, 'Success', GETDATE());

        UPDATE Booking SET Status = 'Confirmed' WHERE BookingID = @bookingId;

        UPDATE i
        SET i.Status = 'Reserved'
        FROM Includes i
        JOIN Has H ON i.SeatNumber = H.SeatNumber AND i.HallID = H.HallID
        JOIN Booking B ON H.BookingID = B.BookingID
        WHERE B.BookingID = @bookingId AND i.ShowID = B.ShowID;

        PRINT 'Payment Successful.';
    END
    ELSE
    BEGIN
        INSERT INTO Payment (BookingID, Status, Date) 
        VALUES (@bookingId, 'Failed: Insufficient Funds', GETDATE());

        UPDATE Booking SET Status = 'Cancelled' WHERE BookingID = @bookingId;

        UPDATE i
        SET i.Status = 'Available'
        FROM Includes i
        JOIN Has H ON i.SeatNumber = H.SeatNumber AND i.HallID = H.HallID
        JOIN Booking B ON H.BookingID = B.BookingID
        WHERE B.BookingID = @bookingId AND i.ShowID = B.ShowID;

        PRINT 'Payment Failed: Insufficient balance. Seats have been released.';
    END
END;
GO
