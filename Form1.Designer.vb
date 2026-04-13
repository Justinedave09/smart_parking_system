<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        ComboBox1 = New ComboBox()
        btnConnect = New Button()
        lvLogs = New ListView()
        pnlSlot2 = New Panel()
        lblStatus2 = New Label()
        pnlSlot3 = New Panel()
        lblStatus3 = New Label()
        pnlSlot4 = New Panel()
        lblStatus4 = New Label()
        btnTestLight = New Button()
        lblNotify = New Label()
        tmrNotify = New Timer(components)
        pnlSlot1 = New Panel()
        lblStatus1 = New Label()
        PrintDocument1 = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox4 = New PictureBox()
        txtPlate1 = New TextBox()
        txtPlate2 = New TextBox()
        txtPlate4 = New TextBox()
        txtPlate3 = New TextBox()
        Timer1 = New Timer(components)
        Timer2 = New Timer(components)
        pnlSlot2.SuspendLayout()
        pnlSlot3.SuspendLayout()
        pnlSlot4.SuspendLayout()
        pnlSlot1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(12, 36)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(213, 28)
        ComboBox1.TabIndex = 0
        ' 
        ' btnConnect
        ' 
        btnConnect.Location = New Point(231, 35)
        btnConnect.Name = "btnConnect"
        btnConnect.Size = New Size(94, 29)
        btnConnect.TabIndex = 1
        btnConnect.Text = "Connect"
        btnConnect.UseVisualStyleBackColor = True
        ' 
        ' lvLogs
        ' 
        lvLogs.FullRowSelect = True
        lvLogs.GridLines = True
        lvLogs.Location = New Point(486, 607)
        lvLogs.Name = "lvLogs"
        lvLogs.Size = New Size(512, 136)
        lvLogs.TabIndex = 4
        lvLogs.UseCompatibleStateImageBehavior = False
        lvLogs.View = View.Details
        ' 
        ' pnlSlot2
        ' 
        pnlSlot2.Controls.Add(lblStatus2)
        pnlSlot2.Location = New Point(552, 130)
        pnlSlot2.Name = "pnlSlot2"
        pnlSlot2.Size = New Size(158, 49)
        pnlSlot2.TabIndex = 6
        ' 
        ' lblStatus2
        ' 
        lblStatus2.AutoSize = True
        lblStatus2.Location = New Point(51, 14)
        lblStatus2.Name = "lblStatus2"
        lblStatus2.Size = New Size(51, 20)
        lblStatus2.TabIndex = 2
        lblStatus2.Text = "Slot 2 "
        ' 
        ' pnlSlot3
        ' 
        pnlSlot3.Controls.Add(lblStatus3)
        pnlSlot3.Location = New Point(787, 129)
        pnlSlot3.Name = "pnlSlot3"
        pnlSlot3.Size = New Size(158, 49)
        pnlSlot3.TabIndex = 6
        ' 
        ' lblStatus3
        ' 
        lblStatus3.AutoSize = True
        lblStatus3.Cursor = Cursors.IBeam
        lblStatus3.Location = New Point(51, 17)
        lblStatus3.Name = "lblStatus3"
        lblStatus3.Size = New Size(51, 20)
        lblStatus3.TabIndex = 3
        lblStatus3.Text = "Slot 3 "
        ' 
        ' pnlSlot4
        ' 
        pnlSlot4.Controls.Add(lblStatus4)
        pnlSlot4.Location = New Point(989, 129)
        pnlSlot4.Name = "pnlSlot4"
        pnlSlot4.Size = New Size(158, 49)
        pnlSlot4.TabIndex = 6
        ' 
        ' lblStatus4
        ' 
        lblStatus4.AutoSize = True
        lblStatus4.Location = New Point(51, 12)
        lblStatus4.Name = "lblStatus4"
        lblStatus4.Size = New Size(51, 20)
        lblStatus4.TabIndex = 4
        lblStatus4.Text = "Slot 4 "
        ' 
        ' btnTestLight
        ' 
        btnTestLight.Location = New Point(340, 36)
        btnTestLight.Name = "btnTestLight"
        btnTestLight.Size = New Size(94, 29)
        btnTestLight.TabIndex = 7
        btnTestLight.Text = "test"
        btnTestLight.UseVisualStyleBackColor = True
        ' 
        ' lblNotify
        ' 
        lblNotify.AutoSize = True
        lblNotify.Location = New Point(194, 655)
        lblNotify.Name = "lblNotify"
        lblNotify.Size = New Size(53, 20)
        lblNotify.TabIndex = 8
        lblNotify.Text = "Label1"
        ' 
        ' tmrNotify
        ' 
        tmrNotify.Enabled = True
        tmrNotify.Interval = 1500
        ' 
        ' pnlSlot1
        ' 
        pnlSlot1.Controls.Add(lblStatus1)
        pnlSlot1.Location = New Point(340, 130)
        pnlSlot1.Name = "pnlSlot1"
        pnlSlot1.Size = New Size(158, 49)
        pnlSlot1.TabIndex = 7
        ' 
        ' lblStatus1
        ' 
        lblStatus1.AutoSize = True
        lblStatus1.Location = New Point(51, 14)
        lblStatus1.Name = "lblStatus1"
        lblStatus1.Size = New Size(47, 20)
        lblStatus1.TabIndex = 2
        lblStatus1.Text = "Slot 1"
        ' 
        ' PrintDocument1
        ' 
        ' 
        ' PrintPreviewDialog1
        ' 
        PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog1.ClientSize = New Size(400, 300)
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.Visible = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = My.Resources.Resources.civic_removebg_preview
        PictureBox1.Location = New Point(115, 108)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(394, 457)
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Image = My.Resources.Resources.trueno_removebg_preview1
        PictureBox2.Location = New Point(500, 159)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(251, 433)
        PictureBox2.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBox2.TabIndex = 11
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = My.Resources.Resources.gt86_removebg_preview
        PictureBox3.Location = New Point(757, 120)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(226, 458)
        PictureBox3.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBox3.TabIndex = 12
        PictureBox3.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.Image = My.Resources.Resources.bmw_removebg_preview
        PictureBox4.Location = New Point(989, 120)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(400, 445)
        PictureBox4.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBox4.TabIndex = 13
        PictureBox4.TabStop = False
        ' 
        ' txtPlate1
        ' 
        txtPlate1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtPlate1.ForeColor = Color.Red
        txtPlate1.Location = New Point(183, 531)
        txtPlate1.Name = "txtPlate1"
        txtPlate1.ReadOnly = True
        txtPlate1.Size = New Size(125, 47)
        txtPlate1.TabIndex = 14
        ' 
        ' txtPlate2
        ' 
        txtPlate2.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtPlate2.ForeColor = Color.Red
        txtPlate2.Location = New Point(515, 531)
        txtPlate2.Name = "txtPlate2"
        txtPlate2.ReadOnly = True
        txtPlate2.Size = New Size(139, 47)
        txtPlate2.TabIndex = 15
        ' 
        ' txtPlate4
        ' 
        txtPlate4.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtPlate4.ForeColor = Color.Red
        txtPlate4.Location = New Point(1172, 531)
        txtPlate4.Name = "txtPlate4"
        txtPlate4.ReadOnly = True
        txtPlate4.Size = New Size(125, 47)
        txtPlate4.TabIndex = 17
        ' 
        ' txtPlate3
        ' 
        txtPlate3.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtPlate3.ForeColor = Color.Red
        txtPlate3.Location = New Point(838, 531)
        txtPlate3.Name = "txtPlate3"
        txtPlate3.ReadOnly = True
        txtPlate3.Size = New Size(131, 47)
        txtPlate3.TabIndex = 18
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Gemini_Generated_Image_mgypqkmgypqkmgyp1
        ClientSize = New Size(1393, 772)
        Controls.Add(txtPlate3)
        Controls.Add(txtPlate4)
        Controls.Add(txtPlate2)
        Controls.Add(txtPlate1)
        Controls.Add(pnlSlot4)
        Controls.Add(pnlSlot3)
        Controls.Add(pnlSlot2)
        Controls.Add(pnlSlot1)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(lblNotify)
        Controls.Add(btnTestLight)
        Controls.Add(lvLogs)
        Controls.Add(btnConnect)
        Controls.Add(ComboBox1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "Form1"
        Text = "Form1"
        pnlSlot2.ResumeLayout(False)
        pnlSlot2.PerformLayout()
        pnlSlot3.ResumeLayout(False)
        pnlSlot3.PerformLayout()
        pnlSlot4.ResumeLayout(False)
        pnlSlot4.PerformLayout()
        pnlSlot1.ResumeLayout(False)
        pnlSlot1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents lvLogs As ListView
    Friend WithEvents pnlSlot2 As Panel
    Friend WithEvents pnlSlot3 As Panel
    Friend WithEvents pnlSlot4 As Panel
    Friend WithEvents lblStatus2 As Label
    Friend WithEvents lblStatus3 As Label
    Friend WithEvents lblStatus4 As Label
    Friend WithEvents btnTestLight As Button
    Friend WithEvents lblNotify As Label
    Friend WithEvents tmrNotify As Timer
    Friend WithEvents pnlSlot1 As Panel
    Friend WithEvents lblStatus1 As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents txtPlate1 As TextBox
    Friend WithEvents txtPlate2 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents txtPlate4 As TextBox
    Friend WithEvents txtPlate3 As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer

End Class
