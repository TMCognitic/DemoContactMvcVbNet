@ModelType DemoContactMvcVB.DisplayContactFull
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>DisplayContactFull</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.LastName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LastName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FirstName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FirstName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BirthDay)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BirthDay)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Phone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Phone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UserId)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UserId)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
