USE CinemaBooking;
GO

SELECT 
    b.BookingID,
    u.Name AS Customer,
    m.Name AS Movie,
    s.Date AS ShowDate,
    s.start_time,
    h.HallID,
    STRING_AGG(CAST(st.SeatNumber AS VARCHAR), ', ') AS SeatsBooked,
    dbo.fn_CalculateTotalPrice(b.BookingID, 0) AS TotalPrice,
    b.Status
FROM Booking b
JOIN [User] u ON b.UserID = u.UserID
JOIN Show s ON b.ShowID = s.ShowID
JOIN Movie m ON s.MovieID = m.MovieID
JOIN Hall h ON s.HallID = h.HallID
JOIN Has hs ON b.BookingID = hs.BookingID
JOIN Seat st ON hs.SeatNumber = st.SeatNumber AND hs.HallID = st.HallID
WHERE b.Status = 'Confirmed'
GROUP BY b.BookingID, u.Name, m.Name, s.Date, s.start_time, h.HallID, b.Status;
GO
