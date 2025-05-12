<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportM
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
        Me.cmbReportType = New System.Windows.Forms.ComboBox()
        Me.btnGenerateReport = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.lblReportType = New System.Windows.Forms.Label()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbReportType
        '
        Me.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReportType.Items.AddRange(New Object() {"View Customers", "View Employees", "View Loans", "View Transactions"})
        Me.cmbReportType.Location = New System.Drawing.Point(419, 30)
        Me.cmbReportType.Name = "cmbReportType"
        Me.cmbReportType.Size = New System.Drawing.Size(150, 24)
        Me.cmbReportType.TabIndex = 0
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnGenerateReport.Location = New System.Drawing.Point(419, 70)
        Me.btnGenerateReport.Name = "btnGenerateReport"
        Me.btnGenerateReport.Size = New System.Drawing.Size(150, 30)
        Me.btnGenerateReport.TabIndex = 1
        Me.btnGenerateReport.Text = "Generate Report"
        Me.btnGenerateReport.UseVisualStyleBackColor = False
        '
        'dgvReport
        '
        Me.dgvReport.Location = New System.Drawing.Point(156, 120)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.Size = New System.Drawing.Size(607, 389)
        Me.dgvReport.TabIndex = 2
        '
        'lblReportType
        '
        Me.lblReportType.Location = New System.Drawing.Point(319, 30)
        Me.lblReportType.Name = "lblReportType"
        Me.lblReportType.Size = New System.Drawing.Size(100, 20)
        Me.lblReportType.TabIndex = 0
        Me.lblReportType.Text = "Select Report Type"
        '
        'ReportM
        '
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(889, 536)
        Me.Controls.Add(Me.lblReportType)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.btnGenerateReport)
        Me.Controls.Add(Me.cmbReportType)
        Me.Name = "ReportM"
        Me.Text = "Manager Report"
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    ' Declare controls
    Private WithEvents cmbReportType As System.Windows.Forms.ComboBox
    Private WithEvents btnGenerateReport As System.Windows.Forms.Button
    Private WithEvents dgvReport As System.Windows.Forms.DataGridView
    Private WithEvents lblReportType As System.Windows.Forms.Label
End Class
