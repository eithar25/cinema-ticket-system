USE CinemaBooking;
GO

CREATE OR ALTER VIEW vw_BookingDetails AS
SELECT 
    b.BookingID,
    b.Booking_date,
    b.Status AS BookingStatus,
    u.UserID,
    u.Name AS CustomerName,
    u.Email,
    s.ShowID,
    s.Date AS ShowDate,
    s.start_time,
    m.MovieID,
    m.Name AS MovieName,
    m.Duration,
    h.HallID,
    h.Capacity,
    p.Status AS PaymentStatus,
    p.Date AS PaymentDate
FROM Booking b
JOIN [User] u ON b.UserID = u.UserID
JOIN Show s ON b.ShowID = s.ShowID
JOIN Movie m ON s.MovieID = m.MovieID
JOIN Hall h ON s.HallID = h.HallID
LEFT JOIN Payment p ON b.BookingID = p.BookingID;
GO
