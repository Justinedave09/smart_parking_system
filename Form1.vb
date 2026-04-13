Imports System.IO.Ports
Imports System.Drawing.Printing

Public Class Form1
    Private WithEvents SerialPort1 As New System.IO.Ports.SerialPort()

    ' Arrays to manage 4 slots (0-3)
    Dim slotStartTimes(3) As DateTime
    Dim isOccupied(3) As Boolean
    Dim slotPanels(3) As Panel
    Dim slotLabels(3) As Label
    Dim slotPictures(3) As PictureBox
    Dim slotPlateTextBoxes(3) As TextBox
    Dim slotPlateNumbers(3) As String
    Dim pendingSlotIndex As Integer = -1
    Dim carIsAtEntrance As Boolean = False
    Private rand As New Random()
    Dim receiptInfo As String = ""

    ' --- FORM LOAD & INITIALIZATION ---
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize Control Arrays
            slotPanels = {pnlSlot1, pnlSlot2, pnlSlot3, pnlSlot4}
            slotLabels = {lblStatus1, lblStatus2, lblStatus3, lblStatus4}
            slotPictures = {PictureBox1, PictureBox2, PictureBox3, PictureBox4}
            slotPlateTextBoxes = {txtPlate1, txtPlate2, txtPlate3, txtPlate4}

            ' Initial UI State
            For i As Integer = 0 To 3
                slotPictures(i).Visible = False
                slotPlateTextBoxes(i).Visible = False
                slotPlateTextBoxes(i).ReadOnly = True
                isOccupied(i) = False
                slotPanels(i).BackColor = Color.Green
                slotLabels(i).Text = "AVAILABLE"
            Next

            ' Setup ListView
            With lvLogs
                .View = View.Details
                .FullRowSelect = True
                .GridLines = True
                .Columns.Clear()
                .Columns.Add("Slot #", 70)
                .Columns.Add("Plate #", 100)
                .Columns.Add("Time In", 100)
                .Columns.Add("Time Out", 100)
                .Columns.Add("Duration", 80)
                .Columns.Add("Fee (₱)", 80)
            End With

            lblNotify.Visible = False
            RefreshComPorts()
        Catch ex As Exception
            MessageBox.Show("Initialization Error: Check if all Controls (Panels, Labels, etc.) are named correctly.")
        End Try
    End Sub

    ' --- COM PORT MANAGEMENT ---
    Private Sub RefreshComPorts()
        ComboBox1.Items.Clear()
        Dim ports() As String = SerialPort.GetPortNames()
        If ports.Length > 0 Then
            ComboBox1.Items.AddRange(ports)
            ComboBox1.SelectedIndex = 0
        Else
            ComboBox1.Items.Add("No Ports Found")
            ComboBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
                btnConnect.Text = "Connect"
                btnConnect.BackColor = Color.LightGray
            Else
                If ComboBox1.Text <> "No Ports Found" Then
                    SerialPort1.PortName = ComboBox1.Text
                    SerialPort1.BaudRate = 9600
                    SerialPort1.Open()
                    btnConnect.Text = "Disconnect"
                    btnConnect.BackColor = Color.LightGreen
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error: " & ex.Message)
        End Try
    End Sub

    ' --- DATA RECEIVING ---
    ' --- DATA RECEIVING (ENTRANCE & CHECKOUT) ---
    ' This runs when the Arduino sends "CHECKOUT:X"
    'Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
    '    Try
    '        Dim incomingData As String = SerialPort1.ReadLine().Trim()
    '        Me.Invoke(Sub()
    '                      If incomingData = "CAR_READY" Then
    '                          ' --- CHECK IF FULL ---
    '                          Dim full As Boolean = True
    '                          For i As Integer = 0 To 3
    '                              If isOccupied(i) = False Then
    '                                  full = False ' Found an empty slot
    '                                  Exit For
    '                              End If
    '                          Next

    '                          If full Then
    '                              ' Notify Slot is Full
    '                              lblNotify.Text = "PARKING FULL: NO SLOTS AVAILABLE"
    '                              lblNotify.BackColor = Color.Red
    '                              lblNotify.ForeColor = Color.White
    '                              lblNotify.Visible = True
    '                              carIsAtEntrance = False ' Block entry logic
    '                          Else
    '                              ' Standard Detection
    '                              carIsAtEntrance = True
    '                              lblNotify.Text = "CAR DETECTED: PLEASE SELECT A SLOT"
    '                              lblNotify.BackColor = Color.Yellow
    '                              lblNotify.ForeColor = Color.Black
    '                              lblNotify.Visible = True
    '                          End If

    '                      ElseIf incomingData.StartsWith("CHECKOUT:") Then
    '                          Dim idx As Integer = Integer.Parse(incomingData.Substring(9)) - 1
    '                          If isOccupied(idx) Then
    '                              CalculateAndLog(idx, slotStartTimes(idx), DateTime.Now)
    '                              ' Reset Slot
    '                              SerialPort1.WriteLine("VACATE:" & (idx + 1))
    '                              isOccupied(idx) = False
    '                              slotPanels(idx).BackColor = Color.Green
    '                              slotPictures(idx).Visible = False
    '                              slotPlateTextBoxes(idx).Visible = False
    '                              slotLabels(idx).Text = "AVAILABLE"
    '                          End If
    '                      End If
    '                  End Sub)
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Dim incomingData As String = SerialPort1.ReadLine().Trim()
            Me.Invoke(Sub()
                          ' --- 1. SENSOR DETECTION ---
                          If incomingData = "CAR_READY" Then
                              Dim isFull As Boolean = True
                              For i As Integer = 0 To 3
                                  If isOccupied(i) = False Then isFull = False : Exit For
                              Next

                              If isFull Then
                                  lblNotify.Text = "PARKING FULL"
                                  lblNotify.BackColor = Color.Red
                                  lblNotify.Visible = True
                              Else
                                  carIsAtEntrance = True
                                  lblNotify.Text = "CAR DETECTED: PRESS A SLOT BUTTON"
                                  lblNotify.BackColor = Color.Yellow
                                  lblNotify.Visible = True
                              End If

                              ' --- 2. HARDWARE BUTTON PRESSED ---
                              'ElseIf incomingData.StartsWith("BTN_PRESSED:") Then
                              '    Dim idx As Integer = Integer.Parse(incomingData.Substring(12)) - 1

                              '    If isOccupied(idx) = False Then
                              '        ' --- ENTRY LOGIC ---
                              '        If carIsAtEntrance Then
                              '            isOccupied(idx) = True
                              '            slotStartTimes(idx) = DateTime.Now
                              '            ' Generate Plate
                              '            Dim plate As String = rand.Next(100, 1000).ToString() & " " & Chr(rand.Next(65, 91)) & Chr(rand.Next(65, 91)) & Chr(rand.Next(65, 91))
                              '            slotPlateNumbers(idx) = plate

                              '            ' Update UI
                              '            slotPanels(idx).BackColor = Color.Red
                              '            slotPictures(idx).Visible = True
                              '            slotPlateTextBoxes(idx).Text = plate
                              '            slotPlateTextBoxes(idx).Visible = True
                              '            slotLabels(idx).Text = "OCCUPIED"

                              '            ' Tell Arduino
                              '            SerialPort1.WriteLine("LED_RED:" & (idx + 1))
                              '            SerialPort1.WriteLine("OPEN_GATE")

                              '            carIsAtEntrance = False
                              '            lblNotify.Text = "Entry Slot " & (idx + 1)
                              '        End If
                              '    Else
                              '        ' --- EXIT LOGIC ---
                              '        ' Process Receipt
                              '        CalculateAndLog(idx, slotStartTimes(idx), DateTime.Now)

                              '        ' Reset State
                              '        isOccupied(idx) = False
                              '        slotPanels(idx).BackColor = Color.Green
                              '        slotPictures(idx).Visible = False
                              '        slotPlateTextBoxes(idx).Visible = False
                              '        slotLabels(idx).Text = "AVAILABLE"

                              '        ' Tell Arduino
                              '        SerialPort1.WriteLine("LED_GREEN:" & (idx + 1))
                              '        ' Gate opening for exit is handled inside CalculateAndLog via "OPEN_GATE"
                              '    End If
                              'End If
                              ' --- Inside SerialPort1_DataReceived ---
                          ElseIf incomingData.StartsWith("BTN_PRESSED:") Then
                              Dim idx As Integer = Integer.Parse(incomingData.Substring(12)) - 1

                              If isOccupied(idx) = False Then
                                  ' --- ENTRY LOGIC ---
                                  If carIsAtEntrance Then
                                      ' 1. Logic updates (happens immediately)
                                      isOccupied(idx) = True
                                      slotStartTimes(idx) = DateTime.Now
                                      Dim plate As String = rand.Next(100, 1000).ToString() & " " & Chr(rand.Next(65, 91)) & Chr(rand.Next(65, 91)) & Chr(rand.Next(65, 91))
                                      slotPlateNumbers(idx) = plate

                                      ' 2. Tell Arduino to open gate NOW
                                      SerialPort1.WriteLine("LED_RED:" & (idx + 1))
                                      SerialPort1.WriteLine("OPEN_GATE")

                                      ' 3. Set up the DELAYED rendering
                                      pendingSlotIndex = idx
                                      carIsAtEntrance = False

                                      ' Show a temporary message
                                      lblNotify.Text = "GATE OPENING... PLEASE WAIT"
                                      lblNotify.BackColor = Color.Orange
                                      lblNotify.Visible = True

                                      ' 4. Start the timer (Make sure tmrNotify.Interval is set to 2000 in Designer)
                                      tmrNotify.Start()
                                  End If
                              Else
                                  ' --- EXIT LOGIC (Your existing code) ---
                                  CalculateAndLog(idx, slotStartTimes(idx), DateTime.Now)
                                  isOccupied(idx) = False
                                  slotPanels(idx).BackColor = Color.Green
                                  slotPictures(idx).Visible = False
                                  slotPlateTextBoxes(idx).Visible = False
                                  slotLabels(idx).Text = "AVAILABLE"
                                  SerialPort1.WriteLine("LED_GREEN:" & (idx + 1))
                              End If
                          End If
                      End Sub)
        Catch ex As Exception
        End Try
    End Sub
    ' --- THE CLICK LOGIC (Fixed) ---
    'Private Sub SlotPanel_Click(sender As Object, e As EventArgs) Handles pnlSlot1.Click, pnlSlot2.Click, pnlSlot3.Click, pnlSlot4.Click
    '    Dim clickedPanel = DirectCast(sender, Panel)
    '    Dim idx As Integer = Integer.Parse(clickedPanel.Name.Replace("pnlSlot", "")) - 1

    '    If isOccupied(idx) = False Then
    '        If carIsAtEntrance Then
    '            ' Authorized Entry
    '            isOccupied(idx) = True
    '            slotStartTimes(idx) = DateTime.Now

    '            Dim plateNum As String = rand.Next(100, 1000).ToString()
    '            Dim plateLetters As String = Chr(rand.Next(65, 91)) & Chr(rand.Next(65, 91)) & Chr(rand.Next(65, 91))
    '            slotPlateNumbers(idx) = plateNum & " " & plateLetters

    '            ' Update UI
    '            slotPanels(idx).BackColor = Color.Red
    '            slotPictures(idx).Visible = True
    '            slotPlateTextBoxes(idx).Text = slotPlateNumbers(idx)
    '            slotPlateTextBoxes(idx).Visible = True
    '            slotLabels(idx).Text = "OCCUPIED"

    '            If SerialPort1.IsOpen Then SerialPort1.WriteLine("OCCUPY:" & (idx + 1))

    '            carIsAtEntrance = False
    '            lblNotify.Text = "Entry Authorized for Slot " & (idx + 1)
    '        Else
    '            MessageBox.Show("No car detected at sensor!")
    '        End If
    '    Else
    '        MessageBox.Show("Slot already occupied! Use the hardware button to checkout.")
    '    End If
    'End Sub

    ' --- RECEIPT & LOGGING ---
    Private Sub CalculateAndLog(slotIndex As Integer, timeIn As DateTime, timeOut As DateTime)
        Dim duration As TimeSpan = timeOut - timeIn
        Dim totalMinutes As Double = duration.TotalMinutes
        Dim blocks As Integer = Math.Max(1, Math.Ceiling(totalMinutes / 2.0))
        Dim totalFee As Integer = blocks * 40

        ' Update ListView
        Dim item As New ListViewItem((slotIndex + 1).ToString())
        item.SubItems.Add(slotPlateNumbers(slotIndex))
        item.SubItems.Add(timeIn.ToString("HH:mm:ss"))
        item.SubItems.Add(timeOut.ToString("HH:mm:ss"))
        item.SubItems.Add(Math.Round(totalMinutes, 2) & "m")
        item.SubItems.Add("₱" & totalFee.ToString())
        lvLogs.Items.Insert(0, item)

        ' Prepare Receipt Content
        receiptInfo = "      SMART PARKING SYSTEM" & vbCrLf &
                      "--------------------------------" & vbCrLf &
                      "Date: " & DateTime.Now.ToShortDateString() & vbCrLf &
                      "Slot Number: " & (slotIndex + 1).ToString() & vbCrLf &
                      "PLATE NUMBER: " & slotPlateNumbers(slotIndex) & vbCrLf &
                      "Time In:    " & timeIn.ToString("hh:mm tt") & vbCrLf &
                      "Time Out:   " & timeOut.ToString("hh:mm tt") & vbCrLf &
                      "Duration:   " & Math.Round(totalMinutes, 2) & " mins" & vbCrLf &
                      "--------------------------------" & vbCrLf &
                      "TOTAL FEE:  PHP " & totalFee.ToString() & ".00" & vbCrLf &
                      "--------------------------------" & vbCrLf &
                      "      THANK YOU FOR PARKING!"

        ' Trigger the actual receipt window
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
        ' --- AFTER RECEIPT: OPEN GATE ---
        If SerialPort1.IsOpen Then
            SerialPort1.WriteLine("OPEN_GATE")
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(receiptInfo, New Font("Courier New", 12), Brushes.Black, 100, 100)
    End Sub

    'Private Sub tmrNotify_Tick(sender As Object, e As EventArgs) Handles tmrNotify.Tick
    '    lblNotify.Visible = False
    '    tmrNotify.Stop()
    'End Sub
    Private Sub tmrNotify_Tick(sender As Object, e As EventArgs) Handles tmrNotify.Tick
        tmrNotify.Stop() ' Stop the timer so it doesn't loop

        ' If there is a car waiting to be rendered
        If pendingSlotIndex <> -1 Then
            Dim i As Integer = pendingSlotIndex

            ' --- NOW SHOW THE CAR IN THE UI ---
            slotPanels(i).BackColor = Color.Red
            slotPictures(i).Visible = True
            slotPlateTextBoxes(i).Text = slotPlateNumbers(i)
            slotPlateTextBoxes(i).Visible = True
            slotLabels(i).Text = "OCCUPIED"

            ' Update Notification
            lblNotify.Text = "CAR PARKED IN SLOT " & (i + 1)
            lblNotify.BackColor = Color.IndianRed

            ' Reset the pending index for the next car
            pendingSlotIndex = -1
        Else
            ' If no car was pending, just hide the label (standard use)
            lblNotify.Visible = False
        End If
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SerialPort1.IsOpen Then SerialPort1.Close()
    End Sub

    Private Sub txtPlate3_TextChanged(sender As Object, e As EventArgs) Handles txtPlate3.TextChanged

    End Sub
End Class