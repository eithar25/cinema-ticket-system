INSERT INTO Movie (duration, name, rating, classification) VALUES 
(148, 'Inception', '8.8', 'Sci-Fi'),
(169, 'Interstellar', '8.7', 'Sci-Fi'),
(152, 'The Dark Knight', '9.0', 'Action'),
(121, 'The Martian', '8.0', 'Adventure');

INSERT INTO Hall (capacity) VALUES 
(50), 
(100), 
(150), 
(60);

INSERT INTO [User] (name, email, password) VALUES 
('Ahmed Ali', 'ahmed@mail.com', 'p1'),
('Seif Shehta', 'seif@mail.com', 'p2'),
('Mona Zaki', 'mona@mail.com', 'p3'),
('Omar Khalid', 'omar@mail.com', 'p4'),
('Sara Hassan', 'sara@mail.com', 'p5'),
('Youssef Adam', 'youssef@mail.com', 'p6'),
('Ziad Amr', 'ziad@mail.com', 'p7');

INSERT INTO User_Phone (userId, phoneNumber) VALUES 
(1, '01011111111'), 
(1, '01222222222'),
(2, '01133333333'),
(3, '01544444444'), 
(3, '01099999999'),
(4, '01055555555'),
(5, '01266666666'),
(6, '01177777777'),
(7, '01088888888');

INSERT INTO Show (movieId, date, startTime, hallId) VALUES 
(1, '2026-05-01', '13:00:00', 1),
(2, '2026-05-01', '20:00:00', 1),
(3, '2026-05-01', '18:00:00', 2),
(4, '2026-05-02', '15:00:00', 3),
(1, '2026-05-02', '19:00:00', 4),
(2, '2026-05-03', '21:00:00', 2);

INSERT INTO Seat (seatNumber, rowNumber, price, hallId, type) VALUES 
(1, 'A', 100.00, 1, 'Regular'),
(2, 'A', 100.00, 1, 'Regular'),
(3, 'A', 100.00, 1, 'Regular'),
(4, 'A', 100.00, 1, 'Regular'),
(1, 'A', 150.00, 2, 'VIP'),
(2, 'A', 150.00, 2, 'VIP'),
(10, 'B', 120.00, 3, 'Regular'),
(5, 'C', 200.00, 4, 'Premium');

INSERT INTO Booking (bookingDate, status, totalPrice, userId, showId) VALUES 
('2026-04-15 10:30:00', 'Confirmed', 0, 1, 1),
('2026-04-18 14:15:00', 'Confirmed', 0, 2, 1),
('2026-04-20 09:00:00', 'Confirmed', 0, 3, 2),
('2026-04-22 18:45:00', 'Confirmed', 0, 4, 3),
('2026-04-23 11:20:00', 'Confirmed', 0, 5, 4),
('2026-04-23 23:10:00', 'Confirmed', 0, 6, 5),
('2026-04-24 08:00:00', 'Confirmed', 0, 7, 3);

INSERT INTO Has (seatNumber, hallId, bookingId) VALUES 
(1, 1, 1), 
(2, 1, 1), 
(3, 1, 1),

(4, 1, 2),
(1, 1, 3),
(1, 2, 4),
(10, 3, 5),
(5, 4, 6),
(2, 2, 7);

INSERT INTO Includes (seatNumber, showId, status, hallId) VALUES 
(1, 1, 'Reserved', 1), 
(2, 1, 'Reserved', 1), 
(3, 1, 'Reserved', 1),
(4, 1, 'Reserved', 1),
(1, 2, 'Reserved', 1),
(1, 3, 'Reserved', 2),
(10, 4, 'Reserved', 3),
(5, 5, 'Reserved', 4),
(2, 3, 'Reserved', 2);

INSERT INTO Payment (bookingId, paymentMethod, date, amount, status) VALUES 
(1, 'Credit Card', '2026-04-15 11:00:00', 300.00, 'Success'),
(2, 'Cash',        '2026-04-18 16:30:00', 100.00, 'Success'),
(3, 'Wallet',      '2026-04-20 09:15:00', 100.00, 'Pending'),
(4, 'Credit Card', '2026-04-22 19:00:00', 150.00, 'Success'),
(5, 'Cash',        '2026-04-23 12:00:00', 120.00, 'Success'),
(6, 'Credit Card', '2026-04-24 10:00:00', 200.00, 'Success'),
(7, 'Cash',        '2026-04-24 09:00:00', 150.00, 'Success');