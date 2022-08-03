Imports System.ComponentModel.DataAnnotations

Public Class EditContactForm
    <HiddenInput>
    Public Property Id As Integer
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
