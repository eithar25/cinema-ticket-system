CREATE PROCEDURE [dbo].[showAllAvaliableSeatsForASpecificShow]
    @showid INT 
AS
BEGIN
    SELECT      
        S.SeatNumber,
        S.Raw_number,  
        S.Type,
        S.HallID,
        I.ShowID
    FROM Seat S
    INNER JOIN Includes I ON S.SeatNumber = I.SeatNumber AND S.HallID = I.HallID
    WHERE I.ShowID = @showid
      AND dbo.checkSeatAvailability(S.SeatNumber, S.HallID, I.ShowID) = 'Available';
END
GO
