@ModelType DemoContactMvcVB.Tools.Result

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>Erreur</title>
</head>
<body>
    <hgroup>
        <h1>Erreur.</h1>
        <h2>Une erreur s'est produite pendant le traitement de votre demande.</h2>
    </hgroup>
    @If Not (Model Is Nothing) Then
        @<div class="container body-content">
            <p Class="alert-danger">@Model.ErrorMessage</p>
        </div>
    End If
</body>
</html>
