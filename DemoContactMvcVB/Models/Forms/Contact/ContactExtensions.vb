Imports System.Runtime.CompilerServices
Imports DemoContactMvcVB.Models

Module ContactExtensions
    <Extension>
    Public Function ToDisplayLight(entity As Contact) As DisplayContactLight
        Return New DisplayContactLight() With {.Id = entity.Id, .LastName = entity.LastName, .FirstName = entity.FirstName}
    End Function

    <Extension>
    Public Function ToDisplayFull(entity As Contact) As DisplayContactFull
        Return New DisplayContactFull() With {.Id = entity.Id, .LastName = entity.LastName, .FirstName = entity.FirstName, .BirthDay = entity.BirthDay, .Email = entity.Email, .Phone = entity.Phone}
    End Function

    <Extension>
    Public Function ToEditContactForm(entity As Contact) As EditContactForm
        Return New EditContactForm() With {.Id = entity.Id, .LastName = entity.LastName, .FirstName = entity.FirstName, .BirthDay = entity.BirthDay, .Email = entity.Email, .Phone = entity.Phone}
    End Function
End Module
