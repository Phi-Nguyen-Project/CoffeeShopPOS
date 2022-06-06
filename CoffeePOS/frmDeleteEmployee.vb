Imports System.Data
Imports System.Data.SqlClient

Public Class frmDeleteEmployee

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
    Private Sub frmDeleteEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        filterRecords()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        frmAdmin.Show()
    End Sub

    Private Sub btnDeleteEmp_Click(sender As Object, e As EventArgs) Handles btnDeleteEmp.Click
        Dim index As Integer
        Dim dialog As DialogResult
        index = DataGridView1.CurrentCell.RowIndex
        dialog = MessageBox.Show("Are you sure you want to Terminate the selected employee", "Delete", MessageBoxButtons.YesNo)
        If dialog = DialogResult.Yes Then

            Dim query As String = "Update TEmployees set dtmTerminationDate = @TerminationDate where intEmployeeID = @ID"
            con3.Open()
            cmd3 = New SqlCommand(query, con3)
            cmd3.Parameters.AddWithValue("@TerminationDate", Date.Now)
            cmd3.Parameters.AddWithValue("@ID", index + 1)

            cmd3.ExecuteNonQuery()

            con3.Close()

            MsgBox("Employee Terminated Successfully")

            filterRecords()
            DataGridView1.Rows(index).DefaultCellStyle.BackColor = Color.Red
        End If

    End Sub

End Class