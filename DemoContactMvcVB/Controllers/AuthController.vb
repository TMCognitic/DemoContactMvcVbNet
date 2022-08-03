Imports DemoContactMvcVB.Models
Imports DemoContactMvcVB.Tools.DbConnectionExtensions

Imports System.Data.Common
Imports System.Data.SqlClient
Imports Microsoft.Extensions.DependencyInjection

Namespace Controllers
    Public Class AuthController
        Inherits BaseController

        Private _authService As AuthService

        Public Sub New()
            _authService = ServiceProvider.GetService(Of AuthService)()
        End Sub

        ' GET: Auth
        Function Index() As ActionResult
            Return RedirectToAction("Login")
        End Function

        Function Register() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Function Register(form As RegisterForm) As ActionResult
            If Not ModelState.IsValid Then
                Return View(form)
            End If

            Return FromResult(_authService.Register(form.Email, form.Passwd), Function() RedirectToAction("Login"))
        End Function

        Function Login() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Function Login(form As LoginForm) As ActionResult
            If Not ModelState.IsValid Then
                Return View(form)
            End If

            Dim userId As Integer = _authService.Login(form.Email, form.Passwd)

            If (userId = -1) Then
                ModelState.AddModelError("", "Bad email or password!")
                Return View(form)
            End If

            SessionManager.UserId = userId
            Return RedirectToAction("Index", "Contact")
        End Function

        <AuthRequired>
        Function Logout() As ActionResult
            Session.Abandon()
            Return RedirectToAction("Index", "Home")
        End Function
    End Class
End Namespace