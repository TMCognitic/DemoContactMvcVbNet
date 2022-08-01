CREATE PROCEDURE TSP_Register
    @Email NVARCHAR(384),
    @Passwd NVARCHAR(20)
AS
BEGIN
    INSERT INTO [User] (Email, Passwd) VALUES (@Email, HASHBYTES('SHA2_512', dbo.TSF_GetPreSalt() + @Passwd + dbo.TSF_GetPostSalt())); 
END