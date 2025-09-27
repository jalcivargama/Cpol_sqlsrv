<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        ComboBox1 = New ComboBox()
        Label1 = New Label()
        DateTimePicker1 = New DateTimePicker()
        Label2 = New Label()
        DataGridView1 = New DataGridView()
        Button1 = New Button()
        txtUuid = New TextBox()
        lblUUID = New Label()
        Label4 = New Label()
        Panel1 = New Panel()
        ComboBox2 = New ComboBox()
        Label7 = New Label()
        Label6 = New Label()
        DateTimePicker2 = New DateTimePicker()
        Label5 = New Label()
        Button2 = New Button()
        Label3 = New Label()
        lblMonto = New Label()
        Label8 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"ACTIVA", "PAGADO", "CANCELADO"})
        ComboBox1.Location = New Point(242, 37)
        ComboBox1.Margin = New Padding(3, 2, 3, 2)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(140, 23)
        ComboBox1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(23, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(30, 15)
        Label1.TabIndex = 1
        Label1.Text = "Lote"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.Location = New Point(74, 37)
        DateTimePicker1.Margin = New Padding(3, 2, 3, 2)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(112, 23)
        DateTimePicker1.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(192, 41)
        Label2.Name = "Label2"
        Label2.Size = New Size(44, 15)
        Label2.TabIndex = 3
        Label2.Text = "Estatus"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(18, 100)
        DataGridView1.Margin = New Padding(3, 2, 3, 2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(1384, 460)
        DataGridView1.TabIndex = 4
        ' 
        ' Button1
        ' 
        Button1.BackgroundImage = My.Resources.Resources._360_F_36371300_aC8BcFtktS28MHEtvWmlj6n7AoBI8ldZ
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.Location = New Point(460, 22)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(54, 56)
        Button1.TabIndex = 5
        Button1.UseVisualStyleBackColor = True
        ' 
        ' txtUuid
        ' 
        txtUuid.Location = New Point(388, 49)
        txtUuid.Margin = New Padding(3, 2, 3, 2)
        txtUuid.Name = "txtUuid"
        txtUuid.Size = New Size(307, 23)
        txtUuid.TabIndex = 6
        ' 
        ' lblUUID
        ' 
        lblUUID.AutoSize = True
        lblUUID.Location = New Point(389, 33)
        lblUUID.Name = "lblUUID"
        lblUUID.Size = New Size(34, 15)
        lblUUID.TabIndex = 7
        lblUUID.Text = "UUID"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(23, 7)
        Label4.Name = "Label4"
        Label4.Size = New Size(161, 25)
        Label4.TabIndex = 8
        Label4.Text = "Consulta del lote"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Panel1.Controls.Add(ComboBox2)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(DateTimePicker2)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(txtUuid)
        Panel1.Controls.Add(lblUUID)
        Panel1.Location = New Point(517, 7)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(885, 87)
        Panel1.TabIndex = 9
        Panel1.Visible = False
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Items.AddRange(New Object() {"                     "})
        ComboBox2.Location = New Point(17, 50)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(345, 23)
        ComboBox2.TabIndex = 13
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(823, 8)
        Label7.Name = "Label7"
        Label7.Size = New Size(59, 15)
        Label7.TabIndex = 12
        Label7.Text = "Actualizar"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(718, 33)
        Label6.Name = "Label6"
        Label6.Size = New Size(68, 15)
        Label6.TabIndex = 11
        Label6.Text = "Fecha UUID"
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Format = DateTimePickerFormat.Short
        DateTimePicker2.Location = New Point(717, 49)
        DateTimePicker2.Margin = New Padding(3, 2, 3, 2)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(97, 23)
        DateTimePicker2.TabIndex = 10
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(11, 6)
        Label5.Name = "Label5"
        Label5.Size = New Size(153, 25)
        Label5.TabIndex = 9
        Label5.Text = "Actualizar UUID"
        ' 
        ' Button2
        ' 
        Button2.BackgroundImage = My.Resources.Resources.lapiz
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.Location = New Point(819, 20)
        Button2.Margin = New Padding(3, 2, 3, 2)
        Button2.Name = "Button2"
        Button2.Size = New Size(63, 56)
        Button2.TabIndex = 8
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 34)
        Label3.Name = "Label3"
        Label3.Size = New Size(29, 15)
        Label3.TabIndex = 7
        Label3.Text = "PPD"
        ' 
        ' lblMonto
        ' 
        lblMonto.AutoSize = True
        lblMonto.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMonto.Location = New Point(23, 63)
        lblMonto.Name = "lblMonto"
        lblMonto.Size = New Size(105, 32)
        lblMonto.TabIndex = 10
        lblMonto.Text = "Monto :"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(390, 40)
        Label8.Name = "Label8"
        Label8.Size = New Size(67, 15)
        Label8.TabIndex = 3
        Label8.Text = "Vista previa"
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1419, 569)
        Controls.Add(lblMonto)
        Controls.Add(Panel1)
        Controls.Add(Label4)
        Controls.Add(Button1)
        Controls.Add(DataGridView1)
        Controls.Add(Label8)
        Controls.Add(Label2)
        Controls.Add(DateTimePicker1)
        Controls.Add(Label1)
        Controls.Add(ComboBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form5"
        StartPosition = FormStartPosition.CenterScreen
        Text = "CPol Actualiza UUID "
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents txtUuid As TextBox
    Friend WithEvents lblUUID As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents lblMonto As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
End Class
