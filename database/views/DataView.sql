CREATE OR ALTER VIEW vw_CustomerBookings AS
SELECT 
    U.Name AS [Customer],
    M.Name AS [Movie Name],
    S.HallID AS [Hall ID],
    dbo.fn_CalculateTotalPrice(B.BookingID, 0) AS [Total Price],
    B.Status AS [Status],
    B.Booking_date AS [Date],
    STRING_AGG(CAST(ST.SeatNumber AS VARCHAR), ', ') AS [Seats List],
    COUNT(CASE WHEN ST.Type = 'Regular' THEN 1 END) AS [Regular Seats],
    COUNT(CASE WHEN ST.Type = 'VIP' THEN 1 END) AS [VIP Seats],
    COUNT(CASE WHEN ST.Type = 'Premium' THEN 1 END) AS [Premium Seats]
FROM Booking B
JOIN [User] U ON B.UserID = U.UserID
JOIN Show S ON B.ShowID = S.ShowID
JOIN Movie M ON S.MovieID = M.MovieID
JOIN Has H ON B.BookingID = H.BookingID
JOIN Seat ST ON H.SeatNumber = ST.SeatNumber AND H.HallID = ST.HallID
GROUP BY 
    B.BookingID, 
    U.Name, 
    M.Name, 
    S.HallID,
    B.Status, 
    B.Booking_date;
GO