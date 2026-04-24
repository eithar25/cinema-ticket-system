USE CinemaBooking;
GO
CREATE OR ALTER VIEW vw_AvailableSeats AS
SELECT 
    s.ShowID,
    m.Name AS MovieName,
    s.Date AS ShowDate,
    s.start_time,
    h.HallID,
    h.Capacity,
    st.SeatNumber,
    st.Raw_number,
    st.Type,
    st.Price
FROM Show s
JOIN Movie m ON s.MovieID = m.MovieID
JOIN Hall h ON s.HallID = h.HallID
JOIN Seat st ON h.HallID = st.HallID
LEFT JOIN Includes i ON st.SeatNumber = i.SeatNumber 
                     AND st.HallID = i.HallID 
                     AND s.ShowID = i.ShowID
WHERE i.Status IS NULL OR i.Status = 'Available';
GO
