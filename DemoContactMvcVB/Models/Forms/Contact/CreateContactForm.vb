Imports System.ComponentModel.DataAnnotations

Public Class CreateContactForm
    <Required>
    Public Property LastName As String
    <Required>
    Public Property FirstName As String
    <Required>
    <DataType(DataType.Date)>
    Public Property BirthDay As Date
    <Required>
    <EmailAddress>
    Public Property Email As String
    Public Property Phone As String
End Class