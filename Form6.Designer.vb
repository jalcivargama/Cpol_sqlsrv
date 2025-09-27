<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form6))
        Label1 = New Label()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        Label3 = New Label()
        Label4 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(248, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(83, 41)
        Label1.TabIndex = 0
        Label1.Text = "Cpol"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(167, 73)
        Label2.Name = "Label2"
        Label2.Size = New Size(226, 20)
        Label2.TabIndex = 0
        Label2.Text = "Control de Pólizas Vs Facturación"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(149, 96)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(97, 123)
        Label3.Name = "Label3"
        Label3.Size = New Size(211, 20)
        Label3.TabIndex = 0
        Label3.Text = "Todos los derechos reservados"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(82, 143)
        Label4.Name = "Label4"
        Label4.Size = New Size(249, 20)
        Label4.TabIndex = 0
        Label4.Text = "Contacto : jalcivar@hamaji-biai.com"
        ' 
        ' Form6
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(394, 191)
        Controls.Add(PictureBox1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form6"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Acerca de"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
