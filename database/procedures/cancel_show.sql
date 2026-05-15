CREATE PROCEDURE [dbo].[CancelShow]
    @showId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Show WHERE ShowID = @showId)
    BEGIN
        RAISERROR('Invalid showId.', 16, 1);
        RETURN;
    END

    DECLARE @RefundList TABLE (
        bookingId  INT,
        userId     INT,
        refundAmount DECIMAL(10,2)
    );

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO @RefundList (bookingId, userId, refundAmount)
        SELECT B.BookingID, B.UserID, dbo.fn_CalculateTotalPrice(B.BookingID, 0)
        FROM Booking B
        WHERE B.ShowID = @showId AND B.Status <> 'Cancelled';

        UPDATE U
        SET U.balance = U.balance + R.refundAmount
        FROM [User] U
        INNER JOIN @RefundList R ON U.UserID = R.userId;

        INSERT INTO Payment (BookingID, Status, Date)
        SELECT bookingId, 'Refunded: Show Cancelled', GETDATE()
        FROM @RefundList;

        UPDATE Booking 
        SET Status = 'Cancelled' 
        WHERE ShowID = @showId;

        UPDATE Includes 
        SET Status = 'Available' 
        WHERE ShowID = @showId;

        SELECT bookingId, userId, refundAmount
        FROM @RefundList;

        COMMIT TRANSACTION;
        PRINT 'Show cancelled and all customers have been refunded successfully.';

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
