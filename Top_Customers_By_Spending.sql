USE CinemaBooking;
GO

SELECT 
    u.UserID,
    u.Name,
    u.Email,
    COUNT(b.BookingID) AS TotalBookings,
    ISNULL(SUM(dbo.fn_CalculateTotalPrice(b.BookingID, 0)), 0) AS TotalSpent,
    ISNULL(AVG(dbo.fn_CalculateTotalPrice(b.BookingID, 0)), 0) AS AvgBookingValue
FROM [User] u
LEFT JOIN Booking b ON u.UserID = b.UserID AND b.Status = 'Confirmed'
GROUP BY u.UserID, u.Name, u.Email
ORDER BY TotalSpent DESC;
GO
