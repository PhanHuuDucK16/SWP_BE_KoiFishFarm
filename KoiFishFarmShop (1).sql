DROP DATABASE KoiFishFarmShop;
GO

-- Create the database
CREATE DATABASE KoiFishFarmShop;
GO

USE KoiFishFarmShop;
GO

CREATE TABLE Category (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(256) NOT NULL
);

CREATE TABLE KoiFish (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(256) NOT NULL,
    Description NVARCHAR(MAX),
    Origin NVARCHAR(256),
    Size INT,
    ThumbnailUrl NVARCHAR(MAX),
    DateOfBirth DATETIME,
    Price INT,
    PromotionPrice INT,
    Status NVARCHAR(256),
    CreatorId INT
);

CREATE TABLE KoiFishCategory (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoryId INT FOREIGN KEY REFERENCES Category(Id),
    KoiFishId INT FOREIGN KEY REFERENCES KoiFish(Id)
);

CREATE TABLE KoiFishGroup (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(256),
    Description NVARCHAR(MAX),
    Size INT,
    Price INT,
    PromotionPrice INT,
    Status NVARCHAR(256),
    CreatorId INT
);

CREATE TABLE Manager (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(256),
    [Password] NVARCHAR(256)
);

CREATE TABLE Customer (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(256),
    Password NVARCHAR(256),
    Name NVARCHAR(256),
    Phone NVARCHAR(256),
    Address NVARCHAR(MAX),
    Point INT,
    Status NVARCHAR(256),
    CreateAt DATETIME
);

CREATE TABLE DeliveryCompany (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(256),
    Phone NVARCHAR(256)
);

CREATE TABLE [Order] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT FOREIGN KEY REFERENCES Customer(Id),
    Amount INT,
    Receiver NVARCHAR(256),
    Address NVARCHAR(MAX),
    Phone NVARCHAR(256),
    PaymentMethod NVARCHAR(256),
    IsPayment BIT,
    Status NVARCHAR(256),
    CreateAt DATETIME,
    DeliveryCompanyId INT FOREIGN KEY REFERENCES DeliveryCompany(Id)
);

CREATE TABLE OrderDetail (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT FOREIGN KEY REFERENCES [Order](Id),
    KoiFishId INT FOREIGN KEY REFERENCES KoiFish(Id),
    KoiFishGroupId INT FOREIGN KEY REFERENCES KoiFishGroup(Id),
    Quantity INT,
    Price INT,
    Plates NVARCHAR(256),
    DriverNumber NVARCHAR(256),
    DeliveryCost INT
);

CREATE TABLE Feedback (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT FOREIGN KEY REFERENCES [Order](Id),
    CustomerId INT FOREIGN KEY REFERENCES Customer(Id),
    Message NVARCHAR(MAX),
    Star INT,
    CreateAt DATETIME
);

-- Insert data into Category table
INSERT INTO Category (Name)
VALUES 
('Tancho'),
('Showa'),
('Kohaku');

-- Insert data into KoiFish table
INSERT INTO KoiFish (Name, Description, Origin, Size, ThumbnailUrl, DateOfBirth, Price, PromotionPrice, Status, CreatorId)
VALUES 
('Tancho Koi', 'A beautiful Tancho koi with a red mark on its head.', 'Japan', 40, 'https://example.com/tancho.jpg', '2020-01-01', 2000, 1800, 'Available', 1),
('Showa Koi', 'Showa koi with bold black and white colors.', 'Japan', 50, 'https://example.com/showa.jpg', '2019-05-10', 2500, 2200, 'Available', 2),
('Kohaku Koi', 'Classic Kohaku koi with red and white patterns.', 'Japan', 45, 'https://example.com/kohaku.jpg', '2021-03-15', 2300, 2100, 'Available', 3);

-- Insert data into KoiFishCategory table
INSERT INTO KoiFishCategory (CategoryId, KoiFishId)
VALUES 
((SELECT Id FROM Category WHERE Name = 'Tancho'), (SELECT Id FROM KoiFish WHERE Name = 'Tancho Koi')),
((SELECT Id FROM Category WHERE Name = 'Showa'), (SELECT Id FROM KoiFish WHERE Name = 'Showa Koi')),
((SELECT Id FROM Category WHERE Name = 'Kohaku'), (SELECT Id FROM KoiFish WHERE Name = 'Kohaku Koi'));

select * from KoiFishCategory
drop table KoiFishCategory
-- Insert data into KoiFishGroup table
INSERT INTO KoiFishGroup (Name, Description, Size, Price, PromotionPrice, Status, CreatorId)
VALUES 
('Group A', 'A group of high-quality Koi fish.', 60, 5000, 4500, 'Available', 1),
('Group B', 'A group of medium-sized Koi fish.', 50, 4000, 3700, 'Available', 2);

-- Insert data into Manager table
INSERT INTO Manager (Username, [Password])
VALUES 
('admin', 'admin123');

-- Insert data into Customer table
INSERT INTO Customer (Username, Password, Name, Phone, Address, Point, Status, CreateAt)
VALUES 
('john_doe', 'password123', 'John Doe', '123-456-7890', '123 Main St, Cityville', 100, 'Active', GETDATE()),
('jane_doe', 'password456', 'Jane Doe', '987-654-3210', '456 Elm St, Townville', 200, 'Active', GETDATE());

-- Insert data into DeliveryCompany table
INSERT INTO DeliveryCompany (Name, Phone)
VALUES 
('Fast Delivery', '555-1234'),
('Express Shipping', '555-5678');

-- Insert data into Order table
INSERT INTO [Order] (CustomerId, Amount, Receiver, Address, Phone, PaymentMethod, IsPayment, Status, CreateAt, DeliveryCompanyId)
VALUES 
((SELECT Id FROM Customer WHERE Username = 'john_doe'), 2500, 'John Doe', '123 Main St, Cityville', '123-456-7890', 'Credit Card', 1, 'Shipped', GETDATE(), (SELECT Id FROM DeliveryCompany WHERE Name = 'Fast Delivery')),
((SELECT Id FROM Customer WHERE Username = 'jane_doe'), 1800, 'Jane Doe', '456 Elm St, Townville', '987-654-3210', 'Cash on Delivery', 0, 'Pending', GETDATE(), (SELECT Id FROM DeliveryCompany WHERE Name = 'Express Shipping'));

-- Insert data into OrderDetail table
INSERT INTO OrderDetail (OrderId, KoiFishId, KoiFishGroupId, Quantity, Price, Plates, DriverNumber, DeliveryCost)
VALUES 
((SELECT Id FROM [Order] WHERE Receiver = 'John Doe'), (SELECT Id FROM KoiFish WHERE Name = 'Tancho Koi'), NULL, 2, 4000, 'ABC123', '555-0000', 200),
((SELECT Id FROM [Order] WHERE Receiver = 'Jane Doe'), NULL, (SELECT Id FROM KoiFishGroup WHERE Name = 'Group B'), 1, 3700, 'DEF456', '555-1111', 150);

-- Insert data into Feedback table
INSERT INTO Feedback (OrderId, CustomerId, Message, Star, CreateAt)
VALUES 
((SELECT Id FROM [Order] WHERE Receiver = 'John Doe'), (SELECT Id FROM Customer WHERE Username = 'john_doe'), 'Excellent fish quality and fast delivery!', 5, GETDATE()),
((SELECT Id FROM [Order] WHERE Receiver = 'Jane Doe'), (SELECT Id FROM Customer WHERE Username = 'jane_doe'), 'Fish arrived in good condition, but delivery was late.', 4, GETDATE());
