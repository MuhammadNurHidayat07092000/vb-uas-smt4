Imports MySql.Data.MySqlClient
Public Class Form1
    Dim conn As MySqlConnection
    Dim cmd As MySqlCommand

    Private Sub lblSign_MouseHover(sender As Object, e As EventArgs) Handles lblSign.MouseHover
        tmrSign.Stop()
        lblSign.ForeColor = Color.Green
    End Sub

    Private Sub lblSign_MouseLeave(sender As Object, e As EventArgs) Handles lblSign.MouseLeave
        tmrSign.Start()
        lblSign.ForeColor = Color.White
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrSign.Start()
    End Sub

    Private Sub tmrSign_Tick(sender As Object, e As EventArgs) Handles tmrSign.Tick
        lblSign.Visible = Not lblSign.Visible
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password=root;database=db_penjualan"
        Dim read As MySqlDataReader
        Try
            conn.Open()
            Dim query As String
            query = "SELECT * FROM tbl_login WHERE username = '" & txUsername.Text & "' AND password = '" & txPassword.Text & "'"
            cmd = New MySqlCommand(query, conn)
            read = cmd.ExecuteReader
            Dim count As Integer
            count = 0

            While read.Read
                count = count + 1
            End While

            If count = 1 Then
                MsgBox("LOGIN SUCCESS" & vbNewLine & "WELCOME" & txUsername.Text & "!", MsgBoxStyle.Information, "SUCCESS")
            ElseIf count > 1 Then
                MsgBox("DOUBLE!")
            Else
                MsgBox("LOGIN FAILED!")
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class
