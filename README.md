# 🎬 Cinema Ticket System

A database-driven cinema booking application built with **Microsoft SQL Server** and a **C# WinForms GUI**, developed as a course project for CSE244: Database Systems Design at Ain Shams University — Faculty of Engineering.

---

## Overview

The system manages the full lifecycle of movie screenings and customer bookings at a multi-hall cinema complex, covering:

- Hall and seat management (Regular, VIP, Premium types)
- Movie catalogue and show scheduling
- Customer registration, login, and profile management
- Seat selection and ticket booking with real-time availability
- Balance-based payment processing with automatic refunds
- Admin dashboard with revenue and occupancy analytics

---

## 🗂️ Repository Structure

```
cinema-ticket-system/
│
├── README.md
├── .gitignore
│
├── docs/
│   ├── Final_DB_Report.pdf       # Full project report (ERD, normalization, SQL)
│   ├── ERD.png                   # Entity-Relationship Diagram
│   └── schema_diagram.png        # Final relational schema
│
├── database/
│   ├── schema/
│   │   ├── 01_tables.sql         # All CREATE TABLE statements
│   │   └── 02_sample_data.sql    # INSERT statements for test data
│   │
│   ├── functions/
│   │   ├── fn_CalculateTotalPrice.sql
│   │   └── fn_checkSeatAvailability.sql
│   │
│   ├── views/
│   │   ├── vw_CustomerBookings.sql
│   │   ├── vw_AvailableSeats.sql
│   │   ├── vw_BookingDetails.sql
│   │   ├── vw_HallOccupancy.sql
│   │   └── vw_MovieRevenue.sql
│   │
│   ├── procedures/
│   │   ├── sp_RegisterUser.sql
│   │   ├── sp_BookTicket.sql
│   │   ├── sp_CancelBooking.sql
│   │   ├── sp_CancelShow.sql
│   │   ├── sp_ProcessBalancePayment.sql
│   │   ├── sp_ShowAvailableSeats.sql
│   │   └── sp_DeleteUser.sql
│   │
│   └── queries/
│       ├── customer_phone_with_booking_count.sql
│       ├── daily_revenue_report.sql
│       ├── low_occupancy_shows.sql
│       ├── payment_status_summary.sql
│       ├── seat_type_distribution_per_movie.sql
│       └── top_customers_by_spending.sql
│
└── app/
    ├── cinema proj.slnx
    └── cinema proj/              # C# WinForms application source
```

---

##  Database Schema

The schema consists of **10 normalized tables** (verified up to BCNF):

| Table | Primary Key | Description |
|---|---|---|
| `Movie` | `MovieID` | Movie catalogue |
| `Hall` | `HallID` | Cinema halls and capacity |
| `Show` | `ShowID` | Scheduled screenings |
| `Seat` | `SeatNumber + HallID` | Physical seats per hall |
| `User` | `UserID` | Registered customers |
| `user_phone` | `UserID + PhoneNumber` | Multi-valued phone numbers (1NF) |
| `Booking` | `BookingID` | Customer reservations |
| `Has` | `BookingID + SeatNumber + HallID` | Junction: bookings ↔ seats |
| `Includes` | `SeatNumber + HallID + ShowID` | Seat availability per show |
| `Payment` | `TransactionID` | Payment transactions |

---

## ⚙️ Setup Instructions

### Prerequisites
- Microsoft SQL Server (2019 or later)
- SQL Server Management Studio (SSMS)
- .NET 8+ (for the C# GUI)

### Database Setup

Run the scripts in this order:

```sql
-- 1. Create all tables
source database/schema/01_tables.sql

-- 2. Insert sample data
source database/schema/02_sample_data.sql

-- 3. Create functions (run both)
source database/functions/fn_CalculateTotalPrice.sql
source database/functions/fn_checkSeatAvailability.sql

-- 4. Create views (run all five)
source database/views/...

-- 5. Create stored procedures (run all seven)
source database/procedures/...
```

### Running the Application

1. Open `app/cinema proj.slnx` in Visual Studio.
2. Update the connection string in the application to point to your SQL Server instance.
3. Build and run.

---

##  Key Features

**Stored Procedures**
- `sp_RegisterUser` — registers a user with email uniqueness check, wrapped in a transaction
- `sp_BookTicket` — books seats atomically: creates booking → links seats → processes payment
- `sp_CancelBooking` — cancels with a 24-hour cutoff policy and full balance refund
- `sp_CancelShow` — bulk cancels all bookings for a show and refunds every customer
- `sp_ProcessBalancePayment` — deducts from user balance; auto-cancels if insufficient funds
- `sp_DeleteUser` — cascading delete that frees reserved seats before removal

**Views**
- `vw_CustomerBookings` — per-booking summary with seat breakdown and total price
- `vw_AvailableSeats` — real-time available seats per show
- `vw_HallOccupancy` — occupancy percentage per hall per show
- `vw_MovieRevenue` — total revenue and booking count per movie

---

##  Normalization Summary

All tables satisfy **1NF, 2NF, 3NF, and BCNF**:
- Multi-valued phone numbers extracted to `user_phone` (1NF)
- No partial dependencies in any composite-key table (2NF)
- Transitive dependency `ShowID → MovieID → Name` resolved by removing `Name` from `Show` (3NF)
- Every determinant in every table is a candidate key (BCNF)

---

## 👥 Team

| Name | ID |
|---|---|
| Mariam Mohey Ibrahiem Arafa | 24P0392 |
| Eithar Diaa Amin Abd Al-Aziz | 24P0383 |
| Rana Salah Mohammed Fawzy | 24P0389 |
| Doaa Shaker Mohamed Aziz Awad Elhofy | 24P0445 |
| Seif Shehta Abdelfattah Zayed | 24P0190 |
| Youssef Mohamed Wafaey Abouelseoud | 24P0177 |
| Youssef Shehta Abdelfattah Zayed | 24P0191 |

