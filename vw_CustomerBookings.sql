USE CinemaBooking;
GO

CREATE OR ALTER VIEW vw_CustomerBookings AS
SELECT 
    u.UserID,
    u.Name AS CustomerName,
    u.Email,
    b.BookingID,
    b.Booking_date,
    b.Status AS BookingStatus,
    m.Name AS MovieName,
    s.Date AS ShowDate,
    s.start_time,
    h.HallID,
    st.SeatNumber,
    st.Raw_number,
    st.Type AS SeatType,
    st.Price AS SeatPrice,
    dbo.fn_CalculateTotalPrice(b.BookingID, 0) AS TotalPrice,
    p.Status AS PaymentStatus
FROM [User] u
JOIN Booking b ON u.UserID = b.UserID
JOIN Show s ON b.ShowID = s.ShowID
JOIN Movie m ON s.MovieID = m.MovieID
JOIN Hall h ON s.HallID = h.HallID
LEFT JOIN Has hs ON b.BookingID = hs.BookingID
LEFT JOIN Seat st ON hs.SeatNumber = st.SeatNumber AND hs.HallID = st.HallID
LEFT JOIN Payment p ON b.BookingID = p.BookingID;
GO
