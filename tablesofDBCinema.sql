CREATE TABLE Movie (
    MovieID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Duration INT,
    Rating VARCHAR(10),
    Classification VARCHAR(100)
);

CREATE TABLE Hall (
    HallID INT PRIMARY KEY IDENTITY(1,1),
    Capacity INT
);

CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE,
    Password VARCHAR(255),
    balance DECIMAL(10, 2) DEFAULT 0.00
);


CREATE TABLE Show (
    ShowID INT PRIMARY KEY IDENTITY(1,1),
    MovieID INT,
    HallID INT,
    Date DATE,
    start_time TIME,
    CONSTRAINT FK_Show_Movie FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
    CONSTRAINT FK_Show_Hall FOREIGN KEY (HallID) REFERENCES Hall(HallID)
);


CREATE TABLE Seat (
    SeatNumber INT , 
    HallID INT ,
    Raw_number INT,
    Type VARCHAR(50),
    Price DECIMAL(10, 2),
    constraint seat_pk primary key(seatNumber, HallID),
    CONSTRAINT FK_Seat_Hall FOREIGN KEY (HallID) REFERENCES Hall(HallID)
);


CREATE TABLE user_phone (
    UserID INT,
    PhoneNumber VARCHAR(20),
    PRIMARY KEY (UserID, PhoneNumber),
    CONSTRAINT FK_Phone_User FOREIGN KEY (UserID) REFERENCES [User](UserID)
);


CREATE TABLE Booking (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    ShowID INT,
    UserID INT,
    Status VARCHAR(50),
    Booking_date DATETIME,
    CONSTRAINT FK_Booking_Show FOREIGN KEY (ShowID) REFERENCES Show(ShowID),
    CONSTRAINT FK_Booking_User FOREIGN KEY (UserID) REFERENCES [User](UserID)
);


CREATE TABLE Has (
    BookingID INT,
    SeatNumber INT,
    HallID INT, 
    PRIMARY KEY (BookingID, SeatNumber, HallID),
    CONSTRAINT FK_Has_Booking FOREIGN KEY (BookingID) REFERENCES Booking(BookingID),
    CONSTRAINT FK_Has_Seat FOREIGN KEY (SeatNumber, HallID) REFERENCES Seat(SeatNumber, HallID)
);



CREATE TABLE Includes (
    SeatNumber INT,
    HallID INT,
    ShowID INT,
    Status VARCHAR(50),
    PRIMARY KEY (SeatNumber, HallID, ShowID),
    CONSTRAINT FK_Includes_Seat FOREIGN KEY (SeatNumber, HallID) REFERENCES Seat(SeatNumber, HallID),
    CONSTRAINT FK_Includes_Show FOREIGN KEY (ShowID) REFERENCES Show(ShowID)
);


CREATE TABLE Payment (
    TransactionID INT IDENTITY(1,1),
    BookingID INT,
    PRIMARY key(TransactionID, BookingID ),
    Status VARCHAR(50),
    Date DATETIME,
    CONSTRAINT FK_Payment_Booking FOREIGN KEY (BookingID) REFERENCES Booking(BookingID)
);
