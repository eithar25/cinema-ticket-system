SELECT 
    m.Name AS MovieName,
    COUNT(CASE WHEN st.Type = 'Regular' THEN 1 END) AS RegularSeats,
    COUNT(CASE WHEN st.Type = 'VIP' THEN 1 END) AS VIPSeats,
    COUNT(CASE WHEN st.Type = 'Premium' THEN 1 END) AS PremiumSeats,
    COUNT(*) AS TotalSeatsSold
FROM Movie m
JOIN Show s ON m.MovieID = s.MovieID
JOIN Booking b ON s.ShowID = b.ShowID AND b.Status = 'Confirmed'
JOIN Has hs ON b.BookingID = hs.BookingID
JOIN Seat st ON hs.SeatNumber = st.SeatNumber AND hs.HallID = st.HallID
GROUP BY m.MovieID, m.Name;
GO
