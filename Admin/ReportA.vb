Imports System.Data.SqlClient
Public Class ReportA
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim gen As String
    Dim str As String
    Dim getuser As String
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim dv As DataView
    Private Sub btnGenerateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateReport.Click
        If cmbReportType.SelectedIndex = "0" Then
            con = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=Z:\Projects\VB.NET\sarjil\BMS\BMS\BMS.mdf;Integrated Security=True;User Instance=True")
            con.Open()
            Dim query As String = "SELECT * FROM customertbl"
            Dim cmd As New SqlCommand(query, con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()

            da.Fill(dt)
            dgvReport.DataSource = dt
        ElseIf cmbReportType.SelectedIndex = "1" Then
            con = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=Z:\Projects\VB.NET\sarjil\BMS\BMS\BMS.mdf;Integrated Security=True;User Instance=True")
            con.Open()
            Dim query As String = "SELECT * FROM Employees"
            Dim cmd As New SqlCommand(query, con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()

            da.Fill(dt)
            dgvReport.DataSource = dt

        ElseIf cmbReportType.SelectedIndex = "2" Then
            con = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=Z:\Projects\VB.NET\sarjil\BMS\BMS\BMS.mdf;Integrated Security=True;User Instance=True")
            con.Open()
            Dim query As String = "SELECT * FROM Loans"
            Dim cmd As New SqlCommand(query, con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()

            da.Fill(dt)
            dgvReport.DataSource = dt

        Else
            con = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=Z:\Projects\VB.NET\sarjil\BMS\BMS\BMS.mdf;Integrated Security=True;User Instance=True")
            con.Open()
            Dim query As String = "SELECT * FROM Trasactiontbl"
            Dim cmd As New SqlCommand(query, con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()

            da.Fill(dt)
            dgvReport.DataSource = dt
        End If
    End Sub
End Class