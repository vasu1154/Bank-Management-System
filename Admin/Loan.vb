Imports System.Data.SqlClient
Public Class Loan
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
    Private Sub Loan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                str = "select nextID=MAX(Id)+1 from Loans"
                com = New SqlCommand(str, connection)
                dr = com.ExecuteReader()
                If dr.Read() Then
                    txtLoanID.Text = dr.GetValue(0).ToString()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                connection.Close()
            End Try
        End Using
    End Sub
    Private Sub ClearFields()
        txtLoanID.Text = ""
        txtCustomerName.Text = ""
        cmbLoanType.SelectedIndex = -1
        txtAmount.Text = ""
        txtInterestRate.Text = ""
        txtTenure.Text = ""
    End Sub
    Private Sub LoadData()
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "SELECT * FROM Loans"
                Dim adapter As New SqlDataAdapter(query, connection)
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridView1.DataSource = table
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                connection.Close()
            End Try
        End Using
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not ValidateFields() Then
            Return
        End If
        Using conn As New SqlConnection(connectionString)

            Try
                conn.Open()
                Dim query As String = "INSERT INTO Loans (CustomerName, LoanType, Amount, InterestRate, Tenure) VALUES (@CustomerName, @LoanType, @Amount, @InterestRate, @Tenure)"
                Dim command As New SqlCommand(query, conn)
                command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text)
                command.Parameters.AddWithValue("@LoanType", cmbLoanType.Text)
                command.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
                command.Parameters.AddWithValue("@InterestRate", Convert.ToDecimal(txtInterestRate.Text))
                command.Parameters.AddWithValue("@Tenure", Convert.ToInt32(txtTenure.Text))
                command.ExecuteNonQuery()
                MessageBox.Show("Record saved successfully.")
                LoadData()
                ClearFields()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If String.IsNullOrEmpty(txtLoanID.Text) Then
            MessageBox.Show("Please enter Customer ID to update.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Loans SET CustomerName=@CustomerName, LoanType=@LoanType, Amount=@Amount, InterestRate=@InterestRate, Tenure=@Tenure WHERE ID=@LoanID"
            Dim command As New SqlCommand(query, conn)
            command.Parameters.AddWithValue("@LoanID", txtLoanID.Text)
            command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text)
            command.Parameters.AddWithValue("@LoanType", cmbLoanType.Text)
            command.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
            command.Parameters.AddWithValue("@InterestRate", Convert.ToDecimal(txtInterestRate.Text))
            command.Parameters.AddWithValue("@Tenure", Convert.ToInt32(txtTenure.Text))
            conn.Open()
            command.ExecuteNonQuery()
            MessageBox.Show("Record updated successfully.")
            conn.Close()
            LoadData()
            ClearFields()

        End Using
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "DELETE FROM Loans WHERE Id=@LoanID"
                Dim command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@LoanID", txtLoanID.Text)
                command.ExecuteNonQuery()
                MessageBox.Show("Record deleted successfully.")
                LoadData()
                ClearFields()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If String.IsNullOrEmpty(txtLoanID.Text) Then
            MessageBox.Show("Please enter Customer ID to view details.")
            Return
        End If
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Loans WHERE Id = @Id"
            Dim cmd As New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtLoanID.Text))

            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ' Populate the form with the data
                Dim row As DataRow = dt.Rows(0)
                txtCustomerName.Text = row("CustomerName").ToString()
                cmbLoanType.SelectedItem = row("LoanType").ToString()
                txtAmount.Text = row("Amount").ToString()
                txtInterestRate.Text = row("InterestRate").ToString()
                txtTenure.Text = row("Tenure").ToString()

            Else
                MessageBox.Show("Customer not found.")
            End If
        End Using
    End Sub
    Private Function ValidateFields() As Boolean
        ' Validate Customer Name
        If String.IsNullOrEmpty(txtCustomerName.Text) Then
            MessageBox.Show("Please enter Customer Name.")
            txtCustomerName.Focus()
            Return False
        End If

        ' Validate Loan Type
        If String.IsNullOrEmpty(cmbLoanType.Text) Then
            MessageBox.Show("Please select Loan Type.")
            cmbLoanType.Focus()
            Return False
        End If

        ' Validate Amount (Must be a positive number)
        If String.IsNullOrEmpty(txtAmount.Text) OrElse Not IsNumeric(txtAmount.Text) OrElse Convert.ToDecimal(txtAmount.Text) <= 0 Then
            MessageBox.Show("Please enter a valid positive Amount.")
            txtAmount.Focus()
            Return False
        End If

        ' Validate Interest Rate (Must be a valid number)
        If String.IsNullOrEmpty(txtInterestRate.Text) OrElse Not IsNumeric(txtInterestRate.Text) OrElse Convert.ToDecimal(txtInterestRate.Text) < 0 Then
            MessageBox.Show("Please enter a valid Interest Rate.")
            txtInterestRate.Focus()
            Return False
        End If

        ' Validate Tenure (Must be a positive integer)
        If String.IsNullOrEmpty(txtTenure.Text) OrElse Not IsNumeric(txtTenure.Text) OrElse Convert.ToInt32(txtTenure.Text) <= 0 Then
            MessageBox.Show("Please enter a valid Tenure.")
            txtTenure.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ClearFields()
    End Sub
End Class