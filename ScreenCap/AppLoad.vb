Imports System.Net.Sockets
Imports System.IO

Module Load_App

    Public ListenNumber As Integer = 1863
    Dim G_AppName As String
    Dim TaskBarDir As String = "N:\Nexus\AppWork\NxTaskBar\AppConfig"

    Dim cUser As String = IO.File.ReadAllText("N:\Nexus\AppWork\Settings\CrrntUser\Name")
    Public SystmColor As Color = Color.FromArgb(CInt(IO.File.ReadAllText("N:\Users\" & cUser & "\Configs\SysColr")))

    Sub Load_Me(ByVal AppName As String, ByVal AppIcon As Image, ByVal CPort As Integer)

        Port.Interval = 10
        G_AppName = AppName

        Dim Number_ As Integer = Val(IO.File.ReadAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount"))

        Try

            If IO.Directory.Exists(TaskBarDir & "/" & AppName) = True Then

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(Number_ + 1))
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Prt", CStr(CPort))
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "Ready")
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/CMD", "")
                AppIcon.Save(TaskBarDir & "/" & AppName & "/Icon.png")

            Else
                IO.Directory.CreateDirectory(TaskBarDir & "/" & AppName)
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(Number_ + 1))
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Prt", CStr(CPort))
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "Ready")
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/CMD", "")
                AppIcon.Save(TaskBarDir & "/" & AppName & "/Icon.png")

            End If

        Catch ex As Exception

        End Try

        IO.File.WriteAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount", Number_)

        Port.Enabled = True

    End Sub


    Sub Load_Me2(ByVal AppName As String)

        Dim Number_ As Integer = Val(IO.File.ReadAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount"))
        G_AppName = AppName

        Try

            If IO.Directory.Exists(TaskBarDir & "/" & AppName) = True Then

                
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "True")
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/CMD", "")
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(Number_ + 1))

            Else
                
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "True")
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/CMD", "")
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(Number_ + 1))

            End If

        Catch ex As Exception

        End Try

        IO.File.WriteAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount", Number_ + 1)

        Port.Enabled = True

    End Sub

    Dim WithEvents Port As New Timer

    Private Sub ListenPort(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Port.Tick

        Dim VisState As String = ""

        Try
            VisState = IO.File.ReadAllText(TaskBarDir & "/" & G_AppName & "/CMD")
        Catch ex As Exception

        End Try

        ListenPort()

        If VisState = "0" Then
            My.Application.ApplicationContext.MainForm.Close()
            IO.File.WriteAllText(TaskBarDir & "/" & G_AppName & "/CMD", "")

        ElseIf VisState = "1" Then
            My.Application.ApplicationContext.MainForm.Show()
            My.Application.ApplicationContext.MainForm.Focus()
            IO.File.WriteAllText(TaskBarDir & "/" & G_AppName & "/CMD", "")

            Form1.Timer1.Interval = 1
            Form1.Panel1.Dock = DockStyle.None
            Form1.Panel1.Visible = True
            Form1.Opacity = 70 / 100
            Form1.Panel1.Size = New Drawing.Size(124, 107)
            Form1.BackColor = Color.White
            Form1.WindowState = FormWindowState.Maximized

            Form1.Show()
            Form1.Timer1.Start()

        ElseIf VisState = "2" Then
            My.Application.ApplicationContext.MainForm.Hide()
            IO.File.WriteAllText(TaskBarDir & "/" & G_AppName & "/CMD", "")

        ElseIf VisState = "3" Then
            CaptureForm.Close()
            IO.File.WriteAllText(TaskBarDir & "/" & G_AppName & "/CMD", "")

        ElseIf VisState = "4" Then
            CaptureForm.Show()
            CaptureForm.Focus()
            IO.File.WriteAllText(TaskBarDir & "/" & G_AppName & "/CMD", "")


        ElseIf VisState = "5" Then
            CaptureForm.Hide()
            IO.File.WriteAllText(TaskBarDir & "/" & G_AppName & "/CMD", "")


        End If

    End Sub

    Dim localhost As Net.IPAddress = Net.Dns.GetHostEntry("localhost").AddressList(1)
    Dim Listener As New TcpListener(localhost, ListenNumber)

    Dim client As TcpClient
    Dim message As String

    Sub ListenPort()

        Try

            Listener.Start()

            If Listener.Pending = True Then
                message = ""
                client = Listener.AcceptTcpClient
                Dim streamr As New StreamReader(client.GetStream())
                While streamr.Peek > -1
                    message = message + Convert.ToChar(streamr.Read()).ToString
                End While
                CMD(message)

            End If


        Catch ex As Exception

        End Try

    End Sub


    Sub CMD(ByVal Line As String)

        If Line.StartsWith("+") Then



        End If

    End Sub


    Sub Close_Me(ByVal AppName As String)

        Dim Cont As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount")

        Try

            If IO.Directory.Exists(TaskBarDir & "/" & AppName) = True Then

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(0))

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "False")


            Else
                IO.Directory.CreateDirectory(TaskBarDir & "/" & AppName)

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(0))

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "False")


            End If

        Catch ex As Exception

        End Try

        IO.File.WriteAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount", Val(Cont - 1))

    End Sub


    Sub Close_Me2(ByVal AppName As String)

        Dim Cont As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount")

        Try

            If IO.Directory.Exists(TaskBarDir & "/" & AppName) = True Then

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(0))

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "False")


            Else
                IO.Directory.CreateDirectory(TaskBarDir & "/" & AppName)

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(0))

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "False")


            End If

        Catch ex As Exception
            MsgBox(ex.Message, Nothing, "SC")
        End Try

        IO.File.WriteAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount", Val(Cont - 1))


    End Sub

    Sub Speak(ByVal Owner As String, ByVal CMD As String, ByVal tipe As String)

        client = New TcpClient("localhost", 2000)
        Dim streamw As New StreamWriter(client.GetStream())
        streamw.Write(Owner & "|" & CMD & ";" & tipe)
        streamw.Flush()

    End Sub


    'Sub Maximiced()

    '    Dim Value As String

    '    Try
    '        Value = IO.File.ReadAllText("N:\NexusFrameWork\Interface\Not Touch")
    '    Catch ex As Exception
    '        Value = IO.File.ReadAllText("N:\NexusFrameWork\Interface\Not Touch")

    '    End Try

    '    Dim X As Integer = Val(Value) + 1

    '    Try
    '        IO.File.WriteAllText("N:\NexusFrameWork\Interface\Not Touch", CStr(X))
    '    Catch ex As Exception
    '        IO.File.WriteAllText("N:\NexusFrameWork\Interface\Not Touch", CStr(X))

    '    End Try

    'End Sub


    'Sub NotMaximiced()

    '    Dim Value As String

    '    Try
    '        Value = IO.File.ReadAllText("N:\NexusFrameWork\Interface\Not Touch")
    '    Catch ex As Exception
    '        Value = IO.File.ReadAllText("N:\NexusFrameWork\Interface\Not Touch")
    '    End Try

    '    Dim X As Integer = Val(Value) - 1

    '    Try
    '        IO.File.WriteAllText("N:\NexusFrameWork\Interface\Not Touch", CStr(X))
    '    Catch ex As Exception
    '        IO.File.WriteAllText("N:\NexusFrameWork\Interface\Not Touch", CStr(X))
    '    End Try


    'End Sub

End Module