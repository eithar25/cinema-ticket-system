create table Movie (
    movieId int primary key identity(1,1),
    duration int,
    name varchar(255) not null,
    rating varchar(10),
    classification varchar(50)
);

create table Hall (
    hallId int primary key identity(1,1),
    capacity int
);

create table [User] (
    userId int primary key identity(1,1),
    name varchar(100) not null,
    email varchar(100) unique not null,
    password varchar(255) not null,
    balance money default 0
);

create table User_Phone (
    userId int,
    phoneNumber varchar(20),
    primary key (userId, phoneNumber),
    foreign key (userId) references [User](userId) on delete cascade
);

GO
CREATE FUNCTION CalculateEndTime(@MovieID INT, @StartTime TIME)
RETURNS TIME
AS
BEGIN
    DECLARE @Dur INT;
    SELECT @Dur = duration FROM Movie WHERE movieId = @MovieID;
    RETURN DATEADD(minute, ISNULL(@Dur, 0), @StartTime);
END;
GO

create table Show (
    showId int primary key identity(1,1),
    movieId int,
    date date,
    startTime time,
    hallId int,
    endTime AS dbo.CalculateEndTime(movieId, startTime),
    foreign key (movieId) references Movie(movieId),
    foreign key (hallId) references Hall(hallId)
);

create table Seat (
    seatNumber int,
    rowNumber varchar(5),
    price money,
    hallId int,
    type varchar(50),
    primary key (seatNumber, hallId),
    foreign key (hallId) references Hall(hallId)
);

create table Booking (
    bookingId int primary key identity(1,1),
    bookingDate datetime,
    status varchar(50),
    -- totalPrice money,
    userId int,
    showId int,
    foreign key (userId) references [User](userId),
    foreign key (showId) references Show(showId)
);

create table Has (
    seatNumber int,
    hallId int,
    bookingId int,
    primary key (seatNumber, hallId, bookingId),
    foreign key (seatNumber, hallId) references Seat(seatNumber, hallId),
    foreign key (bookingId) references Booking(bookingId)
);

create table Includes (
    seatNumber int,
    showId int,
    status varchar(50),
    hallId int,
    primary key (seatNumber, showId, hallId),
    foreign key (seatNumber, hallId) references Seat(seatNumber, hallId),
    foreign key (showId) references Show(showId)
);

create table Payment (
    transactionId int identity(1,1),
    bookingId int,
    -- paymentMethod varchar(50),
    date datetime,
    --amount money,
    status varchar(50),
    primary key (transactionId, bookingId), 
    foreign key (bookingId) references Booking(bookingId) on delete cascade
);

-- GO
-- CREATE TRIGGER update_total_price ON has
-- AFTER INSERT, UPDATE, DELETE
-- AS
-- BEGIN
--     UPDATE Booking
--     SET totalPrice = (
--         SELECT ISNULL(SUM(S.price), 0) 
--         FROM has H
--         JOIN Seat S ON H.seatNumber = S.seatNumber AND H.hallId = S.hallId
--         WHERE H.bookingId = Booking.bookingId
--     )
--     WHERE bookingId IN (SELECT bookingId FROM inserted)
--        OR bookingId IN (SELECT bookingId FROM deleted);
-- END;


select * from Movie;

select * from Hall;

select * from [User];

select * from User_Phone;

select * from Show;

select * from Seat;

select * from Booking;

select * from Has;

select * from Includes;

select * from Payment;
