Imports System.Data
Imports System.Data.SqlClient
Public Class frmUpdateEmployee
    Dim con3 As SqlConnection
    Dim cmd3 As SqlCommand
    Sub filterRecords()
        con3 = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con3.Open()

        cmd3 = New SqlCommand("upsDisplayEmployees", con3)
        cmd3.CommandType = CommandType.StoredProcedure
        Dim dt3 As DataTable = New DataTable()
        dt3.Load(cmd3.ExecuteReader())
        DataGridView1.DataSource = dt3

        con3.Close()
    End Sub


    Private Sub frmUpdateEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        filterRecords()
    End Sub


    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Me.txtEmployeeID.Text = DataGridView1.Item(0, i).Value
        Me.txtFirstName.Text = DataGridView1.Item(1, i).Value
        Me.txtLastName.Text = DataGridView1.Item(2, i).Value
        Me.txtAddress.Text = DataGridView1.Item(3, i).Value
        Me.txtCity.Text = DataGridView1.Item(4, i).Value
        Me.txtState.Text = DataGridView1.Item(5, i).Value
        Me.txtZipCode.Text = DataGridView1.Item(6, i).Value
        Me.txtPhone.Text = DataGridView1.Item(7, i).Value
        Me.txtUserID.Text = DataGridView1.Item(8, i).Value
        Me.txtPassword.Text = DataGridView1.Item(9, i).Value
        Me.txtIsManager.Text = DataGridView1.Item(10, i).Value


    End Sub



    Private Sub btnUpdateEmp_Click(sender As Object, e As EventArgs) Handles btnUpdateEmp.Click
              Dim query As String = "update TEmployees set strFirstName = @FirstName, strLastName = @LastName, strAddress = @Address,
                               strCity = @City, strState = @State, strZip = @Zip, strPhoneNumber = @Phone, 
                               strUserID = @UserID, strPassword = @Password, strIsManager = @IsManager
                               where intEmployeeID = @ID"
        con3.Open()
        cmd3 = New SqlCommand(query, con3)
        cmd3.Parameters.AddWithValue("@ID", txtEmployeeID.Text)
        cmd3.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
        cmd3.Parameters.AddWithValue("@LastName", txtLastName.Text)
        cmd3.Parameters.AddWithValue("@Address", txtAddress.Text)
        cmd3.Parameters.AddWithValue("@City", txtCity.Text)
        cmd3.Parameters.AddWithValue("@State", txtState.Text)
        cmd3.Parameters.AddWithValue("@Zip", txtZipCode.Text)
        cmd3.Parameters.AddWithValue("@Phone", txtPhone.Text)
        cmd3.Parameters.AddWithValue("@UserID", txtUserID.Text)
        cmd3.Parameters.AddWithValue("@Password", txtPassword.Text)
        cmd3.Parameters.AddWithValue("@IsManager", txtIsManager.Text)
        cmd3.ExecuteNonQuery()
        con3.Close()
        MsgBox("Employee Info Updated Successfully")
        filterRecords()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click


        Me.Hide()
        frmAdmin.Show()


    End Sub
End Class