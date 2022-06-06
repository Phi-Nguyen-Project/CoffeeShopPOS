Imports System.Data.SqlClient
Imports System.Windows.Forms.AxHost

Public Class frmLogIn

    Dim rs As New Resizer


    Private Sub frmLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rs.FindAllControls(Me)


        lbltest.Visible = False

        Timer.Enabled = True



    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)

    End Sub

    Private Sub btnViewTrans_Click(sender As Object, e As EventArgs) Handles btnViewTrans.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("uspLogin", con)
        With cmd
            .CommandType = CommandType.StoredProcedure

            .Parameters.AddWithValue("@Password", txtLogInID.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()

            If CInt(.Parameters("@result").Value = 1) Then


                con.Close()

                frmViewTransaction.ShowDialog()

            Else
                MessageBox.Show("login fail, Please Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                txtLogInID.ResetText()
                txtLogInID.Select()

                con.Close()
            End If
        End With


        txtLogInID.ResetText()
    End Sub

    Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click

    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click

        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("uspLogin", con)
        With cmd
            .CommandType = CommandType.StoredProcedure

            .Parameters.AddWithValue("@Password", txtLogInID.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()

            If CInt(.Parameters("@result").Value = 1) Then


                con.Close()

                frmAdmin.Show()
                Me.Hide()

            Else
                MessageBox.Show("login fail, Please Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                txtLogInID.ResetText()
                txtLogInID.Select()

                con.Close()
            End If
        End With

        txtLogInID.ResetText()


    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()

    End Sub

    Private Sub btnPOS_Click(sender As Object, e As EventArgs) Handles btnPOS.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("uspLogin", con)
        With cmd
            .CommandType = CommandType.StoredProcedure

            .Parameters.AddWithValue("@Password", txtLogInID.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()

            If CInt(.Parameters("@result").Value = 1) Then


                con.Close()
                frmMenu.Show()
                Hide()
            ElseIf CInt(.Parameters("@result").Value = 2) Then
                frmMenu.Show()
                Hide()
            Else
                MessageBox.Show("login fail, Please Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                txtLogInID.ResetText()
                txtLogInID.Select()

                con.Close()
            End If
        End With

        txtLogInID.ResetText()

    End Sub



    Private Sub Timer_Tick_1(sender As Object, e As EventArgs) Handles Timer.Tick
        lblDateTime.Text = Date.Now.ToString

    End Sub

    Private Sub cbStates_SelectedIndexChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnNo1_Click(sender As Object, e As EventArgs) Handles btnNo1.Click
        txtLogInID.Text = txtLogInID.Text + "1"
    End Sub

    Private Sub btnNo2_Click(sender As Object, e As EventArgs) Handles btnNo2.Click
        txtLogInID.Text = txtLogInID.Text + "2"
    End Sub

    Private Sub btnNo3_Click(sender As Object, e As EventArgs) Handles btnNo3.Click
        txtLogInID.Text = txtLogInID.Text + "3"
    End Sub

    Private Sub btnNo4_Click(sender As Object, e As EventArgs) Handles btnNo4.Click
        txtLogInID.Text = txtLogInID.Text + "4"
    End Sub

    Private Sub btnNo5_Click(sender As Object, e As EventArgs) Handles btnNo5.Click
        txtLogInID.Text = txtLogInID.Text + "5"
    End Sub

    Private Sub btnNo6_Click(sender As Object, e As EventArgs) Handles btnNo6.Click
        txtLogInID.Text = txtLogInID.Text + "6"
    End Sub

    Private Sub btnNo7_Click(sender As Object, e As EventArgs) Handles btnNo7.Click
        txtLogInID.Text = txtLogInID.Text + "7"
    End Sub

    Private Sub btnNo8_Click(sender As Object, e As EventArgs) Handles btnNo8.Click
        txtLogInID.Text = txtLogInID.Text + "8"
    End Sub

    Private Sub btnNo9_Click(sender As Object, e As EventArgs) Handles btnNo9.Click
        txtLogInID.Text = txtLogInID.Text + "9"
    End Sub

    Private Sub btnNo0_Click(sender As Object, e As EventArgs) Handles btnNo0.Click
        txtLogInID.Text = txtLogInID.Text + "0"
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtLogInID.Clear()
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If txtLogInID.Text.Count > 0 Then
            txtLogInID.Text = txtLogInID.Text.Remove(txtLogInID.Text.Count - 1)
        End If
    End Sub

    Private Sub btnClockIn_Click(sender As Object, e As EventArgs) Handles btnClockIn.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim cmd1 As SqlCommand = New SqlCommand("uspChecKIfClockedIn", con)
        Dim cmd2 As SqlCommand = New SqlCommand("upsGetEmployeeID", con)
        Dim cmd3 As SqlCommand = New SqlCommand("upsValidatePassword", con)
        With cmd3
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@Password", txtLogInID.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()
        End With
        With cmd1
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@Password", txtLogInID.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()
        End With
        If CInt(cmd3.Parameters("@result").Value = 0) Then
            MessageBox.Show("Incorrect Password. Please Try again !")
            Exit Sub
        End If
        If CInt(cmd1.Parameters("@result").Value = 1) Then
            MessageBox.Show("Clock In failed. You are already In !")
            Exit Sub
        End If
        Dim cmd As SqlCommand = New SqlCommand("uspClockIn", con)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@Password", txtLogInID.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()
            If CInt(.Parameters("@result").Value = 1) Then
                With cmd2
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.AddWithValue("@Password", txtLogInID.Text)
                    .Parameters.Add("@EmployeeID", SqlDbType.Int).Direction = ParameterDirection.Output
                    .ExecuteScalar()
                End With
                Dim query As String = "Insert into TOnclock (intEmployeeID, intOnClock, dtmDate,dtmClockIn, dtmClockOut)
                                                           values(@EmployeeID, 1, @Date, @ClockInTime, @ClockOutTime)"
                cmd = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Password", txtLogInID.Text)
                cmd.Parameters.AddWithValue("@EmployeeID", CInt(cmd2.Parameters("@EmployeeID").Value))
                cmd.Parameters.AddWithValue("@Date", Date.Now)
                cmd.Parameters.AddWithValue("@ClockInTime", TimeOfDay.Now)
                cmd.Parameters.AddWithValue("@ClockOutTime", DBNull.Value)
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("ClockIn successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.None)
            Else
                MessageBox.Show("Clock In Failed, Please Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtLogInID.ResetText()
                txtLogInID.Select()
                con.Close()
            End If
        End With
        txtLogInID.ResetText()
    End Sub

    Private Sub btnClockOut_Click(sender As Object, e As EventArgs) Handles btnClockOut.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=MSI;Initial Catalog=dbSQL3;Integrated Security=True")
        con.Open()
        Dim cmd3 As SqlCommand
        Dim cmd As SqlCommand = New SqlCommand("uspClockOut", con)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@Password", txtLogInID.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .ExecuteScalar()
            If CInt(.Parameters("@result").Value = 1) Then
                Dim query As String = "update TOnclock set intOnClock = 2, dtmClockOut = @clockOut
                                     from TOnclock as toc
                                      join TEmployees as te
                                      on te.intEmployeeID = toc.intEmployeeID
                                      where te.strPassword = @Password  and dtmClockOut is Null"
                cmd = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Password", txtLogInID.Text)
                cmd.Parameters.AddWithValue("@clockOut", DateTime.Now)
                cmd.Parameters.AddWithValue("@Date", Date.Now)
                cmd.ExecuteNonQuery()
                Dim query1 As String = "select top 1 toc.dtmClockIn, toc.dtmClockOut
                                            from TOnclock As TOC
                                            join TEmployees as TE
                                            on TOC.intEmployeeID = TE.intEmployeeID
                                            where TE.strPassword = @Password and dtmClockIn is not null and dtmClockOut is not null
                                            order by toc.intOnClockID desc"
                cmd3 = New SqlCommand(query1, con)
                cmd3.Parameters.AddWithValue("@Password", txtLogInID.Text)
                Dim adapter As New SqlDataAdapter(cmd3)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                Dim TimeIn As Date
                Dim TimeOut As Date
                TimeIn = dt.Rows(0).Item(0).ToString
                TimeOut = dt.Rows(0).Item(1).ToString
                Dim HourDifference = TimeOut - TimeIn
                Dim query2 As String = "update TOnclock set intHoursWorked = @Hours
                                     from TOnclock as toc
                                      join TEmployees as te
                                      on te.intEmployeeID = toc.intEmployeeID
                                      where te.strPassword = @Password  and dtmClockOut is not Null and dtmClockIn is not Null and intHoursWorked is Null"

                cmd = New SqlCommand(query2, con)
                cmd.Parameters.AddWithValue("@Password", txtLogInID.Text)
                cmd.Parameters.AddWithValue("@Hours", HourDifference)
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Clock Out successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.None)
            Else
                MessageBox.Show("Clock OUt Failed, Please Try again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtLogInID.ResetText()
                txtLogInID.Select()
                con.Close()
            End If
        End With

        txtLogInID.ResetText()
    End Sub

    Private Sub txtLogInID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLogInID.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub
End Class

Public Class Resizer

    '----------------------------------------------------------
    ' ControlInfo
    ' Structure of original state of all processed controls
    '----------------------------------------------------------
    Private Structure ControlInfo
        Public name As String
        Public parentName As String
        Public leftOffsetPercent As Double
        Public topOffsetPercent As Double
        Public heightPercent As Double
        Public originalHeight As Integer
        Public originalWidth As Integer
        Public widthPercent As Double
        Public originalFontSize As Single
    End Structure

    '-------------------------------------------------------------------------
    ' ctrlDict
    ' Dictionary of (control name, control info) for all processed controls
    '-------------------------------------------------------------------------
    Private ctrlDict As Dictionary(Of String, ControlInfo) = New Dictionary(Of String, ControlInfo)

    '----------------------------------------------------------------------------------------
    ' FindAllControls
    ' Recursive function to process all controls contained in the initially passed
    ' control container and store it in the Control dictionary
    '----------------------------------------------------------------------------------------
    Public Sub FindAllControls(thisCtrl As Control)


        For Each ctl As Control In thisCtrl.Controls
            Try
                If Not IsNothing(ctl.Parent) Then
                    Dim parentHeight = ctl.Parent.Height
                    Dim parentWidth = ctl.Parent.Width

                    Dim c As New ControlInfo
                    c.name = ctl.Name
                    c.parentName = ctl.Parent.Name
                    c.topOffsetPercent = Convert.ToDouble(ctl.Top) / Convert.ToDouble(parentHeight)
                    c.leftOffsetPercent = Convert.ToDouble(ctl.Left) / Convert.ToDouble(parentWidth)
                    c.heightPercent = Convert.ToDouble(ctl.Height) / Convert.ToDouble(parentHeight)
                    c.widthPercent = Convert.ToDouble(ctl.Width) / Convert.ToDouble(parentWidth)
                    c.originalFontSize = ctl.Font.Size
                    c.originalHeight = ctl.Height
                    c.originalWidth = ctl.Width
                    ctrlDict.Add(c.name, c)
                End If

            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

            If ctl.Controls.Count > 0 Then
                FindAllControls(ctl)
            End If

        Next '-- For Each

    End Sub

    '----------------------------------------------------------------------------------------
    ' ResizeAllControls
    ' Recursive function to resize and reposition all controls contained in the Control
    ' dictionary
    '----------------------------------------------------------------------------------------
    Public Sub ResizeAllControls(thisCtrl As Control)

        Dim fontRatioW As Single
        Dim fontRatioH As Single
        Dim fontRatio As Single
        Dim f As Font

        '-- Resize and reposition all controls in the passed control
        For Each ctl As Control In thisCtrl.Controls
            Try
                If Not IsNothing(ctl.Parent) Then
                    Dim parentHeight = ctl.Parent.Height
                    Dim parentWidth = ctl.Parent.Width

                    Dim c As New ControlInfo

                    Dim ret As Boolean = False
                    Try
                        '-- Get the current control's info from the control info dictionary
                        ret = ctrlDict.TryGetValue(ctl.Name, c)

                        '-- If found, adjust the current control based on control relative
                        '-- size and position information stored in the dictionary
                        If (ret) Then
                            '-- Size
                            ctl.Width = Int(parentWidth * c.widthPercent)
                            ctl.Height = Int(parentHeight * c.heightPercent)

                            '-- Position
                            ctl.Top = Int(parentHeight * c.topOffsetPercent)
                            ctl.Left = Int(parentWidth * c.leftOffsetPercent)

                            '-- Font
                            f = ctl.Font
                            fontRatioW = ctl.Width / c.originalWidth
                            fontRatioH = ctl.Height / c.originalHeight
                            fontRatio = (fontRatioW +
                            fontRatioH) / 2 '-- average change in control Height and Width
                            ctl.Font = New Font(f.FontFamily,
                            c.originalFontSize * fontRatio, f.Style)

                        End If
                    Catch
                    End Try
                End If
            Catch ex As Exception
            End Try

            '-- Recursive call for controls contained in the current control
            If ctl.Controls.Count > 0 Then
                ResizeAllControls(ctl)
            End If

        Next '-- For Each
    End Sub

End Class
