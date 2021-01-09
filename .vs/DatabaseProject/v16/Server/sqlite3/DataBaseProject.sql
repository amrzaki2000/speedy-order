create database SpeedyOrder
go
use SpeedyOrder


CREATE TABLE Admins (
AdminID INT PRIMARY KEY NOT NULL,
Fname VARCHAR (50) NOT NULL,
Lname VARCHAR (50) NOT NULL,
Email VARCHAR (50) NOT NULL,
PhoneNumber INT NOT NULL,
Salary INT NOT NULL
);


CREATE TABLE Sellers(
SellerID INT PRIMARY KEY NOT NULL,
Fname VARCHAR (50) NOT NULL,
Lname VARCHAR (50) NOT NULL,
Email VARCHAR (50) NOT NULL,
PhoneNumber INT NOT NULL,
[Address] VARCHAR (100) NOT NULL,
Rating INT NOT NULL,
Profit INT NOT NULL,
Income INT NOT NULL
);


CREATE TABLE [Customers] (
[CustomerID] INT PRIMARY KEY NOT NULL,
[Fname] VARCHAR (50) NOT NULL,
[Lname] VARCHAR (50) NOT NULL,
[Email] VARCHAR (50) NOT NULL,
[PhoneNumber ] INT NOT NULL,
[zipcode] INT NOT NULL,
[City] VARCHAR (50) NOT NULL,
[Points] INT NOT NULL
);


CREATE TABLE [Products] (
[ProductID] INT PRIMARY KEY NOT NULL,
[ProductName] VARCHAR (50) NOT NULL,
[Description ] VARCHAR (300) NOT NULL,
[Color ] VARCHAR (30) ,
[Category ] VARCHAR (50) NOT NULL,
[Size] INT ,
[Price] INT NOT NULL,
[Rating ] INT NOT NULL,
quantity int not null,
[Quality_Control_Admin] INT not null,
[QualityStatus] VARCHAR (50) NOT NULL,
[Seller] INT NOT NULL,
foreign key (Quality_Control_Admin) references Admins
on delete no action /* hanshofhaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa */
on update cascade,
foreign key (Seller) references Sellers
on delete cascade
on update cascade
);



CREATE TABLE CustomerService(
EmployeeID INT PRIMARY KEY NOT NULL,
WorkingHours INT NOT NULL,
Salary INT NOT NULL,
SuperID INT NOT NULL,
foreign key (SuperID) references Admins
on delete no action
on update cascade,
);

CREATE TABLE Subscriber(
Username VARCHAR (50) PRIMARY KEY NOT NULL,
[Password] INT NOT NULL,
AdminID INT ,
SellerID INT ,
CustomerID INT ,
UserType VARCHAR (30) NOT NULL,
foreign key (AdminID) references Admins
on delete no action
on update cascade,
foreign key (SellerID) references Sellers
on delete cascade
on update cascade,
foreign key (CustomerID) references Customers
on delete set null
on update cascade
);


create table [Banned]
(
BanningAdmin int not null,
BannedSub varchar(50) not null,
ReasonOfSusbension varchar(300) not null,
Appealed varchar(30) not null,
AppealDescription varchar(300) ,
NoOfBans int not null
primary key(BanningAdmin,Bannedsub,NoOfBans),
foreign key (BanningAdmin) references Admins
on delete no action
on update cascade,
foreign key (BannedSub) references Subscriber
on delete cascade
on update no action
);



CREATE TABLE [ProductReviews] (
[CustomerID] INT NOT NULL,
[ProductID] INT NOT NULL,
[Rating] INT NOT NULL,
[Description ] VARCHAR (300) NOT NULL,
PRIMARY KEY ([CustomerID],[ProductID]),
foreign key (CustomerID) references Customers
on delete cascade
on update cascade,
foreign key (ProductID) references Products
on delete cascade
on update cascade,
);


CREATE TABLE [Orders] (
[OrderID] INT PRIMARY KEY NOT NULL,
[DateCreated] DATE NOT NULL,
[TotalOrderPrice] INT NOT NULL,
[PaymenMethod] VARCHAR (50) NOT NULL,
[ShippingPrice] INT NOT NULL,
[PaymentMethodFees] INT NOT NULL,
[OrderStatus] VARCHAR (50) NOT NULL,
[DateDelivered ] DATE NOT NULL,
[CustomerID] INT NOT NULL,
foreign key (CustomerID) references Customers
on delete cascade
on update cascade,
);

CREATE TABLE [Complaints ] (
[OrderID] INT NOT NULL,
[CustomerID] INT NOT NULL,
[EmployeeID] INT default 1 NOT NULL, --el default han8ayaro ba3deeeeeeeeeeeeeeeeeeeeeen
[Status] VARCHAR (50)  NOT NULL,
[Description] VARCHAR (300) NOT NULL,
PRIMARY KEY ([OrderID],[CustomerID],[EmployeeID]),
foreign key (OrderID) references Orders
on delete cascade
on update no action,
foreign key (CustomerID) references Customers
on delete no action
on update no action,
foreign key (EmployeeID) references CustomerService
on delete set default
on update no action
);

CREATE TABLE [OrderContent ] (
[OrderID] INT NOT NULL,
[ProductID] INT NOT NULL,
[Quantity ] INT NOT NULL,
PRIMARY KEY ([ProductID],[OrderID]),
foreign key(OrderID) references Orders
on delete cascade
on update no action,
foreign key(ProductID) references Products
on delete no action --hnshofhaaaaaaaaaaa brdooooooooooo
on update cascade
);

CREATE TABLE [Warehouse] (
[WarehouseID] INT PRIMARY KEY NOT NULL,
[WarehouseName] VARCHAR (50) NOT NULL,
[WarehouseLocation] VARCHAR (50) NOT NULL,
);

CREATE TABLE [WarehouseProducts] (
[WarehouseID] INT NOT NULL,
[ProductID] INT NOT NULL,
[QuantityinWarehouse] INT NOT NULL,
PRIMARY KEY ([WarehouseID],[ProductID]),
foreign key (WarehouseID) references Warehouse
on delete cascade
on update no action,
foreign key (ProductID) references Products
on delete cascade
on update no action
);


CREATE TABLE PromoCodes(
PromoID INT PRIMARY KEY NOT NULL,
DiscountPrecentage INT NOT NULL,
);

CREATE TABLE UsedPromoCodes(
PromoID INT NOT NULL,
customerID INT NOT NULL,
IsUsed VARCHAR (30) NOT NULL,
PRIMARY KEY (PromoID,customerID),
foreign key (PromoID) references PromoCodes
on delete cascade
on update no action,
foreign key (customerID) references Customers
on delete cascade
on update no action
);



create table Returned
(
CustomerID int not null,
ProductID int not null,
reason varchar(300) not null,
NoOfReturns int not null,
Primary key (CustomerID,ProductID,NoOfReturns),
foreign key (CustomerID) references Customers
on delete no action
on update cascade,
foreign key (ProductID) references Products
on delete no action
on update cascade
);