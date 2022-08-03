Public Class Result
    Public ReadOnly Property IsSuccess() As Boolean

    Public ReadOnly Property IsFailure() As Boolean
        Get
            Return Not IsSuccess
        End Get
    End Property

    Public ReadOnly Property ErrorMessage() As String

    Private Sub New(isSuccess As Boolean, errorMessage As String)
        Me.IsSuccess = isSuccess
        Me.ErrorMessage = errorMessage
    End Sub

    Public Shared Function Success() As Result
        Return New Result(True, Nothing)
    End Function

    Public Shared Function Failure(errorMessage As String) As Result
        If String.IsNullOrEmpty(errorMessage) Or String.IsNullOrWhiteSpace(errorMessage) Then
            Throw New ArgumentException(NameOf(errorMessage), "Veuillez spécifier le message d'erreur")
        End If

        Return New Result(False, errorMessage)
    End Function
End Class
