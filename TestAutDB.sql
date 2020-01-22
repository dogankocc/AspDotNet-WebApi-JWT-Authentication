CREATE TABLE UserMaster
(
  UserID INT PRIMARY KEY,
  UserName VARCHAR(50),
  UserPassword VARCHAR(50),
  UserRoles VARCHAR(500),
  UserEmailID VARCHAR(100),
)
GO
INSERT INTO UserMaster VALUES(101, 'Anurag', '123456', 'Admin', 'Anurag@g.com')
INSERT INTO UserMaster VALUES(102, 'Priyanka', 'abcdef', 'User', 'Priyanka@g.com')
INSERT INTO UserMaster VALUES(103, 'Sambit', '123pqr', 'SuperAdmin', 'Sambit@g.com')
INSERT INTO UserMaster VALUES(104, 'Pranaya', 'abc123', 'Admin, User', 'Pranaya@g.com')

-- Create ClientMaster table
CREATE TABLE ClientMaster
(
  ClientKeyId INT PRIMARY KEY IDENTITY,
  ClientId VARCHAR(500),
  ClientSecret VARCHAR(500),
  ClientName VARCHAR(100),
  CreatedOn DateTime
)
GO
-- Populate the ClientMaster with test data
 INSERT INTO ClientMaster(ClientId, ClientSecret, ClientName, CreatedOn) 
 VALUES(NEWID(), NEWID(), 'Login', GETDATE())
 INSERT INTO ClientMaster(ClientId, ClientSecret, ClientName, CreatedOn) 
 VALUES(NEWID(), NEWID(), 'Register', GETDATE())
 INSERT INTO ClientMaster(ClientId, ClientSecret, ClientName, CreatedOn) 
 VALUES(NEWID(), NEWID(), 'My Client3', GETDATE())

 select * from ClientMaster
 select * from UserMaster
