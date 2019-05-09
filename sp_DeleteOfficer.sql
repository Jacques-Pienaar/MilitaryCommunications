USE MilitaryComms
GO

CREATE PROCEDURE sp_DeleteOfficer
@OfficerID		int
AS
DELETE FROM Officers 
WHERE OfficerID = @OfficerID
GO;