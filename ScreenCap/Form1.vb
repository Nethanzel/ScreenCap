Imports Microsoft.VisualBasic.Devices

Public Class Form1

    Dim x As Integer, y As Integer, a As Integer = x, b As Integer = y
    Private mover As Boolean
    Private XY As Point


    Function GetCapture() As Image

        Dim pic As Bitmap

        Dim H = PictureBox1.Height
        Dim W = PictureBox1.Width

        pic = New Bitmap(W, H)

        Dim gfx As Graphics = Graphics.FromImage(pic)

        gfx.CopyFromScreen(New Point(Me.Location.X + Panel1.Location.X, Me.Location.Y + Panel1.Location.Y - 2), New Point(0, 0), pic.Size)

        Return pic

    End Function


    Dim Cord As New Point

    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        Cord.X = MousePosition.X - Panel1.Left
        Cord.Y = MousePosition.Y - Panel1.Top
        PictureBox3.Hide()

    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Panel1.Top = MousePosition.Y - Cord.Y
            Panel1.Left = MousePosition.X - Cord.X

        End If
    End Sub

    Private Sub PictureBox3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseDown
        XY.X = CInt(CLng(x))
        XY.Y = CInt(CLng(y))
    End Sub

    Private Sub PictureBox3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            'redimensionamos el ancho
            If (Panel1.Width + (x + e.X)) > 0 Then

                Panel1.Width = Panel1.Width + (x + e.X)
            End If
            'redimensionams el alto
            If (Panel1.Height + (y + e.Y)) > 0 Then

                Panel1.Height = Panel1.Height + (y + e.Y)
            End If
        End If

    End Sub

    Dim result As Integer
    Dim strin As String = Nothing
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Int32) As Int16
    Private Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Long) As Integer


    'Public Function GetCapslock() As Boolean
    '    ' Return Or Set the Capslock toggle.

    '    GetCapslock = CBool(GetKeyState(&H14) And 1)

    'End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim Fr As New Keyboard

        For i As Integer = 1 To 225
            result = 0
            result = GetAsyncKeyState(i)

            If result = -32767 Then

                If CBool(Me.Visible) = True And i = 13 Then

                    Timer1.Stop()
                    Do While PictureBox3.Visible = True
                        PictureBox3.Hide()
                    Loop

                    My.Computer.Audio.Play(".\NeckSnap.wav", AudioPlayMode.Background)
                    CaptureForm.PictureBox1.Image = GetCapture()
                    CaptureForm.Show()
                    Me.Hide()

                ElseIf CBool(Me.Visible) = True And i = CInt(Keys.Escape) Then

                    Me.Hide()


                ElseIf CBool(Fr.AltKeyDown) = True And i = 67 Then
                    Timer1.Interval = 1
                    Me.Hide()
                    Me.BackColor = Color.White


                    Me.WindowState = FormWindowState.Maximized
                    Me.Show()

                    Me.Panel1.Dock = DockStyle.Fill
                    Me.Panel1.Visible = False
                    Me.Opacity = 0 / 100

                    My.Computer.Audio.Play(".\SnapSound.wav", AudioPlayMode.Background)
                    CaptureForm.PictureBox1.Image = GetCapture()

                    Do While Me.Opacity > 0
                        Me.Opacity = Me.Opacity - 5

                    Loop

                    Me.Hide()

                    CaptureForm.Show()

                ElseIf CBool(Fr.AltKeyDown) = True And i = 88 Then
                    CaptureForm.Hide()

                    Timer1.Interval = 1
                    Panel1.Dock = DockStyle.None
                    Panel1.Visible = True
                    Opacity = 70 / 100
                    Panel1.Size = New Drawing.Size(124, 107)
                    BackColor = Color.White
                    WindowState = FormWindowState.Maximized

                    Show()
                    Timer1.Start()


                End If
              
            End If

        Next

    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        PictureBox3.Visible = True
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Close_Me("ScreenCap")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        PictureBox3.BackColor = Color.FromArgb(1, Color.White)
        NotifyIcon1.ShowBalloonTip(5000)
        'Load_Me("ScreenCap", CaptureForm.PictureBox2.Image, ListenNumber)
    End Sub


    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        End
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        CaptureForm.Show()
    End Sub
End Class
