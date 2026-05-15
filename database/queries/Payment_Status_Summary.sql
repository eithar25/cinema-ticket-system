SELECT 
    p.TransactionID,
    p.BookingID,
    p.Status AS PaymentStatus,
    p.Date AS PaymentDate,
    u.Name AS CustomerName,
    u.Email,
    m.Name AS MovieName,
    s.Date AS ShowDate,
    dbo.fn_CalculateTotalPrice(b.BookingID, 0) AS Amount
FROM Payment p
JOIN Booking b ON p.BookingID = b.BookingID
JOIN [User] u ON b.UserID = u.UserID
JOIN Show s ON b.ShowID = s.ShowID
JOIN Movie m ON s.MovieID = m.MovieID
ORDER BY p.Date DESC;
GO
