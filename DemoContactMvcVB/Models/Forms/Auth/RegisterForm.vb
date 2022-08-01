Imports System.ComponentModel.DataAnnotations

Public Class RegisterForm
    <Required>
    <EmailAddress>
    Public Property Email As String
    '<RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{8, 20}$")>
    <Required>
    <DataType(DataType.Password)>
    Public Property Passwd As String
    <Compare(NameOf(Passwd))>
    <DataType(DataType.Password)>
    Public Property Confirm As String
End Class
