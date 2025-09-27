Imports System.Data.SQLite
Imports System.Xml

Public Class Form5
    Private cadenaConexion As String = "Data Source=SCB_BaseDeDatos.db;Version=3;"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' aqui valido que traigan valor los campos si el numero de filas es mayor a cero habilito el campo de factura PUE y/o PPD 
        ' si es estatus activa va a PPD la actualizacion 
        cargaGrid()

        If DataGridView1.DataSource IsNot Nothing Then
            Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Panel1.Visible = True
            Else
                Panel1.Visible = False
                MessageBox.Show("No se encontraron registros con los criterios de búsqueda.")
            End If


            Dim valoresUnicos As New HashSet(Of String)

            For Each fila As DataRow In dt.Rows
                Dim valor As String = fila("FacPPD").ToString().Trim()
                If Not String.IsNullOrEmpty(valor) Then
                    valoresUnicos.Add(valor)
                End If
            Next

            ' Limpiamos el ComboBox antes de agregar
            ComboBox2.Items.Clear()
            valoresUnicos.Add("SIN PPD")
            ComboBox2.Items.AddRange(valoresUnicos.ToArray())
            txtUuid.Text = ""
            ComboBox2.Text = ""


        Else
            MessageBox.Show("No hay fuente de datos asignada.")
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtUuid.Text.Trim = "" Then
            MessageBox.Show("Ingresa el UUID a ser actualizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim campoBD = ""
        Dim campoBDF = ""
        Dim fechaFormateada As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim fechaLote As Date = DateTimePicker1.Value.Date
        Dim fechaUUID As Date = DateTimePicker2.Value.Date
        Dim filasActualizadas As Integer = 0
        Dim PPDPrevio As String = ""
        Dim filtroEstatus As String = ""


        Select Case ComboBox1.SelectedItem.ToString()
            Case "ACTIVA"
                campoBD = "FacPPD"
                campoBDF = "FecPPD"
                filtroEstatus = "Activa"
            Case "PAGADO"
                campoBD = "FacPUE"
                campoBDF = "FecPUE"
                filtroEstatus = "Pagado"
            Case "CANCELADO"
                campoBD = "FacPUE"
                campoBDF = "FecPUE"
                filtroEstatus = "Cancelado"
            Case Else
                MessageBox.Show("Selección no válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        If ComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona el PPD a ser Actualizado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Select Case ComboBox2.SelectedItem.ToString()
            Case "SIN PPD"
                PPDPrevio = ""
            Case Else
                PPDPrevio = ComboBox2.SelectedItem.ToString()

        End Select


        Using conn As New SQLiteConnection(cadenaConexion)
            conn.Open()
            Using transaccion As SQLiteTransaction = conn.BeginTransaction()

                Try

                    ' UPDATE
                    Dim updateSQL As String = $"UPDATE campos SET {campoBD} = '{txtUuid.Text}' , {campoBDF}= '{fechaUUID.ToString("yyyy-MM-dd")}' , FecEst = '{fechaFormateada}' WHERE date(FecLote) = '{fechaLote.ToString("yyyy-MM-dd")}' AND FacPPD ='{PPDPrevio}' AND Estatus ='{filtroEstatus}' "

                    Using updateCmd As New SQLiteCommand(updateSQL, conn)
                        filasActualizadas = updateCmd.ExecuteNonQuery()
                    End Using
                    transaccion.Commit()
                    MessageBox.Show($"Transacción completada correctamente : {filasActualizadas} Filas actualizadas")
                    cargaGrid()
                Catch ex As Exception
                    transaccion.Rollback()
                    MessageBox.Show($"Error al actualizar el UUID " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        txtUuid.Text = ""
        ComboBox2.Text = ""


    End Sub


    Private Sub cargaGrid()
        Dim montoLote As Decimal = 0.00

        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona el estatus a actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim fechaLote As Date = DateTimePicker1.Value.Date
        Dim campoBD As String = ""
        Select Case ComboBox1.SelectedItem.ToString()
            Case "ACTIVA"
                campoBD = "Activa"
            Case "PAGADO"
                campoBD = "Pagado"
            Case "CANCELADO"
                campoBD = "Cancelado"
            Case Else
                MessageBox.Show("Selección no válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        Try
            Using conn As New SQLiteConnection(cadenaConexion)
                conn.Open()
                Dim sql As String = $"SELECT * FROM campos WHERE date(FecLote) = date(@fechaLote) AND Estatus = @estatus"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@fechaLote", fechaLote.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@estatus", campoBD)

                    Dim dt As New DataTable()

                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    For Each fila As DataRow In dt.Rows
                        fila("Prima") = Convert.ToDecimal(fila("Prima"))
                        fila("Comision") = Convert.ToDecimal(fila("Comision"))

                        montoLote = montoLote + fila("Prima")
                    Next

                    DataGridView1.DataSource = dt


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

            lblMonto.Text = $" Monto total de primas : {montoLote.ToString("C")}"



        Catch ex As Exception
            MessageBox.Show("Error al realizar la búsqueda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class