Public Class CashierD

    Private Sub btnProcessPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessPayment.Click
        Transaction.ShowDialog()
    End Sub
End Class