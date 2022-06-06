<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewTransaction
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
        Me.btnViewTransaction = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExit = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(35, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(589, 288)
        Me.DataGridView1.TabIndex = 7
        '
        'btnViewTransaction
        '
        Me.btnViewTransaction.BorderRadius = 20
        Me.btnViewTransaction.CheckedState.Parent = Me.btnViewTransaction
        Me.btnViewTransaction.CustomImages.Parent = Me.btnViewTransaction
        Me.btnViewTransaction.FillColor = System.Drawing.Color.Silver
        Me.btnViewTransaction.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnViewTransaction.ForeColor = System.Drawing.Color.Black
        Me.btnViewTransaction.HoverState.Parent = Me.btnViewTransaction
        Me.btnViewTransaction.Location = New System.Drawing.Point(101, 330)
        Me.btnViewTransaction.Name = "btnViewTransaction"
        Me.btnViewTransaction.ShadowDecoration.Parent = Me.btnViewTransaction
        Me.btnViewTransaction.Size = New System.Drawing.Size(164, 53)
        Me.btnViewTransaction.TabIndex = 52
        Me.btnViewTransaction.Text = "Submit"
        '
        'btnExit
        '
        Me.btnExit.BorderRadius = 20
        Me.btnExit.CheckedState.Parent = Me.btnExit
        Me.btnExit.CustomImages.Parent = Me.btnExit
        Me.btnExit.FillColor = System.Drawing.Color.Silver
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.HoverState.Parent = Me.btnExit
        Me.btnExit.Location = New System.Drawing.Point(385, 330)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.ShadowDecoration.Parent = Me.btnExit
        Me.btnExit.Size = New System.Drawing.Size(164, 53)
        Me.btnExit.TabIndex = 53
        Me.btnExit.Text = "Exit"
        '
        'frmViewTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.ClientSize = New System.Drawing.Size(676, 423)
        Me.Controls.Add(Me.btnViewTransaction)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmViewTransaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Transactions"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnViewTransaction As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExit As Guna.UI2.WinForms.Guna2Button
End Class
