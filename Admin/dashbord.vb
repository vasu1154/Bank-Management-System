Public Class dashbord

    Private Sub btnCustomerManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerManagement.Click
        CustomerManagementForm.ShowDialog()
    End Sub

    Private Sub btnTransactionManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransactionManagement.Click
        Transaction.ShowDialog()
    End Sub

    Private Sub btnLoanManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoanManagement.Click
        Loan.ShowDialog()
    End Sub

    Private Sub btnEmployeeManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeManagement.Click
        Emplyoee.ShowDialog()
    End Sub

    Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click
        Login.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ReportA.ShowDialog()
    End Sub
End Class
