Imports System.ComponentModel.DataAnnotations

Public Class LoginForm
    <Required>
    <EmailAddress>
    Public Property Email As String
    <Required>
    <DataType(DataType.Password)>
    Public Property Passwd As String
End Class
