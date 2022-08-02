Imports System.Runtime.CompilerServices

Module DataRecordExtensions
    <Extension>
    Public Function ToContact(dataRecord As IDataRecord) As Contact
        Return New Contact() With {.Id = CType(dataRecord("Id"), Integer),
                                    .LastName = CType(dataRecord("LastName"), String),
                                    .FirstName = CType(dataRecord("FirstName"), String),
                                    .BirthDay = CType(dataRecord("BirthDay"), Date),
                                    .Email = CType(dataRecord("Email"), String),
                                    .Phone = If(TypeOf (dataRecord("Phone")) Is DBNull, Nothing, CType(dataRecord("Phone"), String)),
                                    .UserId = CType(dataRecord("UserId"), Integer)}
    End Function
End Module
