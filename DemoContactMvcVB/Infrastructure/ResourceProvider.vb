Imports System.Data.Common
Imports System.Data.SqlClient
Imports DemoContactMvcVB.Models
Imports Microsoft.Extensions.DependencyInjection

Public Class ResourceProvider
    Private Shared _instance As ResourceProvider

    Public Shared ReadOnly Property Instance As ResourceProvider
        Get
            If _instance Is Nothing Then
                _instance = New ResourceProvider()
            End If
            Return _instance
        End Get
    End Property

    Private _container As IServiceProvider

    Private Sub New()
        Dim services As IServiceCollection = New ServiceCollection()
        ConfigureServices(services)
        _container = services.BuildServiceProvider()
    End Sub

    Private Sub ConfigureServices(services As IServiceCollection)
        services.AddTransient(Of DbConnection)(Function(sp) New SqlConnection(ConfigurationManager.ConnectionStrings("DemoContact").ConnectionString))
        services.AddScoped(Of ContactService)()
        services.AddScoped(Of AuthService)()
    End Sub

    Public ReadOnly Property ServiceProvider() As IServiceProvider
        Get
            Return _container.CreateScope().ServiceProvider
        End Get
    End Property
End Class
