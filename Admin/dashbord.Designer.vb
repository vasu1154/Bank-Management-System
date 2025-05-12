<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dashbord
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCustomerManagement = New System.Windows.Forms.Button()
        Me.btnTransactionManagement = New System.Windows.Forms.Button()
        Me.btnLoanManagement = New System.Windows.Forms.Button()
        Me.btnEmployeeManagement = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCustomerManagement
        '
        Me.btnCustomerManagement.Location = New System.Drawing.Point(787, 26)
        Me.btnCustomerManagement.Name = "btnCustomerManagement"
        Me.btnCustomerManagement.Size = New System.Drawing.Size(150, 60)
        Me.btnCustomerManagement.TabIndex = 0
        Me.btnCustomerManagement.Text = "Customer Management"
        Me.btnCustomerManagement.UseVisualStyleBackColor = True
        '
        'btnTransactionManagement
        '
        Me.btnTransactionManagement.Location = New System.Drawing.Point(787, 107)
        Me.btnTransactionManagement.Name = "btnTransactionManagement"
        Me.btnTransactionManagement.Size = New System.Drawing.Size(150, 60)
        Me.btnTransactionManagement.TabIndex = 2
        Me.btnTransactionManagement.Text = "Transaction Management"
        Me.btnTransactionManagement.UseVisualStyleBackColor = True
        '
        'btnLoanManagement
        '
        Me.btnLoanManagement.Location = New System.Drawing.Point(787, 189)
        Me.btnLoanManagement.Name = "btnLoanManagement"
        Me.btnLoanManagement.Size = New System.Drawing.Size(150, 60)
        Me.btnLoanManagement.TabIndex = 3
        Me.btnLoanManagement.Text = "Loan Management"
        Me.btnLoanManagement.UseVisualStyleBackColor = True
        '
        'btnEmployeeManagement
        '
        Me.btnEmployeeManagement.Location = New System.Drawing.Point(787, 268)
        Me.btnEmployeeManagement.Name = "btnEmployeeManagement"
        Me.btnEmployeeManagement.Size = New System.Drawing.Size(150, 60)
        Me.btnEmployeeManagement.TabIndex = 4
        Me.btnEmployeeManagement.Text = "Employee Management"
        Me.btnEmployeeManagement.UseVisualStyleBackColor = True
        '
        'btnReports
        '
        Me.btnReports.Location = New System.Drawing.Point(787, 422)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(150, 60)
        Me.btnReports.TabIndex = 5
        Me.btnReports.Text = "Exit"
        Me.btnReports.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(787, 346)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 60)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dashbord
        '
        Me.BackgroundImage = Global.BMS.My.Resources.Resources.WhatsApp_Image_2025_01_05_at_19_13_56_92a5f1ae__2_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(972, 589)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnReports)
        Me.Controls.Add(Me.btnEmployeeManagement)
        Me.Controls.Add(Me.btnLoanManagement)
        Me.Controls.Add(Me.btnTransactionManagement)
        Me.Controls.Add(Me.btnCustomerManagement)
        Me.Name = "dashbord"
        Me.Text = "Main Dashboard"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents btnCustomerManagement As System.Windows.Forms.Button
    Private WithEvents btnTransactionManagement As System.Windows.Forms.Button
    Private WithEvents btnLoanManagement As System.Windows.Forms.Button
    Private WithEvents btnEmployeeManagement As System.Windows.Forms.Button
    Private WithEvents btnReports As System.Windows.Forms.Button
    Private WithEvents Button1 As System.Windows.Forms.Button
End Class
