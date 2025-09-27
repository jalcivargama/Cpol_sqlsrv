Imports System.Data.SQLite
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    Private Sub login()
        Dim usuarioIngresado = usuario.Text.Trim
        Dim contrasenaIngresada = contrasenia.Text

        If usuarioIngresado = "" Or contrasenaIngresada = "" Then
            MessageBox.Show("Por favor ingresa usuario y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Dim hashIngresado As String = HashPassword(contrasenaIngresada)
        Dim cadenaConexion = "Data Source=" & Application.StartupPath & "\SCB_BaseDeDatos.db;Version=3;"

        Try
            Using conexion As New SQLiteConnection(cadenaConexion)
                conexion.Open()
                Dim sql = "SELECT COUNT(*) FROM Login WHERE Usuario = @usuario AND password = @hash"
                Using cmd As New SQLiteCommand(sql, conexion)
                    cmd.Parameters.AddWithValue("@usuario", usuarioIngresado)
                    cmd.Parameters.AddWithValue("@hash", contrasenaIngresada)
                    Dim count = Convert.ToInt32(cmd.ExecuteScalar)
                    If count > 0 Then

                        Panel1.Visible = False
                        'Me.Hide()

                        'Dim f2 As New Form2
                        'f2.Show()
                    Else
                        MessageBox.Show("¡Usuario inválido!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        login()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim f2 As New Form2
        f2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim f3 As New Form3
        f3.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim f4 As New Form4
        f4.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f5 As New Form5
        f5.Show()
    End Sub



    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Dim f6 As New Form6
        f6.Show()
    End Sub

    Private Sub enterLogin(sender As Object, e As EventArgs) Handles contrasenia.Enter

        If contrasenia.Text <> "" Then
            Button1.Focus()

        End If

    End Sub
End Class