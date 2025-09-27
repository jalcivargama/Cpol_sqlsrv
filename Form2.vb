Imports System.Data.SQLite
Imports System.IO
Imports System.Security
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form2

    ' Contadores
    Private polizasInsertadas As New HashSet(Of String)
    Private polizasActualizadas As New HashSet(Of String)
    Private contadorBusquedas As Integer = 0

    ' Ruta de la base de datos (ajústala a tu entorno)
    Private cadenaConexion As String = "Data Source=SCB_BaseDeDatos.db;Version=3;"
    Private esCargaInicial As Boolean


    ' Botón para agregar archivo CSV
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*"
        OpenFileDialog1.Title = "Selecciona el archivo CSV"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ProcesarCSV(OpenFileDialog1.FileName)
        End If
    End Sub

    ' Procesar CSV
    Private Sub ProcesarCSV(ruta As String)

        Using conn As New SQLiteConnection(cadenaConexion)
            conn.Open()
            Dim msg As String = ""

            Using transaccion As SQLiteTransaction = conn.BeginTransaction()
                Try
                    Dim FecLoteInserta As String = ""
                    Dim lineasRepetidas As Integer = 0
                    Dim lineasInsertadas As Integer = 0
                    Dim lineasActualizadas As Integer = 0
                    Dim lineasOmitidas As Integer = 0
                    Dim updateSQL As String = ""
                    Dim msgOmitidas As String = ""

                    Dim fechaFormateada As String = DateTime.Now.ToString("yyyy-MM-dd")

                    Dim lineas = File.ReadAllLines(ruta)
                    Dim separador As Char = If(lineas(0).Contains(";"), ";"c, ","c)

                    For i As Integer = 1 To lineas.Length - 1
                        Dim campos = lineas(i).Split(separador)
                        FecLoteInserta = Format(CDate(campos(0)), "yyyy-MM-dd")
                        ' Formatear fechas
                        For j As Integer = 0 To campos.Length - 1
                            Dim valor As String = campos(j).Trim()
                            If IsDate(valor) Then
                                campos(j) = Format(CDate(valor), "yyyy-MM-dd")
                            End If
                        Next


                        Dim noPoliza As String = campos(1).Replace("'"c, "")
                        Dim recibo As String = campos(2)
                        Dim fecLote As String = campos(0)
                        Dim estatus As String = campos(7)
                        Dim prima As String = campos(5)

                        'para cada archivo revisamos primero si el registro no existe igual validando todos los campos para evitar meter duplicados

                        Dim existeExactoSQL As String = "SELECT COUNT(*) FROM campos WHERE NoPoliza = @NoPoliza AND Recibo = @Recibo AND FecLote = @FecLote AND Estatus = @Estatus AND Prima = @Prima"
                        Using exactCmd As New SQLiteCommand(existeExactoSQL, conn)
                            exactCmd.Parameters.AddWithValue("@NoPoliza", noPoliza)
                            exactCmd.Parameters.AddWithValue("@Recibo", recibo)
                            exactCmd.Parameters.AddWithValue("@FecLote", fecLote)
                            exactCmd.Parameters.AddWithValue("@Estatus", estatus)
                            exactCmd.Parameters.AddWithValue("@Prima", prima)

                            Dim existeExacto As Integer = Convert.ToInt32(exactCmd.ExecuteScalar())
                            If existeExacto > 0 Then
                                lineasRepetidas = lineasRepetidas + 1
                                Continue For
                            End If
                        End Using

                        ' si no existe por carga previa  verificar si existe la poliza el recibo y la prima lo metemos 

                        Dim existePorPolizaReciboSQL As String = "SELECT * FROM campos WHERE NoPoliza = @NoPoliza AND Recibo = @Recibo  AND Prima = @Prima"
                        Dim resultado As New DataTable()



                        Using existeporPolizaCmd As New SQLiteCommand(existePorPolizaReciboSQL, conn)
                            existeporPolizaCmd.Parameters.AddWithValue("@NoPoliza", noPoliza)
                            existeporPolizaCmd.Parameters.AddWithValue("@Recibo", recibo)
                            existeporPolizaCmd.Parameters.AddWithValue("@Prima", prima)

                            Using adaptador As New SQLiteDataAdapter(existeporPolizaCmd)
                                adaptador.Fill(resultado)
                            End Using


                            If resultado.Rows.Count > 0 Then
                                Dim estatusDb As String = resultado.Rows(0)("Estatus").ToString()
                                Dim ID As String = resultado.Rows(0)("ID").ToString()
                                Dim FacPPD As String = resultado.Rows(0)("FacPPD").ToString().Trim()


                                ' si si existe por comparacion de poliza recibo y prima
                                If estatusDb = estatus And estatus = "ACTIVA" Then
                                    'y  el estatus  del registro es ACTIVA actualizamos todos los campos de LOTE PPD FECESTATUS y LOTE
                                    updateSQL = $"UPDATE campos SET FecLote = '{campos(0)}' , FacPPD= '{campos(10)}' , FecPPD = '{campos(11)}' , Estatus = '{campos(7)}' , FecEst = '{fechaFormateada}' WHERE ID = '{ID}' "
                                    Using updateCmd As New SQLiteCommand(updateSQL, conn)
                                        lineasActualizadas = lineasActualizadas + updateCmd.ExecuteNonQuery()
                                    End Using

                                Else
                                    ' si si está y no tienen el mismo estatus quiere decir que o se pago o se cancelo por lo tanto actualizamos  el registro en los campos de PUE
                                    ' solo puede actualizarse si el registro de la base ya trae la PPD

                                    If FacPPD <> "" Then
                                        updateSQL = $"UPDATE campos SET FecLote = '{campos(0)}' , FacPUE= '{campos(12)}' , FecPUE = '{campos(13)}' , Estatus = '{campos(7)}' , FecEst = '{fechaFormateada}'  WHERE ID = '{ID}' "
                                        Using updateCmd As New SQLiteCommand(updateSQL, conn)
                                            lineasActualizadas = lineasActualizadas + updateCmd.ExecuteNonQuery()
                                        End Using
                                    Else

                                        msg = msg & $"{i},"

                                    End If


                                End If

                                    ' UPDATE



                                    Else
                                ' si no xistio en ninguno de los casos entonces no hay registro y se ingresa tal como esta

                                'Validar que no puedas meter pagadas 


                                If campos(7).ToString = "Activa" Then
                                    Dim poliza = campos(1).Replace("'", "")

                                    Dim insertSQL As String = "INSERT INTO campos 
                                            (FecLote, NoPoliza, Recibo, IniVig,   FinVig,    Prima,  Comision,  Estatus,  FecEst,  MotCan,  FacPPD,  FecPPD,  FacPUE,  FecPUE , FecCarga)
                                    VALUES (@FecLote, @NoPoliza, @Recibo, @IniVig, @FinVig, @Prima, @Comision, @Estatus, @FecEst, @MotCan, @FacPPD, @FecPPD, @FacPUE, @FecPUE , @FecCarga)"

                                    Using insertCmd As New SQLiteCommand(insertSQL, conn)
                                        insertCmd.Parameters.AddWithValue("@FecLote", campos(0))
                                        insertCmd.Parameters.AddWithValue("@NoPoliza", poliza)
                                        insertCmd.Parameters.AddWithValue("@Recibo", campos(2))
                                        insertCmd.Parameters.AddWithValue("@IniVig", campos(3))
                                        insertCmd.Parameters.AddWithValue("@FinVig", campos(4))
                                        insertCmd.Parameters.AddWithValue("@Prima", campos(5))
                                        insertCmd.Parameters.AddWithValue("@Comision", campos(6))
                                        insertCmd.Parameters.AddWithValue("@Estatus", campos(7))
                                        insertCmd.Parameters.AddWithValue("@FecEst", campos(8))
                                        insertCmd.Parameters.AddWithValue("@MotCan", campos(9))
                                        insertCmd.Parameters.AddWithValue("@FacPPD", campos(10))
                                        insertCmd.Parameters.AddWithValue("@FecPPD", campos(11))
                                        insertCmd.Parameters.AddWithValue("@FacPUE", campos(12))
                                        insertCmd.Parameters.AddWithValue("@FecPUE", campos(13))
                                        insertCmd.Parameters.AddWithValue("@FecCarga", fechaFormateada)


                                        lineasInsertadas = lineasInsertadas + insertCmd.ExecuteNonQuery()
                                    End Using
                                Else

                                    lineasOmitidas = lineasOmitidas + 1
                                    msgOmitidas = msgOmitidas & $"{i},"
                                End If




                            End If


                        End Using



                    Next

                    lblInsertadas.Text = $"Lineas Insertadas : {lineasInsertadas}"
                    lblActualizadas.Text = $"Lineas Actualizadas : {lineasActualizadas}"
                    lblDuplicadas.Text = $"Lineas Duplicadas : {lineasRepetidas}"
                    transaccion.Commit()

                    If msg <> "" Then
                        msg = "Los registros " & msg & " no pudieron ser actualizados , no contienen UUID PPD"
                    End If

                    If msgOmitidas <> "" Then
                        msgOmitidas = "Los registros " & msgOmitidas & " no pudieron ser insertados , no contienen UUID PPD y son estatus Pagados o Cancelados"
                    End If



                    MessageBox.Show($"Operacion completada, Insertadas : {lineasInsertadas} ,  Actualizadas : {lineasActualizadas},  Duplicadas : {lineasRepetidas}  {msg}  {msgOmitidas}")

                    cargaGrid(FecLoteInserta)

                Catch ex As Exception
                    MessageBox.Show("Error al importar CSV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    transaccion.Rollback()
                End Try


            End Using
        End Using
    End Sub

    ' Botón Buscar: filtra por campo de fecha seleccionado y rango entre DateTimePicker1 y DateTimePicker2


    ' Botón Finalizar: muestra resumen (polizas insertadas/actualizadas y búsquedas realizadas) y cierra
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim mensajeFinal =
        "Se actualizaron " & polizasActualizadas.Count & " pólizas con cambios." & vbCrLf &
        "Se insertaron " & polizasInsertadas.Count & " pólizas nuevas." & vbCrLf &
        "Se realizaron " & contadorBusquedas & " búsquedas."
        MessageBox.Show(mensajeFinal, "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Using conn As New SQLiteConnection(cadenaConexion)


                conn.Open()
                Dim existeExactoSQL As String = "SELECT COUNT(*) FROM campos"
                Using exactCmd As New SQLiteCommand(existeExactoSQL, conn)


                    Dim existeExacto As Integer = Convert.ToInt32(exactCmd.ExecuteScalar())
                    If existeExacto = 0 Then
                        Button2.Enabled = True
                        Button2.Visible = True

                        Button1.Enabled = False
                        Button1.Visible = False

                    Else
                        Button2.Enabled = False
                        Button2.Visible = False

                        Button1.Enabled = True
                        Button1.Visible = True

                    End If
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*"
        OpenFileDialog1.Title = "Selecciona el archivo CSV"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ProcesarCSVInicial(OpenFileDialog1.FileName)
        End If
    End Sub



    Private Sub ProcesarCSVInicial(ruta As String)
        Dim noFila As Integer = 0
        Dim FecLoteInserta As String = ""
        Dim fechaFormateada As String = DateTime.Now.ToString("yyyy-MM-dd")
        Using conn As New SQLiteConnection(cadenaConexion)
            conn.Open()



            Dim existeExactoSQL As String = "SELECT COUNT(*) FROM campos"
            Using exactCmd As New SQLiteCommand(existeExactoSQL, conn)


                Dim existeExacto As Integer = Convert.ToInt32(exactCmd.ExecuteScalar())
                If existeExacto > 0 Then
                    Button2.Enabled = False
                    Button2.Visible = False
                    Me.Close()
                End If

            End Using





            Using transaccion As SQLiteTransaction = conn.BeginTransaction()

                Try


                    Dim lineas = File.ReadAllLines(ruta)
                    Dim separador As Char = If(lineas(0).Contains(";"), ";"c, ","c)

                    For i As Integer = 1 To lineas.Length - 1
                        noFila = i
                        Dim campos = lineas(i).Split(separador)
                        FecLoteInserta = Format(CDate(campos(0)), "yyyy-MM-dd")
                        ' Formatear fechas
                        For j As Integer = 0 To campos.Length - 1
                            Dim valor As String = campos(j).Trim()
                            If IsDate(valor) Then
                                campos(j) = Format(CDate(valor), "yyyy-MM-dd")
                            End If
                        Next

                        ' INSERT
                        Dim insertSQL As String = "INSERT INTO campos 
                                            (FecLote, NoPoliza, Recibo, IniVig,   FinVig,    Prima,  Comision,  Estatus,  FecEst,  MotCan,  FacPPD,  FecPPD,  FacPUE,  FecPUE , FecCarga )
                                    VALUES (@FecLote, @NoPoliza, @Recibo, @IniVig, @FinVig, @Prima, @Comision, @Estatus, @FecEst, @MotCan, @FacPPD, @FecPPD, @FacPUE, @FecPUE,@FecCarga)"
                        Dim poliza = campos(1).Replace("'", "")
                        Using insertCmd As New SQLiteCommand(insertSQL, conn)
                            insertCmd.Parameters.AddWithValue("@FecLote", campos(0))
                            insertCmd.Parameters.AddWithValue("@NoPoliza", poliza)
                            insertCmd.Parameters.AddWithValue("@Recibo", campos(2))
                            insertCmd.Parameters.AddWithValue("@IniVig", campos(3))
                            insertCmd.Parameters.AddWithValue("@FinVig", campos(4))
                            insertCmd.Parameters.AddWithValue("@Prima", campos(5))
                            insertCmd.Parameters.AddWithValue("@Comision", campos(6))
                            insertCmd.Parameters.AddWithValue("@Estatus", campos(7))
                            insertCmd.Parameters.AddWithValue("@FecEst", campos(8))
                            insertCmd.Parameters.AddWithValue("@MotCan", campos(9))
                            insertCmd.Parameters.AddWithValue("@FacPPD", campos(10))
                            insertCmd.Parameters.AddWithValue("@FecPPD", campos(11))
                            insertCmd.Parameters.AddWithValue("@FacPUE", campos(12))
                            insertCmd.Parameters.AddWithValue("@FecPUE", campos(13))
                            insertCmd.Parameters.AddWithValue("@FecCarga", fechaFormateada)
                            insertCmd.ExecuteNonQuery()
                        End Using

                    Next
                    transaccion.Commit()
                    MessageBox.Show($"Transacción completada correctamente, numero de filas insertadas :{noFila}")

                    lblInsertadas.Text = "Registros insertados : " & noFila
                    cargaGrid(FecLoteInserta)


                    If noFila > 0 Then
                        Button2.Visible = False
                    End If


                Catch ex As Exception

                    transaccion.Rollback()
                    MessageBox.Show($"Error al importar CSV en la line {noFila}: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

    End Sub



    Private Sub cargaGrid(FecLoteInserta As String)
        Using conn As New SQLiteConnection(cadenaConexion)
            conn.Open()
            Dim sql As String = $"SELECT * FROM campos WHERE FecLote = @FechaLote "
            Using cmd As New SQLiteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@FechaLote", FecLoteInserta)


                Dim dt As New DataTable()
                Using da As New SQLiteDataAdapter(cmd)
                    da.Fill(dt)
                End Using

                For Each fila As DataRow In dt.Rows
                    fila("Prima") = Convert.ToDecimal(fila("Prima"))
                    fila("Comision") = Convert.ToDecimal(fila("Comision"))
                Next

                DataGridView1.DataSource = dt
            End Using

            With DataGridView1.Columns("Comision")
                .DefaultCellStyle.Format = "C2" ' Formato moneda con 2 decimales
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            With DataGridView1.Columns("Prima")
                .DefaultCellStyle.Format = "C2" ' Formato moneda con 2 decimales
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        End Using

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim valorID As String = ""
        Dim fechaLote As String = ""

        If DataGridView1.CurrentRow IsNot Nothing Then


            Dim respuesta As DialogResult
            respuesta = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If respuesta = DialogResult.Yes Then
                valorID = DataGridView1.CurrentRow.Cells("ID").Value.ToString()

                fechaLote = DataGridView1.CurrentRow.Cells("FecLote").Value.ToString()

                Using conn As New SQLiteConnection(cadenaConexion)
                    conn.Open()
                    Using transaccion As SQLiteTransaction = conn.BeginTransaction()

                        Try

                            ' DELETE
                            Dim deleteSQL As String = $"delete from campos   WHERE ID = {valorID} "

                            Using updateCmd As New SQLiteCommand(deleteSQL, conn)
                                updateCmd.ExecuteNonQuery()
                            End Using

                            transaccion.Commit()
                            MessageBox.Show($"Transacción completada correctamente : 1 Fila eliminada")

                            cargaGrid(fechaLote)


                        Catch ex As Exception

                            transaccion.Rollback()
                            MessageBox.Show($"Error al actualizar el UUID " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Using
                End Using
            Else
                ' Acción cancelada
                MessageBox.Show("Operación cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If



        Else
                MessageBox.Show("No hay renglón seleccionado.")
        End If

    End Sub
End Class