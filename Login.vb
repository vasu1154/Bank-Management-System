Imports System.Data.SqlClient

Public Class Login
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim gen As String
    Dim str As String
    Dim getuser As String
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim dv As DataView
    Dim blood As Object
    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        If comboBox1.SelectedIndex = "0" Then

            If textBox1.Text = "admin" And textBox2.Text = "admin" Then
                MessageBox.Show("Welcome Admin")

                comboBox1.Text = "--Select Type--"
                textBox1.Text = ""
                textBox2.Text = ""
                Hide()
                dashbord.ShowDialog()

            Else
                MessageBox.Show("login fail")
            End If
        End If
        If comboBox1.SelectedIndex = "1" Then

            If textBox1.Text = "manager" And textBox2.Text = "manager" Then
                MessageBox.Show("Welcome Manager")

                comboBox1.Text = "--Select Type--"
                textBox1.Text = ""
                textBox2.Text = ""
                Hide()
                ManagerD.ShowDialog()

            Else
                MessageBox.Show("login fail")
            End If
        End If
        If comboBox1.SelectedIndex = "2" Then

            If textBox1.Text = "cashier" And textBox2.Text = "cashier" Then
                MessageBox.Show("Welcome Cashier")

                comboBox1.Text = "--Select Type--"
                textBox1.Text = ""
                textBox2.Text = ""
                Hide()
                CashierD.ShowDialog()

            Else
                MessageBox.Show("login fail")
            End If
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class