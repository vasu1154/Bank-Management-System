Imports System.Data.SqlClient
Public Class Transaction
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim gen As String
    Dim str As String
    Dim getuser As String
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim dv As DataView
    Dim con As SqlConnection
    Dim connectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=Z:\Projects\VB.NET\sarjil\BMS\BMS\BMS.mdf;Integrated Security=True;User Instance=True"

    Private Sub Transaction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Load data into customertbl table
        Me.CustomertblTableAdapter.Fill(Me.BMSDataSet1.customertbl)
        LoadTransactions()

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Try
                str = "SELECT nextID = MAX(Id) + 1 FROM Trasactiontbl"
                com = New SqlCommand(str, conn)
                dr = com.ExecuteReader()
                If dr.Read() Then
                    txtTransactionID.Text = dr.GetValue(0).ToString()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Using
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not ValidateFields() Then Return

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO Trasactiontbl (AccountNumber, TransactionType, Amount, Date) " &
                                  "VALUES (@AccountNumber, @TransactionType, @Amount, @Date)"
            Dim cmd As New SqlCommand(query, conn)
            Dim selectedAccountNumber As String = cmbAccountNo.SelectedValue.ToString()

            ' Parameters
            cmd.Parameters.AddWithValue("@AccountNumber", selectedAccountNumber)
            cmd.Parameters.AddWithValue("@TransactionType", cmbTransactionType.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value)

            ' Open connection and execute command
            conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Transaction Saved Successfully.")

            ' Refresh DataGridView and clear textboxes
            LoadTransactions()
            ClearTextBoxes()
        End Using
    End Sub

    Private Sub LoadTransactions()
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Trasactiontbl"
            Dim cmd As New SqlCommand(query, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
        End Using
    End Sub

    Private Sub ClearTextBoxes()
        txtTransactionID.Clear()
        cmbAccountNo.SelectedItem = Nothing
        txtAmount.Clear()
        cmbTransactionType.SelectedIndex = -1
        dtpDate.Value = DateTime.Now
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If String.IsNullOrEmpty(txtTransactionID.Text) Then
            MessageBox.Show("Please enter Transaction ID to view details.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Trasactiontbl WHERE Id = @Id"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtTransactionID.Text))

            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ' Populate form with data
                Dim row As DataRow = dt.Rows(0)
                cmbAccountNo.SelectedValue = row("AccountNumber").ToString()
                cmbTransactionType.SelectedItem = row("TransactionType").ToString()
                txtAmount.Text = row("Amount").ToString()
                dtpDate.Value = Convert.ToDateTime(row("Date"))
            Else
                MessageBox.Show("Transaction not found.")
            End If
        End Using
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If String.IsNullOrEmpty(txtTransactionID.Text) Then
            MessageBox.Show("Please enter a Transaction ID to update.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Trasactiontbl SET AccountNumber = @AccountNumber, TransactionType = @TransactionType, " &
                                  "Amount = @Amount, Date = @Date WHERE ID = @TransactionID"
            Dim cmd As New SqlCommand(query, conn)
            Dim selectedAccountNumber As String = cmbAccountNo.SelectedValue.ToString()

            ' Parameters
            cmd.Parameters.AddWithValue("@TransactionID", txtTransactionID.Text)
            cmd.Parameters.AddWithValue("@AccountNumber", selectedAccountNumber)
            cmd.Parameters.AddWithValue("@TransactionType", cmbTransactionType.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value)

            ' Open connection and execute command
            conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Transaction Updated Successfully.")

            ' Refresh DataGridView and clear textboxes
            LoadTransactions()
            ClearTextBoxes()
        End Using
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(txtTransactionID.Text) Then
            MessageBox.Show("Please enter a Transaction ID to delete.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "DELETE FROM Trasactiontbl WHERE ID = @TransactionID"
            Dim cmd As New SqlCommand(query, conn)

            ' Parameters
            cmd.Parameters.AddWithValue("@TransactionID", txtTransactionID.Text)

            ' Open connection and execute command
            conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Transaction Deleted Successfully.")

            ' Refresh DataGridView and clear textboxes
            LoadTransactions()
            ClearTextBoxes()
        End Using
    End Sub

    Private Function ValidateFields() As Boolean
        If cmbAccountNo.SelectedItem Is Nothing Then
            MessageBox.Show("Please select an Account Number.")
            cmbAccountNo.Focus()
            Return False
        ElseIf cmbTransactionType.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a Transaction Type.")
            cmbTransactionType.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtAmount.Text) OrElse Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a valid Amount.")
            txtAmount.Focus()
            Return False
        ElseIf Convert.ToDecimal(txtAmount.Text) <= 0 Then
            MessageBox.Show("Amount must be greater than zero.")
            txtAmount.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ClearTextBoxes()
    End Sub
End Class
