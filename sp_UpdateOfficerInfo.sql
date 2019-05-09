USE MilitaryComms
GO

CREATE PROCEDURE sp_UpdateOfficerInfo
@Officer		int,
@FirstName		varchar(50),
@LastName		varchar(50),
@Age			int,
@Rank			int,
@Username		varchar(50),
@Password		varchar(50)
AS
UPDATE Officers
SET FirstName   = @FirstName, 
	LastName	= @LastName,
	Age			= @Age,
	[Rank]		= @Rank,
	Username	= @Username,
	[Password]  = @Password
WHERE OfficerID = @Officer
GO;