<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeleteEmployee
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnExit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteEmp = New Guna.UI2.WinForms.Guna2Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 103)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(993, 365)
        Me.DataGridView1.TabIndex = 3
        '
        'btnExit
        '
        Me.btnExit.BorderRadius = 20
        Me.btnExit.CheckedState.Parent = Me.btnExit
        Me.btnExit.CustomImages.Parent = Me.btnExit
        Me.btnExit.FillColor = System.Drawing.Color.Silver
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.HoverState.Parent = Me.btnExit
        Me.btnExit.Location = New System.Drawing.Point(644, 487)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.ShadowDecoration.Parent = Me.btnExit
        Me.btnExit.Size = New System.Drawing.Size(194, 74)
        Me.btnExit.TabIndex = 94
        Me.btnExit.Text = "EXIT"
        '
        'btnDeleteEmp
        '
        Me.btnDeleteEmp.BorderRadius = 20
        Me.btnDeleteEmp.CheckedState.Parent = Me.btnDeleteEmp
        Me.btnDeleteEmp.CustomImages.Parent = Me.btnDeleteEmp
        Me.btnDeleteEmp.FillColor = System.Drawing.Color.Silver
        Me.btnDeleteEmp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDeleteEmp.ForeColor = System.Drawing.Color.Black
        Me.btnDeleteEmp.HoverState.Parent = Me.btnDeleteEmp
        Me.btnDeleteEmp.Location = New System.Drawing.Point(202, 487)
        Me.btnDeleteEmp.Name = "btnDeleteEmp"
        Me.btnDeleteEmp.ShadowDecoration.Parent = Me.btnDeleteEmp
        Me.btnDeleteEmp.Size = New System.Drawing.Size(194, 74)
        Me.btnDeleteEmp.TabIndex = 95
        Me.btnDeleteEmp.Text = "DELETE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Mongolian Baiti", 40.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(261, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(503, 73)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Select Employee"
        '
        'frmDeleteEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.ClientSize = New System.Drawing.Size(1025, 594)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDeleteEmp)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDeleteEmployee"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDeleteEmployee"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnExit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteEmp As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
End Class
