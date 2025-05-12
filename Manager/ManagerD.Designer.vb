<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManagerD
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
        Me.lblTotalEmployees = New System.Windows.Forms.Label()
        Me.lblPendingApprovals = New System.Windows.Forms.Label()
        Me.btnViewReports = New System.Windows.Forms.Button()
        Me.btnManageEmployees = New System.Windows.Forms.Button()
        Me.btnApproveRequests = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTotalEmployees
        '
        Me.lblTotalEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEmployees.Location = New System.Drawing.Point(20, 20)
        Me.lblTotalEmployees.Name = "lblTotalEmployees"
        Me.lblTotalEmployees.Size = New System.Drawing.Size(200, 30)
        Me.lblTotalEmployees.TabIndex = 0
        Me.lblTotalEmployees.Text = "Total Employees: 100"
        '
        'lblPendingApprovals
        '
        Me.lblPendingApprovals.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingApprovals.Location = New System.Drawing.Point(20, 60)
        Me.lblPendingApprovals.Name = "lblPendingApprovals"
        Me.lblPendingApprovals.Size = New System.Drawing.Size(200, 30)
        Me.lblPendingApprovals.TabIndex = 2
        Me.lblPendingApprovals.Text = "Total Customer: "
        '
        'btnViewReports
        '
        Me.btnViewReports.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnViewReports.Location = New System.Drawing.Point(784, 350)
        Me.btnViewReports.Name = "btnViewReports"
        Me.btnViewReports.Size = New System.Drawing.Size(150, 40)
        Me.btnViewReports.TabIndex = 6
        Me.btnViewReports.Text = "View Reports"
        Me.btnViewReports.UseVisualStyleBackColor = False
        '
        'btnManageEmployees
        '
        Me.btnManageEmployees.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnManageEmployees.Location = New System.Drawing.Point(784, 220)
        Me.btnManageEmployees.Name = "btnManageEmployees"
        Me.btnManageEmployees.Size = New System.Drawing.Size(150, 40)
        Me.btnManageEmployees.TabIndex = 7
        Me.btnManageEmployees.Text = "Manage Employees"
        Me.btnManageEmployees.UseVisualStyleBackColor = False
        '
        'btnApproveRequests
        '
        Me.btnApproveRequests.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnApproveRequests.Location = New System.Drawing.Point(784, 152)
        Me.btnApproveRequests.Name = "btnApproveRequests"
        Me.btnApproveRequests.Size = New System.Drawing.Size(150, 40)
        Me.btnApproveRequests.TabIndex = 5
        Me.btnApproveRequests.Text = "Transaction"
        Me.btnApproveRequests.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(784, 283)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 40)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Manage Customer"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.BMS.My.Resources.Resources.WhatsApp_Image_2025_01_05_at_19_14_00_397d0a77__3_
        Me.PictureBox1.Location = New System.Drawing.Point(234, 131)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(495, 279)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'ManagerD
        '
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1022, 620)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblTotalEmployees)
        Me.Controls.Add(Me.lblPendingApprovals)
        Me.Controls.Add(Me.btnApproveRequests)
        Me.Controls.Add(Me.btnViewReports)
        Me.Controls.Add(Me.btnManageEmployees)
        Me.Name = "ManagerD"
        Me.Text = "Manager Dashboard"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    ' Declare controls
    Private WithEvents lblTotalEmployees As System.Windows.Forms.Label
    Private WithEvents lblPendingApprovals As System.Windows.Forms.Label
    Private WithEvents btnViewReports As System.Windows.Forms.Button
    Private WithEvents btnManageEmployees As System.Windows.Forms.Button

    ' Event handlers
    Private Sub ApproveRequests_Click(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("Redirecting to request approval page.")
    End Sub

    Private Sub ViewReports_Click(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("Redirecting to financial reports page.")
    End Sub

    Private Sub ManageEmployees_Click(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("Redirecting to employee management page.")
    End Sub

    Private Sub ManageFinances_Click(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("Redirecting to finance management page.")
    End Sub
    Private WithEvents btnApproveRequests As System.Windows.Forms.Button
    Private WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
