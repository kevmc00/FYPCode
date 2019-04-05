Imports System.IO
Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Numerics.Complex
Imports System.Numerics
Imports Excel = Microsoft.Office.Interop.Excel
Imports SerialCommsApp

Public Class Form1
    Dim sp As IO.Ports.SerialPort
    Dim data As New List(Of Snapshot)
    Dim reading As Boolean = False
    Dim count As Integer = 0
    Dim BitReversal As ArrayList = New ArrayList()
    Dim fftLeft, fftRight As New List(Of List(Of Complex))
    Dim xaxis As ArrayList = New ArrayList()
    Dim RMSA As ArrayList = New ArrayList()
    Dim MaxFrequency As ArrayList = New ArrayList()
    Dim AveragePower As ArrayList = New ArrayList()
    'Dim PeakFrequency As ArrayList = New ArrayList()
    Dim Peaks As ArrayList = New ArrayList()
    Dim peakIndex As ArrayList = New ArrayList()
    Dim movingAvg As List(Of Double) = Enumerable.Repeat(0.0, 3).ToList()
    Dim templateLoc As String = "C:\Users\kevmc\OneDrive\Documents\Engineering\Final Year\Final Year Project\Testing\Testing PC Application\Results\TEMPLATE_DO_NOT_EDIT"
    Dim excel As Excel.Application = New Excel.Application
    Dim directory As String
    Dim failDet As Boolean = False
    Dim peakMovingAvgBuff As List(Of Double) = Enumerable.Repeat(0.0, 3).ToList()
    Dim PeakMovingAvg As ArrayList = New ArrayList()
    Dim Delta As ArrayList = New ArrayList()
    Dim redundancy As Integer
    Dim check As Double
    Dim trigger As Double
    Dim manual As Boolean = False
    Dim connected As Boolean = False
    Dim frameSizeNum As Integer
    Dim peakCheck As Integer = 3
    Dim command As String = ""
    Dim manualTrigger As Integer


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each port As String In My.Computer.Ports.SerialPortNames
            comPorts.Items.Add(port)
        Next
        chart.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Spline
        chart.Series(0).Name = "Left"
        chart.Series.Add("Right")
        chart.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Spline
        chart.ChartAreas(0).AxisX.Minimum = 0
        chart.ChartAreas(0).AxisX.Maximum = 500
        chart.ChartAreas(0).AxisY.Minimum = 0
        chart.ChartAreas(0).AxisY.Maximum = 1000
        'chart.ChartAreas(0).AxisY.Maximum = 150
        chart.ChartAreas(0).AxisX.Title = "Frequency (Hz)"
        Peaks.Add(0)
        FrameSize.SelectedIndex = 1
        TriggerSelect.SelectedIndex = 0
        frameSizeNum = Convert.ToInt32(FrameSize.Text)

        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\Users\kevmc\OneDrive\Documents\Engineering\Final Year\Final Year Project\Testing\Testing PC Application\BitReversal" + FrameSize.Text + ".csv")
        Dim split() As String = fileReader.Split(",")
        For i As Integer = 0 To split.Count - 1
            Dim intVal As Integer = split(i)
            BitReversal.Add(intVal)
            xaxis.Add(i * 1000 / frameSizeNum)
        Next

        'Dim numerator As List(Of Double) = {0.4019, 0, -1.2057, 0, 1.2057, 0, -0.4019}.ToList
        'Dim denominator As List(Of Double) = {1, -0.7568, -1.0451, 0.4161, 0.7345, -0.1302, -0.1598}.ToList
        'Dim filter As Filter = New Filter(numerator, denominator)
        'Filter.ImpulseResponse(10)

    End Sub

    Private Sub Connect_Click(sender As Object, e As EventArgs) Handles Connect.Click
        connected = True
        sp = My.Computer.Ports.OpenSerialPort(comPorts.Text)
        sp.BaudRate = 230400
        sp.RtsEnable = True
        sp.DtrEnable = True
        Test.Enabled = True
        GroupBox2.Enabled = True
    End Sub


    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click
        Dim filename As String
        Dim thread, thread1 As Thread

        reading = Not reading

        If reading Then
            Start.Text = "Stop"
            data.Clear()
            If connected Then
                sp.DiscardInBuffer()
            End If

            If Not modeSelect.Checked Then
                Dim fileSelect As OpenFileDialog = New OpenFileDialog()
                fileSelect.Title = "Select File"
                fileSelect.InitialDirectory = "C:\Users\kevmc\OneDrive\Documents\Engineering\Final Year\Final Year Project\Testing\Testing PC Application\Results"
                fileSelect.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
                fileSelect.RestoreDirectory = True
                If fileSelect.ShowDialog() = DialogResult.OK Then
                    directory = fileSelect.FileName
                    thread = New Thread(AddressOf SerialListener)
                    thread.Start()
                    modeSelect.Enabled = False
                    TriggerSelect.Enabled = False
                Else
                    reading = Not reading
                    Start.Text = "Start"
                    directory = "CANCELLED"
                End If
            Else
                thread = New Thread(AddressOf SerialListener)
                thread.Start()
            End If
        Else
            Start.Text = "Start"
            For Each peak In Peaks
                Console.Write("Peak Value: ")
                Console.WriteLine(peak)
            Next
            Console.WriteLine("Number of Peaks: {0}", Peaks.Count)
            count = 0
            filename = InputBox("Please enter a file name", "Create File") + ".csv"
            modeSelect.Enabled = True
            TriggerSelect.Enabled = True

            If modeSelect.Checked Then
                Dim sw As New StreamWriter("C:\Users\kevmc\OneDrive\Documents\Engineering\Final Year\Final Year Project\Testing\Testing PC Application\Results\RAW_" + filename)
                For Each record In data
                    sw.WriteLine(record.commaSeparated())
                Next
                sw.Close()
            End If

            If filename <> ".csv" Then
                excel.Visible = True
                Dim book As Excel.Workbook = excel.Workbooks.Open("C:\Users\kevmc\OneDrive\Documents\Engineering\Final Year\Final Year Project\Testing\Testing PC Application\Results\TEMPLATE_DO_NOT_EDIT")
                book.SaveAs("C:\Users\kevmc\OneDrive\Documents\Engineering\Final Year\Final Year Project\Testing\Testing PC Application\Results\" + filename)
                Dim AnalysisSheet As Excel.Worksheet = book.Sheets(1)
                Dim FFTSheetL As Excel.Worksheet = book.Sheets(2)
                Dim FFTSheetR As Excel.Worksheet = book.Sheets(3)

                Dim list As List(Of Complex)
                Dim sum As Double
                For i As Integer = 0 To AveragePower.Count - 1

                    AnalysisSheet.Cells(i + 3, 2).Value = i + 1
                    AnalysisSheet.Cells(i + 3, 3).Value = RMSA(i)
                    AnalysisSheet.Cells(i + 3, 4).Value = MaxFrequency(i)
                    AnalysisSheet.Cells(i + 3, 5).Value = AveragePower(i)
                    'AnalysisSheet.Cells(i + 3, 6).Value = 
                    'If i > 2 Then
                    'AnalysisSheet.Cells(i + 3, 7).Value = movingAvg(i - 2)
                    'End If
                Next

                Dim index As Integer
                For i As Integer = 0 To peakIndex.Count - 1
                    index = peakIndex(i)
                    FFTSheetL.Cells(i + 3, 2).Value = i + 1
                    FFTSheetR.Cells(i + 3, 2).Value = i + 1
                    For j As Integer = 0 To (fftLeft(i).Count / 2) - 1
                        sum = 0
                        For k As Integer = 0 To 2
                            list = fftLeft(index - k)
                            sum += list(j).Magnitude
                        Next
                        FFTSheetL.Cells(i + 3, j + 3).Value = sum / 3

                        sum = 0
                        For k As Integer = 0 To 2
                            list = fftRight(index - k)
                            sum += list(j).Magnitude
                        Next
                        FFTSheetR.Cells(i + 3, j + 3).Value = sum / 3
                    Next
                Next

                For i As Integer = 1 To Peaks.Count - 1
                    AnalysisSheet.Cells(i + 2, 7).Value = i
                    AnalysisSheet.Cells(i + 2, 8).Value = Peaks(i)
                Next

                'Dim ind As Integer = 3
                'For Each point In data
                '   rawSheet.Cells(ind, 3).Value = point.getLeft().ToString()
                '   rawSheet.Cells(ind, 4).Value = point.getRight().ToString()
                '   ind += 1
                'Next
                book.SaveAs("C:\Users\kevmc\OneDrive\Documents\Engineering\Final Year\Final Year Project\Testing\Testing PC Application\Results\" + filename)
                book.Close()
                excel.Quit()



            End If

            Console.WriteLine("Moving Average")
            For Each thing In PeakMovingAvg
                Console.WriteLine(thing)
            Next

            Console.WriteLine("Delta")
            For Each thing In Delta
                Console.WriteLine(thing)
            Next


            RMSA.Clear()
            MaxFrequency.Clear()
            AveragePower.Clear()
            'PeakFrequency.Clear()
            Peaks.Clear()
            PeakMovingAvg.Clear()
            Peaks.Add(0)
            peakIndex.Clear()
            Delta.Clear()
            failDet = False
            movingAvg = Enumerable.Repeat(0.0, 3).ToList()
            peakMovingAvgBuff = Enumerable.Repeat(0.0, 3).ToList()
            TensionDisplay.BackColor = Color.Gray
            AnalysisBox.Invoke(Sub()
                                   FatigueBar.Value = 0
                               End Sub)
        End If
    End Sub

    Private Sub FatigueDetect()
        Dim index As Integer
        Dim length As Integer = AveragePower.Count
        Dim peakDet As Boolean = True

        If length > 10 Then
            index = length - 4
            For i As Integer = 1 To 3
                ' If statement used to break at a certain reading for debugging
                If length = 25 Then
                    Dim dummy As Integer = 0
                End If

                If (AveragePower.Item(index) < AveragePower.Item(index - i)) Or (AveragePower.Item(index) < AveragePower.Item(index + i)) Or (AveragePower.Item(index) < 100) Then
                    peakDet = False
                End If
            Next


            If peakDet Then
                Console.WriteLine("Peak Number " + Peaks.Count.ToString + " detected!")
                Peaks.Add(AveragePower(index))
                peakIndex.Add(index)

                If manual Then
                    If Peaks.Count - 1 = trigger Then
                        command = "u"
                        redundancy = 3
                        failDet = True
                    End If
                Else
                    'If Peaks.Count > 2 Then
                    'If Peaks(Peaks.Count - 1) < Peaks(Peaks.Count - 2) * 0.8 Then
                    'failDet += 1
                    'TensionDisplay.BackColor = Color.Red
                    'Console.WriteLine("Failure Dectected at Rep " + (Peaks.Count - 1).ToString)
                    'If failDet = 1 And modeSelect.Checked Then
                    'command = "u"
                    'redundancy = 3
                    'failDet = 0
                    'End If
                    'End If
                    'End If

                    Dim fatigue As Double = Peaks(Peaks.Count - 2) - Peaks(Peaks.Count - 1)
                    fatigue = fatigue / Peaks(Peaks.Count - 1)
                    fatigue = (fatigue + Log(New Complex(CType(Peaks.Count - 1, Double), 0), 20).Real) / 2
                    If fatigue > 0.5 And failDet = False Then
                        Console.WriteLine("Fatigue!")
                        failDet = True
                        command = "u"
                        redundancy = 3
                        AnalysisBox.Invoke(Sub()
                                               FatigueBar.Value = 100
                                           End Sub)
                    End If
                End If


                'Console.WriteLine("Number of Failures: " + failDet.ToString)
                'peakMovingAvgBuff(2) = peakMovingAvgBuff(1)
                'peakMovingAvgBuff(1) = peakMovingAvgBuff(0)
                'peakMovingAvgBuff(0) = AveragePower(index)
                'System.Windows.Forms.Application.DoEvents()

                'If Peaks.Count > 3 Then
                'PeakMovingAvg.Add(peakMovingAvgBuff.Average)
                'End If

                'If PeakMovingAvg.Count > 1 Then
                'Delta.Add(PeakMovingAvg(PeakMovingAvg.Count - 1) - PeakMovingAvg(PeakMovingAvg.Count - 2))

                'Dim sum As Double = 0
                'For Each point In Delta
                'sum += point
                'Next


                'trigger = sum / Delta.Count
                'Console.Write("Trigger = ")
                'Console.WriteLine(trigger)
                'End If


                'If Delta.Count > 0 Then
                'If Delta(Delta.Count - 1) < trigger Then
                'failDet += 1
                'If failDet = 2 Then
                ''Console.WriteLine("Fatigue!")
                'If modeSelect.Checked Then
                'sp.Write("u")
                'End If
                '
                'TensionDisplay.BackColor = Color.Red
                'AnalysisBox.Invoke(Sub()
                'FatigueBar.Value = 33
                'End Sub)
                'ElseIf failDet = 4 Then
                'AnalysisBox.Invoke(Sub()
                'FatigueBar.Value = 66
                'End Sub)
                'ElseIf failDet = 6 Then
                'AnalysisBox.Invoke(Sub()
                'FatigueBar.Value = 100
                'End Sub)
                'End If
                'Else
                '   TensionDisplay.BackColor = Color.Lime
                '  failDet = 0
                'End If
                'Else
                'TensionDisplay.BackColor = Color.Lime
                'End If

                'If failDet = 0 Then
                'check = Peaks(Peaks.Count - 2)
                'End If

                'Console.WriteLine("Peak No. {0}: {1} @ index of {2}", Peaks.Count - 1, AveragePower(index), index + 1)

            Else
                If AveragePower(AveragePower.Count - 1) < 100 Then
                    TensionDisplay.BackColor = Color.Gray
                ElseIf failDet = False Then
                    TensionDisplay.BackColor = Color.Lime
                Else
                    TensionDisplay.BackColor = Color.Red
                End If
            End If
        End If
    End Sub

    Private Sub SerialListener()
        Dim values() As String
        Dim current_raw As List(Of Snapshot) = New List(Of Snapshot)
        Dim current_filt As List(Of Snapshot) = New List(Of Snapshot)
        Dim frame As List(Of Snapshot)
        Dim filtered As Snapshot
        Dim thread1, thread2 As Thread
        Dim numerator As List(Of Double) = {0.4019, 0, -1.2057, 0, 1.2057, 0, -0.4019}.ToList
        Dim denominator As List(Of Double) = {1, -0.7568, -1.0451, 0.4161, 0.7345, -0.1302, -0.1598}.ToList
        Dim read As StreamReader
        Dim hpf As Filter = New Filter(numerator, denominator)
        Dim cont As Boolean = True

        Dim readings() As String
        Dim index As Integer = 0
        If modeSelect.Checked = False Then
            read = File.OpenText(directory)
            readings = read.ReadToEnd().Split(Environment.NewLine)
        Else
            sp.DiscardInBuffer()
        End If

        While (cont)

            If modeSelect.Checked Then
                While sp.BytesToRead = 0
                    If Not command = "" Then
                        sp.WriteLine(command)
                        If redundancy = 0 Then
                            command = ""
                        Else
                            redundancy -= 1
                        End If
                    End If
                End While
                Try
                    values = sp.ReadLine().Split(",")
                Catch
                    values = {0}
                End Try

            Else
                values = readings(index).Split(",")
                index += 1
            End If
            count += 1


            If values.Length() = 2 Then
                Dim snap As Snapshot = New Snapshot(count, values(0), values(1))
                current_raw.Add(snap)
                If filterSignalCheck.Checked = True Then
                    filtered = hpf.FilterSig(snap)
                    current_filt.Add(filtered)
                    frame = current_filt
                Else
                    frame = current_raw
                End If

                If (frame.Count = frameSizeNum) Then
                    Dim toBeAnalysed As List(Of Snapshot) = New List(Of Snapshot)
                    toBeAnalysed.AddRange(frame)
                    Test.Invoke(Sub()
                                    inboxTime.Text = count
                                    inboxVal1.Text = values(0)
                                    inboxVal2.Text = values(1)
                                End Sub)
                    If modeSelect.Checked Then
                        'Start FFT Thread with relevant data
                        thread1 = New Thread(Sub() FFT(toBeAnalysed))
                        thread2 = New Thread(Sub() RMSAmplitude(toBeAnalysed))
                        thread1.Start()
                        thread2.Start()
                    Else
                        FFT(toBeAnalysed)
                        RMSAmplitude(toBeAnalysed)
                    End If

                    data.AddRange(frame)

                    current_raw.Clear()
                    current_filt.Clear()
                End If
                System.Windows.Forms.Application.DoEvents()
            End If

            If modeSelect.Checked Then
                If Start.Text = "Start" Then
                    cont = False
                End If
            Else
                If index = readings.Count Then
                    cont = False
                    read.Close()
                End If
            End If
        End While

    End Sub

    Private Function FFT(points As List(Of Snapshot))
        Dim watch As Stopwatch = Stopwatch.StartNew()
        Dim incr As Double = 1000 / frameSizeNum
        Dim x As List(Of Snapshot) = New List(Of Snapshot)
        Dim N As Integer = points.Count
        Dim M As Integer = N / 2
        Dim j As Complex = New Complex(0, 1)
        Dim shift As Integer = 0
        Dim zLeft As List(Of Complex) = New List(Of Complex)
        Dim zRight As List(Of Complex) = New List(Of Complex)
        Dim yL As List(Of Complex) = New List(Of Complex)
        Dim yR As List(Of Complex) = New List(Of Complex)
        Dim index As Integer
        Dim thresh As Integer = 50
        Dim MaxFreq As Double = 0
        'Dim MaxVal As Double = 0
        Dim avgPower As Double = 0
        Dim sum As Double = 0

        For i As Integer = 0 To N - 1
            Dim left As Double = points.Item(BitReversal(i)).getLeft()
            Dim right As Double = points.Item(BitReversal(i)).getRight()
            zLeft.Add(New Complex(left, 0))
            zRight.Add(New Complex(right, 0))
        Next

        For i As Integer = 1 To Log(N, 2).Real
            shift = N / M
            For k As Integer = 0 To M - 1
                index = k * shift
                yL = butterfly(zLeft.GetRange(index, shift))
                yR = butterfly(zRight.GetRange(index, shift))
                For p As Integer = 0 To yL.Count - 1
                    zLeft(index + p) = yL(p)
                    zRight(index + p) = yR(p)
                Next
            Next
            M = M / 2
        Next
        FFTGraphic.Invoke(Sub()
                              chart.Series(0).Points.Clear()
                              chart.Series(1).Points.Clear()

                              For i As Integer = 0 To zLeft.Count / 2 - 1
                                  chart.Series(0).Points.AddXY(i * incr, zLeft(i).Magnitude)
                                  chart.Series(1).Points.AddXY(i * incr, zRight(i).Magnitude)
                                  If (zLeft(i).Magnitude > thresh) Or (zRight(i).Magnitude > thresh) Then
                                      MaxFreq = i * incr
                                  End If
                                  sum += (((zLeft(i).Magnitude + zRight(i).Magnitude) / 2) * (incr)) ^ 2

                              Next
                              System.Windows.Forms.Application.DoEvents()
                          End Sub)

        avgPower = sum / points.Count
        movingAvg(2) = movingAvg(1)
        movingAvg(1) = movingAvg(0)
        movingAvg(0) = avgPower

        avgPower = movingAvg.Average / frameSizeNum
        AveragePower.Add(avgPower)
        MaxFrequency.Add(MaxFreq)
        AnalysisBox.Invoke(Sub()
                               MaxFreqDisplay.Text = MaxFreq
                               AvgPowerDisplay.Text = avgPower
                           End Sub)
        System.Windows.Forms.Application.DoEvents()
        FatigueDetect()
        fftLeft.Add(zLeft)
        fftRight.Add(zRight)

        watch.Stop()
        'Console.Write("FFT Time Taken (ms): ")
        'Console.WriteLine(watch.ElapsedMilliseconds)

    End Function

    Private Function butterfly(list As List(Of Complex)) As List(Of Complex)
        Dim N As Integer = list.Count
        Dim M As Integer = N / 2
        Dim y As List(Of Complex) = New List(Of Complex)(N)
        y = Enumerable.Repeat(New Complex(0, 0), N).ToList()
        Dim j As Complex = New Complex(0, 1)
        Dim exp As List(Of Complex) = New List(Of Complex)

        For i As Integer = 0 To N - 1
            exp.Add(Complex.Exp(-2 * j * Math.PI * i / N))
        Next

        For i As Integer = 0 To M - 1
            y(i) = list(i) + list(M + i) * exp(i)
            y(M + i) = list(i) - list(M + i) * exp(i)
        Next

        Return y

    End Function

    Private Function DFT(list As List(Of Snapshot)) As List(Of Complex)
        Dim watch As Stopwatch = Stopwatch.StartNew()
        Dim N As Integer = list.Count
        Dim count As Integer = 0
        Dim result As List(Of Complex) = New List(Of Complex)
        Dim j As Complex = New Complex(0, 1)

        FFTGraphic.Invoke(Sub()
                              chart.Series(0).Points.Clear()
                          End Sub)

        For k As Integer = 0 To N - 1
            Dim sum As Complex = New Complex(0, 0)
            For i As Integer = 0 To N - 1
                sum += list(i).getLeft() * Exp(-2 * Math.PI * i * k * j / N)
            Next
            result.Add(sum)
            FFTGraphic.Invoke(Sub()
                                  chart.Series(0).Points.AddXY(count * 1000 / frameSizeNum, sum.Magnitude)
                                  System.Windows.Forms.Application.DoEvents()
                              End Sub)
            count = count + 1
            'Console.WriteLine(sum.Magnitude)
        Next

        watch.Stop()
        Console.Write("DFT Time Taken (ms): ")
        Console.WriteLine(watch.ElapsedMilliseconds)
        'Console.WriteLine("\n\n\n")

        Return result
    End Function

    Private Sub upButton_Click(sender As Object, e As EventArgs) Handles upButton.Click
        If sp.BytesToRead > 0 Then
            sp.DiscardInBuffer()
        End If
        'Do nothing
        'End While
        'sp.Write("f")
        sp.Write("u")
        System.Windows.Forms.Application.DoEvents()
        'commandRet = "f"
        Console.WriteLine("Forward")
    End Sub

    Private Sub stopButton_Click(sender As Object, e As EventArgs) Handles stopButton.Click
        If sp.BytesToRead > 0 Then
            sp.DiscardInBuffer()
        End If

        sp.Write("s")
        System.Windows.Forms.Application.DoEvents()
        Console.WriteLine("Stop")
    End Sub

    Private Sub downButton_Click(sender As Object, e As EventArgs) Handles downButton.Click
        If sp.BytesToRead > 0 Then
            sp.DiscardInBuffer()
        End If
        sp.Write("b")
        System.Windows.Forms.Application.DoEvents()
        Console.WriteLine("Back")
    End Sub

    Private Sub modeSelect_CheckedChanged(sender As Object, e As EventArgs) Handles modeSelect.CheckedChanged
        If modeSelect.Checked Then
            filterSignalCheck.Enabled = True
            filterSignalCheck.Checked = True
            If Not connected Then
                Test.Enabled = False
            End If
        Else
            filterSignalCheck.Enabled = False
            filterSignalCheck.Checked = False
            Test.Enabled = True
        End If
    End Sub

    Private Sub FrameSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FrameSize.SelectedIndexChanged
        BitReversal.Clear()
        frameSizeNum = Convert.ToInt32(FrameSize.Text)
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\Users\kevmc\OneDrive\Documents\Engineering\Final Year\Final Year Project\Testing\Testing PC Application\BitReversal" + FrameSize.Text + ".csv")
        Dim split() As String = fileReader.Split(",")
        For i As Integer = 0 To split.Count - 1
            Dim intVal As Integer = split(i)
            BitReversal.Add(intVal)
            xaxis.Add(i * 1000 / frameSizeNum)
        Next

    End Sub

    Private Sub TriggerSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TriggerSelect.SelectedIndexChanged
        If TriggerSelect.Text = "Manual" Then
            manual = True
            trigger = -1
            While trigger.Equals(-1)
                Dim result As String = InputBox("How many reps would you like the system to trigger after?", "Manual Trigger Configuration")
                Try
                    trigger = CType(result, Integer)
                    If trigger < 1 Then
                        MsgBox("Please enter a positive integer value")
                        trigger = -1
                    End If
                Catch ex As Exception
                    MsgBox("Please enter a positive integer value")
                End Try
            End While
        Else
            manual = False
        End If
    End Sub

    Private Function RMSAmplitude(list As List(Of Snapshot))
        Dim sum As Double = 0
        Dim sqr As Double
        Dim result As Double

        For i As Integer = 0 To list.Count - 1
            sqr = list(i).getLeft ^ 2
            sum += sqr
            sqr = list(i).getRight ^ 2
            sum += sqr
        Next

        result = (Math.Sqrt(sum / list.Count * 2))
        RMSA.Add(result)
        AnalysisBox.Invoke(Sub()
                               RMSDisplay.Text = result
                           End Sub)
        System.Windows.Forms.Application.DoEvents()

    End Function
End Class
