SELECT 
    CAST(s.Date AS DATE) AS ShowDate,
    COUNT(DISTINCT b.BookingID) AS TotalBookings,
    SUM(dbo.fn_CalculateTotalPrice(b.BookingID, 0)) AS ExpectedRevenue,
    SUM(CASE WHEN p.Status = 'Success' THEN dbo.fn_CalculateTotalPrice(b.BookingID, 0) ELSE 0 END) AS PaidRevenue,
    SUM(CASE WHEN p.Status IS NULL THEN dbo.fn_CalculateTotalPrice(b.BookingID, 0) ELSE 0 END) AS UnpaidRevenue,
    SUM(CASE WHEN p.Status = 'Failed: Insufficient Funds' THEN dbo.fn_CalculateTotalPrice(b.BookingID, 0) ELSE 0 END) AS FailedRevenue
FROM Show s
LEFT JOIN Booking b ON s.ShowID = b.ShowID AND b.Status = 'Confirmed'
LEFT JOIN Payment p ON b.BookingID = p.BookingID
GROUP BY CAST(s.Date AS DATE)
ORDER BY ShowDate;
GO
