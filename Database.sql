Create database SpeedyOrder
go
use SpeedyOrder

CREATE TABLE Admins (
AdminID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Fname VARCHAR (50) NOT NULL,
Lname VARCHAR (50) NOT NULL,
Email VARCHAR (50) NOT NULL Unique,
[Address] VARCHAR(100) NOT NULL,
PhoneNumber INT NOT NULL,
Salary INT NOT NULL
);


CREATE TABLE Sellers(
SellerID INT IDENTITY(100,1) PRIMARY KEY NOT NULL,
Fname VARCHAR (50) NOT NULL,
Lname VARCHAR (50) NOT NULL,
Email VARCHAR (50) NOT NULL Unique,
PhoneNumber INT NOT NULL,
[Address] VARCHAR (100) NOT NULL,
BirthDate Date Not NULL,
Rating INT,
Profit INT,
Income INT 
);


CREATE TABLE [Customers] (
[CustomerID] INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,
[Fname] VARCHAR (50) NOT NULL,
[Lname] VARCHAR (50) NOT NULL,
[Email] VARCHAR (50) NOT NULL Unique,
BirthDate Date Not NULL,
[PhoneNumber] INT NOT NULL,
[Address] VARCHAR (50) NOT NULL,
[Points] INT default 0
);


CREATE TABLE [Products] (
[ProductID] INT IDENTITY(10000,1) PRIMARY KEY NOT NULL,
[ProductName] VARCHAR (50) NOT NULL,
[Description ] VARCHAR (300) NOT NULL,
[Color ] VARCHAR (30) ,
[Category ] VARCHAR (50) NOT NULL,
[Size] VARCHAR(2) ,
[Price] INT NOT NULL,
[Rating ] INT ,
quantity int not null,
[Quality_Control_Admin] INT ,
[QualityStatus] VARCHAR (50) default 'Pending',
[Seller] INT NOT NULL,
[prodImg] varchar(100) NOT NULL
foreign key (Quality_Control_Admin) references Admins
on delete no action /* hanshofhaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa */
on update cascade,
foreign key (Seller) references Sellers
on delete cascade
on update cascade
);



CREATE TABLE CustomerService(
EmployeeID INT IDENTITY(50,1) PRIMARY KEY NOT NULL,
Fname varchar(50) not null,
Lname varchar(50) not null,
PhoneNumber int not null,
[Address] varchar(50) not null,
Email varchar(50) not null Unique,
WorkingHours INT NOT NULL,
Salary INT NOT NULL,
SuperID INT NOT NULL,
foreign key (SuperID) references Admins
on delete no action
on update cascade,
);

CREATE TABLE Subscriber(
Username VARCHAR (50) PRIMARY KEY NOT NULL,
[Password] varchar(50) NOT NULL,
AdminID INT default NULL ,
SellerID INT default NULL,
CustomerID INT default NULL,
EmployeeID INT default NULL,
UserType VARCHAR (30) NOT NULL,
foreign key (AdminID) references Admins
on delete no action
on update cascade,
foreign key (SellerID) references Sellers
on delete cascade
on update cascade,
foreign key (CustomerID) references Customers
on delete set null
on update cascade,
foreign key (EmployeeID) references CustomerService
on delete No Action
on update no action
);



create table [Banned]
(
BanningAdmin int not null,
BannedSub varchar(50) not null,
ReasonOfSusbension varchar(300) not null,
AppealStatus varchar(30),
AppealDescription varchar(300) ,
primary key(BanningAdmin,Bannedsub),
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
[OrderID] INT IDENTITY(20000,1) PRIMARY KEY NOT NULL,
[DateCreated] DATE NOT NULL,
[TotalOrderPrice] INT NOT NULL,
[ShippingPrice] INT NOT NULL,
[OrderStatus] VARCHAR (50) NOT NULL,
[DateDelivered ] DATE ,
[CustomerID] INT NOT NULL,
foreign key (CustomerID) references Customers
on delete cascade
on update cascade,
);

CREATE TABLE [Complaints ] (
[ComplaintID] INT IDENTITY(9000,1) PRIMARY KEY NOT NULL,
[OrderID] INT NOT NULL,
[ProductID] INT NOT NULL,
[CustomerID] INT NOT NULL,
[EmployeeID] INT , 
[Status] VARCHAR (50)  NOT NULL,
[Description] VARCHAR (300) NOT NULL,
[Respond] varchar(50),
foreign key(ProductID) references Products,
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
on delete no action
on update cascade
);

CREATE TABLE [Warehouse] (
[WarehouseID] INT IDENTITY(30000,1) PRIMARY KEY NOT NULL,
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
PromoID Varchar(50) PRIMARY KEY NOT NULL,
DiscountPrecentage INT NOT NULL,
);

CREATE TABLE UsedPromoCodes(
PromoID Varchar(50) NOT NULL,
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
[Status] int not null default 'Pending',
Primary key (CustomerID,ProductID),
foreign key (CustomerID) references Customers
on delete no action
on update cascade,
foreign key (ProductID) references Products
on delete no action
on update cascade
);

CREATE TABLE Incart(
CustomerID int not null,
ProductID int not null,
quantity int not null,
prodim varchar(100),
price int not null,

foreign key (CustomerID) references Customers, 
foreign key (ProductID) references Products
)


INSERT INTO Admins
values
('Dina','Maged','dina@gmail.com','manial',011500,100000)

INSERT INTO Subscriber
values
('Dina_Maged','987654',1,null,null,null,'Admin')


go
--------------------Customer Sign up---------------
create procedure CustomerSignup
@Fname varchar(50),
@Lname varchar(50),
@Email varchar(50),
@PhoneNumber int,
@address varchar(50),
@birthdate date
As
begin
insert into Customers(Fname,Lname,Email,[PhoneNumber],[Address],Birthdate,Points)
values(@Fname,@Lname,@Email ,@PhoneNumber ,@Address, @birthdate,0)
end

go
------------------Seller Sign up-------------
create procedure SellerSignup
@Fname varchar(50),
@Lname varchar(50),
@Email varchar(50),
@PhoneNumber int,
@address varchar(50),
@birthdate date
As
begin
insert into Sellers(Fname,Lname,Email,[PhoneNumber],[Address],Birthdate, Rating, Profit, Income)
values(@Fname,@Lname,@Email ,@PhoneNumber ,@address, @birthdate,5,0,0)
end
go

-------Add promocode-----
create PROCEDURE [AddPromocode]
	@promoid varchar(50),
	@discountprecent int
AS
BEGIN
	
	Insert into PromoCodes(PromoID,DiscountPrecentage)
	values (@promoid,@discountprecent)
END
GO





------Get ALL Admin Usernames-----
create procedure [GetAllAdminsUserNames]
AS
BEGIN
select UserName from Subscriber where UserType='Admin'
END
GO

---------get password from username
Create procedure [getpassfromusername]
@username varchar(50),
@oldpass varchar(50)
AS
BEGIN
select [PassWord] 
FROM Subscriber
where Username=@username
END
GO



-------Insert Admin-------
Create procedure [InsertAdmin]
@Fname varchar(50),
@Lname varchar(50),
@PhoneNumber int,
@address varchar(50),
@Email varchar(50),
@salary int
AS
BEGIN
insert into Admins(Fname,Lname,PhoneNumber,address,Email,Salary)
values(@Fname,@Lname,@PhoneNumber,@address ,@Email ,@salary)
END
GO



---------Insert Customer Service-----
Create procedure [InsertCustomerService]
	-- Add the parameters for the stored procedure here
	@Fname varchar(50),
    @Lname varchar(50),
	@PhoneNumber int,
	@Address varchar(50),
	@Email varchar(50),
	@workinghours int,
	@salary int,
	@superid int
AS
BEGIN
INSERT INTO CustomerService(Fname,Lname,PhoneNumber,[Address],Email,WorkingHours,Salary,SuperID)
Values (@Fname,@Lname,@PhoneNumber,@Address,@Email,@WorkingHours,@salary,@superid)
END
GO



------Remove Promocode------
Create PROCEDURE [RemovePromocode]
	@promoid varchar(50)
AS
BEGIN
	Delete from PromoCodes
	where PromoID=@promoid
END
go


---------Update Admin---------
create procedure [UpdateAdmin]
@username varchar(50),
@Fname varchar(50),
@Lname varchar(50),
@PhoneNumber int,
@Address varchar(100)
AS
BEGIN
update admins
set Fname=@Fname,Lname=@Lname,PhoneNumber=@PhoneNumber,[Address]=@Address
where AdminID in(
select AdminId
from Subscriber
where Username=@username
)
END
go

-------Update Promocode---------
Create PROCEDURE [UpdatePromocode]
	@promoid varchar(50),
	@discountprecent int
AS
BEGIN
	update PromoCodes
	set PromoID=@promoid,DiscountPrecentage=@discountprecent
END
go



----------Update Admin Subscriber--------
Create procedure updatesubsAdmin
@username varchar(50),
@newpassword varchar(50)
AS
BEGIN
update Subscriber
set [Password]=@newpassword
where Username=@username
END

