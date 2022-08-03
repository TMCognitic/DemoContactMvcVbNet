Imports System.Web.Mvc
Imports DemoContactMvcVB.Tools

Namespace Controllers
    Public MustInherit Class BaseController
        Inherits Controller

        Private ReadOnly _ServiceProvider As IServiceProvider


        Protected ReadOnly Property ServiceProvider As IServiceProvider
            Get
                Return _ServiceProvider
            End Get
        End Property

        Protected Sub New()
            _ServiceProvider = ResourceProvider.Instance.ServiceProvider
        End Sub

        Protected Function FromResult(result As Result, Optional actionIfSuccess As Func(Of ActionResult) = Nothing) As ActionResult
            If result.IsSuccess And actionIfSuccess Is Nothing Then
                Return View("Error", Result.Failure("C'est un succès et aucune action n'est définie"))
            End If

            If result.IsFailure Then
                Return View("Error", result)
            End If

            Return actionIfSuccess()
        End Function
    End Class
End Namespace