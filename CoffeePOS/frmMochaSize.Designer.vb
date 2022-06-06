<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMochaSize
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
        Me.btnSmall = New Guna.UI2.WinForms.Guna2Button()
        Me.btnLarge = New Guna.UI2.WinForms.Guna2Button()
        Me.btnMedium = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'btnSmall
        '
        Me.btnSmall.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSmall.BorderRadius = 15
        Me.btnSmall.CheckedState.Parent = Me.btnSmall
        Me.btnSmall.CustomImages.Parent = Me.btnSmall
        Me.btnSmall.FillColor = System.Drawing.Color.Silver
        Me.btnSmall.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSmall.ForeColor = System.Drawing.Color.White
        Me.btnSmall.HoverState.Parent = Me.btnSmall
        Me.btnSmall.Location = New System.Drawing.Point(16, 37)
        Me.btnSmall.Name = "btnSmall"
        Me.btnSmall.ShadowDecoration.Parent = Me.btnSmall
        Me.btnSmall.Size = New System.Drawing.Size(148, 97)
        Me.btnSmall.TabIndex = 2
        Me.btnSmall.Text = "Small"
        '
        'btnLarge
        '
        Me.btnLarge.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnLarge.BorderRadius = 15
        Me.btnLarge.CheckedState.Parent = Me.btnLarge
        Me.btnLarge.CustomImages.Parent = Me.btnLarge
        Me.btnLarge.FillColor = System.Drawing.Color.Silver
        Me.btnLarge.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnLarge.ForeColor = System.Drawing.Color.White
        Me.btnLarge.HoverState.Parent = Me.btnLarge
        Me.btnLarge.Location = New System.Drawing.Point(362, 37)
        Me.btnLarge.Name = "btnLarge"
        Me.btnLarge.ShadowDecoration.Parent = Me.btnLarge
        Me.btnLarge.Size = New System.Drawing.Size(148, 97)
        Me.btnLarge.TabIndex = 1
        Me.btnLarge.Text = "Large"
        '
        'btnMedium
        '
        Me.btnMedium.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnMedium.BorderRadius = 15
        Me.btnMedium.CheckedState.Parent = Me.btnMedium
        Me.btnMedium.CustomImages.Parent = Me.btnMedium
        Me.btnMedium.FillColor = System.Drawing.Color.Silver
        Me.btnMedium.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMedium.ForeColor = System.Drawing.Color.White
        Me.btnMedium.HoverState.Parent = Me.btnMedium
        Me.btnMedium.Location = New System.Drawing.Point(189, 37)
        Me.btnMedium.Name = "btnMedium"
        Me.btnMedium.ShadowDecoration.Parent = Me.btnMedium
        Me.btnMedium.Size = New System.Drawing.Size(148, 97)
        Me.btnMedium.TabIndex = 1
        Me.btnMedium.Text = "Medium"
        '
        'frmMochaSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(543, 188)
        Me.Controls.Add(Me.btnMedium)
        Me.Controls.Add(Me.btnLarge)
        Me.Controls.Add(Me.btnSmall)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMochaSize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMochaSize"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSmall As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnLarge As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnMedium As Guna.UI2.WinForms.Guna2Button
End Class
