Imports System.Data
Imports System.Data.SqlClient
Public Class frmAddEmployee

    Dim con3 As SqlConnection
    Dim cmd3 As SqlCommand
    Dim cmd4 As SqlCommand

    Sub filterRecords()
        con3 = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        Dim query As New SqlCommand("select * from TStates", con3)
        Dim query1 As New SqlCommand("select * from TIsManager", con3)
        Dim query2 As New SqlCommand("select * from TEmployees", con3)
        con3.Open()
        Dim adapter As New SqlDataAdapter(query)
        Dim adapter1 As New SqlDataAdapter(query1)
        Dim adapter2 As New SqlDataAdapter(query2)

        Dim dt3 As New DataTable()
        Dim dt4 As New DataTable()
        Dim dt5 As New DataTable()
        adapter.Fill(dt3)
        adapter1.Fill(dt4)
        adapter2.Fill(dt5)
        cboState.DataSource = dt3
        cboIsManager.DataSource = dt4
        cboState.DisplayMember = "strState"
        cboState.ValueMember = "intStateID"
        cboIsManager.DisplayMember = "strIsManager"
        cboIsManager.ValueMember = "intIsManagerID"
        txtFirstName.Focus()

        con3.Close()
    End Sub
    Private Sub frmAddEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        filterRecords()
    End Sub
    Private Function ValidateFirstName()
        Try
            If txtFirstName.Text = String.Empty Or IsNumeric(txtFirstName.Text) = True Then
                txtFirstName.Focus()
                txtFirstName.BackColor = Color.Yellow
                Return False
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function

    Private Function ValidateLastName()
        Try
            If txtLastName.Text = String.Empty Or IsNumeric(txtLastName.Text) = True Then
                txtLastName.Focus()
                txtLastName.BackColor = Color.Yellow
                Return False
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function

    Private Function ValidateAddress()
        Try
            If txtAddress.Text = String.Empty Then
                txtAddress.Focus()
                txtAddress.BackColor = Color.Yellow
                Return False
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function
    Private Function ValidateCity()
        Try
            If txtCity.Text = String.Empty Then
                txtCity.Focus()
                txtCity.BackColor = Color.Yellow
                Return False
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function



    Private Function ValidateZip()
        Try
            If txtZipCode.TextLength <> 5 Or IsNumeric(txtZipCode.Text) = False Then
                txtZipCode.Focus()
                txtZipCode.BackColor = Color.Yellow
                Return False
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function
    Private Function ValidatePhoneNumber()
        Try
            If txtPhone.TextLength <> 10 Or IsNumeric(txtPhone.Text) = False Then
                txtPhone.Focus()
                txtPhone.BackColor = Color.Yellow
                Return False
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function

    Private Function ValidateUserID()
        Try
            If txtUserID.Text = String.Empty Then
                txtUserID.Focus()
                txtUserID.BackColor = Color.Yellow
                Return False
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function

    Private Function ValidatePassword()
        Try
            If txtPassword.Text = String.Empty Then
                txtPassword.Focus()
                txtPassword.BackColor = Color.Yellow
                Return False
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function


    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        If ValidateFirstName() = False Then
            MessageBox.Show("Invalid First Name, please Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If ValidateLastName() = False Then
            MessageBox.Show("Invalid Last Name, Please Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If ValidateAddress() = False Then
            MessageBox.Show("Invalid Address, please Try again(Address Can't be Empty)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If ValidateCity() = False Then
            MessageBox.Show("Invalid City, please Try again(City Can't be Empty)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If ValidateZip() = False Then
            MessageBox.Show("Invalid Zip Code, please Try again,(Zip code must be 5 digit Number)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End If

        If ValidatePhoneNumber() = False Then
            MessageBox.Show("Invalid Phone Number, please Try again,(Phone Number must be 10 digit Number)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End If
        If ValidateUserID() = False Then
            MessageBox.Show("Invalid UserID, please Try again,(UserID can't be empty)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End If
        If ValidatePassword() = False Then
            MessageBox.Show("Invalid Password, please Try again,(Password can't be empty)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End If
        Try
            Dim query As String = "Insert into TEmployees (strFirstName, strLastName, strAddress, strCity, strState, strZip, strPhoneNumber, strUserID, strPassword, strIsManager, strHireDate,dtmTerminationDate) 
                                values(@FirstName,@LastName, @Address, @City, @State, @Zip, @Phone, @UserID, @Password, @IsManager, @HireDate,@TerminationDate )"
            Dim qurey1 As String = "Insert into TOnclock(intEmployeeID, intOnClock,dtmDate, dtmClockIn, dtmClockOut, intHoursWorked)
                                        Values(@EmployeeID, @onclock, @Date, @clockin, @clockOut, @HoursWorked)"

            con3.Open()
            cmd3 = New SqlCommand(query, con3)

            cmd3.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
            cmd3.Parameters.AddWithValue("@LastName", txtLastName.Text)
            cmd3.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmd3.Parameters.AddWithValue("@City", txtCity.Text)
            cmd3.Parameters.AddWithValue("@State", cboState.Text)
            cmd3.Parameters.AddWithValue("@Zip", txtZipCode.Text)
            cmd3.Parameters.AddWithValue("@Phone", txtPhone.Text)
            cmd3.Parameters.AddWithValue("@UserID", txtUserID.Text)
            cmd3.Parameters.AddWithValue("@Password", txtPassword.Text)
            cmd3.Parameters.AddWithValue("@IsManager", cboIsManager.Text)
            cmd3.Parameters.AddWithValue("@HireDate", Date.Now)
            cmd3.Parameters.AddWithValue("@TerminationDate", DBNull.Value)
            cmd3.ExecuteNonQuery()

            cmd4 = New SqlCommand(qurey1, con3)
            cmd4.Parameters.AddWithValue("@EmployeeID", 3)
            cmd4.Parameters.AddWithValue("@onclock", 2)
            cmd4.Parameters.AddWithValue("@Date", DBNull.Value)
            cmd4.Parameters.AddWithValue("@clockin", DBNull.Value)
            cmd4.Parameters.AddWithValue("@clockOut", DBNull.Value)
            cmd4.Parameters.AddWithValue("@HoursWorked", DBNull.Value)
            cmd4.ExecuteNonQuery()
            con3.Close()

            MsgBox("Employee Added Successfully")
            filterRecords()

            Me.Hide()
            frmAdmin.Show()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class