Imports System.Data
Imports System.Data.SqlClient


Public Class frmPaidGC

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click


        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("upsGiftCard", con)
        Dim cmd1 As SqlCommand = New SqlCommand("upsGiftCardBalance", con)
        cmd1.CommandType = CommandType.StoredProcedure
        cmd1.Parameters.AddWithValue("@Number", txtGiftcardNumber.Text)
        cmd1.Parameters.Add("@Balance", SqlDbType.Int).Direction = ParameterDirection.Output
        cmd1.ExecuteScalar()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@Number", txtGiftcardNumber.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()
            If CInt(.Parameters("@result").Value = 1) Then
                Dim dblBalance As Double = 0.00
                dblBalance = CDbl(lblBalance.Text)

                If ((CInt(cmd1.Parameters("@Balance").Value >= dblBalance))) Then
                    Dim query As String = "update TGiftCards set dblRemainingBalance = dblRemainingBalance - @Balance where strCardNumber = @Number"
                    cmd = New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Balance", lblBalance.Text)
                    cmd.Parameters.AddWithValue("@Number", txtGiftcardNumber.Text)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show("Thank You For Your Business", "Success", MessageBoxButtons.OK, MessageBoxIcon.None)
                    GiftCardBalance()
                Else
                    MsgBox("Insufficent Balance on gift card, Try agian")
                    Exit Sub
                End If
            Else
                MessageBox.Show("Incorrect Gift Card Number, Please Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGiftcardNumber.ResetText()

                txtGiftcardNumber.Select()
                con.Close()
            End If
        End With


    End Sub
    Private Function GiftCardBalance()
        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim cmd1 As SqlCommand = New SqlCommand("upsGiftCardBalance", con)
        cmd1.CommandType = CommandType.StoredProcedure
        cmd1.Parameters.AddWithValue("@Number", txtGiftcardNumber.Text)
        cmd1.Parameters.Add("@Balance", SqlDbType.Float).Direction = ParameterDirection.Output
        cmd1.ExecuteScalar()
        MessageBox.Show("Your Gift Card Remaining Balance is $" & cmd1.Parameters("@Balance").Value)
        con.Close()
    End Function

    Private Sub frmPaidGC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblBalance.Text = frmCheckOut.lblBalance.Text
    End Sub
End Class