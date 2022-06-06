Public Class frmBlondeRoastSize
    Private Sub btnSmall_Click(sender As Object, e As EventArgs) Handles btnSmall.Click
        Try

            Dim strSelect As String
            Dim strInsert As String
            Dim cmdSelect As OleDb.OleDbCommand
            Dim cmdInsert As OleDb.OleDbCommand
            Dim intNextHighestRecordID As Integer
            Dim intRowsAffected As Integer
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim strAmount As String = ""


            'Open Database, if can't connect to database, pop message box let user know
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show("Database Connection error" & vbNewLine & "The application now will be closed",
                                 Me.Text + "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Then Close the form
                Me.Close()
            End If
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID = 13"

            'Execute command
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            'read Result

            drSourceTable.Read()
            'If the table is empty, start the ID at 1. If not, start at the hight ID
            If drSourceTable.IsDBNull(0) = True Then
                intNextHighestRecordID = 1
            Else
                intNextHighestRecordID = CInt(drSourceTable.Item(0))

            End If

            'Insert new item

            strInsert = "Insert into TOrders ( intOrderNum, intItemID, monItemPrice, dtmSaleDate)" &
              " Values ('" & CInt(Int(frmMenu.lblOrderNumber.Text)) & "'," & "' 13 '," & "' 3.00 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'frmMenu.lstItems.Items.Add("Espresso          Small         1            3.50")
            'frmMenu.lstItems.SelectedIndex = frmMenu.lstItems.SelectedIndex + 1


            CloseDatabaseConnection()
            Me.Hide()
            frmMenu.Show()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub btnMedium_Click(sender As Object, e As EventArgs) Handles btnMedium.Click
        Try

            Dim strSelect As String
            Dim strInsert As String
            Dim cmdSelect As OleDb.OleDbCommand
            Dim cmdInsert As OleDb.OleDbCommand
            Dim intNextHighestRecordID As Integer
            Dim intRowsAffected As Integer
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim strAmount As String = ""


            'Open Database, if can't connect to database, pop message box let user know
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show("Database Connection error" & vbNewLine & "The application now will be closed",
                                 Me.Text + "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Then Close the form
                Me.Close()
            End If
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID = 14 "

            'Execute command
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            'read Result

            drSourceTable.Read()
            'If the table is empty, start the ID at 1. If not, start at the hight ID
            If drSourceTable.IsDBNull(0) = True Then
                intNextHighestRecordID = 1
            Else
                intNextHighestRecordID = CInt(drSourceTable.Item(0))

            End If

            'Insert new item

            strInsert = "Insert into TOrders ( intOrderNum, intItemID, monItemPrice, dtmSaleDate)" &
              " Values ('" & CInt(Int(frmMenu.lblOrderNumber.Text)) & "'," & "' 14 '," & "' 3.50 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1


            CloseDatabaseConnection()

            Me.Hide()
            frmMenu.Show()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnLarge_Click(sender As Object, e As EventArgs) Handles btnLarge.Click
        Try

            Dim strSelect As String
            Dim strInsert As String
            Dim cmdSelect As OleDb.OleDbCommand
            Dim cmdInsert As OleDb.OleDbCommand
            Dim intNextHighestRecordID As Integer
            Dim intRowsAffected As Integer
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim strAmount As String = ""


            'Open Database, if can't connect to database, pop message box let user know
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show("Database Connection error" & vbNewLine & "The application now will be closed",
                                 Me.Text + "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Then Close the form
                Me.Close()
            End If
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=15"

            'Execute command
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            'read Result

            drSourceTable.Read()
            'If the table is empty, start the ID at 1. If not, start at the hight ID
            If drSourceTable.IsDBNull(0) = True Then
                intNextHighestRecordID = 1
            Else
                intNextHighestRecordID = CInt(drSourceTable.Item(0))

            End If

            'Insert new item

            strInsert = "Insert into TOrders ( intOrderNum, intItemID, monItemPrice, dtmSaleDate)" &
              " Values ('" & CInt(Int(frmMenu.lblOrderNumber.Text)) & "'," & "' 15 '," & "' 4.00 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            Close()
            Me.Hide()
            frmMenu.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class