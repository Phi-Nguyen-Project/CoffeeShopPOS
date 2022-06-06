-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbSQL3;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
-- Drop Tables
-- --------------------------------------------------------------------------------

IF OBJECT_ID( 'uspChecKIfClockedIn' )				IS NOT NULL DROP PROCEDURE  uspChecKIfClockedIn
IF OBJECT_ID( 'upsGetEmployeeID' )					IS NOT NULL DROP PROCEDURE  upsGetEmployeeID
IF OBJECT_ID( 'upsGiftCardBalance' )				IS NOT NULL DROP PROCEDURE  upsGiftCardBalance
IF OBJECT_ID( 'upsValidatePassword' )				IS NOT NULL DROP PROCEDURE  upsValidatePassword
IF OBJECT_ID( 'upsDisplayInventory' )				IS NOT NULL DROP PROCEDURE  upsDisplayInventory
IF OBJECT_ID( 'upsDisplayEmployees' )				IS NOT NULL DROP PROCEDURE  upsDisplayEmployees
IF OBJECT_ID( 'uspLogin' )							IS NOT NULL DROP PROCEDURE  uspLogin
IF OBJECT_ID( 'upsGiftCard' )						IS NOT NULL DROP PROCEDURE  upsGiftCard
IF OBJECT_ID( 'TItemTransactions' )				    IS NOT NULL DROP TABLE	TItemTransactions
IF OBJECT_ID( 'TSales' )						    IS NOT NULL DROP TABLE	TSales
IF OBJECT_ID( 'TInventory' )						IS NOT NULL DROP TABLE	TInventory
IF OBJECT_ID( 'TMenus' )						    IS NOT NULL DROP TABLE	TMenus
IF OBJECT_ID( 'TTransactions' )						IS NOT NULL DROP TABLE	TTransactions
IF OBJECT_ID( 'TTimes' )						    IS NOT NULL DROP TABLE	TTimes
IF OBJECT_ID( 'TOnclock' )							IS NOT NULL DROP TABLE	TOnclock
IF OBJECT_ID( 'TEmployees' )						IS NOT NULL DROP TABLE	TEmployees
IF OBJECT_ID( 'TStates' )						    IS NOT NULL DROP TABLE	TStates
IF OBJECT_ID( 'TOrders' )						    IS NOT NULL DROP TABLE	TOrders
IF OBJECT_ID( 'TItems' )						    IS NOT NULL DROP TABLE	TItems
IF OBJECT_ID( 'TGiftCards' )						IS NOT NULL DROP TABLE	TGiftCards
IF OBJECT_ID( 'TIsManager' )						IS NOT NULL DROP TABLE	TIsManager


-- --------------------------------------------------------------------------------
-- Step #1: Create Tables
-- --------------------------------------------------------------------------------

CREATE TABLE TEmployees
(
	 intEmployeeID		INTEGER			identity
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strAddress	        VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strUserID			VARCHAR(50)		NOT NULL
	,strPassword		VARCHAR(50)		NOT NULL	
	,strIsManager	    VARCHAR(50)		NOT NULL
	
	
	,CONSTRAINT TEmployees_PK PRIMARY KEY ( intEmployeeID )
)

CREATE TABLE TOrders
(
	 intOrderID			INTEGER			identity
	,intOrderNum		INTEGER			NOT NULL
	,intItemID			INTEGER			NOT NULL
	,monItemPrice		MONEY			NOT NULL
	,dtmSaleDate		DATE			NOT NULL
	,CONSTRAINT TOrders_PK PRIMARY KEY ( intOrderID	)
)

CREATE TABLE  TTimes
(
	 intTimeID			INTEGER			NOT NULL	
	,intEmployeeID		INTEGER			NOT NULL
	,dtmClockIn		    DATETIME		NOT NULL
	,dtmClockOut	    DATETIME		NOT NULL
	,CONSTRAINT TTimes_PK PRIMARY KEY ( intTimeID	)
)

CREATE TABLE TGiftCards
(
	 intGiftCardID		INTEGER			identity
	,strCardNumber		VARCHAR(50)		NOT NULL
	,dblRemainingBalance   MONEY		NOT NULL
	,CONSTRAINT TGiftCards_PK PRIMARY KEY ( intGiftCardID	)
)

CREATE TABLE TStates
(
	 intStateID			INTEGER			NOT NULL
	,strState			VARCHAR(50)	    NOT NULL
	,CONSTRAINT TState_PK PRIMARY KEY ( intStateID	)
)

CREATE TABLE TItems
(
	 intItemID			INTEGER			NOT NULL
	 ,strCategory		VARCHAR(50)		NOT NULL
	,strItemName		VARCHAR(50)		NOT NULL
	,strSize			VARCHAR(50)		
	,monPrice			MONEY			NOT NULL

	,CONSTRAINT TItems_PK PRIMARY KEY ( intItemID	)
)

CREATE TABLE TTransactions
(
	 intTransactionID	INTEGER			NOT NULL
	,intEmployeeID		INTEGER			NOT NULL
	,intOrderID			INTEGER			NOT NULL
	,dtmTransactionDate		DATETIME    NOT NULL
	,dtmTransactionTime		DATETIME    NOT NULL
	,CONSTRAINT TTransactions_PK PRIMARY KEY ( intTransactionID	)
)

CREATE TABLE TItemTransactions
(
	 intItemTransactionID	INTEGER		NOT NULL
	,intTransactionID		INTEGER		NOT NULL
	,intItemID				INTEGER		NOT NULL
	--,CONSTRAINT TItemTransactions_UQ UNIQUE ( intTransactionID, intItemID )
	,CONSTRAINT TItemTransactions_PK PRIMARY KEY ( intItemTransactionID )
)

CREATE TABLE TSales
(
	 intSaleID			INTEGER			NOT NULL
	,intTransactionID	INTEGER			NOT NULL
	,dblTotalAmount     MONEY			NOT NULL
	,CONSTRAINT TSales_PK PRIMARY KEY ( intSaleID	)
)

CREATE TABLE TInventory
(
	 intInventoryID		INTEGER			NOT NULL
	,intItemID			INTEGER			NOT NULL
	,intQuantity		INTEGER			NOT NULL
	,CONSTRAINT TInventory_PK PRIMARY KEY ( intInventoryID	)
)

CREATE TABLE TMenus
(
	 intMenuID			INTEGER			NOT NULL
	,intItemID			INTEGER			NOT NULL
	,CONSTRAINT TMenus_PK PRIMARY KEY ( intMenuID	)
)

CREATE TABLE TOnclock
(
	
	 intOnClockID			INTEGER			identity
	,intEmployeeID			INTEGER			NOT NULL
	,intOnClock				INTEGER			NOT NULL
	,dtmDate				date
	,dtmClockIn				time
	,dtmClockOut			time
	,intHoursWorked			time			
	,CONSTRAINT TOnclock_PK PRIMARY KEY ( intOnClockID	)

)

Create Table TIsManager
(
	 intIsManagerID			INTEGER			NOT NULL
	,strIsManager			VARCHAR(50)		NOT NULL
	,CONSTRAINT TIsManager_PK PRIMARY KEY ( intIsManagerID	)
)
-- --------------------------------------------------------------------------------
-- Step #2: Identify and Create Foreign Keys
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						    Column(s)
-- -	-----							------						    ---------
-- 1	TEmployees					    TStates							intStateID
-- 2	TTimes						    TEmployees						intEmployeeID
-- 3	TTransactions				    TEmployees						intEmployeeID
-- 4	TTransactions				    TOrders							intOrderID
-- 5    TItemTransactions			    TTransactions					intTransactionID
-- 6	TItemTransactions			    TItems							intItemID
-- 7	TSales							TTransactions					intTransactionsID
-- 8	TInventory			            TItems							intItemID
-- 9	TMenus							TItems							intItemID
-- 10	TOrders							TItems							intItemID
--11	TOnclock						TEmployees						intEmployeeID

-- 1
--ALTER TABLE TEmployees ADD CONSTRAINT TEmployees_TStates_FK
--FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID )

-- 2
ALTER TABLE TTimes ADD CONSTRAINT TTimes_TEmployees_FK
FOREIGN KEY ( intEmployeeID ) REFERENCES TEmployees ( intEmployeeID )

-- 3
ALTER TABLE TTransactions ADD CONSTRAINT TTransactions_TEmployees_FK
FOREIGN KEY ( intEmployeeID ) REFERENCES TEmployees ( intEmployeeID )

-- 4
ALTER TABLE TTransactions ADD CONSTRAINT TTransactions_TOrders_FK
FOREIGN KEY ( intOrderID ) REFERENCES TOrders ( intOrderID )

-- 5
ALTER TABLE TItemTransactions ADD CONSTRAINT TItemTransactions_TTransactions_FK
FOREIGN KEY ( intTransactionID ) REFERENCES TTransactions ( intTransactionID )
-- 6
ALTER TABLE TItemTransactions ADD CONSTRAINT TItemTransactions_TItems_FK
FOREIGN KEY ( intItemID ) REFERENCES TItems ( intItemID )

-- 7
ALTER TABLE TSales ADD CONSTRAINT TSales_TTransactions_FK
FOREIGN KEY ( intTransactionID ) REFERENCES TTransactions ( intTransactionID )

-- 8
ALTER TABLE TInventory ADD CONSTRAINT TInventory_TItems_FK
FOREIGN KEY ( intItemID ) REFERENCES TItems ( intItemID )

-- 9
ALTER TABLE TMenus ADD CONSTRAINT TMenus_TItems_FK
FOREIGN KEY ( intItemID ) REFERENCES TItems ( intItemID )

-- 10
ALTER TABLE TOrders ADD CONSTRAINT TOrders_TItems_FK
FOREIGN KEY ( intItemID ) REFERENCES TItems ( intItemID )

ALTER TABLE TOnclock ADD CONSTRAINT TOnclock_TEmployees_FK
FOREIGN KEY ( intEmployeeID ) REFERENCES TEmployees ( intEmployeeID )



---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------
INSERT INTO TStates ( intStateID, strState)
VALUES	 (1, 'OH' )
		,(2, 'KY' )
		,(3, 'IN')
		,(4, 'PA')
		,(5, 'MI')
		,(6, 'WV')
		,(7, 'NY')

-- --------------------------------------------------------------------------------
-- Step #3: Add data to Employee
-- --------------------------------------------------------------------------------
INSERT INTO TEmployees (  strFirstName, strLastName, strAddress, strCity, strState, strZip, strPhoneNumber, strUserID, strPassword, strIsManager  )
VALUES	 ( 'Jackson', 'Lisa', '156 Main St.', 'Mason', 'OH', '45040', '5135559999','djkhatiwada', '12345', 'Yes' )
		,( 'Gray', 'Janette', '3976 Deer Run', 'West Chester', 'OH', '45069', '5135550101','Awet', '56789', 'No' )




	
INSERT INTO TItems ( intItemID, strCategory, strItemName, strSize, monPrice )
VALUES	 (1, 'Coffee', 'Espresso Coffee', 'Small', 3.50 )
		,(2, 'Coffee', 'Espresso Coffee', 'Medium', 4 )
		,(3, 'Coffee', 'Espresso Cofee', 'Large', 4.75 )
		,(4, 'Coffee', 'Latte Coffee', 'Small', 3.70 )
		,(5, 'Coffee', 'Latte Coffee', 'Medium', 4.25 )
		,(6, 'Coffee', 'Latte Coffee', 'Large', 5 )
		,(7, 'Coffee', 'Americano Coffee', 'Small', 3)
		,(8, 'Coffee', 'Americano Coffee', 'Medium', 3.50)
		,(9, 'Coffee', 'Americano Coffee', 'Large', 4.25)
		,(10, 'Coffee', 'Dark Roast Coffee', 'Small', 2.50)
		,(11, 'Coffee', 'Dark Roast Coffee', 'Medium', 3)
		,(12, 'Coffee', 'Dark Roast Coffee', 'Large', 3.75)
		,(13, 'Coffee', 'Blonde Roast Coffee', 'Small', 3)
		,(14, 'Coffee', 'Blonde Roast Coffee', 'Medium', 3.50)
		,(15, 'Coffee', 'Blonde Roast Coffee', 'Large', 4.25)
		,(16, 'Coffee', 'Mocha Coffee', 'Small', 3.75)
		,(17, 'Coffee', 'Mocha Coffee', 'Medium', 4.25)
		,(18, 'Coffee', 'Mocha Coffee', 'Large', 5)
		,(19, 'Coffee', 'White Mocha Coffee', 'Small', 3.75)
		,(20, 'Coffee', 'White Mocha Coffee', 'Medium', 4.25)
		,(21, 'Coffee', 'White Mocha Coffee', 'Large', 5)
		,(22, 'Coffee', 'Machiato Coffee', 'Small', 3.50)
		,(23, 'Coffee', 'Machiato Coffee', 'Medium', 4)
		,(24, 'Coffee', 'Machiato Coffee', 'Large', 4.75)
		,(25, 'Frapuchino', 'Caramel Frapuchino', 'Small', 4.25)
		,(26, 'Frapuchino', 'Caramel Frapuchino', 'Medium', 4.75)
		,(27, 'Frapuchino', 'Caramel Frapuchino', 'Large', 5.50)
		,(28, 'Frapuchino', 'Peppermint Frapuchino', 'Small', 4.25)
		,(29, 'Frapuchino', 'Peppermint Frapuchino', 'Medium', 4.75)
		,(30, 'Frapuchino', 'Peppermint Frapuchino', 'Large', 5.50)
		,(31, 'Frapuchino', 'Mocha Frapuchino', 'Small', 4.25)
		,(32, 'Frapuchino', 'Mocha Frapuchino', 'Medium', 4.75)
		,(33, 'Frapuchino', 'Mocha Frapuchino', 'Large', 5.50)
		,(34, 'Frapuchino', 'White Mocha Frapuchino', 'Small', 4.25)
		,(35, 'Frapuchino', 'White Mocha Frapuchino', 'Medium', 4.75)
		,(36, 'Frapuchino', 'White Mocha Frapuchino', 'Large', 5.50)
		,(37, 'Frapuchino', 'Macha Latte Frapuchino', 'Small', 4.75)
		,(38, 'Frapuchino', 'Macha Latte Frapuchino', 'Medium', 5)
		,(39, 'Frapuchino', 'Macha Latte Frapuchino', 'Large', 5.75)
		,(40, 'Frapuchino', 'Cookie Frapuchino', 'Small', 4.50)
		,(41, 'Frapuchino', 'Cookie Frapuchino', 'Medium', 5.25)
		,(42, 'Frapuchino', 'Cookie Frapuchino', 'Large', 6)
		,(43, 'Dessert', 'Chocolate Chips', 'Small', 4.50)
		,(44, 'Dessert', 'Chocolate Chips', 'Medium', 5.25)
		,(45, 'Dessert', 'Chocolate Chips', 'Large', 6)
		,(46, 'Dessert', 'Apple Gallette', null,  5.25)
		,(47, 'Dessert', 'Waffles ', null,  5)
		,(48, 'Dessert', 'Plain Bagel ', null,  1.75)
		,(49, 'Dessert', 'Flavour Bagel ', null,  2.45)
		,(50, 'Dessert', 'Plain Crosant ', null,  2.95)
		,(51, 'Dessert', 'Flavour Crosant ', null,  3.50)
		,(52, 'Extra', 'Espresso Shot', null,  0.90)
		,(53, 'Extra', 'Sirup Shot', null,  0.50)
		,(54, 'Extra', 'Organic Soymilk', null,  0.60)
		,(55, 'Extra', 'Almond Milk', null,  0.60)
		



INSERT INTO TIsManager(intIsManagerID, strIsManager)
VALUES				(1, 'Yes')
			       ,(2, 'No')
---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------		

INSERT INTO TOrders(intOrderNum,intItemID,monItemPrice,dtmSaleDate)
values (1,1,1,'03-01-2020')


---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

INSERT INTO TTimes ( intTimeID, intEmployeeID, dtmClockIn, dtmClockOut)
VALUES	 (1, 2, 1, 4 )



---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

INSERT INTO TGiftCards(strCardNumber, dblRemainingBalance )
VALUES	 ( 2, 1 )




---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------




---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

	

---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------



---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------


---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

INSERT INTO TInventory( intInventoryID , intItemID, intQuantity )
VALUES	 (1, 1, 1 )
		,(2, 2, 2 )
		,(3, 3, 2 )
		,(4, 4, 2 )
		,(5, 5, 2 )
		,(6, 6, 4 )
		,(7, 7, 4 )
		,(8, 8, 4 )
		,(9, 9, 4 )
		,(10, 10, 4 )
		,(11, 11, 4 )
		,(12, 12, 4 )
		,(13, 13, 4 )
		,(14, 14, 4 )
		,(15, 15, 4 )
		,(16, 16, 4 )
		,(17, 17, 2 )
		,(18, 18, 4 )
		,(19, 19, 4 )
		,(20, 20, 1 )
		,(21, 21, 4 )
		,(22, 22, 4 )
		,(23, 23, 4 )
		,(24, 24, 4 )
		,(25, 25, 2 )
		,(26, 26, 4 )
		,(27, 27, 4 )
		,(28, 28, 4 )
		,(29, 29, 4 )
		,(30, 30, 4 )
		,(31, 31, 4 )
		,(32, 32, 4 )
		,(33, 33, 4 )
		,(34, 34, 4 )
		,(35, 35, 4 )
		,(36, 36, 4 )
		,(37, 37, 4 )
		,(38, 38, 4 )
		,(39, 39, 4 )
		,(40, 40, 4 )
		,(41, 41, 4 )
		,(42, 42, 4 )
		,(43, 43, 4 )
		,(44, 44, 4 )
		,(45, 45, 4 )
		,(46, 46, 4 )
		,(47, 47, 4 )
		,(48, 48, 4 )
		,(49, 49, 4 )
		,(50, 50, 4 )
		,(51, 51, 4 )
		,(52, 52, 4 )
		,(53, 53, 4 )
		,(54, 54, 4 )
		,(55, 55, 4 )




---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

INSERT INTO TMenus( intMenuID, intItemID )
VALUES	 (1, 2 )
		


INSERT INTO TOnclock(intEmployeeID, intOnClock,dtmDate, dtmClockIn, dtmClockOut,intHoursWorked)
VALUES	 (1 ,2, Null, Null, Null,Null)
		,(2,2, Null, Null, Null,Null)
		
go
create procedure upsDisplayInventory
as
select it.intItemID as ID, It.strItemName as Names, Inv.intQuantity as Quantity, It.strSize as Size , it.monPrice as Price
from TInventory As Inv
join TItems As It on  
It.intItemID = Inv.intItemID

go

Create procedure uspLogin
@UserName varchar(50),
@Password varchar(50),
@result int output
as begin
set Nocount on;
if exists(select *
	 from  TEmployees as TE
	 join TOnclock as TOC
	 on te.intEmployeeID = toc.intEmployeeID
	 where te.strPassword like @Password and 
	 te.strIsManager = 'Yes' and toc.intOnClock = 1)
	 set @result = 1
else if exists(select *
	 from  TEmployees as TE
	 join TOnclock as TOC
	 on te.intEmployeeID = toc.intEmployeeID
	 where te.strPassword like @Password and 
	 te.strIsManager = 'No' and toc.intOnClock = 1)
	 set @result = 2
else
	 set @result = 0
	 return @result
end
go

 
create procedure upsDisplayEmployees
as
select TE.intEmployeeID, TE.strFirstName, TE.strLastName, TE.strAddress, TE.strCity
,TE.strState, TE.strZip, TE.strPhoneNumber, TE.strUserID, TE.strPassword, TE.strIsManager
from TEmployees As TE


go
Create procedure upsGiftCard

@Number varchar(50),
@result int output
as begin
set Nocount on;
	if exists(select *
		from  TGiftCards		
		where strCardNumber like @Number)
		set @result = 1
	else
	 
	 set @result = 0
	 return @result
end
go

Create procedure upsGiftCardBalance
@Number varchar(50),
@Balance money output

 as begin
 set Nocount on;
		select @Balance = dblRemainingBalance
		from TGiftCards as TG where strCardNumber = @Number
		
		return @Balance
		end
	go

Create procedure upsValidatePassword

@Password varchar(50),
@result int output
as begin
set Nocount on;
 if exists(select intEmployeeID
 from TEmployees where strPassword = @Password)
 set @result = 1
 else
 set @result = 0
 return @result
end
go
Create procedure upsGetEmployeeID

@Password varchar(50),
@EmployeeID int output
as begin
set Nocount on;
 select @EmployeeID = intEmployeeID
 from TEmployees where strPassword = @Password
	 return @EmployeeID
end

go
Create procedure uspChecKIfClockedIn
@Password varchar(50),
@result int output
as begin
set Nocount on;
		select top 1 @result =  TOC.intOnClock
		from TOnclock As TOC
		join TEmployees AS TE
		on TE.intEmployeeID = TOC.intEmployeeID
		where TE.strPassword = @Password
		order by TOC.intOnClockID desc
		return @result
end


go


	SELECT TI.intItemID ,TI.strItemName, TI.strSize, TI.monPrice, TOR.intOrderID,TOR.intOrderNum
                        FROM TOrders AS TOR	,TItems AS TI
                        WHERE TOR.intItemID = TI.intItemID 
                            AND TOR.intOrderNum =5 





 select *from TEmployees
 select * from TGiftCards
--SELECT * FROM TEmployees
--SELECT * FROM TOrders
--SELECT * FROM TTimes
--SELECT * FROM TGiftCards
--SELECT * FROM TStates
--SELECT * FROM TItems
--SELECT * FROM TTransactions
--SELECT * FROM TItemTransactions
--SELECT * FROM TSales
--SELECT * FROM TInventory
--SELECT * FROM TMenus
