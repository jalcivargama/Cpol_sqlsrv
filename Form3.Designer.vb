<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        ComboBox1 = New ComboBox()
        Label2 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Button3 = New Button()
        DateTimePicker2 = New DateTimePicker()
        DateTimePicker1 = New DateTimePicker()
        DataGridView1 = New DataGridView()
        Label1 = New Label()
        txtPol = New TextBox()
        lblMonto = New Label()
        Label5 = New Label()
        ComboBox2 = New ComboBox()
        Label6 = New Label()
        Button1 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Fecha de Lote", "Fecha PPD", "Fecha PUE"})
        ComboBox1.Location = New Point(13, 30)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(162, 23)
        ComboBox1.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(13, 11)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 15)
        Label2.TabIndex = 8
        Label2.Text = "Campo filtro"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(493, 11)
        Label4.Name = "Label4"
        Label4.Size = New Size(64, 15)
        Label4.TabIndex = 15
        Label4.Text = "Fecha final"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(354, 11)
        Label3.Name = "Label3"
        Label3.Size = New Size(72, 15)
        Label3.TabIndex = 14
        Label3.Text = "Fecha inicial"
        ' 
        ' Button3
        ' 
        Button3.BackgroundImage = My.Resources.Resources._360_F_36371300_aC8BcFtktS28MHEtvWmlj6n7AoBI8ldZ
        Button3.BackgroundImageLayout = ImageLayout.Stretch
        Button3.Location = New Point(746, 22)
        Button3.Name = "Button3"
        Button3.Size = New Size(40, 37)
        Button3.TabIndex = 13
        Button3.UseVisualStyleBackColor = True
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Format = DateTimePickerFormat.Short
        DateTimePicker2.Location = New Point(490, 31)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(112, 23)
        DateTimePicker2.TabIndex = 12
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.Location = New Point(354, 31)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(112, 23)
        DateTimePicker1.TabIndex = 11
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 65)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(1551, 482)
        DataGridView1.TabIndex = 16
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(607, 13)
        Label1.Name = "Label1"
        Label1.Size = New Size(38, 15)
        Label1.TabIndex = 17
        Label1.Text = "Póliza"
        ' 
        ' txtPol
        ' 
        txtPol.Location = New Point(607, 32)
        txtPol.Margin = New Padding(3, 2, 3, 2)
        txtPol.Name = "txtPol"
        txtPol.Size = New Size(110, 23)
        txtPol.TabIndex = 19
        ' 
        ' lblMonto
        ' 
        lblMonto.AutoSize = True
        lblMonto.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMonto.Location = New Point(822, 25)
        lblMonto.Name = "lblMonto"
        lblMonto.Size = New Size(88, 25)
        lblMonto.TabIndex = 20
        lblMonto.Text = "Monto : "
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(195, 9)
        Label5.Name = "Label5"
        Label5.Size = New Size(44, 15)
        Label5.TabIndex = 21
        Label5.Text = "Estatus"
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Items.AddRange(New Object() {"TODOS", "ACTIVA", "PAGADO", "CANCELADO"})
        ComboBox2.Location = New Point(195, 30)
        ComboBox2.Margin = New Padding(3, 2, 3, 2)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(133, 23)
        ComboBox2.TabIndex = 22
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(746, 6)
        Label6.Name = "Label6"
        Label6.Size = New Size(42, 15)
        Label6.TabIndex = 23
        Label6.Text = "Buscar"
        ' 
        ' Button1
        ' 
        Button1.BackgroundImage = My.Resources.Resources._1064770
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.Location = New Point(1520, 23)
        Button1.Name = "Button1"
        Button1.Size = New Size(43, 38)
        Button1.TabIndex = 24
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(1575, 574)
        Controls.Add(Button1)
        Controls.Add(Label6)
        Controls.Add(ComboBox2)
        Controls.Add(Label5)
        Controls.Add(lblMonto)
        Controls.Add(txtPol)
        Controls.Add(Label1)
        Controls.Add(DataGridView1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Button3)
        Controls.Add(DateTimePicker2)
        Controls.Add(DateTimePicker1)
        Controls.Add(ComboBox1)
        Controls.Add(Label2)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form3"
        StartPosition = FormStartPosition.CenterScreen
        Text = "CPol Consulta de Polizas VS Facturas"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPol As TextBox
    Friend WithEvents lblMonto As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
End Class
