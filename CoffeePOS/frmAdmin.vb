Imports System.Data
Imports System.Data.SqlClient
Public Class frmAdmin

    Dim con3 As SqlConnection
    Dim cmd3 As SqlCommand

    Dim con4 As SqlConnection
    Dim cmd4 As SqlCommand


    Dim con5 As SqlConnection
    Dim cmd5 As SqlCommand


    Sub fillGridview5()
        con5 = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        Try

            Dim query1 As String = "select TOD.intOrderNum as OrderNumber,  TOD.intItemID As ItemID, TIT.strItemName as ItemName, monItemPrice as Price 
                                    from TOrders AS TOD
                                    join TItems AS TIT
                                    on TOD.intItemID = TIT.intItemID
                                    where dtmSaleDate >= @StartDate and dtmSaleDate <= @EndDate"
            cmd5 = New SqlCommand(query1, con5)

            cmd5.Parameters.AddWithValue("@StartDate", DateTimePicker1Sale.Value)
            cmd5.Parameters.AddWithValue("@EndDate", DateTimePicker2Sale.Value)
            Dim adapter As New SqlDataAdapter(cmd5)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            grdSale.DataSource = dt
            Dim sum As Double
            Dim TotalHours As Double
            For i = 0 To dt.Rows.Count - 1
                TotalHours = dt.Rows(i).Item(3).ToString
                sum += CDbl(TotalHours.ToString("n2"))
            Next
            txtTotalSale.Text = sum
        Catch ex As Exception
            MessageBox.Show("Please Check Your Data and try again")
        End Try

    End Sub

    Sub filterRecords2()
        con4 = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        Dim query1 As New SqlCommand("select strFirstName, intEmployeeID from TEmployees", con3)
        con4.Open()
        Dim adapter1 As New SqlDataAdapter(query1)

        Dim dt4 As New DataTable()
        adapter1.Fill(dt4)
        Dim row As DataRow = dt4.NewRow()

        row(0) = "Select"
        dt4.Rows.InsertAt(row, 0)
        cboFirstName.DataSource = dt4
        cboFirstName.DisplayMember = "strFirstName"
        cboFirstName.ValueMember = "intEmployeeID"

        con3.Close()
    End Sub

    Sub filterRecords()
        con3 = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con3.Open()

        cmd3 = New SqlCommand("upsDisplayInventory", con3)
        Dim query2 As New SqlCommand("select * from TEmployees", con3)
        Dim adapter2 As New SqlDataAdapter(query2)
        Dim dt5 As New DataTable()
        adapter2.Fill(dt5)
        grdEmployee.DataSource = dt5
        cmd3.CommandType = CommandType.StoredProcedure
        Dim dt3 As DataTable = New DataTable()
        dt3.Load(cmd3.ExecuteReader())
        lstInventory.DataSource = dt3

        con3.Close()
    End Sub

    Sub fillGridview()
        con4 = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        Try
            Dim query1 As String = "select TE.strFirstName AS FirstName, TE.strLastName AS LastName,  TOC.dtmDate AS Date, TOC.intHoursWorked AS HoursWorked
                                from TEmployees As TE
                                join TOnclock as TOC
                                on TE.intEmployeeID = TOC.intEmployeeID
                                where te.strFirstName = @FirstName and TOC.intHoursWorked is not null
                                and te.strPassword = @Password and TOC.dtmDate >= @StartDate and TOC.dtmDate <= @EndDate"
            cmd4 = New SqlCommand(query1, con4)
            cmd4.Parameters.AddWithValue("@FirstName", cboFirstName.Text)
            cmd4.Parameters.AddWithValue("@Password", txtPassword.Text)
            cmd4.Parameters.AddWithValue("@StartDate", DateTimePicker1.Value)
            cmd4.Parameters.AddWithValue("@EndDate", DateTimePicker2.Value)
            Dim adapter As New SqlDataAdapter(cmd4)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            grdTimeSheet.DataSource = dt
            Dim sum As Double
            Dim TotalHours As Double
            For i = 0 To dt.Rows.Count - 1
                TotalHours = dt.Rows(i).Item(3).ToString
                sum += CDbl(TotalHours.ToString("n2"))
            Next
            txtTotalHours.Text = sum
        Catch ex As Exception
            MessageBox.Show("Please Check Your Data and try again")
        End Try

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmLogIn.Show()
        Me.Hide()

    End Sub

    Private Sub lstInventory_MouseClick(sender As Object, e As MouseEventArgs)
        Dim i As Integer
        i = lstInventory.CurrentRow.Index
        Me.txtInventoryID.Text = lstInventory.Item(0, i).Value
        Me.txtItemName.Text = lstInventory.Item(1, i).Value
        Me.txtQuantity.Text = lstInventory.Item(2, i).Value
        Me.txtSize.Text = lstInventory.Item(3, i).Value


    End Sub
    Private Sub frmAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        filterRecords()
        pnlEmpSetUp.Visible = False
        pnlInventory.Visible = False
        pnlSale.Visible = True
        pnlTimeSheet.Visible = False

        filterRecords2()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "MM/dd/yyyy"

        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "MM/dd/yyyy"

        DateTimePicker1Sale.Format = DateTimePickerFormat.Custom
        DateTimePicker1Sale.CustomFormat = "MM/dd/yyyy"

        DateTimePicker2Sale.Format = DateTimePickerFormat.Custom
        DateTimePicker2Sale.CustomFormat = "MM/dd/yyyy"

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Dim query As String = "update TInventory set intQuantity = @Quantity where intInventoryID = @ID"
        con3.Open()
        cmd3 = New SqlCommand(query, con3)
        cmd3.Parameters.AddWithValue("@ID", txtInventoryID.Text)
        cmd3.Parameters.AddWithValue("@Quantity", txtQuantity.Text)
        cmd3.ExecuteNonQuery()
        con3.Close()
        MsgBox("Inventory Updated Successfully")
        filterRecords()
    End Sub





    Private Sub txtSize_TextChanged(sender As Object, e As EventArgs) Handles txtSize.TextChanged, txtPrice.TextChanged

    End Sub

    Private Sub btnEmp_Click_1(sender As Object, e As EventArgs) Handles btnEmp.Click
        pnlEmpSetUp.Visible = True
        pnlInventory.Visible = False
        pnlSale.Visible = False
        pnlTimeSheet.Visible = False
        pnlViewOrder.Visible = False
    End Sub

    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        frmAddEmployee.ShowDialog()
        frmAdmin_Load(sender, e)
        pnlEmpSetUp.Show()


    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        frmDeleteEmployee.ShowDialog()
        frmAdmin_Load(sender, e)
        pnlEmpSetUp.Show()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        frmUpdateEmployee.ShowDialog()
        frmAdmin_Load(sender, e)
    End Sub

    Private Sub btnShcedule_Click(sender As Object, e As EventArgs) Handles btnShcedule.Click
        pnlEmpSetUp.Visible = False
        pnlInventory.Visible = False
        pnlSale.Visible = False
        pnlTimeSheet.Visible = True
        pnlViewOrder.Visible = False
    End Sub

    Private Sub btnViewOrder_Click(sender As Object, e As EventArgs) Handles btnViewOrder.Click
        pnlEmpSetUp.Visible = False
        pnlInventory.Visible = False
        pnlSale.Visible = False
        pnlTimeSheet.Visible = False
        pnlViewOrder.Visible = True

    End Sub

    Private Sub btnPrinterSetUp_Click(sender As Object, e As EventArgs) Handles btnPrinterSetUp.Click


    End Sub

    Private Sub lstInventory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles lstInventory.CellContentClick

    End Sub

    Private Sub btnViewTrans_Click(sender As Object, e As EventArgs) Handles btnViewTrans.Click
        Dim strSelect As String = ""
        Dim strName As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

        ' open the database this is in module
        If OpenDatabaseConnectionSQLServer() = False Then

            ' No, warn the user ...
            MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' and close the form/application
            Me.Close()

        End If

        ' Build the select statement using PK from name selected
        strSelect = " Select * from TTransactions"

        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader

        ' load the data table from the reader
        dt.Load(drSourceTable)

        grdTrans.DataSource = dt

        ' close the database connection
        CloseDatabaseConnection()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        fillGridview5()
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        pnlEmpSetUp.Visible = False
        pnlInventory.Visible = True
        pnlSale.Visible = False
        pnlTimeSheet.Visible = False
        pnlViewOrder.Visible = False
    End Sub

    Private Sub btnCalculateTime_Click(sender As Object, e As EventArgs) Handles btnCalculateTime.Click
        If cboFirstName.Text.Equals("Select") = True Then
            MsgBox("Please Select First Name and try again")
            cboFirstName.BackColor = Color.Yellow
            cboFirstName.Focus()
            Exit Sub
        End If
        If txtPassword.Text = String.Empty Then
            cboFirstName.BackColor = Color.White
            MsgBox("Please Enter Password and try again")
            txtPassword.BackColor = Color.Yellow
            txtPassword.Focus()
            Exit Sub
        End If
        con3 = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con3.Open()
        Dim cmd As SqlCommand = New SqlCommand("upsValidateForTimesheet", con3)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@FirstName", cboFirstName.Text)
            .Parameters.AddWithValue("@Password", txtPassword.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()
        End With
        If CInt(cmd.Parameters("@result").Value = 0) Then
            MsgBox("First Name and Password Combination incorrect, Please try again")
            Exit Sub
        End If
        Try
            txtPassword.BackColor = Color.White
            fillGridview()
            grdTimeSheet.Show()
        Catch ex As Exception
            MessageBox.Show("Please Check your data and try agian")
        End Try
        txtTotalHours.Show()
        lblTotalHours.Show()
    End Sub
    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles lstInventory.MouseClick
        Dim i As Integer
        i = lstInventory.CurrentRow.Index
        Me.txtInventoryID.Text = lstInventory.Item(0, i).Value
        Me.txtItemName.Text = lstInventory.Item(1, i).Value
        Me.txtQuantity.Text = lstInventory.Item(2, i).Value
        Me.txtSize.Text = lstInventory.Item(3, i).Value
        Me.txtPrice.Text = lstInventory.Item(4, i).Value


    End Sub

    Private Sub btnSalesMNG_Click(sender As Object, e As EventArgs) Handles btnSalesMNG.Click
        pnlEmpSetUp.Visible = False
        pnlInventory.Visible = False
        pnlSale.Visible = True
        pnlTimeSheet.Visible = False
        pnlViewOrder.Visible = False
    End Sub

    Private Sub btnUpdate_Click_1(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim query As String = "update TInventory set intQuantity = @Quantity where intInventoryID = @ID"
        con3.Open()
        cmd3 = New SqlCommand(query, con3)
        cmd3.Parameters.AddWithValue("@ID", txtInventoryID.Text)
        cmd3.Parameters.AddWithValue("@Quantity", txtQuantity.Text)
        cmd3.ExecuteNonQuery()
        con3.Close()
        MsgBox("Inventory Updated Successfully")
        filterRecords()
    End Sub
End Class