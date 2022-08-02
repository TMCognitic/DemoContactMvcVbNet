@ModelType IEnumerable(Of DemoContactMvcVB.DisplayContactLight)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

@If Not (ViewBag.Error Is Nothing) Then
    @<p class="alert-danger">@ViewBag.Error</p>
Else
    @<p>
        @Html.ActionLink("Create New", "Create")
    </p>
    @<Table Class="table">
        <tr>
        <th>
                @Html.DisplayNameFor(Function(model) model.LastName)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.FirstName)
            </th>
            <th></th>
        </tr>
    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.LastName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.FirstName)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
            </td>
        </tr>
    Next
    </table>
End If
