<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.comPorts = New System.Windows.Forms.ComboBox()
        Me.Connect = New System.Windows.Forms.Button()
        Me.Test = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TriggerSelect = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.inboxVal2 = New System.Windows.Forms.TextBox()
        Me.inboxVal1 = New System.Windows.Forms.TextBox()
        Me.inboxTime = New System.Windows.Forms.TextBox()
        Me.Start = New System.Windows.Forms.Button()
        Me.ReadClock = New System.Windows.Forms.Timer(Me.components)
        Me.modeSelect = New System.Windows.Forms.CheckBox()
        Me.FFTGraphic = New System.Windows.Forms.GroupBox()
        Me.chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.AnalysisBox = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.FatigueBar = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.AvgPowerDisplay = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MaxFreqDisplay = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RMSDisplay = New System.Windows.Forms.TextBox()
        Me.filterSignalCheck = New System.Windows.Forms.CheckBox()
        Me.TensionDisplay = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.downButton = New System.Windows.Forms.Button()
        Me.stopButton = New System.Windows.Forms.Button()
        Me.upButton = New System.Windows.Forms.Button()
        Me.FrameSize = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Test.SuspendLayout()
        Me.FFTGraphic.SuspendLayout()
        CType(Me.chart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AnalysisBox.SuspendLayout()
        CType(Me.TensionDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.comPorts)
        Me.GroupBox1.Controls.Add(Me.Connect)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(204, 110)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connect"
        '
        'comPorts
        '
        Me.comPorts.FormattingEnabled = True
        Me.comPorts.Location = New System.Drawing.Point(7, 21)
        Me.comPorts.Name = "comPorts"
        Me.comPorts.Size = New System.Drawing.Size(191, 24)
        Me.comPorts.TabIndex = 1
        '
        'Connect
        '
        Me.Connect.Location = New System.Drawing.Point(7, 68)
        Me.Connect.Name = "Connect"
        Me.Connect.Size = New System.Drawing.Size(191, 23)
        Me.Connect.TabIndex = 0
        Me.Connect.Text = "Connect"
        Me.Connect.UseVisualStyleBackColor = True
        '
        'Test
        '
        Me.Test.Controls.Add(Me.Label6)
        Me.Test.Controls.Add(Me.TriggerSelect)
        Me.Test.Controls.Add(Me.Label3)
        Me.Test.Controls.Add(Me.Label2)
        Me.Test.Controls.Add(Me.Label1)
        Me.Test.Controls.Add(Me.inboxVal2)
        Me.Test.Controls.Add(Me.inboxVal1)
        Me.Test.Controls.Add(Me.inboxTime)
        Me.Test.Controls.Add(Me.Start)
        Me.Test.Enabled = False
        Me.Test.Location = New System.Drawing.Point(31, 142)
        Me.Test.Name = "Test"
        Me.Test.Size = New System.Drawing.Size(204, 195)
        Me.Test.TabIndex = 3
        Me.Test.TabStop = False
        Me.Test.Text = "Test"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Trigger"
        '
        'TriggerSelect
        '
        Me.TriggerSelect.FormattingEnabled = True
        Me.TriggerSelect.Items.AddRange(New Object() {"Automatic", "Manual"})
        Me.TriggerSelect.Location = New System.Drawing.Point(70, 80)
        Me.TriggerSelect.Name = "TriggerSelect"
        Me.TriggerSelect.Size = New System.Drawing.Size(127, 24)
        Me.TriggerSelect.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Right"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Left"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Time"
        '
        'inboxVal2
        '
        Me.inboxVal2.Location = New System.Drawing.Point(71, 166)
        Me.inboxVal2.Name = "inboxVal2"
        Me.inboxVal2.Size = New System.Drawing.Size(126, 22)
        Me.inboxVal2.TabIndex = 8
        '
        'inboxVal1
        '
        Me.inboxVal1.Location = New System.Drawing.Point(71, 138)
        Me.inboxVal1.Name = "inboxVal1"
        Me.inboxVal1.Size = New System.Drawing.Size(126, 22)
        Me.inboxVal1.TabIndex = 7
        '
        'inboxTime
        '
        Me.inboxTime.Location = New System.Drawing.Point(71, 110)
        Me.inboxTime.Name = "inboxTime"
        Me.inboxTime.Size = New System.Drawing.Size(126, 22)
        Me.inboxTime.TabIndex = 6
        '
        'Start
        '
        Me.Start.Location = New System.Drawing.Point(34, 21)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(126, 52)
        Me.Start.TabIndex = 2
        Me.Start.Text = "Start"
        Me.Start.UseVisualStyleBackColor = True
        '
        'ReadClock
        '
        Me.ReadClock.Interval = 10
        '
        'modeSelect
        '
        Me.modeSelect.AutoSize = True
        Me.modeSelect.Checked = True
        Me.modeSelect.CheckState = System.Windows.Forms.CheckState.Checked
        Me.modeSelect.Location = New System.Drawing.Point(38, 343)
        Me.modeSelect.Name = "modeSelect"
        Me.modeSelect.Size = New System.Drawing.Size(91, 21)
        Me.modeSelect.TabIndex = 4
        Me.modeSelect.Text = "Live Input"
        Me.modeSelect.UseVisualStyleBackColor = True
        '
        'FFTGraphic
        '
        Me.FFTGraphic.Controls.Add(Me.chart)
        Me.FFTGraphic.Location = New System.Drawing.Point(242, 33)
        Me.FFTGraphic.Name = "FFTGraphic"
        Me.FFTGraphic.Size = New System.Drawing.Size(477, 331)
        Me.FFTGraphic.TabIndex = 5
        Me.FFTGraphic.TabStop = False
        Me.FFTGraphic.Text = "FFT"
        '
        'chart
        '
        ChartArea1.Name = "ChartArea1"
        Me.chart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chart.Legends.Add(Legend1)
        Me.chart.Location = New System.Drawing.Point(6, 21)
        Me.chart.Name = "chart"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chart.Series.Add(Series1)
        Me.chart.Size = New System.Drawing.Size(465, 300)
        Me.chart.TabIndex = 0
        Me.chart.Text = "Chart1"
        '
        'AnalysisBox
        '
        Me.AnalysisBox.Controls.Add(Me.Label8)
        Me.AnalysisBox.Controls.Add(Me.FatigueBar)
        Me.AnalysisBox.Controls.Add(Me.Label7)
        Me.AnalysisBox.Controls.Add(Me.AvgPowerDisplay)
        Me.AnalysisBox.Controls.Add(Me.Label5)
        Me.AnalysisBox.Controls.Add(Me.MaxFreqDisplay)
        Me.AnalysisBox.Controls.Add(Me.Label4)
        Me.AnalysisBox.Controls.Add(Me.RMSDisplay)
        Me.AnalysisBox.Location = New System.Drawing.Point(242, 370)
        Me.AnalysisBox.Name = "AnalysisBox"
        Me.AnalysisBox.Size = New System.Drawing.Size(570, 68)
        Me.AnalysisBox.TabIndex = 6
        Me.AnalysisBox.TabStop = False
        Me.AnalysisBox.Text = "Analysis"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(412, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 17)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Fatigue Level"
        '
        'FatigueBar
        '
        Me.FatigueBar.BackColor = System.Drawing.Color.Lime
        Me.FatigueBar.ForeColor = System.Drawing.Color.Red
        Me.FatigueBar.Location = New System.Drawing.Point(354, 38)
        Me.FatigueBar.Name = "FatigueBar"
        Me.FatigueBar.Size = New System.Drawing.Size(210, 23)
        Me.FatigueBar.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(245, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 17)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Average Energy"
        '
        'AvgPowerDisplay
        '
        Me.AvgPowerDisplay.HideSelection = False
        Me.AvgPowerDisplay.Location = New System.Drawing.Point(248, 39)
        Me.AvgPowerDisplay.Name = "AvgPowerDisplay"
        Me.AvgPowerDisplay.ReadOnly = True
        Me.AvgPowerDisplay.Size = New System.Drawing.Size(100, 22)
        Me.AvgPowerDisplay.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(126, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 17)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Max Frequency"
        '
        'MaxFreqDisplay
        '
        Me.MaxFreqDisplay.HideSelection = False
        Me.MaxFreqDisplay.Location = New System.Drawing.Point(129, 38)
        Me.MaxFreqDisplay.Name = "MaxFreqDisplay"
        Me.MaxFreqDisplay.ReadOnly = True
        Me.MaxFreqDisplay.Size = New System.Drawing.Size(100, 22)
        Me.MaxFreqDisplay.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "RMS Amplitude"
        '
        'RMSDisplay
        '
        Me.RMSDisplay.HideSelection = False
        Me.RMSDisplay.Location = New System.Drawing.Point(6, 40)
        Me.RMSDisplay.Name = "RMSDisplay"
        Me.RMSDisplay.ReadOnly = True
        Me.RMSDisplay.Size = New System.Drawing.Size(100, 22)
        Me.RMSDisplay.TabIndex = 0
        '
        'filterSignalCheck
        '
        Me.filterSignalCheck.AutoSize = True
        Me.filterSignalCheck.Checked = True
        Me.filterSignalCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.filterSignalCheck.Location = New System.Drawing.Point(38, 370)
        Me.filterSignalCheck.Name = "filterSignalCheck"
        Me.filterSignalCheck.Size = New System.Drawing.Size(104, 21)
        Me.filterSignalCheck.TabIndex = 7
        Me.filterSignalCheck.Text = "Filter Signal"
        Me.filterSignalCheck.UseVisualStyleBackColor = True
        '
        'TensionDisplay
        '
        Me.TensionDisplay.BackColor = System.Drawing.Color.Gray
        Me.TensionDisplay.Location = New System.Drawing.Point(174, 343)
        Me.TensionDisplay.Name = "TensionDisplay"
        Me.TensionDisplay.Size = New System.Drawing.Size(55, 50)
        Me.TensionDisplay.TabIndex = 8
        Me.TensionDisplay.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.downButton)
        Me.GroupBox2.Controls.Add(Me.stopButton)
        Me.GroupBox2.Controls.Add(Me.upButton)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(726, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(86, 331)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Manual Controls"
        '
        'downButton
        '
        Me.downButton.Location = New System.Drawing.Point(6, 263)
        Me.downButton.Name = "downButton"
        Me.downButton.Size = New System.Drawing.Size(74, 52)
        Me.downButton.TabIndex = 5
        Me.downButton.Text = "Down"
        Me.downButton.UseVisualStyleBackColor = True
        '
        'stopButton
        '
        Me.stopButton.Location = New System.Drawing.Point(6, 164)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(74, 52)
        Me.stopButton.TabIndex = 4
        Me.stopButton.Text = "Stop"
        Me.stopButton.UseVisualStyleBackColor = True
        '
        'upButton
        '
        Me.upButton.Location = New System.Drawing.Point(6, 68)
        Me.upButton.Name = "upButton"
        Me.upButton.Size = New System.Drawing.Size(74, 52)
        Me.upButton.TabIndex = 3
        Me.upButton.Text = "Up"
        Me.upButton.UseVisualStyleBackColor = True
        '
        'FrameSize
        '
        Me.FrameSize.FormattingEnabled = True
        Me.FrameSize.Items.AddRange(New Object() {"128", "256", "512"})
        Me.FrameSize.Location = New System.Drawing.Point(122, 399)
        Me.FrameSize.Name = "FrameSize"
        Me.FrameSize.Size = New System.Drawing.Size(107, 24)
        Me.FrameSize.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 402)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 17)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Frame Size"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 451)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.FrameSize)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TensionDisplay)
        Me.Controls.Add(Me.filterSignalCheck)
        Me.Controls.Add(Me.AnalysisBox)
        Me.Controls.Add(Me.FFTGraphic)
        Me.Controls.Add(Me.modeSelect)
        Me.Controls.Add(Me.Test)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Test Controller"
        Me.GroupBox1.ResumeLayout(False)
        Me.Test.ResumeLayout(False)
        Me.Test.PerformLayout()
        Me.FFTGraphic.ResumeLayout(False)
        CType(Me.chart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AnalysisBox.ResumeLayout(False)
        Me.AnalysisBox.PerformLayout()
        CType(Me.TensionDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents comPorts As ComboBox
    Friend WithEvents Connect As Button
    Friend WithEvents Test As GroupBox
    Friend WithEvents Start As Button
    Friend WithEvents inboxTime As TextBox
    Friend WithEvents ReadClock As Timer
    Friend WithEvents inboxVal1 As TextBox
    Friend WithEvents inboxVal2 As TextBox
    Friend WithEvents modeSelect As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents FFTGraphic As GroupBox
    Friend WithEvents chart As DataVisualization.Charting.Chart
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents AnalysisBox As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents RMSDisplay As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents MaxFreqDisplay As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents AvgPowerDisplay As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents FatigueBar As ProgressBar
    Friend WithEvents filterSignalCheck As CheckBox
    Friend WithEvents TensionDisplay As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents downButton As Button
    Friend WithEvents stopButton As Button
    Friend WithEvents upButton As Button
    Friend WithEvents FrameSize As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TriggerSelect As ComboBox
End Class
