<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(36, 98)
        Button1.Name = "Button1"
        Button1.Size = New Size(270, 55)
        Button1.TabIndex = 0
        Button1.Text = "Respaldar y Reiniciar Base de Datos"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(36, 158)
        Button2.Name = "Button2"
        Button2.Size = New Size(270, 55)
        Button2.TabIndex = 1
        Button2.Text = "Reiniciar base de datos"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(36, 37)
        Button3.Name = "Button3"
        Button3.Size = New Size(270, 55)
        Button3.TabIndex = 2
        Button3.Text = "Respaldar Base de Datos"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(335, 450)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form4"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Herramientas"
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
