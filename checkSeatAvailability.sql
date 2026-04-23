CREATE FUNCTION checkSeatAvailability(
    @seatNumber INT, 
    @hallid INT, 
    @showid INT  
)
RETURNS VARCHAR(50)
AS 
BEGIN 
    DECLARE @seatStatus VARCHAR(50);

    SELECT @seatStatus = status 
    FROM Includes 
    WHERE seatNumber = @seatNumber 
      AND hallId = @hallid 
      AND showId = @showid;

    RETURN ISNULL(@seatStatus, 'Not Found'); 
END;
