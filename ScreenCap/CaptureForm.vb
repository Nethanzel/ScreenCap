Public Class CaptureForm

    Dim x As Integer, y As Integer, a As Integer = x, b As Integer = y
    Private XY As Point

    Private Sub PictureBox3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseDown
        XY.X = CInt(CLng(x))
        XY.Y = CInt(CLng(y))
    End Sub

    Private Sub PictureBox3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Right Or e.Button = Windows.Forms.MouseButtons.Left Then
            'redimensionamos el ancho
            If (Me.Width + (x + e.X)) > 0 Then

                Me.Width = Me.Width + (x + e.X)
            End If
            'redimensionams el alto
            If (Me.Height + (y + e.Y)) > 0 Then

                Me.Height = Me.Height + (y + e.Y)
            End If
        End If
    End Sub
  
    '________________________________________________
    Private aaa As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
    '_________________________________________________

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = True
            MouseX = e.X
            MouseY = e.Y

        End If

    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove

        If aaa = True Then

            Dim tmp As Point = New Point

            tmp.X = Me.Location.X + (e.X - MouseX)
            tmp.Y = Me.Location.Y + (e.Y - MouseY)
            Me.Location = tmp
            tmp = Nothing

        End If

    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp

        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        'Close_Me2("ScreenCap")
        Form1.Timer1.Enabled = True

        'If Mx = True Then
        '    NotMaximiced()
        'End If

        End
    End Sub

    Dim Min As Boolean = False

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.Hide()
        Min = True
    End Sub

    Dim Mx As Boolean = False

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

        'Maximiced()


        Dim lX As Integer = My.Computer.Screen.WorkingArea.Width
        Dim lY As Integer = My.Computer.Screen.WorkingArea.Height

        Me.Left = 0
        Me.Top = 0

        Me.Width = lX
        Me.Height = lY

        Me.MaximumSize = Me.Size


        Mx = True

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Close_Me2("ScreenCap")

        Me.Hide()

        Form1.Timer1.Interval = 1
        Form1.Panel1.Dock = DockStyle.None
        Form1.Panel1.Visible = True
        Form1.Opacity = 70 / 100
        Form1.Panel1.Size = New Drawing.Size(124, 107)
        Form1.BackColor = Color.White
        Form1.WindowState = FormWindowState.Maximized

        Form1.Show()
        Form1.Timer1.Start()

    End Sub

    'Private Sub CaptureForm_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
    '    If Me.Visible = True And Min = False Then
    '        'Load_Me2("ScreenCap")
    '    End If

    'End Sub

    'Private Sub CaptureForm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged

    '    If Mx = True Then

    '        Mx = False
    '        NotMaximiced()

    '    End If

    'End Sub


    'Sub Maximiced()

    '    Dim Value As String

    '    Try
    '        Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
    '    Catch ex As Exception
    '        Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")

    '    End Try

    '    Dim X As Integer = Val(Value) + 1

    '    Try
    '        IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))
    '    Catch ex As Exception
    '        IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))

    '    End Try

    'End Sub


    'Sub NotMaximiced()

    '    Dim Value As String

    '    Try
    '        Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
    '    Catch ex As Exception
    '        Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
    '    End Try

    '    Dim X As Integer = Val(Value) - 1

    '    Try
    '        IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))
    '    Catch ex As Exception
    '        IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))
    '    End Try


    'End Sub

    'Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
    '    'Panel1.BackColor = Color.DarkGray
    '    'Panel2.BackColor = Color.DarkGray

    'End Sub

    'Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    '    'Panel1.BackColor = SystmColor
    '    'Panel2.BackColor = SystmColor

    'End Sub

    'Private Sub Form1_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged

    '    'If Me.Visible = True Then

    '    '    If Mx = True Then
    '    '        Maximiced()

    '    '    End If

    '    'Else
    '    '    If Mx = True Then
    '    '        NotMaximiced()
    '    '    End If

    '    'End If

    'End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Desktop = My.Computer.FileSystem.SpecialDirectories.Desktop

        Dim fileName = Desktop + "\" + "captura"

        While My.Computer.FileSystem.GetFileInfo(fileName + ".jpg").Exists = True
            fileName += "_"
        End While

        PictureBox1.Image.Save(fileName + ".jpg")
    End Sub
End Class