Imports System.Data.SqlClient
Public Class ManagerD

    Private Function lblTotalEmpSloyees() As Object
        Throw New NotImplementedException
    End Function

    Private Function GetTotalEmployees() As Integer
        Dim connectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=Z:\Projects\VB.NET\sarjil\BMS\BMS\BMS.mdf;Integrated Security=True;User Instance=True"
        Dim query As String = "SELECT COUNT(*) FROM Employees"
        Dim totalEmployees As Integer = 0

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand(query, connection)
                    totalEmployees = Convert.ToInt32(command.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching total employees: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return totalEmployees
    End Function

    Private Function totalCustomer() As Integer
        Dim connectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=Z:\Projects\VB.NET\sarjil\BMS\BMS\BMS.mdf;Integrated Security=True;User Instance=True"
        Dim query As String = "SELECT COUNT(*) FROM customertbl " ' Assuming there's a Status column
        Dim totalCustomers As Integer = 0

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand(query, connection)
                    totalCustomers = Convert.ToInt32(command.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching total customers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return totalCustomers
    End Function
    Private Sub UpdateDashboardData()
        ' Example logic for populating data dynamically (hardcoded for now)
        lblTotalEmployees.Text = "Total Employees: " & GetTotalEmployees().ToString()
        lblPendingApprovals.Text = "Total Customers: " & totalCustomer().ToString()
    End Sub
    Private Sub btnApproveRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproveRequests.Click
        Transaction.ShowDialog()
    End Sub

    Private Sub btnManageEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManageEmployees.Click
        Emplyoee.ShowDialog()
    End Sub

    Private Sub btnViewReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReports.Click
        ReportM.ShowDialog()
    End Sub

    Private Sub ManagerD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UpdateDashboardData()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CustomerManagementForm.ShowDialog()
    End Sub
End Class