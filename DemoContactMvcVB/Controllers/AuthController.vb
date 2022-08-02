Imports DemoContactMvcVB.Tools.DbConnectionExtensions

Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Web.Mvc

Namespace Controllers
    Public Class AuthController
        Inherits BaseController

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

            Try
                Using dbConnection As DbConnection = New SqlConnection()
                    dbConnection.ConnectionString = ConnectionString
                    dbConnection.ExecuteNonQuery("TSP_Register", True, New With {Key .Email = form.Email, .Passwd = form.Passwd})
                    Return RedirectToAction("Login")
                End Using
            Catch ex As Exception
                ModelState.AddModelError("", ex.Message)
                Return View(form)
            End Try
        End Function

        Function Login() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Function Login(form As LoginForm) As ActionResult
            If Not ModelState.IsValid Then
                Return View(form)
            End If

            Try
                Using dbConnection As DbConnection = New SqlConnection()
                    dbConnection.ConnectionString = ConnectionString
                    Dim Id As Integer? = CType(dbConnection.ExecuteScalar("TSP_Authorize", True, New With {Key .Email = form.Email, .Passwd = form.Passwd}), Integer?)

                    If Not Id.HasValue Then
                        ModelState.AddModelError("", "Bad email or password!")
                        Return View(form)
                    End If

                    SessionManager.UserId = Id
                    Return RedirectToAction("Index", "Contact")
                End Using
            Catch ex As Exception
                ModelState.AddModelError("", ex.Message)
                Return View(form)
            End Try


            If Not ModelState.IsValid Then
                Return View(form)
            End If
        End Function

        Function Logout() As ActionResult
            Session.Abandon()
            Return RedirectToAction("Index", "Home")
        End Function
    End Class
End Namespace