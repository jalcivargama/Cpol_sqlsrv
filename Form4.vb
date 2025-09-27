Imports System.Data.SQLite
Imports System.IO

Public Class Form4

    Private cadenaConexion As String = "Data Source=SCB_BaseDeDatos.db;Version=3;"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button2.Click
        inicializa()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim respuesta As DialogResult
        respuesta = MessageBox.Show("¿Estás seguro de que deseas  Respaldar la BAse de datos y eliminar todos los registros de la base actual ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If respuesta = DialogResult.Yes Then
            respalda()
            inicializa()
        Else
            ' Acción cancelada
            MessageBox.Show("Operación cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        respalda()

    End Sub

    Private Sub respalda()
        Dim folderDialog As New FolderBrowserDialog()
        folderDialog.Description = "Selecciona el directorio de destino"
        Dim fechaFormateada As String = DateTime.Now.ToString("YYMMdd")

        If folderDialog.ShowDialog() = DialogResult.OK Then
            Dim rutaDestino As String = folderDialog.SelectedPath

            ' Ruta de origen: carpeta donde se ejecuta el programa
            Dim rutaOrigen As String = Application.StartupPath
            Dim nombreArchivo As String = "SCB_BaseDeDatos.db" ' Cambia esto por el nombre real del archivo
            Dim archivoOrigen As String = Path.Combine(rutaOrigen, nombreArchivo)
            Dim archivoDestino As String = Path.Combine(rutaDestino, $"{fechaFormateada}_" & nombreArchivo)

            Try
                If File.Exists(archivoOrigen) Then
                    File.Copy(archivoOrigen, archivoDestino, True)
                    MessageBox.Show("Archivo copiado exitosamente a: " & archivoDestino)
                Else
                    MessageBox.Show("El archivo de origen no existe: " & archivoOrigen)
                End If
            Catch ex As Exception
                MessageBox.Show("Error al copiar el archivo: " & ex.Message)
            End Try
        End If

    End Sub

    Private Sub inicializa()
        Try

            Dim respuesta As DialogResult
            respuesta = MessageBox.Show("¿Estás seguro de que deseas eliminar todos los registros de la base de datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If respuesta = DialogResult.Yes Then
                Using conn As New SQLiteConnection(cadenaConexion)
                    conn.Open()

                    Dim sql As String = "DELETE FROM campos"
                    Using comando As New SQLiteCommand(sql, conn)
                        Dim filasAfectadas As Integer = comando.ExecuteNonQuery()
                        MessageBox.Show($"Se eliminaron {filasAfectadas} registros de la tabla 'campos'.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using

                    sql = "UPDATE sqlite_sequence set seq = 0 where Name  ='campos'"

                    Using comando As New SQLiteCommand(sql, conn)
                        Dim filasAfectadas As Integer = comando.ExecuteNonQuery()
                        MessageBox.Show($"Se inicializaron los secuenciales para los registros de la tabla 'campos'.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using



                End Using
                ' Acción confirmada
                MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Acción cancelada
                MessageBox.Show("Operación cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If



        Catch ex As Exception
            MessageBox.Show("Ocurrio un error : ", ex.Message)

        End Try
    End Sub
End Class