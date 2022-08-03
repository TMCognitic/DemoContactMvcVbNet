<AttributeUsage(AttributeTargets.Method Or AttributeTargets.Class)>
Public Class AuthRequiredAttribute
    Inherits AuthorizeAttribute

    Public Overrides Sub OnAuthorization(filterContext As AuthorizationContext)
        If SessionManager.UserId Is Nothing Then
            filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary(New With {Key .Action = "Login", .Controller = "Auth"}))
        End If
    End Sub
End Class
