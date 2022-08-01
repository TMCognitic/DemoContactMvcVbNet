CREATE PROCEDURE TSP_Authorize
    @Email NVARCHAR(384),
    @Passwd NVARCHAR(20)
AS
BEGIN
    SELECT Id 
    From [User]
    WHERE Email = @Email AND Passwd = HASHBYTES('SHA2_512', dbo.TSF_GetPreSalt() + @Passwd + dbo.TSF_GetPostSalt()); 
END