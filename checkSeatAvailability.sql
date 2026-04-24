CREATE FUNCTION checkSeatAvailability(
    @seatNumber INT, 
    @hallid INT, 
    @showid INT  
)
RETURNS VARCHAR(50)
AS 
BEGIN 
    DECLARE @seatStatus VARCHAR(50);

    SELECT @seatStatus = Status 
    FROM Includes 
    WHERE SeatNumber = @seatNumber 
      AND HallID = @hallid 
      AND ShowID = @showid;

    RETURN ISNULL(@seatStatus, 'Not Found'); 
END;
GO
