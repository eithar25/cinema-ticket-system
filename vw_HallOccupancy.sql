CREATE OR ALTER VIEW vw_HallOccupancy AS
SELECT 
    h.HallID,
    h.Capacity,
    s.ShowID,
    s.Date AS ShowDate,
    s.start_time,
    COUNT(DISTINCT hs.SeatNumber) AS BookedSeats,
    h.Capacity - COUNT(DISTINCT hs.SeatNumber) AS AvailableSeats,
    CAST(
        COUNT(DISTINCT hs.SeatNumber) * 100.0 / NULLIF(h.Capacity, 0)
        AS DECIMAL(5,2)
    ) AS OccupancyPercent
FROM Hall h
JOIN Show s ON h.HallID = s.HallID
LEFT JOIN Booking b ON s.ShowID = b.ShowID AND b.Status = 'Confirmed'
LEFT JOIN Has hs ON b.BookingID = hs.BookingID
GROUP BY h.HallID, h.Capacity, s.ShowID, s.Date, s.start_time;
GO
