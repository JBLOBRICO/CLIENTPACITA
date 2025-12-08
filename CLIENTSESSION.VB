Public Class CLIENTSESSION
    Private Sub CLIENTSESSION_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    ' Public methods for ClientModule to call
    Public Sub SetAmount(amt As Decimal)
        lblAmount.Text = $"₱{amt:0.00}"
    End Sub

    Public Sub SetPCName(name As String)
        lblPC.Text = $"PC: {name}"
    End Sub

    Public Sub SetTime(time As String)
        lblTime.Text = time
    End Sub

    Public Sub StartSessionTimer()
        sessionTimer.Start()
    End Sub

    Public Sub StopSessionTimer()
        sessionTimer.Stop()
    End Sub
End Class
