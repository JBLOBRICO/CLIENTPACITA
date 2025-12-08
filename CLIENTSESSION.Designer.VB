<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CLIENTSESSION
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Private pnlMini As Panel
    Private lblPC As Label
    Private lblTime As Label
    Private lblAmount As Label
    Private sessionTimer As Timer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlMini = New System.Windows.Forms.Panel()
        Me.lblPC = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.sessionTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlMini.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMini
        '
        Me.pnlMini.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.pnlMini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMini.Controls.Add(Me.lblPC)
        Me.pnlMini.Controls.Add(Me.lblTime)
        Me.pnlMini.Controls.Add(Me.lblAmount)
        Me.pnlMini.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMini.Location = New System.Drawing.Point(0, 0)
        Me.pnlMini.Name = "pnlMini"
        Me.pnlMini.Size = New System.Drawing.Size(200, 100)
        Me.pnlMini.TabIndex = 0
        '
        'lblPC
        '
        Me.lblPC.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPC.ForeColor = System.Drawing.Color.White
        Me.lblPC.Location = New System.Drawing.Point(5, 5)
        Me.lblPC.Name = "lblPC"
        Me.lblPC.Size = New System.Drawing.Size(190, 20)
        Me.lblPC.TabIndex = 0
        Me.lblPC.Text = "PC: MyPC"
        Me.lblPC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTime
        '
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTime.ForeColor = System.Drawing.Color.LightGreen
        Me.lblTime.Location = New System.Drawing.Point(5, 30)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(190, 20)
        Me.lblTime.TabIndex = 1
        Me.lblTime.Text = "00:00:00"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAmount
        '
        Me.lblAmount.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAmount.ForeColor = System.Drawing.Color.Gold
        Me.lblAmount.Location = New System.Drawing.Point(5, 55)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(190, 20)
        Me.lblAmount.TabIndex = 2
        Me.lblAmount.Text = "₱0.00"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sessionTimer
        '
        Me.sessionTimer.Interval = 1000
        '
        'CLIENTSESSION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(200, 100)
        Me.Controls.Add(Me.pnlMini)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(10, 10)
        Me.Name = "CLIENTSESSION"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Client Mini"
        Me.TopMost = True
        Me.pnlMini.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
End Class
