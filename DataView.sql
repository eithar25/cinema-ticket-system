-- Customer Bookings
SELECT 
    U.name AS [Customer],
    M.name AS [Movie Name],
    S.hallId AS [Hall ID],
    B.totalPrice AS [Price],
    B.status AS [Status],
    B.bookingDate AS [Date],
    STRING_AGG(CONCAT(ST.rowNumber, ST.seatNumber), ', ') AS [Seats List],
    COUNT(CASE WHEN ST.type = 'Regular' THEN 1 END) AS [Regular Seats],
    COUNT(CASE WHEN ST.type = 'VIP' THEN 1 END) AS [VIP Seats],
    COUNT(CASE WHEN ST.type = 'Premium' THEN 1 END) AS [Premium Seats]
FROM Booking B
JOIN [User] U ON B.userId = U.userId
JOIN Show S ON B.showId = S.showId
JOIN Movie M ON S.movieId = M.movieId
JOIN Has H ON B.bookingId = H.bookingId
JOIN Seat ST ON H.seatNumber = ST.seatNumber AND H.hallId = ST.hallId
GROUP BY 
    B.bookingId, 
    U.name, 
    M.name, 
    S.hallId,
    B.totalPrice, 
    B.status, 
    B.bookingDate
ORDER BY B.bookingDate;