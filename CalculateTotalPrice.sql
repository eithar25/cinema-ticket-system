CREATE FUNCTION fn_CalculateTotalPrice(
    @bookingId INT,
    @discountPercent DECIMAL(5,2) = 0
)
RETURNS MONEY
AS
BEGIN
    DECLARE @subtotal MONEY;
    
   
    SELECT @subtotal = SUM(Seat.price)
    FROM Has
    JOIN Seat ON Has.seatNumber = Seat.seatNumber AND Has.hallId = Seat.hallId
    WHERE Has.bookingId = @bookingId;
    
    RETURN ISNULL(@subtotal, 0) * (1 - @discountPercent / 100.0);
END;
