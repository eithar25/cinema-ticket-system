USE CinemaBooking;
GO

SELECT 
    HallID,
    ShowDate,
    start_time,
    Capacity,
    BookedSeats,
    OccupancyPercent
FROM vw_HallOccupancy
WHERE OccupancyPercent < 50 OR OccupancyPercent IS NULL
ORDER BY ShowDate, HallID;
GO
