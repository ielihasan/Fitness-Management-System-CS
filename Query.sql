-- Creating the database 'fitnessData'
CREATE DATABASE fitnessData;

-- Use the 'fitnessData' database
USE fitnessData;

-- Creating the Users table
CREATE TABLE Users (
    UserId INT PRIMARY KEY,                     -- Primary key
    Username VARCHAR(255) NOT NULL,             -- Username column
    Password VARCHAR(255) NOT NULL,             -- Password column
    CompletedDays INT DEFAULT 0,                -- Default value 0
    MembershipType VARCHAR(50),                 -- Membership type column
    FitnessLevel VARCHAR(50),                   -- Fitness level column
    Email VARCHAR(255),                         -- Email column
    Phone VARCHAR(50)                           -- Phone number column
);

-- Inserting dummy data into Users table
INSERT INTO Users (UserId, Username, Password, CompletedDays, MembershipType, FitnessLevel, Email, Phone)
VALUES 
(1, 'john_doe', 'password123', 5, 'Premium', 'Beginner', 'john.doe@example.com', '123-456-7890'),
(2, 'jane_smith', 'password456', 10, 'Standard', 'Intermediate', 'jane.smith@example.com', '234-567-8901'),
(3, 'alex_jones', 'password789', 0, 'Free', 'Beginner', 'alex.jones@example.com', '345-678-9012'),
(4, 'emily_brown', 'password101', 20, 'Premium', 'Advanced', 'emily.brown@example.com', '456-789-0123'),
(5, 'michael_davis', 'password202', 15, 'Standard', 'Intermediate', 'michael.davis@example.com', '567-890-1234'),
(6, 'sarah_white', 'password303', 3, 'Free', 'Beginner', 'sarah.white@example.com', '678-901-2345'),
(7, 'william_moore', 'password404', 8, 'Premium', 'Advanced', 'william.moore@example.com', '789-012-3456'),
(8, 'olivia_jackson', 'password505', 12, 'Standard', 'Intermediate', 'olivia.jackson@example.com', '890-123-4567'),
(9, 'ethan_clark', 'password606', 25, 'Free', 'Beginner', 'ethan.clark@example.com', '901-234-5678'),
(10, 'ava_roberts', 'password707', 30, 'Premium', 'Advanced', 'ava.roberts@example.com', '012-345-6789');

-- Selecting data from Users table
SELECT * FROM Users;

-- Step 1: Rename the column 'FitnessLevel' to 'FeePaid'
EXEC sp_rename 'Users.FitnessLevel', 'FeePaid', 'COLUMN';

-- Step 2: Temporarily set a larger size for the column to prevent truncation
ALTER TABLE Users
ALTER COLUMN FeePaid VARCHAR(50);

-- Step 3: Clear existing data in the 'FeePaid' column (if applicable)
UPDATE Users
SET FeePaid = NULL;

-- Step 4: Update the 'FeePaid' column with new values ("YES" or "NO")
UPDATE Users
SET FeePaid = CASE UserId
    WHEN 1 THEN 'YES'
    WHEN 2 THEN 'NO'
    WHEN 3 THEN 'YES'
    WHEN 4 THEN 'YES'
    WHEN 5 THEN 'NO'
    WHEN 6 THEN 'NO'
    WHEN 7 THEN 'NO'
    WHEN 8 THEN 'YES'
    WHEN 9 THEN 'NO'
    WHEN 10 THEN 'NO'
END;

-- Step 5: Optionally resize the column to VARCHAR(3) once data is updated
ALTER TABLE Users
ALTER COLUMN FeePaid VARCHAR(3);

DELETE FROM Users
WHERE UserID BETWEEN 15 AND 21;

SET IDENTITY_INSERT Users ON;

-- Step 6: Verify the changes
SELECT * FROM Users;







-- Creating the Instructors table
CREATE TABLE Instructors (
    InstructorId VARCHAR(50) PRIMARY KEY,       -- Instructor ID as primary key
    Name VARCHAR(100),                          -- Name of the instructor
    Specialization VARCHAR(100)                 -- Specialization of the instructor
);

-- Inserting sample data into Instructors table
INSERT INTO Instructors (InstructorId, Name, Specialization) 
VALUES
('INS001', 'John Smith', 'Data Science'),
('INS002', 'Alice Johnson', 'Machine Learning'),
('INS003', 'Michael Brown', 'Computer Vision');

-- Selecting data from Instructors table
SELECT * FROM Instructors;

-- Creating the Instruments table
CREATE TABLE Instruments (
    InstrumentsID INT IDENTITY(1,1) PRIMARY KEY,  -- Auto-incrementing primary key
    InstrumentsName NVARCHAR(255) NOT NULL,       -- Name of the instrument
    InstrumentsPrice NVARCHAR(50) NOT NULL,      -- Price of the instrument
    InstrumentsBarcode NVARCHAR(50) NOT NULL,    -- Barcode of the instrument
    InstrumentsType INT NOT NULL                 -- Type in minutes (as per your description)
);

-- Inserting sample data into Instruments table
INSERT INTO Instruments (InstrumentsName, InstrumentsPrice, InstrumentsBarcode, InstrumentsType) 
VALUES 
('Treadmill', '100', 'ABC123', 30),
('Cycling Machine', '150', 'DEF456', 45),
('Rowing Machine', '200', 'GHI789', 60),
('Elliptical', '250', 'JKL012', 90),
('Free Weights', '300', 'MNO345', 120),
('Resistance Bands', '50', 'PQR678', 15),
('Exercise Ball', '180', 'STU901', 30),
('Kettlebells', '220', 'VWX234', 60),
('Punching Bag', '270', 'YZA567', 75),
('Jump Rope', '350', 'BCD890', 120);

-- Selecting data from Instruments table
SELECT * FROM Instruments;

-- Creating the Admin table
CREATE TABLE Admins (
    AdminId VARCHAR(50) PRIMARY KEY,   -- Admin ID as primary key
    Username VARCHAR(255) NOT NULL,    -- Username of the admin
    Password VARCHAR(255) NOT NULL     -- Password for the admin
);

-- Inserting sample admin data
INSERT INTO Admins (AdminId, Username, Password) 
VALUES
('ADMIN001', 'admin', '1234'),
('ADMIN002', 'admin_jane', 'securepassword2'),
('ADMIN003', 'admin_mike', 'securepassword3');

-- Selecting data from Admins table
SELECT * FROM Admins;



-- Step 1: Drop the existing Users table (if it exists)
DROP TABLE IF EXISTS Users;

-- Step 2: Create a new Users table without the IDENTITY property on the UserId column
CREATE TABLE Users (
    UserId INT PRIMARY KEY,                    -- Primary key without IDENTITY
    Username VARCHAR(255) NOT NULL,            -- Username column
    Password VARCHAR(255) NOT NULL,            -- Password column
    CompletedDays INT DEFAULT 0,               -- Default value 0
    MembershipType VARCHAR(50),                -- Membership type column
    FeePaid VARCHAR(3),                        -- Fee Paid column ("YES" or "NO")
    Email VARCHAR(255),                        -- Email column
    Phone VARCHAR(50)                          -- Phone number column
);

-- Step 3: Insert dummy data (or real data) into the Users table
INSERT INTO Users (UserId, Username, Password, CompletedDays, MembershipType, FeePaid, Email, Phone)
VALUES 
(1, 'john_doe', 'password123', 5, 'Premium', 'YES', 'john.doe@example.com', '123-456-7890'),
(2, 'jane_smith', 'password456', 10, 'Standard', 'NO', 'jane.smith@example.com', '234-567-8901'),
(3, 'alex_jones', 'password789', 0, 'Free', 'YES', 'alex.jones@example.com', '345-678-9012'),
(4, 'emily_brown', 'password101', 20, 'Premium', 'YES', 'emily.brown@example.com', '456-789-0123'),
(5, 'michael_davis', 'password202', 15, 'Standard', 'NO', 'michael.davis@example.com', '567-890-1234'),
(6, 'sarah_white', 'password303', 3, 'Free', 'NO', 'sarah.white@example.com', '678-901-2345'),
(7, 'william_moore', 'password404', 8, 'Premium', 'YES', 'william.moore@example.com', '789-012-3456'),
(8, 'olivia_jackson', 'password505', 12, 'Standard', 'NO', 'olivia.jackson@example.com', '890-123-4567'),
(9, 'ethan_clark', 'password606', 25, 'Free', 'YES', 'ethan.clark@example.com', '901-234-5678'),
(10, 'ava_roberts', 'password707', 30, 'Premium', 'NO', 'ava.roberts@example.com', '012-345-6789');

-- Step 4: Verify the changes
SELECT * FROM Users;
