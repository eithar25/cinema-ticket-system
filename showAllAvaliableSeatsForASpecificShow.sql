USE [CinemaDB]
GO

/****** Object:  StoredProcedure [dbo].[showAllAvaliableSeatsForASpecificShow]    Script Date: 4/23/2026 8:24:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[showAllAvaliableSeatsForASpecificShow](@showid INT )
AS
BEGIN
SELECT     
    Seat.seatNumber,
    Seat.rowNumber,
    Seat.type,
    Seat.hallId,
    Includes.showId
FROM Seat INNER JOIN Includes 
ON Seat.seatNumber = Includes.seatNumber
AND Seat.hallId = Includes.hallId
WHERE
Includes.showId=showid
AND Includes.status='available'
END
GO

