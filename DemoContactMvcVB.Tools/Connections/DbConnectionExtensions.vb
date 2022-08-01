Imports System.Data.Common
Imports System.Reflection
Imports System.Runtime.CompilerServices

Public Module DbConnectionExtensions
    <Extension>
    Public Function ExecuteNonQuery(dbConnection As DbConnection, query As String,
                                    Optional isStoredProcedure As Boolean = False, Optional parameters As Object = Nothing) As Integer
        Using dbCommand As DbCommand = dbConnection.CreateCommand()
            dbCommand.CommandText = query

            If isStoredProcedure Then
                dbCommand.CommandType = CommandType.StoredProcedure
            End If

            If Not (parameters Is Nothing) Then
                Dim properties As IEnumerable(Of PropertyInfo) = parameters.GetType().GetProperties()

                For Each propertyInfo As PropertyInfo In properties
                    Dim dbParameter As DbParameter = dbCommand.CreateParameter()
                    dbParameter.ParameterName = propertyInfo.Name
                    dbParameter.Value = If(propertyInfo.GetMethod.Invoke(parameters, Nothing), DBNull.Value)
                    dbCommand.Parameters.Add(dbParameter)
                Next
            End If

            dbConnection.Open()
            Return dbCommand.ExecuteNonQuery()
        End Using
    End Function

    <Extension>
    Public Function ExecuteScalar(dbConnection As DbConnection, query As String,
                                    Optional isStoredProcedure As Boolean = False, Optional parameters As Object = Nothing) As Object
        Using dbCommand As DbCommand = dbConnection.CreateCommand()
            dbCommand.CommandText = query

            If isStoredProcedure Then
                dbCommand.CommandType = CommandType.StoredProcedure
            End If

            If Not (parameters Is Nothing) Then
                Dim properties As IEnumerable(Of PropertyInfo) = parameters.GetType().GetProperties()

                For Each propertyInfo As PropertyInfo In properties
                    Dim dbParameter As DbParameter = dbCommand.CreateParameter()
                    dbParameter.ParameterName = propertyInfo.Name
                    dbParameter.Value = If(propertyInfo.GetMethod.Invoke(parameters, Nothing), DBNull.Value)
                    dbCommand.Parameters.Add(dbParameter)
                Next
            End If

            dbConnection.Open()
            Dim result As Object = dbCommand.ExecuteScalar()
            Return If(TypeOf (result) Is DBNull, Nothing, result)
        End Using
    End Function
End Module
