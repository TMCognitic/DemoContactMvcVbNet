Imports System.Web.Mvc

Namespace Controllers
    Public MustInherit Class BaseController
        Inherits Controller

        Protected ReadOnly Property ConnectionString As String
            Get
                Return ConfigurationManager.ConnectionStrings("DemoContact").ConnectionString
            End Get
        End Property

    End Class
End Namespace