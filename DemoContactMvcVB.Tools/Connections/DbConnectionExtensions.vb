Imports System.Data.Common
Imports System.Reflection
Imports System.Runtime.CompilerServices

Public Module DbConnectionExtensions
    <Extension>
    Public Function ExecuteNonQuery(dbConnection As DbConnection, query As String,
                                    Optional isStoredProcedure As Boolean = False, Optional parameters As Object = Nothing) As Integer

        Using dbCommand As DbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters)
            dbConnection.Open()
            Return dbCommand.ExecuteNonQuery()
        End Using
    End Function

    <Extension>
    Public Function ExecuteScalar(dbConnection As DbConnection, query As String,
                                    Optional isStoredProcedure As Boolean = False, Optional parameters As Object = Nothing) As Object
        Using dbCommand As DbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters)
            dbConnection.Open()
            Dim result As Object = dbCommand.ExecuteScalar()
            Return If(TypeOf (result) Is DBNull, Nothing, result)
        End Using
    End Function

    <Extension>
    Public Function ExecuteReader(Of TResult)(dbConnection As DbConnection, query As String, selector As Func(Of IDataRecord, TResult), immediately As Boolean,
                                    Optional isStoredProcedure As Boolean = False, Optional parameters As Object = Nothing) As IEnumerable(Of TResult)
        Dim result As IEnumerable(Of TResult) = ExecuteReader(dbConnection, query, selector, isStoredProcedure, parameters)

        Return If(immediately, result.ToList(), result)
    End Function

    <Extension>
    Public Iterator Function ExecuteReader(Of TResult)(dbConnection As DbConnection, query As String, selector As Func(Of IDataRecord, TResult),
                                    Optional isStoredProcedure As Boolean = False, Optional parameters As Object = Nothing) As IEnumerable(Of TResult)
        If selector Is Nothing Then
            Throw New ArgumentNullException(NameOf(selector))
        End If

        Using dbCommand As DbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters)
            dbConnection.Open()
            Using dataReader As IDataReader = dbCommand.ExecuteReader()
                While dataReader.Read()
                    Yield selector(dataReader)
                End While
            End Using
        End Using
    End Function

    Private Function CreateCommand(dbConnection As DbConnection, query As String, isStoredProcedure As Boolean, parameters As Object) As DbCommand
        Dim dbCommand As DbCommand = dbConnection.CreateCommand()
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
        Return dbCommand
    End Function
End Module
