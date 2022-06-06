Imports System.Data.SqlClient

Public Class frmMenu

    Dim i As Integer = 0
    Dim j As Integer = 0


    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmLogIn.Show()
        Me.Hide()

    End Sub

    Private Sub btnCoffee_Click(sender As Object, e As EventArgs) Handles btnCoffee.Click

        pnlCoffee.Visible = True
        pnlDessert.Visible = False
        pnlFrap.Visible = False
        pnlExtra.Visible = False



    End Sub

    Private Sub btnFrap_Click(sender As Object, e As EventArgs) Handles btnFrap.Click

        pnlCoffee.Visible = False
        pnlDessert.Visible = False
        pnlFrap.Visible = True
        pnlExtra.Visible = False
    End Sub

    Private Sub btnEspresso_Click(sender As Object, e As EventArgs) Handles btnCoffeeEspresso.Click

        frmCoffEssSize.ShowDialog()
        frmMenu_Load(sender, e)

    End Sub

    Private Function getSize() As Integer
        frmCoffEssSize.Show()
        getSize = intSize

    End Function

    Private Sub getT()
        pnlTemp.Show()
    End Sub


    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        pnlCoffee.Visible = True
        pnlFrap.Visible = False
        pnlDessert.Visible = False
        pnlExtra.Visible = False

        pnlTemp.Visible = False




        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' Used for select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' This is where data is retreived to 
            Dim dt As DataTable = New DataTable 'This is the table used to load data from reader
            Dim strSelectPrice As String = ""

            'Open Database. if could not connect to sever, Show message box to let user know
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine & "The application now will be close.", Me.Text + "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Close the application
                Me.Close()

            End If

            ' Build the select statement for all vehicle model to load the combo box
            strSelect = " SELECT TI.intItemID ,TI.strItemName, TI.strSize, TI.monPrice, TOR.intOrderID,TOR.intOrderNum
                        FROM TOrders AS TOR	,TItems AS TI
                        WHERE TOR.intItemID = TI.intItemID 
                            AND TOR.intOrderNum = " & lblOrderNumber.Text.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the list box.
            lstItems.ValueMember = "intOrderID"
            lstItems.DisplayMember = "strItemName"
            lstItems.DataSource = dt



            ' Select the first item in the list by default
            If lstItems.Items.Count > 0 Then lstItems.SelectedIndex = 0


            Dim dblTotal As Double = 0.00
            Dim dblTax As Double = 0.07
            Dim dblTaxTotal As Double = 0.00
            Dim dblGrandTotal As Double = 0.00
            Try
                Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
                con.Open()
                Dim sql As String = "SELECT SUM(monItemPrice) as TotalPrice FROM TOrders
                                WHERE intOrderNum =" & lblOrderNumber.Text.ToString
                Dim cmd As SqlCommand = New SqlCommand(sql)
                cmd.Connection = con
                Dim rdr As SqlDataReader = cmd.ExecuteReader()
                If rdr.Read Then
                    dblTotal = Convert.ToDouble(String.Format("{0:0.00}", rdr.Item("TotalPrice")))
                    dblTaxTotal = Convert.ToDouble(String.Format("{0:0.00}", (rdr.Item("TotalPrice") * 0.07)))
                    dblGrandTotal = Convert.ToDouble(String.Format("{0:0.00}", (dblTotal + dblTaxTotal)))

                    lblTotal.Text = dblTotal.ToString
                    lblTax.Text = dblTaxTotal.ToString
                    lblGrandTotal.Text = dblGrandTotal.ToString
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
                con.Close()

            Catch ex As Exception

            End Try

            ' Show any changes
            lstItems.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Private Sub btnDessert_Click(sender As Object, e As EventArgs) Handles btnDessert.Click

        pnlCoffee.Visible = False
        pnlFrap.Visible = False
        pnlDessert.Visible = True
        pnlExtra.Visible = False
    End Sub

    Private Sub btnExtra_Click(sender As Object, e As EventArgs) Handles btnExtra.Click

        pnlCoffee.Visible = False
        pnlFrap.Visible = False
        pnlDessert.Visible = False
        pnlExtra.Visible = True

    End Sub


    Private Sub btnHot_Click(sender As Object, e As EventArgs) Handles btnHot.Click
        pnlTemp.Visible = False
        frmCoffEssSize.Refresh()
        frmCoffEssSize.Show()
    End Sub

    Private Sub btnCold_Click(sender As Object, e As EventArgs) Handles btnCold.Click
        pnlTemp.Visible = False

        frmCoffEssSize.Refresh()
        frmCoffEssSize.Show()
    End Sub

    Private Sub btnGiftCard_Click(sender As Object, e As EventArgs) Handles btnGiftCard.Click
        frmGiftCard.ShowDialog()
    End Sub



    Private Sub btnCoffeeMocha_Click(sender As Object, e As EventArgs) Handles btnCoffeeMocha.Click
        frmMochaSize.showdialog()
        frmMenu_Load(sender, e)
    End Sub

    Private Sub btnCoffeeWhiteMocha_Click(sender As Object, e As EventArgs) Handles btnCoffeeWhiteMocha.Click
        frmWhiteMochaSize.showDialog()
        frmMenu_Load(sender, e)

    End Sub

    Private Sub btnCoffeeAmericano_Click(sender As Object, e As EventArgs) Handles btnCoffeeAmericano.Click

        frmCoffAmericanoSize.ShowDialog()
        frmMenu_Load(sender, e)
    End Sub

    Private Sub btnCoffeeMachiato_Click(sender As Object, e As EventArgs) Handles btnCoffeeMachiato.Click
        frmMachiatoSize.showdialog()
        frmMenu_Load(sender, e)

    End Sub

    Private Sub btnCoffeeDarkRoast_Click(sender As Object, e As EventArgs) Handles btnCoffeeDarkRoast.Click
        frmDarkRoastSize.ShowDialog()
        frmMenu_Load(sender, e)

    End Sub

    Private Sub btnCoffeeBlondeRoast_Click(sender As Object, e As EventArgs) Handles btnCoffeeBlondeRoast.Click
        frmBlondeRoastSize.ShowDialog()
        frmMenu_Load(sender, e)

    End Sub

    Private Sub btnCoffeeLatte_Click(sender As Object, e As EventArgs) Handles btnCoffeeLatte.Click

        frmCoffLateSize.ShowDialog()
        frmMenu_Load(sender, e)

    End Sub

    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click

        Try
            Dim strDelete As String = ""
            Dim strSelect As String = String.Empty
            Dim strDealer As String = ""
            Dim intRowsAffected As Integer
            Dim cmdDelete As OleDb.OleDbCommand 'command used for deletion
            Dim dt As DataTable = New DataTable 'Data table load from reader
            ' open the database, if can not connect to database, pop message box let user know
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                'close the form
                Me.Close()
            End If

            'delete from the table TDealerAutos in SQL
            strDelete = "Delete FROM TOrders where intOrderID = " & lstItems.SelectedValue.ToString

            ' Delete the record
            cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
            intRowsAffected = cmdDelete.ExecuteNonQuery()

            ' close the database connection
            CloseDatabaseConnection()

            ' refresh the form
            frmMenu_Load(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        frmCheckOut.ShowDialog()
        frmMenu_Load(sender, e)
    End Sub

    Private Sub btnEspessoShot_Click(sender As Object, e As EventArgs) Handles btnEspessoShot.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=52"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 52 '," & "' 0.90 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSisupShot_Click(sender As Object, e As EventArgs) Handles btnSisupShot.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=53"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 53 '," & "' 0.50 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSoyMilk_Click(sender As Object, e As EventArgs) Handles btnSoyMilk.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=54"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 54 '," & "' 0.60 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAppleGallette_Click(sender As Object, e As EventArgs) Handles btnAppleGallette.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=46"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 46 '," & "' 5.25 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnWaffle_Click(sender As Object, e As EventArgs) Handles btnWaffle.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=47"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 47 '," & "' 5.00 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnPlainBagel_Click(sender As Object, e As EventArgs) Handles btnPlainBagel.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=48"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 48 '," & "' 1.75 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnFlavourBagel_Click(sender As Object, e As EventArgs) Handles btnFlavourBagel.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=49"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 49 '," & "' 2.45 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnPlainCroisant_Click(sender As Object, e As EventArgs) Handles btnPlainCroisant.Click

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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=50"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 50 '," & "' 2.95 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnFlavourCroisant_Click(sender As Object, e As EventArgs) Handles btnFlavourCroisant.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=51"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 51 '," & "' 3.50 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnFrapCaramel_Click(sender As Object, e As EventArgs) Handles btnFrapCaramel.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=27"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 27 '," & "' 5.50 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnFrapPeppermint_Click(sender As Object, e As EventArgs) Handles btnFrapPeppermint.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=30"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 30 '," & "' 5.50 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnFrapMocha_Click(sender As Object, e As EventArgs) Handles btnFrapMocha.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=33"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 33 '," & "' 5.50 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnFrapWhiteMocha_Click(sender As Object, e As EventArgs) Handles btnFrapWhiteMocha.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=36"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 36 '," & "' 5.50 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnFrapMachaLatte_Click(sender As Object, e As EventArgs) Handles btnFrapMachaLatte.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=39"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 39 '," & "' 5.75 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnFrapCookie_Click(sender As Object, e As EventArgs) Handles btnFrapCookie.Click
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
            strSelect = "SELECT intItemID, strCategory, strItemName, strSize, monPrice FROM TItems WHERE intItemID=42"

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
              " Values ('" & CInt(Int(lblOrderNumber.Text)) & "'," & "' 42 '," & "' 6.00 '," & "  GETDATE() )"

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()
            'show message box let user know the item has been added


            'lstItems.Items.Add("Espresso           1            3.50")
            'lstItems.SelectedIndex = lstItems.SelectedIndex + 1

            CloseDatabaseConnection()

            frmMenu_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class