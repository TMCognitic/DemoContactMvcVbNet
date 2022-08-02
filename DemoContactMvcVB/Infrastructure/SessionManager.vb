Public Class SessionManager

    Public Shared Property UserId() As Integer?
        Get
            If Not (HttpContext.Current.Session.Keys.OfType(Of String)().Contains(NameOf(UserId))) Then
                Return Nothing
            End If
            Return CType(HttpContext.Current.Session(NameOf(UserId)), Integer)
        End Get
        Set(ByVal value As Integer?)
            If Not value.HasValue Then
                Throw New InvalidOperationException()
            End If

            HttpContext.Current.Session(NameOf(UserId)) = value.Value
        End Set
    End Property
End Class
