Imports System.Data.SqlClient

Public Class frmCheckOut

    Public Property Total As Double

    Private Sub btnNo1_Click(sender As Object, e As EventArgs) Handles btnNo1.Click
        txtCashPaid.Text = txtCashPaid.Text + "1"

    End Sub

    Private Sub btnNo2_Click(sender As Object, e As EventArgs) Handles btnNo2.Click
        txtCashPaid.Text = txtCashPaid.Text + "2"

    End Sub

    Private Sub btnNo3_Click(sender As Object, e As EventArgs) Handles btnNo3.Click
        txtCashPaid.Text = txtCashPaid.Text + "3"

    End Sub

    Private Sub btnNo4_Click(sender As Object, e As EventArgs) Handles btnNo4.Click
        txtCashPaid.Text = txtCashPaid.Text + "4"

    End Sub

    Private Sub btnNo5_Click(sender As Object, e As EventArgs) Handles btnNo5.Click
        txtCashPaid.Text = txtCashPaid.Text + "5"

    End Sub

    Private Sub btnNo6_Click(sender As Object, e As EventArgs) Handles btnNo6.Click
        txtCashPaid.Text = txtCashPaid.Text + "6"

    End Sub

    Private Sub btnNo7_Click(sender As Object, e As EventArgs) Handles btnNo7.Click
        txtCashPaid.Text = txtCashPaid.Text + "7"

    End Sub

    Private Sub btnNo8_Click(sender As Object, e As EventArgs) Handles btnNo8.Click
        txtCashPaid.Text = txtCashPaid.Text + "8"

    End Sub

    Private Sub btnNo9_Click(sender As Object, e As EventArgs) Handles btnNo9.Click
        txtCashPaid.Text = txtCashPaid.Text + "9"

    End Sub

    Private Sub btnNo0_Click(sender As Object, e As EventArgs) Handles btnNo0.Click
        txtCashPaid.Text = txtCashPaid.Text + "0"

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtCashPaid.Clear()

    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If txtCashPaid.Text.Count > 0 Then
            txtCashPaid.Text = txtCashPaid.Text.Remove(txtCashPaid.Text.Count - 1)
        End If
    End Sub

    Private Sub frmCheckOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblBalance.Text = frmMenu.lblGrandTotal.Text


    End Sub




    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Dim strCurrency As String = ""
    Dim acceptableKey As Boolean = False


    Private Sub txtCashPaid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCashPaid.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
        If acceptableKey = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
            Return
        Else
            If e.KeyChar = Convert.ToChar(Keys.Back) Then
                If strCurrency.Length > 0 Then
                    strCurrency = strCurrency.Substring(0, strCurrency.Length - 1)
                End If
            Else
                strCurrency = strCurrency & e.KeyChar
            End If

            If strCurrency.Length = 0 Then
                txtCashPaid.Text = ""
            ElseIf strCurrency.Length = 1 Then
                txtCashPaid.Text = "0.0" & strCurrency
            ElseIf strCurrency.Length = 2 Then
                txtCashPaid.Text = "0." & strCurrency
            ElseIf strCurrency.Length > 2 Then
                txtCashPaid.Text = strCurrency.Substring(0, strCurrency.Length - 2) & "." & strCurrency.Substring(strCurrency.Length - 2)
            End If
            txtCashPaid.Select(txtCashPaid.Text.Length, 0)

        End If
        e.Handled = True

    End Sub

    Private Sub txtCashPaid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCashPaid.KeyDown
        If (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse e.KeyCode = Keys.Back Then
            acceptableKey = True
        Else
            acceptableKey = False
        End If
    End Sub



    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles btnCard.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        Dim cmd3 As SqlCommand
        Dim query1 As String = "SELECT MAX(intOrderNum) as MAX FROM TOrders "
        cmd3 = New SqlCommand(query1, con)

        Dim adapter As New SqlDataAdapter(cmd3)
        Dim dt As New DataTable()
        adapter.Fill(dt)
        Dim intCount As Integer
        intCount = dt.Rows(0).Item(0).ToString

        Dim intCount1 As Integer
        intCount1 = intCount + 1

        frmMenu.lblOrderNumber.Text = intCount1.ToString
        'frmLogIn.Show()

        frmLogIn.Show()
        frmMenu.lblTotal.Text = "0.00"
        frmMenu.lblTax.Text = "0.00"
        frmMenu.lblGrandTotal.Text = "0.00"

        frmMenu.Hide()
        Me.Hide()

        txtCashPaid.ResetText()
        lblChange.ResetText()
        lblBalance.ResetText()



    End Sub

    Private Sub btnGiftCard_Click(sender As Object, e As EventArgs) Handles btnGiftCard.Click

        frmPaidGC.ShowDialog()

    End Sub

    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles btnCash.Click

        Try

            Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
            Dim cmd3 As SqlCommand
            Dim query1 As String = "SELECT MAX(intOrderNum) as MAX FROM TOrders "
            cmd3 = New SqlCommand(query1, con)

            Dim adapter As New SqlDataAdapter(cmd3)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            Dim intCount As Integer
            intCount = dt.Rows(0).Item(0).ToString

            Dim intCount1 As Integer
            intCount1 = intCount + 1

            frmMenu.lblOrderNumber.Text = intCount1.ToString
            'frmLogIn.Show()

            frmMenu.lblTotal.Text = "0.00"
            frmMenu.lblTax.Text = "0.00"
            frmMenu.lblGrandTotal.Text = "0.00"

            Dim Moneys As Double
            Dim difference As Double
            Dim dblTotal As Double = 0.00

            dblTotal = CDbl(lblBalance.Text)

            Moneys = CDbl(txtCashPaid.Text)

            If (Moneys >= dblTotal) Then

                difference = Moneys - dblTotal
                lblChange.Text = difference
                MessageBox.Show("The change is $" + difference.ToString + ".")

                frmLogIn.Show()
                Me.Hide()
                frmMenu.Hide()

                txtCashPaid.ResetText()
                lblChange.ResetText()
                lblBalance.ResetText()

            Else

                MessageBox.Show("Insufficent fund, please try again")

            End If

        Catch ex As Exception

        End Try


    End Sub
End Class