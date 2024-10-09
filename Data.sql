USE KoiFishFarmShop;
GO
-- Insert data into Category table
INSERT INTO Category (Id, Name)
VALUES 
(NEWID(), 'Tancho'),
(NEWID(), 'Showa'),
(NEWID(), 'Kohaku');

-- Insert data into KoiFish table
INSERT INTO KoiFish (Id, Name, Description, Origin, Size, ThumbnailUrl, DateOfBirth, Price, PromotionPrice, Status, CreatorId)
VALUES 
(NEWID(), 'Tancho Koi', 'A beautiful Tancho koi with a red mark on its head.', 'Japan', 40, 'https://example.com/tancho.jpg', '2020-01-01', 2000, 1800, 'Available', NEWID()),
(NEWID(), 'Showa Koi', 'Showa koi with bold black and white colors.', 'Japan', 50, 'https://example.com/showa.jpg', '2019-05-10', 2500, 2200, 'Available', NEWID()),
(NEWID(), 'Kohaku Koi', 'Classic Kohaku koi with red and white patterns.', 'Japan', 45, 'https://example.com/kohaku.jpg', '2021-03-15', 2300, 2100, 'Available', NEWID());

-- Insert data into KoiFishCategory table
INSERT INTO KoiFishCategory (Id, CategoryId, KoiFishId)
VALUES 
(NEWID(), (SELECT Id FROM Category WHERE Name = 'Tancho'), (SELECT Id FROM KoiFish WHERE Name = 'Tancho Koi')),
(NEWID(), (SELECT Id FROM Category WHERE Name = 'Showa'), (SELECT Id FROM KoiFish WHERE Name = 'Showa Koi')),
(NEWID(), (SELECT Id FROM Category WHERE Name = 'Kohaku'), (SELECT Id FROM KoiFish WHERE Name = 'Kohaku Koi'));

-- Insert data into KoiFishGroup table
INSERT INTO KoiFishGroup (Id, Name, Description, Size, Price, PromotionPrice, Status, CreatorId)
VALUES 
(NEWID(), 'Group A', 'A group of high-quality Koi fish.', 60, 5000, 4500, 'Available', NEWID()),
(NEWID(), 'Group B', 'A group of medium-sized Koi fish.', 50, 4000, 3700, 'Available', NEWID());

-- Insert data into Manager table
INSERT INTO Manager (Id, Username, [Password])
VALUES 
(NEWID(), 'admin', 'admin123');
select * from Manager
-- Insert data into Customer table
INSERT INTO Customer (Id, Username, Password, Name, Phone, Address, Point, Status, CreateAt)
VALUES 
(NEWID(), 'john_doe', 'password123', 'John Doe', '123-456-7890', '123 Main St, Cityville', 100, 'Active', GETDATE()),
(NEWID(), 'jane_doe', 'password456', 'Jane Doe', '987-654-3210', '456 Elm St, Townville', 200, 'Active', GETDATE());
select * from Customer
-- Insert data into DeliveryCompany table
INSERT INTO DeliveryCompany (Id, Name, Phone)
VALUES 
(NEWID(), 'Fast Delivery', '555-1234'),
(NEWID(), 'Express Shipping', '555-5678');
select * from DeliveryCompany
-- Insert data into Order table
INSERT INTO [Order] (Id, CustomerId, Amount, Receiver, Address, Phone, PaymentMethod, IsPayment, Status, CreateAt, DeliveryCompanyId)
VALUES 
(NEWID(), (SELECT Id FROM Customer WHERE Username = 'john_doe'), 2500, 'John Doe', '123 Main St, Cityville', '123-456-7890', 'Credit Card', 1, 'Shipped', GETDATE(), (SELECT Id FROM DeliveryCompany WHERE Name = 'Fast Delivery')),
(NEWID(), (SELECT Id FROM Customer WHERE Username = 'jane_doe'), 1800, 'Jane Doe', '456 Elm St, Townville', '987-654-3210', 'Cash on Delivery', 0, 'Pending', GETDATE(), (SELECT Id FROM DeliveryCompany WHERE Name = 'Express Shipping'));
select * from [Order]
-- Insert data into OrderDetail table
INSERT INTO OrderDetail (Id, OrderId, KoiFishId, KoiFishGroupId, Quantity, Price, Plates, DriverNumber, DeliveryCost)
VALUES 
(NEWID(), (SELECT Id FROM [Order] WHERE Receiver = 'John Doe'), (SELECT Id FROM KoiFish WHERE Name = 'Tancho Koi'), NULL, 2, 4000, 'ABC123', '555-0000', 200),
(NEWID(), (SELECT Id FROM [Order] WHERE Receiver = 'Jane Doe'), NULL, (SELECT Id FROM KoiFishGroup WHERE Name = 'Group B'), 1, 3700, 'DEF456', '555-1111', 150);
select * from OrderDetail
-- Insert data into Feedback table
INSERT INTO Feedback (Id, OrderId, CustomerId, Message, Star, CreateAt)
VALUES 
(NEWID(), (SELECT Id FROM [Order] WHERE Receiver = 'John Doe'), (SELECT Id FROM Customer WHERE Username = 'john_doe'), 'Excellent fish quality and fast delivery!', 5, GETDATE()),
(NEWID(), (SELECT Id FROM [Order] WHERE Receiver = 'Jane Doe'), (SELECT Id FROM Customer WHERE Username = 'jane_doe'), 'Fish arrived in good condition, but delivery was late.', 4, GETDATE());
select * from Feedback
