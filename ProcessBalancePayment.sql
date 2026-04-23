GO
CREATE PROCEDURE ProcessBalancePayment
    @bookingId INT,
    @userId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @totalPrice MONEY;
    DECLARE @currentBalance MONEY;


    SET @totalPrice = dbo.fn_CalculateTotalPrice(@bookingId, 0);


    IF @totalPrice = 0
    BEGIN
        PRINT 'Error: No seats found for this booking or booking does not exist.';
        RETURN;
    END

 
    SELECT @currentBalance = balance FROM [User] WHERE userId = @userId;


    IF @currentBalance >= @totalPrice
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
       
            UPDATE [User] 
            SET balance = balance - @totalPrice 
            WHERE userId = @userId;

         
            IF EXISTS (SELECT 1 FROM Payment WHERE bookingId = @bookingId)
            BEGIN
                UPDATE Payment 
                SET status = 'Success', 
                    date = GETDATE()
                WHERE bookingId = @bookingId;
            END
            ELSE
            BEGIN
                INSERT INTO Payment (bookingId, date, status)
                VALUES (@bookingId, GETDATE(), 'Success');
            END

            UPDATE Booking 
            SET status = 'Confirmed' 
            WHERE bookingId = @bookingId;

            COMMIT TRANSACTION;
            PRINT 'Payment Successful. ' + CAST(@totalPrice AS VARCHAR) + ' EGP deducted from balance.';
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION;
            PRINT 'Transaction Failed: An error occurred during processing.';
        END CATCH
    END
    ELSE
    BEGIN

        UPDATE Booking 
        SET status = 'Cancelled' 
        WHERE bookingId = @bookingId;

        -- Log the failed attempt in Payment table
        IF EXISTS (SELECT 1 FROM Payment WHERE bookingId = @bookingId)
        BEGIN
            UPDATE Payment SET status = 'Failed: Insufficient Funds', date = GETDATE() WHERE bookingId = @bookingId;
        END
        ELSE
        BEGIN
            INSERT INTO Payment (bookingId, date, status) VALUES (@bookingId, GETDATE(), 'Failed: Insufficient Funds');
        END

        PRINT 'Payment Failed: Insufficient balance. Current Balance: ' + CAST(@currentBalance AS VARCHAR);
    END
END;
GO
