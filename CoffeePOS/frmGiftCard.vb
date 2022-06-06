Imports System.Data
Imports System.Data.SqlClient

Public Class frmGiftCard
    Dim cmd3 As SqlCommand

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("upsGiftCard", con)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@Number", txtGiftcardNumber.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()
            If CInt(.Parameters("@result").Value = 1) And ValidateAmount() = True Then
                Dim query As String = "update TGiftCards set dblRemainingBalance = dblRemainingBalance + @Balance where strCardNumber = @Number"
                cmd = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Balance", txtGiftAmount.Text)
                cmd.Parameters.AddWithValue("@Number", txtGiftcardNumber.Text)
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Balance Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.None)
                txtGiftAmount.BackColor = Color.White
                txtGiftcardNumber.BackColor = Color.White
            Else
                MessageBox.Show("Incorrect Gift Card Number Or Amount, Please Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGiftcardNumber.ResetText()
                txtGiftAmount.ResetText()
                txtGiftcardNumber.Select()
                con.Close()
            End If
        End With

    End Sub
    Private Function ValidateAmount()
        Try
            If txtGiftAmount.Text = String.Empty Or IsNumeric(txtGiftAmount.Text) = False Then
                txtGiftAmount.Focus()
                txtGiftAmount.BackColor = Color.Yellow
                Return False
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function
    Private Function ValidateGiftCard()
        Try
            If txtGiftcardNumber.Text = String.Empty Then
                txtGiftcardNumber.Focus()
                txtGiftcardNumber.BackColor = Color.Yellow
                Return False
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function
    Private Sub btnCheckBalance_Click(sender As Object, e As EventArgs) Handles btnCheckBalance.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("upsGiftCard", con)

        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@Number", txtGiftcardNumber.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()

            If CInt(.Parameters("@result").Value = 1) Then
                GiftCardBalance()
            Else
                MessageBox.Show("Incorrect Gift Card Number, Please Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGiftcardNumber.ResetText()
                txtGiftAmount.ResetText()
                txtGiftcardNumber.Select()
                con.Close()
            End If
        End With
        txtGiftAmount.ResetText()
        txtGiftcardNumber.ResetText()
    End Sub
    Private Function GiftCardBalance()
        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim cmd1 As SqlCommand = New SqlCommand("upsGiftCardBalance", con)
        cmd1.CommandType = CommandType.StoredProcedure
        cmd1.Parameters.AddWithValue("@Number", txtGiftcardNumber.Text)
        cmd1.Parameters.Add("@Balance", SqlDbType.Float).Direction = ParameterDirection.Output
        cmd1.ExecuteScalar()
        MessageBox.Show("Your Gift Card Remaining Balance is $" & (cmd1.Parameters("@Balance").Value))
        con.Close()
    End Function

    Private Sub btnAddGiftCardToSystem_Click(sender As Object, e As EventArgs) Handles btnAddGiftCardToSystem.Click
        If ValidateGiftCard() = False Then
            MessageBox.Show("Invalid Gift Card Number, please Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim query As String = "Insert into TGiftCards (strCardNumber, dblRemainingBalance)
                                           values(@CardNumber, @dblBalance)"

        Dim cmd As SqlCommand = New SqlCommand("upsGiftCard", con)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@Number", txtGiftcardNumber.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()
            If CInt(.Parameters("@result").Value = 0) Then
                cmd = New SqlCommand(query, con)

                cmd.Parameters.AddWithValue("@CardNumber", txtGiftcardNumber.Text)
                cmd.Parameters.AddWithValue("@dblBalance", 0)
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Gift Card Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.None)
            Else
                MessageBox.Show("Gift Card already added, Please Try another gift card", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGiftcardNumber.ResetText()
                txtGiftAmount.ResetText()
                txtGiftcardNumber.Select()
                con.Close()
            End If
        End With

        txtGiftAmount.ResetText()
        txtGiftcardNumber.ResetText()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Close()
    End Sub

    Private Sub btnAddBalance_Click(sender As Object, e As EventArgs) Handles btnAddBalance.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("upsGiftCard", con)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@Number", txtGiftcardNumber.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()
            If CInt(.Parameters("@result").Value = 1) And ValidateAmount() = True Then
                Dim query As String = "update TGiftCards set dblRemainingBalance = dblRemainingBalance + @Balance where strCardNumber = @Number"
                cmd = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Balance", txtGiftAmount.Text)
                cmd.Parameters.AddWithValue("@Number", txtGiftcardNumber.Text)
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Balance Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.None)
                txtGiftAmount.BackColor = Color.White
                txtGiftcardNumber.BackColor = Color.White
            Else
                MessageBox.Show("Incorrect Gift Card Number Or Amount, Please Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGiftcardNumber.ResetText()
                txtGiftAmount.ResetText()
                txtGiftcardNumber.Select()
                con.Close()
            End If
        End With

        txtGiftAmount.ResetText()
        txtGiftcardNumber.ResetText()
    End Sub
End Class