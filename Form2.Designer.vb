<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Button1 = New Button()
        OpenFileDialog1 = New OpenFileDialog()
        DataGridView1 = New DataGridView()
        lblInsertadas = New Label()
        lblActualizadas = New Label()
        Button2 = New Button()
        lblDuplicadas = New Label()
        Button3 = New Button()
        Label1 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(1533, 21)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(125, 35)
        Button1.TabIndex = 0
        Button1.Text = "Cargar archivo"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 69)
        DataGridView1.Margin = New Padding(3, 4, 3, 4)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(1653, 517)
        DataGridView1.TabIndex = 8
        ' 
        ' lblInsertadas
        ' 
        lblInsertadas.AutoSize = True
        lblInsertadas.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold)
        lblInsertadas.Location = New Point(38, 27)
        lblInsertadas.Name = "lblInsertadas"
        lblInsertadas.Size = New Size(124, 31)
        lblInsertadas.TabIndex = 9
        lblInsertadas.Text = "Insertadas"
        ' 
        ' lblActualizadas
        ' 
        lblActualizadas.AutoSize = True
        lblActualizadas.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold)
        lblActualizadas.Location = New Point(325, 28)
        lblActualizadas.Name = "lblActualizadas"
        lblActualizadas.Size = New Size(149, 31)
        lblActualizadas.TabIndex = 10
        lblActualizadas.Text = "Actualizadas"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(1533, 21)
        Button2.Name = "Button2"
        Button2.Size = New Size(125, 35)
        Button2.TabIndex = 11
        Button2.Text = "Carga Inicial"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' lblDuplicadas
        ' 
        lblDuplicadas.AutoSize = True
        lblDuplicadas.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold)
        lblDuplicadas.Location = New Point(622, 28)
        lblDuplicadas.Name = "lblDuplicadas"
        lblDuplicadas.Size = New Size(132, 31)
        lblDuplicadas.TabIndex = 12
        lblDuplicadas.Text = "Duplicadas"
        ' 
        ' Button3
        ' 
        Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), Image)
        Button3.BackgroundImageLayout = ImageLayout.Stretch
        Button3.Location = New Point(1603, 593)
        Button3.Name = "Button3"
        Button3.Size = New Size(55, 51)
        Button3.TabIndex = 13
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(1463, 608)
        Label1.Name = "Label1"
        Label1.Size = New Size(134, 20)
        Label1.TabIndex = 14
        Label1.Text = "Eliminar el registro"
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1677, 667)
        Controls.Add(Label1)
        Controls.Add(Button3)
        Controls.Add(lblDuplicadas)
        Controls.Add(Button2)
        Controls.Add(lblActualizadas)
        Controls.Add(lblInsertadas)
        Controls.Add(DataGridView1)
        Controls.Add(Button1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Form2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "CPol Carga de Archivos"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Friend WithEvents Button1 As Button

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog

    Private Sub OpenFileDialog1_FileOk_1(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblInsertadas As Label
    Friend WithEvents lblActualizadas As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents lblDuplicadas As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label1 As Label
End Class
