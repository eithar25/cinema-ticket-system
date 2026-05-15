CREATE FUNCTION fn_CalculateTotalPrice(
    @bookingId INT,
    @discountPercent DECIMAL(5,2) = 0
)
RETURNS MONEY
AS
BEGIN
    DECLARE @subtotal MONEY;
    
    SELECT @subtotal = SUM(S.Price)
    FROM Has H
    JOIN Seat S ON H.SeatNumber = S.SeatNumber AND H.HallID = S.HallID
    WHERE H.BookingID = @bookingId;
    
    RETURN ISNULL(@subtotal, 0) * (1 - @discountPercent / 100.0);
END;
