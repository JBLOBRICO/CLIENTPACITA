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

    ' PC identity
    Public PCID As String = Environment.MachineName
    Public PCNumber As Integer = -1

    ' ==========================
    ' CONNECT
    ' ==========================
    Public Sub ConnectToServer()
        Try
            client = New TcpClient()
            client.Connect(serverIP, serverPort)

            clientStream = client.GetStream()
            reader = New IO.StreamReader(clientStream, Encoding.UTF8)
            writer = New IO.StreamWriter(clientStream, Encoding.UTF8) With {.AutoFlush = True}

            isConnected = True
            Console.WriteLine("Connected to server")

            ' REGISTER
            writer.WriteLine("REGISTER|" & PCID)

            receiveThread = New Thread(AddressOf ReceiveData)
            receiveThread.IsBackground = True
            receiveThread.Start()

        Catch ex As Exception
            Console.WriteLine("Connect failed: " & ex.Message)
        End Try
    End Sub

    ' ==========================
    ' RECEIVE
    ' ==========================
    Private Sub ReceiveData()
        Try
            While isConnected
                Dim msg = reader.ReadLine()
                If msg Is Nothing Then Exit While
                ProcessServerCommand(msg)
            End While
        Catch
        Finally
            isConnected = False
        End Try
    End Sub

    ' ==========================
    ' PROCESS COMMAND
    ' ==========================
    Private Sub ProcessServerCommand(msg As String)
        Dim parts = msg.Split("|"c)

        Select Case parts(0)

            Case "ASSIGN_PC"
                If parts(1) <> PCID Then Exit Sub

                PCNumber = Integer.Parse(parts(2))

                MessageBox.Show(
        "PC Name: " & PCID & vbCrLf &
        "Assigned PC Number: " & PCNumber,
        "PC Registered",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
    )

            Case "START_SESSION"
                Console.WriteLine("SESSION STARTED")

            Case "END_SESSION"
                Console.WriteLine("SESSION ENDED")

            Case "SHUTDOWN"
                Console.WriteLine("Shutdown command received")

            Case Else
                Console.WriteLine("Server says: " & msg)
        End Select
    End Sub

End Module
