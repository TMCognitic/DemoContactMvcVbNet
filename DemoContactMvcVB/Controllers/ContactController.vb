﻿Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Web.Mvc
Imports DemoContactMvcVB.Tools

Namespace Controllers
    Public Class ContactController
        Inherits BaseController

        ' GET: Contact
        Function Index() As ActionResult
            If SessionManager.UserId Is Nothing Then
                Return RedirectToAction("Login", "Auth")
            End If

            Try
                Using dbConnection As DbConnection = New SqlConnection()
                    dbConnection.ConnectionString = ConnectionString
                    Dim contacts As IEnumerable(Of Contact) = dbConnection.ExecuteReader("Select Id, LastName, FirstName, BirthDay, Email, Phone, UserId FROM Contact WHERE UserId = @Id",
                                                                                         Function(dr) dr.ToContact(),
                                                                                         immediately:=True,
                                                                                         parameters:=New With {Key .Id = SessionManager.UserId})

                    Return View(contacts.Select(Function(c) New DisplayContactLight() With {.Id = c.Id, .LastName = c.LastName, .FirstName = c.FirstName}))
                End Using
            Catch ex As Exception
                ViewBag.Error = ex.Message
                Return View(New List(Of DisplayContactLight)())
            End Try
        End Function

        ' GET: Contact/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: Contact/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Contact/Create
        <HttpPost()>
        Function Create(form As CreateContactForm) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Contact/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Contact/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, form As EditContactForm) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Contact/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Contact/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace