USE CinemaBooking;
GO

SELECT 
    u.UserID,
    u.Name AS CustomerName,
    up.PhoneNumber,
    COUNT(DISTINCT b.BookingID) AS TotalBookings,
    ISNULL(SUM(dbo.fn_CalculateTotalPrice(b.BookingID, 0)), 0) AS TotalSpent
FROM [User] u
LEFT JOIN user_phone up ON u.UserID = up.UserID
LEFT JOIN Booking b ON u.UserID = b.UserID AND b.Status = 'Confirmed'
GROUP BY u.UserID, u.Name, up.PhoneNumber
ORDER BY TotalSpent DESC;
GO
