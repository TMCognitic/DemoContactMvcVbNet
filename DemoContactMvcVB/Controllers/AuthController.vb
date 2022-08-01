Imports System.Web.Mvc

Namespace Controllers
    Public Class AuthController
        Inherits Controller

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

            'Inscription dans la DB
            Return RedirectToAction("Login")
        End Function

        Function Login() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Function Login(form As LoginForm) As ActionResult
            If Not ModelState.IsValid Then
                Return View(form)
            End If

            Dim Id As Integer = 0

            If Id = 0 Then
                ModelState.AddModelError("", "Bad email or password!")
                Return View(form)
            End If

            Return RedirectToAction("Index", "Contact")
        End Function
    End Class
End Namespace