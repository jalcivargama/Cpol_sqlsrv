Imports System.Data.SQLite
Imports System.IO
Imports System.Text

Public Class Form3

    ' Ruta de la base de datos (ajústala a tu entorno)
    Private cadenaConexion As String = "Data Source=SCB_BaseDeDatos.db;Version=3;"
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim montoLote As Decimal = 0.00
        Dim estatus As String = ""

        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona un campo de búsqueda en el combo box.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If ComboBox2.SelectedIndex = -1 Then
            ComboBox2.SelectedIndex = 0

        End If
        ' Validar rango de fechas
        Dim fIni As Date = DateTimePicker1.Value.Date
        Dim fFin As Date = DateTimePicker2.Value.Date
        If fIni > fFin Then
            MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Mapear selección del ComboBox al nombre del campo en BD
        Dim campoBD As String = ""
        Select Case ComboBox1.SelectedItem.ToString()
            Case "Fecha de Lote"
                campoBD = "FecLote"
            Case "Fecha PPD"
                campoBD = "FecPPD"
            Case "Fecha PUE"
                campoBD = "FecPUE"
            Case Else
                MessageBox.Show("Selección no válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        Select Case ComboBox2.SelectedItem.ToString()
            Case "ACTIVA"
                estatus = "Activa"

            Case "PAGADO"
                estatus = "Pagado"

            Case "CANCELADO"
                estatus = "Cancelado"
            Case "TODOS"
                estatus = ""

            Case Else
                MessageBox.Show("Selección no válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        Dim wherePolFac = " 1 = 1 "

        If txtPol.Text <> "" Then
            wherePolFac = wherePolFac & $" AND NoPoliza = '{txtPol.Text}' "
        End If

        If estatus <> "" Then
            wherePolFac = wherePolFac & $" AND Estatus = '{estatus}' "
        End If


        ' Consultar y llenar DataGridView
        Try
            Using conn As New SQLiteConnection(cadenaConexion)
                conn.Open()
                Dim sql As String = $"SELECT * FROM campos WHERE {wherePolFac} AND date({campoBD}) BETWEEN date(@FechaInicio) AND date(@FechaFin)"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@FechaInicio", fIni.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@FechaFin", fFin.ToString("yyyy-MM-dd"))

                    Dim dt As New DataTable()
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    DataGridView1.DataSource = dt


                    For Each fila As DataRow In dt.Rows
                        fila("Prima") = Convert.ToDecimal(fila("Prima"))
                        fila("Comision") = Convert.ToDecimal(fila("Comision"))

                        montoLote = montoLote + fila("Prima")
                    Next




                    With DataGridView1.Columns("Comision")
                        .DefaultCellStyle.Format = "C2" ' Formato moneda con 2 decimales
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End With
                    With DataGridView1.Columns("Prima")
                        .DefaultCellStyle.Format = "C2" ' Formato moneda con 2 decimales
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End With



                End Using
            End Using

            lblMonto.Text = $"Monto : { montoLote.ToString("C2")}"


        Catch ex As Exception
            MessageBox.Show("Error al realizar la búsqueda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Columns(e.ColumnIndex).Name = "Estatus" AndAlso e.Value IsNot Nothing Then
            Dim valorEstatus As String = e.Value.ToString().Trim().ToUpper()

            Select Case valorEstatus
                Case "PAGADO"
                    e.CellStyle.BackColor = Color.LightGreen
                    e.CellStyle.ForeColor = Color.Black
                Case "CANCELADO"
                    e.CellStyle.BackColor = Color.LightYellow
                    e.CellStyle.ForeColor = Color.Black
            End Select
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Diálogo para seleccionar carpeta
        Dim folderDialog As New FolderBrowserDialog()
        folderDialog.Description = "Selecciona la carpeta donde guardar el archivo CSV"

        If folderDialog.ShowDialog() = DialogResult.OK Then
            Dim rutaDestino As String = folderDialog.SelectedPath
            Dim nombreArchivo As String = "polizas_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            Dim rutaCompleta As String = Path.Combine(rutaDestino, nombreArchivo)

            Try
                Using writer As New StreamWriter(rutaCompleta, False, Encoding.UTF8)
                    ' Escribir encabezados
                    Dim encabezados As New List(Of String)
                    For Each col As DataGridViewColumn In DataGridView1.Columns
                        If col.Visible Then
                            encabezados.Add(col.HeaderText)
                        End If
                    Next
                    writer.WriteLine(String.Join(",", encabezados))

                    ' Escribir filas
                    For Each fila As DataGridViewRow In DataGridView1.Rows
                        If Not fila.IsNewRow Then
                            Dim valores As New List(Of String)
                            For Each celda As DataGridViewCell In fila.Cells
                                If celda.OwningColumn.Visible Then
                                    Dim valor As String = celda.Value?.ToString().Replace(",", " ") ' Evita romper el CSV
                                    valores.Add(valor)
                                End If
                            Next
                            writer.WriteLine(String.Join(",", valores))
                        End If
                    Next
                End Using

                MessageBox.Show("Archivo CSV guardado exitosamente en: " & rutaCompleta)
            Catch ex As Exception
                MessageBox.Show("Error al guardar el archivo: " & ex.Message)
            End Try
        End If

    End Sub
End Class