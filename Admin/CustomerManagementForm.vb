Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class CustomerManagementForm
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim gen As String
    Dim str As String
    Dim getuser As String
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim dv As DataView
    Dim connectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=Z:\Projects\VB.NET\sarjil\BMS\BMS\BMS.mdf;Integrated Security=True;User Instance=True"

    Private Sub ClearTextBoxes()
        txtFullName.Clear()
        dtpDOB.Value = DateTime.Now
        txtPhoneNumber.Clear()
        txtEmail.Clear()
        txtAddress.Clear()
        cmbAccountType.SelectedIndex = -1
        txtAccountBalance.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub LoadCustomers()
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM customertbl"
            Dim cmd As New SqlCommand(query, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()

            da.Fill(dt)
            dgvCustomers.DataSource = dt
        End Using
    End Sub

    Private Sub btnAddCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCustomer.Click
        If Not ValidateForm() Then
            Exit Sub
        End If
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO customertbl (FullName, DOB, PhoneNumber, Email, Address, AccountType,AccountNumber, AccountBalance) " &
                                  "VALUES (@FullName, @DOB, @PhoneNumber, @Email, @Address, @AccountType,@AccountNumber, @AccountBalance)"
            Dim cmd As New SqlCommand(query, conn)

            ' Parameters
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text)
            cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value)
            cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@AccountType", cmbAccountType.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@AccountNumber", Convert.ToDecimal(TextBox2.Text))
            cmd.Parameters.AddWithValue("@AccountBalance", Convert.ToDecimal(txtAccountBalance.Text))

            ' Open connection and execute command
            conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("New Customer Inserted Successfully..")
            conn.Close()

            ' Refresh DataGridView
            LoadCustomers()

            ' Clear textboxes after insertion
            ClearTextBoxes()
        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("Please enter Customer ID to view details.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM customertbl WHERE Id = @CustomerId"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(TextBox1.Text))

            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ' Populate the form with the data
                Dim row As DataRow = dt.Rows(0)
                txtFullName.Text = row("FullName").ToString()
                dtpDOB.Value = Convert.ToDateTime(row("DOB"))
                txtPhoneNumber.Text = row("PhoneNumber").ToString()
                txtEmail.Text = row("Email").ToString()
                txtAddress.Text = row("Address").ToString()
                cmbAccountType.SelectedItem = row("AccountType").ToString()
                TextBox2.Text = row("AccountNumber").ToString()
                txtAccountBalance.Text = row("AccountBalance").ToString()
            Else
                MessageBox.Show("Customer not found.")
            End If
        End Using
    End Sub

    Private Sub CustomerManagementForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomers()
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Try
                str = "select nextID=MAX(Id)+1 from customertbl"
                com = New SqlCommand(str, conn)
                dr = com.ExecuteReader()
                If dr.Read() Then
                    TextBox1.Text = dr.GetValue(0).ToString()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Using
    End Sub

    Private Sub btnUpdateCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateCustomer.Click
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("Please enter Customer ID to update.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "UPDATE customertbl SET FullName = @FullName, DOB = @DOB, PhoneNumber = @PhoneNumber, " &
                                  "Email = @Email, Address = @Address, AccountType = @AccountType, AccountBalance = @AccountBalance " &
                                  "WHERE Id = @CustomerId"
            Dim cmd As New SqlCommand(query, conn)

            ' Parameters
            cmd.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(TextBox1.Text))
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text)
            cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value)
            cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@AccountType", cmbAccountType.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@AccountNumber", TextBox2.Text.ToString())
            cmd.Parameters.AddWithValue("@AccountBalance", Convert.ToDecimal(txtAccountBalance.Text))

            ' Open connection and execute command
            conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Customer Update Successfully..")
            conn.Close()

            ' Refresh DataGridView
            LoadCustomers()

            ' Clear textboxes after update
            ClearTextBoxes()
        End Using
    End Sub

    Private Sub btnDeleteCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteCustomer.Click
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("Please enter Customer ID to delete.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "DELETE FROM customertbl WHERE Id = @CustomerId"
            Dim cmd As New SqlCommand(query, conn)

            ' Parameters
            cmd.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(TextBox1.Text))

            ' Open connection and execute command
            conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Customer Deleted Successfully..")
            conn.Close()

            ' Refresh DataGridView
            LoadCustomers()

            ' Clear textboxes after deletion
            ClearTextBoxes()
        End Using
    End Sub
    Private Function ValidateForm() As Boolean
        ' Initialize validation status
        Dim isValid As Boolean = True

        ' Validate CustomerId
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("CustomerId cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            isValid = False
        End If

        ' Validate Full Name
        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Full Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            isValid = False
        End If

        ' Validate Phone Number
        If Not Regex.IsMatch(txtPhoneNumber.Text, "^\d{10}$") Then
            MessageBox.Show("Phone Number must be 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            isValid = False
        End If

        ' Validate Email
        If Not Regex.IsMatch(txtEmail.Text, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            MessageBox.Show("Invalid Email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            isValid = False
        End If

        ' Validate Account Type
        If cmbAccountType.SelectedIndex = -1 Then
            MessageBox.Show("Please select an Account Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            isValid = False
        End If

        ' Validate Account Balance
        Dim accountBalance As Decimal
        If Not Decimal.TryParse(txtAccountBalance.Text, accountBalance) OrElse accountBalance < 0 Then
            MessageBox.Show("Account Balance must be a non-negative number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            isValid = False
        End If

        Return isValid
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ClearTextBoxes()
    End Sub
End Class