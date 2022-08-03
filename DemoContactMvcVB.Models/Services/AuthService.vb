Imports System.Data.Common
Imports System.Data.SqlClient
Imports DemoContactMvcVB.Tools

Public Class AuthService
    Private ReadOnly _dbConnection As DbConnection

    Public Sub New(dbConnection As DbConnection)
        _dbConnection = dbConnection
    End Sub

    Public Function Register(email As String, passwd As String) As Result
        Using _dbConnection
            Try
                _dbConnection.ExecuteNonQuery("TSP_Register", True, New With {Key .Email = email, .Passwd = passwd})
                Return Result.Success
            Catch ex As Exception
                Return Result.Failure(ex.Message)
            End Try
        End Using
    End Function

    Public Function Login(email As String, passwd As String) As Integer
        Using _dbConnection
            Dim result As Object = _dbConnection.ExecuteScalar("TSP_Authorize", True, New With {Key .Email = email, .Passwd = passwd})
            If result Is Nothing Then
                Return -1
            End If
            Return CType(result, Integer)
        End Using
    End Function
End Class
