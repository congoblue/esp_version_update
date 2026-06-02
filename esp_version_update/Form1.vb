Imports System.IO

Public Class Form1

    Dim fpath As String
    Dim fname As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim FileNameOpenWith As String = My.Application.CommandLineArgs(0)
        fpath = Strings.Left(FileNameOpenWith, InStrRev(FileNameOpenWith, "\") - 1)
        fname = Strings.Mid(FileNameOpenWith, InStrRev(FileNameOpenWith, "\") + 1)
        Dim verpos = InStr(fname, "_v")
        Dim verendpos = InStr(verpos, fname, ".") - 1
        Dim newfname = Strings.Left(fname, verpos) & "_"
        TextBox1.Text = fname
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ferr = 0
        If Not My.Computer.FileSystem.FileExists(fpath & "\.pio\build\esp32dev\firmware.bin") Then MsgBox("Firmware.bin doesn't exist") : ferr = 1
        If (ferr = 0) Then
            My.Computer.FileSystem.DeleteFile(fpath & "\" & fname)
            My.Computer.FileSystem.CopyFile(fpath & "\.pio\build\esp32dev\firmware.bin", fpath & "\" & TextBox1.Text)
        End If
        Me.Close()
        End Sub
        End Class
