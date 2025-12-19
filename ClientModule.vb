Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Module ClientModule

    Public client As TcpClient
    Private clientStream As NetworkStream
    Private reader As IO.StreamReader
    Private writer As IO.StreamWriter
    Private receiveThread As Thread

    Public serverIP As String = "127.0.0.1"
    Public serverPort As Integer = 5000

    Public isConnected As Boolean = False

    ' 🔑 PC ID (important!)
    Public PCID As String = Environment.MachineName

    ' ==========================
    ' CONNECT TO SERVER
    ' ==========================
    Public Sub ConnectToServer()
        Try
            client = New TcpClient()
            client.Connect(serverIP, serverPort)

            clientStream = client.GetStream()
            reader = New IO.StreamReader(clientStream, Encoding.UTF8)
            writer = New IO.StreamWriter(clientStream, Encoding.UTF8) With {.AutoFlush = True}

            isConnected = True
            Console.WriteLine("Connected to server.")

            ' 🔑 REGISTER PC
            writer.WriteLine("REGISTER|" & PCID)

            receiveThread = New Thread(AddressOf ReceiveData)
            receiveThread.IsBackground = True
            receiveThread.Start()

        Catch ex As Exception
            isConnected = False
            Console.WriteLine("Failed to connect: " & ex.Message)
        End Try
    End Sub

    ' ==========================
    ' SEND MESSAGE
    ' ==========================
    Public Sub SendMessage(message As String)
        If isConnected Then
            Try
                writer.WriteLine(message)
            Catch ex As Exception
                Console.WriteLine("Send failed: " & ex.Message)
            End Try
        End If
    End Sub

    ' ==========================
    ' RECEIVE LOOP
    ' ==========================
    Private Sub ReceiveData()
        Try
            While isConnected
                Dim msg As String = reader.ReadLine()
                If msg Is Nothing Then Exit While
                ProcessServerCommand(msg)
            End While
        Catch ex As Exception
            Console.WriteLine("Disconnected: " & ex.Message)
        Finally
            isConnected = False
        End Try
    End Sub

    ' ==========================
    ' PROCESS SERVER COMMANDS
    ' ==========================
    Private Sub ProcessServerCommand(msg As String)
        Dim parts() As String = msg.Split("|"c)

        Select Case parts(0).ToUpper()

            Case "START_SESSION"
                ' START_SESSION|PCID|SessionType|Amount
                If parts(1) <> PCID Then Exit Sub

                Dim amount As Decimal = Decimal.Parse(parts(3))
                CLIENTDASHBOARD.Invoke(Sub()
                                           CLIENTDASHBOARD.Hide()
                                           CLIENTSESSION.SetPCName(PCID)
                                           CLIENTSESSION.SetAmount(amount)
                                           CLIENTSESSION.SetTime("00:00:00")
                                           CLIENTSESSION.Show()
                                           CLIENTSESSION.StartSessionTimer()
                                       End Sub)

            Case "END_SESSION"
                ' END_SESSION|PCID
                If parts(1) <> PCID Then Exit Sub

                CLIENTSESSION.Invoke(Sub()
                                         CLIENTSESSION.StopSessionTimer()
                                         CLIENTSESSION.Hide()
                                         CLIENTDASHBOARD.Show()
                                     End Sub)

            Case "UPDATE_AMOUNT"
                ' UPDATE_AMOUNT|Amount
                Dim amount As Decimal = Decimal.Parse(parts(1))
                CLIENTSESSION.Invoke(Sub()
                                         CLIENTSESSION.SetAmount(amount)
                                     End Sub)

            Case "SEND_MESSAGE"
                ' SEND_MESSAGE|Text
                CLIENTDASHBOARD.Invoke(Sub()
                                           CLIENTDASHBOARD.SetMessage(parts(1))
                                       End Sub)

            Case "SHUTDOWN"
                ' SHUTDOWN|PCID
                If parts(1) <> PCID Then Exit Sub

                CLIENTDASHBOARD.Invoke(Sub()
                                           MessageBox.Show("PC will shutdown in 10 seconds.", "Shutdown",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                       End Sub)

                Thread.Sleep(10000)
                Process.Start("shutdown", "/s /t 0")

            Case Else
                Console.WriteLine("Unknown command: " & msg)
        End Select
    End Sub

    ' ==========================
    ' DISCONNECT CLEANLY
    ' ==========================
    Public Sub DisconnectClient()
        Try
            isConnected = False
            reader?.Close()
            writer?.Close()
            clientStream?.Close()
            client?.Close()
        Catch
        End Try
    End Sub

End Module
