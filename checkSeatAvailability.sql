CREATE FUNCTION checkSeatAvailability(
    @seatNumber INT, 
    @hallid INT, 
    @showid INT  -- Added INT data type here
)
RETURNS VARCHAR(50) -- You must define what the function returns
AS 
BEGIN 
    DECLARE @seatStatus VARCHAR(50);

    SELECT @seatStatus = status 
    FROM Includes 
    WHERE seatNumber = @seatNumber 
      AND hallId = @hallid 
      AND showId = @showid;

    -- If the seat isn't found in Includes, return 'Not Found' instead of NULL
    RETURN ISNULL(@seatStatus, 'Not Found'); 
END;
