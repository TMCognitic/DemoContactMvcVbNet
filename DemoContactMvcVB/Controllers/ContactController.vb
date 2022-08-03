Imports DemoContactMvcVB.Models
Imports Microsoft.Extensions.DependencyInjection

Namespace Controllers
    <AuthRequired>
    Public Class ContactController
        Inherits BaseController

        Private ReadOnly _contactService As ContactService

        Public Sub New()
            _contactService = ServiceProvider.GetService(Of ContactService)()
        End Sub

        ' GET: Contact
        Function Index() As ActionResult
            Try
                Dim contacts As IEnumerable(Of Contact) = _contactService.GetAll(SessionManager.UserId)
                Return View(contacts.Select(Function(c) c.ToDisplayLight()))
            Catch ex As Exception
                ViewBag.Error = ex.Message
                Return View(New List(Of DisplayContactLight)())
            End Try
        End Function

        ' GET: Contact/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Try
                Dim contact As Contact = _contactService.GetOne(SessionManager.UserId, id)
                If contact Is Nothing Then
                    Return RedirectToAction("Index")
                End If
                Return View(contact.ToDisplayFull())
            Catch ex As Exception
                ViewBag.Error = ex.Message
                Return View()
            End Try
        End Function

        ' GET: Contact/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Contact/Create
        <HttpPost()>
        Function Create(form As CreateContactForm) As ActionResult
            Dim contact As New Contact() With {.LastName = form.LastName, .FirstName = form.FirstName, .Email = form.Email, .BirthDay = form.BirthDay, .Phone = form.Phone, .UserId = SessionManager.UserId}
            Return FromResult(_contactService.Insert(contact), Function() RedirectToAction("Index"))
        End Function

        ' GET: Contact/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Try
                Dim contact As Contact = _contactService.GetOne(SessionManager.UserId, id)

                If contact Is Nothing Then
                    Return RedirectToAction("Index")
                End If

                Return View(contact.ToEditContactForm())
            Catch ex As Exception
                ViewBag.Error = ex.Message
                Return View()
            End Try
        End Function

        ' POST: Contact/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, form As EditContactForm) As ActionResult
            Dim contact As New Contact() With {.Id = id, .LastName = form.LastName, .FirstName = form.FirstName, .Email = form.Email, .BirthDay = form.BirthDay, .Phone = form.Phone, .UserId = SessionManager.UserId}
            Return FromResult(_contactService.Update(contact), Function() RedirectToAction("Index"))
        End Function

        ' GET: Contact/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Try
                Dim contact As Contact = _contactService.GetOne(SessionManager.UserId, id)

                If contact Is Nothing Then
                    Return RedirectToAction("Index")
                End If

                Return View(contact.ToDisplayFull())
            Catch ex As Exception
                ViewBag.Error = ex.Message
                Return View()
            End Try
        End Function

        ' POST: Contact/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Return FromResult(_contactService.Delete(SessionManager.UserId, id), Function() RedirectToAction("Index"))
        End Function
    End Class
End Namespace