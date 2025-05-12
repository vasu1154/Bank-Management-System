Imports System.Data.SqlClient

Public Class Emplyoee
    Dim connectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=Z:\Projects\VB.NET\sarjil\BMS\BMS\BMS.mdf;Integrated Security=True;User Instance=True"

    Private Sub Emplyoee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        GenerateEmployeeID()
    End Sub

    Private Sub LoadData()
        Try
            Using conn As New SqlConnection(connectionString)
                Dim query As String = "SELECT * FROM Employees"
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridView1.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub GenerateEmployeeID()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim str As String = "SELECT ISNULL(MAX(Id), 0) + 1 AS nextID FROM Employees"
                Dim com As New SqlCommand(str, connection)
                Dim dr As SqlDataReader = com.ExecuteReader()
                If dr.Read() Then
                    txtEmployeeID.Text = dr("nextID").ToString()
                End If
                dr.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating Employee ID: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearFields()
        txtEmployeeID.Clear()
        txtName.Clear()
        txtemail.Clear()
        txtphone.Clear()
        txtage.Clear()
        cmbDesignation.SelectedIndex = -1
        txtSalary.Clear()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not ValidateFields() Then
            Return
        End If
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "INSERT INTO Employees (Name, Email, Phone, Age, Designation, Salary) VALUES (@Name, @Email, @Phone, @Age, @Designation, @Salary)"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Name", txtName.Text)
                cmd.Parameters.AddWithValue("@Email", txtemail.Text)
                cmd.Parameters.AddWithValue("@Phone", txtphone.Text)
                cmd.Parameters.AddWithValue("@Age", txtage.Text)
                cmd.Parameters.AddWithValue("@Designation", cmbDesignation.Text)
                cmd.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtSalary.Text))
                cmd.ExecuteNonQuery()
                MessageBox.Show("Record saved successfully.")
                LoadData()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving record: " & ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If String.IsNullOrEmpty(txtEmployeeID.Text) Then
            MessageBox.Show("Please enter Employee ID to update.")
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE Employees SET Name = @Name, Email = @Email, Phone = @Phone, Age = @Age, Designation = @Designation, Salary = @Salary WHERE Id = @EmployeeID"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@EmployeeID", Convert.ToInt32(txtEmployeeID.Text))
                cmd.Parameters.AddWithValue("@Name", txtName.Text)
                cmd.Parameters.AddWithValue("@Email", txtemail.Text)
                cmd.Parameters.AddWithValue("@Phone", txtphone.Text)
                cmd.Parameters.AddWithValue("@Age", txtage.Text)
                cmd.Parameters.AddWithValue("@Designation", cmbDesignation.Text)
                cmd.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtSalary.Text))
                cmd.ExecuteNonQuery()
                MessageBox.Show("Record updated successfully.")
                LoadData()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating record: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(txtEmployeeID.Text) Then
            MessageBox.Show("Please select an employee to delete.")
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "DELETE FROM Employees WHERE Id = @EmployeeID"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@EmployeeID", Convert.ToInt32(txtEmployeeID.Text))
                cmd.ExecuteNonQuery()
                MessageBox.Show("Record deleted successfully.")
                LoadData()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting record: " & ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If String.IsNullOrEmpty(txtEmployeeID.Text) Then
            MessageBox.Show("Please enter Customer ID to view details.")
            Return
        End If
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Employees WHERE Id = @Id"
            Dim cmd As New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtEmployeeID.Text))

            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ' Populate the form with the data
                Dim row As DataRow = dt.Rows(0)
                txtEmployeeID.Text = row("Id").ToString()
                txtName.Text = row("Name").ToString()
                cmbDesignation.SelectedItem = row("Designation").ToString()
                txtage.Text = row("Age").ToString()
                txtemail.Text = row("Email").ToString()
                txtphone.Text = row("Email").ToString()
                txtSalary.Text = row("Salary").ToString()

            Else
                MessageBox.Show("Customer not found.")
            End If
        End Using
    End Sub
    Private Function ValidateFields() As Boolean
        ' Validate Name
        If String.IsNullOrEmpty(txtName.Text) Then
            MessageBox.Show("Please enter Employee Name.")
            txtName.Focus()
            Return False
        End If

        ' Validate Email
        If String.IsNullOrEmpty(txtemail.Text) Then
            MessageBox.Show("Please enter Employee Email.")
            txtemail.Focus()
            Return False
        ElseIf Not txtemail.Text.Contains("@") Then
            MessageBox.Show("Please enter a valid Email address.")
            txtemail.Focus()
            Return False
        End If

        ' Validate Phone
        If String.IsNullOrEmpty(txtphone.Text) Then
            MessageBox.Show("Please enter Employee Phone Number.")
            txtphone.Focus()
            Return False
        ElseIf Not IsNumeric(txtphone.Text) OrElse txtphone.Text.Length < 10 Then
            MessageBox.Show("Please enter a valid Phone Number with at least 10 digits.")
            txtphone.Focus()
            Return False
        End If

        ' Validate Age (Must be a positive integer)
        If String.IsNullOrEmpty(txtage.Text) OrElse Not IsNumeric(txtage.Text) OrElse Convert.ToInt32(txtage.Text) <= 0 Then
            MessageBox.Show("Please enter a valid Age.")
            txtage.Focus()
            Return False
        End If

        ' Validate Designation
        If String.IsNullOrEmpty(cmbDesignation.Text) Then
            MessageBox.Show("Please select Employee Designation.")
            cmbDesignation.Focus()
            Return False
        End If

        ' Validate Salary (Must be a positive number)
        If String.IsNullOrEmpty(txtSalary.Text) OrElse Not IsNumeric(txtSalary.Text) OrElse Convert.ToDecimal(txtSalary.Text) <= 0 Then
            MessageBox.Show("Please enter a valid Salary.")
            txtSalary.Focus()
            Return False
        End If

        Return True
    End Function

End Class
