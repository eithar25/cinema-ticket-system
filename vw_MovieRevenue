USE CinemaBooking;
GO

CREATE OR ALTER VIEW vw_MovieRevenue AS
SELECT 
    m.MovieID,
    m.Name AS MovieName,
    m.Classification,
    COUNT(DISTINCT b.BookingID) AS TotalBookings,
    ISNULL(SUM(dbo.fn_CalculateTotalPrice(b.BookingID, 0)), 0) AS TotalRevenue
FROM Movie m
LEFT JOIN Show s ON m.MovieID = s.MovieID
LEFT JOIN Booking b ON s.ShowID = b.ShowID AND b.Status = 'Confirmed'
GROUP BY m.MovieID, m.Name, m.Classification;
GO
