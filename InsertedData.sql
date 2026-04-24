
INSERT INTO Movie (Duration, Name, Rating, Classification) VALUES 
(148, 'Inception', '8.8', 'Sci-Fi'),
(169, 'Interstellar', '8.7', 'Sci-Fi'),
(152, 'The Dark Knight', '9.0', 'Action'),
(121, 'The Martian', '8.0', 'Adventure');


INSERT INTO Hall (Capacity) VALUES 
(50), (100), (150), (60);


INSERT INTO [User] (Name, Email, Password, balance) VALUES 
('Ahmed Ali', 'ahmed@mail.com', 'p1', 500.00), 
('Seif Shehta', 'seif@mail.com', 'p2', 200.00),
('Mona Zaki', 'mona@mail.com', 'p3', 1000.00),
('Omar Khalid', 'omar@mail.com', 'p4', 50.00),
('Sara Hassan', 'sara@mail.com', 'p5', 300.00),
('Youssef Adam', 'youssef@mail.com', 'p6', 400.00),
('Ziad Amr', 'ziad@mail.com', 'p7', 150.00);


INSERT INTO user_phone (UserID, PhoneNumber) VALUES 
(1, '01011111111'), (1, '01222222222'),
(2, '01133333333'), (3, '01544444444'), 
(3, '01099999999'), (4, '01055555555');


INSERT INTO Show (MovieID, Date, start_time, HallID) VALUES 
(1, '2026-05-01', '13:00:00', 1),
(2, '2026-05-01', '20:00:00', 1),
(3, '2026-05-01', '18:00:00', 2),
(4, '2026-05-02', '15:00:00', 3);


INSERT INTO Seat (SeatNumber, HallID, Raw_number, Type, Price) VALUES 
(1, 1, 1, 'Regular', 100.00),
(2, 1, 1, 'Regular', 100.00),
(3, 1, 1, 'Regular', 100.00),
(4, 1, 1, 'Regular', 100.00),
(1, 2, 1, 'VIP', 150.00),
(2, 2, 1, 'VIP', 150.00),
(10, 3, 2, 'Regular', 120.00);


INSERT INTO Booking (Booking_date, Status, UserID, ShowID) VALUES 
('2026-04-15 10:30:00', 'Confirmed', 1, 1),
('2026-04-18 14:15:00', 'Confirmed', 2, 1),
('2026-04-20 09:00:00', 'Confirmed', 3, 2);


INSERT INTO Has (BookingID, SeatNumber, HallID) VALUES 
(1, 1, 1), (1, 2, 1), (1, 3, 1),
(2, 4, 1), (3, 1, 1);


INSERT INTO Includes (SeatNumber, HallID, ShowID, Status) VALUES 
(1, 1, 1, 'Reserved'), (2, 1, 1, 'Reserved'), (3, 1, 1, 'Reserved'),
(4, 1, 1, 'Reserved'), (1, 1, 2, 'Reserved');


INSERT INTO Payment (BookingID, Status, Date) VALUES 
(1, 'Success', '2026-04-15 11:00:00'),
(2, 'Success', '2026-04-18 16:30:00'),
(3, 'Success', '2026-04-20 09:15:00');
