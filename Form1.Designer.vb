<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Panel1 = New Panel()
        Label5 = New Label()
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        Label1 = New Label()
        Button1 = New Button()
        contrasenia = New TextBox()
        usuario = New TextBox()
        Button2 = New Button()
        Button3 = New Button()
        Label3 = New Label()
        Label4 = New Label()
        Button4 = New Button()
        Label6 = New Label()
        Button5 = New Button()
        Label7 = New Label()
        Button6 = New Button()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(contrasenia)
        Panel1.Controls.Add(usuario)
        Panel1.Location = New Point(32, 32)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(709, 266)
        Panel1.TabIndex = 5
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(47, 230)
        Label5.Name = "Label5"
        Label5.Size = New Size(278, 25)
        Label5.TabIndex = 11
        Label5.Text = "Control de Polizas y facturación"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(31, 28)
        PictureBox1.Margin = New Padding(3, 2, 3, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(326, 191)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(361, 122)
        Label2.Name = "Label2"
        Label2.Size = New Size(67, 15)
        Label2.TabIndex = 9
        Label2.Text = "Contraseña"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(382, 64)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 15)
        Label1.TabIndex = 8
        Label1.Text = "Usuario"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(508, 189)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(150, 29)
        Button1.TabIndex = 7
        Button1.Text = "ACEPTAR"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' contrasenia
        ' 
        contrasenia.Location = New Point(453, 119)
        contrasenia.Margin = New Padding(3, 2, 3, 2)
        contrasenia.Name = "contrasenia"
        contrasenia.PasswordChar = "*"c
        contrasenia.Size = New Size(204, 23)
        contrasenia.TabIndex = 6
        ' 
        ' usuario
        ' 
        usuario.Location = New Point(453, 59)
        usuario.Margin = New Padding(3, 2, 3, 2)
        usuario.Name = "usuario"
        usuario.Size = New Size(204, 23)
        usuario.TabIndex = 5
        ' 
        ' Button2
        ' 
        Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), Image)
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.Location = New Point(44, 66)
        Button2.Margin = New Padding(3, 2, 3, 2)
        Button2.Name = "Button2"
        Button2.Size = New Size(160, 135)
        Button2.TabIndex = 6
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), Image)
        Button3.BackgroundImageLayout = ImageLayout.Stretch
        Button3.Location = New Point(388, 66)
        Button3.Margin = New Padding(3, 2, 3, 2)
        Button3.Name = "Button3"
        Button3.Size = New Size(158, 135)
        Button3.TabIndex = 7
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(68, 203)
        Label3.Name = "Label3"
        Label3.Size = New Size(101, 15)
        Label3.TabIndex = 8
        Label3.Text = "Carga de archivos"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(412, 203)
        Label4.Name = "Label4"
        Label4.Size = New Size(117, 15)
        Label4.TabIndex = 9
        Label4.Text = "Consulta de Facturas"
        ' 
        ' Button4
        ' 
        Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), Image)
        Button4.BackgroundImageLayout = ImageLayout.Stretch
        Button4.Location = New Point(564, 66)
        Button4.Margin = New Padding(3, 2, 3, 2)
        Button4.Name = "Button4"
        Button4.Size = New Size(158, 130)
        Button4.TabIndex = 10
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(605, 203)
        Label6.Name = "Label6"
        Label6.Size = New Size(78, 15)
        Label6.TabIndex = 12
        Label6.Text = "Herramientas"
        ' 
        ' Button5
        ' 
        Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), Image)
        Button5.BackgroundImageLayout = ImageLayout.Stretch
        Button5.Location = New Point(209, 68)
        Button5.Margin = New Padding(3, 2, 3, 2)
        Button5.Name = "Button5"
        Button5.Size = New Size(160, 133)
        Button5.TabIndex = 13
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(239, 206)
        Label7.Name = "Label7"
        Label7.Size = New Size(85, 15)
        Label7.TabIndex = 14
        Label7.Text = "Actualiza UUID"
        ' 
        ' Button6
        ' 
        Button6.BackgroundImage = My.Resources.Resources.icone_question_verte2
        Button6.BackgroundImageLayout = ImageLayout.Zoom
        Button6.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button6.Location = New Point(710, 1)
        Button6.Margin = New Padding(3, 2, 3, 2)
        Button6.Name = "Button6"
        Button6.Size = New Size(31, 27)
        Button6.TabIndex = 15
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(751, 334)
        Controls.Add(Button6)
        Controls.Add(Panel1)
        Controls.Add(Button2)
        Controls.Add(Button3)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Button4)
        Controls.Add(Label6)
        Controls.Add(Button5)
        Controls.Add(Label7)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "CPol Ver 1.0.0"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents contrasenia As TextBox
    Friend WithEvents usuario As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Button6 As Button

End Class
