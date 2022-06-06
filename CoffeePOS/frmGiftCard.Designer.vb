<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGiftCard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtGiftAmount = New System.Windows.Forms.TextBox()
        Me.txtGiftcardNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAddBalance = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCheckBalance = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button2 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddGiftCardToSystem = New Guna.UI2.WinForms.Guna2Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtGiftAmount
        '
        Me.txtGiftAmount.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGiftAmount.Location = New System.Drawing.Point(117, 229)
        Me.txtGiftAmount.Name = "txtGiftAmount"
        Me.txtGiftAmount.Size = New System.Drawing.Size(141, 33)
        Me.txtGiftAmount.TabIndex = 13
        Me.txtGiftAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGiftcardNumber
        '
        Me.txtGiftcardNumber.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGiftcardNumber.Location = New System.Drawing.Point(182, 126)
        Me.txtGiftcardNumber.Name = "txtGiftcardNumber"
        Me.txtGiftcardNumber.Size = New System.Drawing.Size(201, 33)
        Me.txtGiftcardNumber.TabIndex = 12
        Me.txtGiftcardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(96, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(189, 27)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Gift Cards Amount"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(19, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 33)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Gift Cards Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAddBalance
        '
        Me.btnAddBalance.BorderRadius = 20
        Me.btnAddBalance.CheckedState.Parent = Me.btnAddBalance
        Me.btnAddBalance.CustomImages.Parent = Me.btnAddBalance
        Me.btnAddBalance.FillColor = System.Drawing.Color.Silver
        Me.btnAddBalance.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddBalance.ForeColor = System.Drawing.Color.Black
        Me.btnAddBalance.HoverState.Parent = Me.btnAddBalance
        Me.btnAddBalance.Location = New System.Drawing.Point(29, 330)
        Me.btnAddBalance.Name = "btnAddBalance"
        Me.btnAddBalance.ShadowDecoration.Parent = Me.btnAddBalance
        Me.btnAddBalance.Size = New System.Drawing.Size(164, 53)
        Me.btnAddBalance.TabIndex = 50
        Me.btnAddBalance.Text = "Add Balance"
        '
        'btnCheckBalance
        '
        Me.btnCheckBalance.BorderRadius = 20
        Me.btnCheckBalance.CheckedState.Parent = Me.btnCheckBalance
        Me.btnCheckBalance.CustomImages.Parent = Me.btnCheckBalance
        Me.btnCheckBalance.FillColor = System.Drawing.Color.Silver
        Me.btnCheckBalance.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnCheckBalance.ForeColor = System.Drawing.Color.Black
        Me.btnCheckBalance.HoverState.Parent = Me.btnCheckBalance
        Me.btnCheckBalance.Location = New System.Drawing.Point(219, 330)
        Me.btnCheckBalance.Name = "btnCheckBalance"
        Me.btnCheckBalance.ShadowDecoration.Parent = Me.btnCheckBalance
        Me.btnCheckBalance.Size = New System.Drawing.Size(164, 53)
        Me.btnCheckBalance.TabIndex = 51
        Me.btnCheckBalance.Text = "Check Balance"
        '
        'Guna2Button2
        '
        Me.Guna2Button2.BorderRadius = 20
        Me.Guna2Button2.CheckedState.Parent = Me.Guna2Button2
        Me.Guna2Button2.CustomImages.Parent = Me.Guna2Button2
        Me.Guna2Button2.FillColor = System.Drawing.Color.Silver
        Me.Guna2Button2.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button2.ForeColor = System.Drawing.Color.Black
        Me.Guna2Button2.HoverState.Parent = Me.Guna2Button2
        Me.Guna2Button2.Location = New System.Drawing.Point(219, 410)
        Me.Guna2Button2.Name = "Guna2Button2"
        Me.Guna2Button2.ShadowDecoration.Parent = Me.Guna2Button2
        Me.Guna2Button2.Size = New System.Drawing.Size(164, 53)
        Me.Guna2Button2.TabIndex = 51
        Me.Guna2Button2.Text = "Exit"
        '
        'btnAddGiftCardToSystem
        '
        Me.btnAddGiftCardToSystem.BorderRadius = 20
        Me.btnAddGiftCardToSystem.CheckedState.Parent = Me.btnAddGiftCardToSystem
        Me.btnAddGiftCardToSystem.CustomImages.Parent = Me.btnAddGiftCardToSystem
        Me.btnAddGiftCardToSystem.FillColor = System.Drawing.Color.Silver
        Me.btnAddGiftCardToSystem.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddGiftCardToSystem.ForeColor = System.Drawing.Color.Black
        Me.btnAddGiftCardToSystem.HoverState.Parent = Me.btnAddGiftCardToSystem
        Me.btnAddGiftCardToSystem.Location = New System.Drawing.Point(29, 410)
        Me.btnAddGiftCardToSystem.Name = "btnAddGiftCardToSystem"
        Me.btnAddGiftCardToSystem.ShadowDecoration.Parent = Me.btnAddGiftCardToSystem
        Me.btnAddGiftCardToSystem.Size = New System.Drawing.Size(164, 53)
        Me.btnAddGiftCardToSystem.TabIndex = 50
        Me.btnAddGiftCardToSystem.Text = "Add GC"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(68, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(250, 38)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Swipe To Scan"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmGiftCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.ClientSize = New System.Drawing.Size(420, 506)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnAddGiftCardToSystem)
        Me.Controls.Add(Me.btnAddBalance)
        Me.Controls.Add(Me.Guna2Button2)
        Me.Controls.Add(Me.btnCheckBalance)
        Me.Controls.Add(Me.txtGiftAmount)
        Me.Controls.Add(Me.txtGiftcardNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmGiftCard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmGiftCard"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtGiftAmount As TextBox
    Friend WithEvents txtGiftcardNumber As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddBalance As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCheckBalance As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddGiftCardToSystem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label3 As Label
End Class
