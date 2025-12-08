Public Class CLIENTDASHBOARD
    Private Sub CLIENTDASHBOARD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    ' Public method for ClientModule to call
    Public Sub SetMessage(msg As String)
            lblMessage.Text = msg
        End Sub


End Class