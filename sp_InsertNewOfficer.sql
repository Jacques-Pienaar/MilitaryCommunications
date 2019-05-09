USE MilitaryComms
GO

CREATE PROCEDURE InsertNewOfficer
@FirstName		varchar(50),
@LastName		varchar(50),
@Age			int,
@Rank			int,
@Username		varchar(50),
@Password		varchar(50)
AS
INSERT INTO Officers(FirstName,LastName,Age,[Rank],Username,Password)
VALUES(@FirstName,@LastName,@Age,@Rank,@Username,@Password)
GO;

