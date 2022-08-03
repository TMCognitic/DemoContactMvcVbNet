Imports System.Data.Common
Imports System.Data.SqlClient
Imports DemoContactMvcVB.Tools

Public Class ContactService

    Private ReadOnly _dbConnection As DbConnection

    Public Sub New(dbConnection As DbConnection)
        _dbConnection = dbConnection
    End Sub

    Public Function GetAll(userId As Integer) As IEnumerable(Of Contact)
        Using _dbConnection
            Return _dbConnection.ExecuteReader("Select Id, LastName, FirstName, BirthDay, Email, Phone, UserId FROM Contact WHERE UserId = @Id And IsDeleted = 0",
                                              Function(dr) dr.ToContact(),
                                              immediately:=True,
                                              parameters:=New With {Key .Id = userId})
        End Using
    End Function

    Public Function GetOne(userId As Integer, id As Integer) As Contact
        Using _dbConnection
            Return _dbConnection.ExecuteReader("Select Id, LastName, FirstName, BirthDay, Email, Phone, UserId FROM Contact WHERE UserId = @UserId AND Id = @Id And IsDeleted = 0",
                                              Function(dr) dr.ToContact(),
                                              immediately:=True,
                                              parameters:=New With {Key .UserId = userId, .Id = id}).SingleOrDefault()
        End Using
    End Function

    Public Function Insert(contact As Contact) As Result
        Try
            Using _dbConnection
                _dbConnection.ExecuteNonQuery("Insert Into Contact (LastName, FirstName, BirthDay, Email, Phone, UserId) VALUES (@LastName, @FirstName, @BirthDay, @Email, @Phone, @UserId);",
                                             parameters:=New With {Key .LastName = contact.LastName, .FirstName = contact.FirstName, .BirthDay = contact.BirthDay, .Email = contact.Email, .Phone = contact.Phone, .UserId = contact.UserId})
                Return Result.Success()
            End Using
        Catch ex As Exception
            Return Result.Failure(ex.Message)
        End Try
    End Function

    Public Function Update(contact As Contact) As Result
        Try
            Using _dbConnection
                _dbConnection.ExecuteNonQuery("Update Contact Set LastName = @LastName, FirstName = @FirstName, BirthDay = @BirthDay, Email = @Email, Phone = @Phone Where UserId = @UserId AND Id = @Id And IsDeleted = 0;",
                                             parameters:=New With {Key .Id = contact.Id, .LastName = contact.LastName, .FirstName = contact.FirstName, .BirthDay = contact.BirthDay, .Email = contact.Email, .Phone = contact.Phone, .UserId = contact.UserId})
                Return Result.Success()
            End Using
        Catch ex As Exception
            Return Result.Failure(ex.Message)
        End Try
    End Function

    Public Function Delete(userid As Integer, id As Integer) As Result
        Try
            Using _dbConnection
                _dbConnection.ExecuteNonQuery("Delete From Contact Where UserId = @UserId And Id = @Id And IsDeleted = 0;",
                                             parameters:=New With {Key .Id = id, .UserId = userid})
                Return Result.Success()
            End Using
        Catch ex As Exception
            Return Result.Failure(ex.Message)
        End Try
    End Function
End Class
