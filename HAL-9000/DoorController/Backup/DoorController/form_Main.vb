Delegate Sub UpdateTrafficWindow(ByVal From As String, ByVal Message As String)
Delegate Sub ProcessMessage(ByVal Sender As System.Net.IPAddress, ByVal Port As Integer, ByVal message_in As String)
Delegate Sub MoveThisDirectionDelegate(ByVal MoveDirection As String)
'HASendCommandDelegate
Delegate Sub HASendActionMessageDelegate(ByVal Message As String)

Public Class form_main
    Inherits System.Windows.Forms.Form

    Delegate Sub ProcessEnded(ByVal IP As System.Net.IPAddress, ByVal Port As Integer)

    Private Const SUCCESSFUL_ As String = "Successful"
    Private Const FAILED_ As String = "Failed"
    Private Const CONNECTED_ As String = "Connected"
    Private Const NOT_CONNECTED_ As String = "Not Connected"
    Private Const MAX_MISSILES_ As Int16 = 3
    Private Const PropertyElementText As String = "Property"
    Private Const PositionElementText As String = "Position"
    Private Const UP_ As String = "U"
    Private Const DOWN_ As String = "D"
    Private Const LEFT_ As String = "L"
    Private Const RIGHT_ As String = "R"
    Private Const HA_SEND_PLC As String = "sendplc"
    Private Const HA_SEND_RF As String = "sendrf"
    Private Const HA_ACTION_ON = "on"
    Private Const HA_ACTION_OFF = "off"


    Private TxID_ As Integer = 0
    Private AppStateXMLdoc_ As New Xml.XmlDocument
    Private AppStateXMLdocPropGrp_ As Xml.XmlElement
    Private AppStateXMLdocMsgID_ As Xml.XmlAttribute
    Private AppStateXMLdocPartID_ As Xml.XmlAttribute
    Private AvailableSongsXMLDocPropGrp As Xml.XmlElement
    Private CurrentPlaylistXMLDocPropGrp As Xml.XmlElement
    Private DoorStatusXMLDocProp As Xml.XmlElement
    Private RedLightOnXMLDocProp As Xml.XmlElement
    Private GreenLightOnXMLDocProp As Xml.XmlElement
    Private BlueLightOnXMLDocProp As Xml.XmlElement
    Private PowerSupplyOnXMLDocProp As Xml.XmlElement
    Private WithEvents UDPcommSys_ As StaXCommsLib.StaxCommunications
    Private SystemTrayContextMenu_ As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemOpen_ As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemConfig_ As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemExit_ As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAbout_ As System.Windows.Forms.MenuItem
    Friend WithEvents SystemTrayIcon_ As System.Windows.Forms.NotifyIcon
    Private MenuClosing_ As Boolean = False
    Private AccountingOnElem_ As Xml.XmlElement
    Private MissilesRemainingElem_ As Xml.XmlElement
    Private MissileAccountingOn As Boolean = True
    Private MissilesRemaining As Int16 = 3
    ' '' ''    Private usbToys As Striker2API.Usb
    Private PositionGrpElement_ As Xml.XmlElement
    Private LatLonDDGrpElement_ As Xml.XmlElement
    Private LatitudeElement_ As Xml.XmlElement
    Friend WithEvents btnToggleRedLights As System.Windows.Forms.Button
    Friend WithEvents btnToggleBlueLights As System.Windows.Forms.Button
    Friend WithEvents btnToggleGreenLights As System.Windows.Forms.Button
    Friend WithEvents btnTogglePowerSupply As System.Windows.Forms.Button
    Friend WithEvents tmrMove As System.Windows.Forms.Timer
    Friend WithEvents lblUsbStatus As System.Windows.Forms.Label
    Private LongitudeElement_ As Xml.XmlElement
    Private WithEvents MyActiveHome As ActiveHomeScriptLib.ActiveHome
    Private RedLightsOn As Boolean
    Private BlueLightsOn As Boolean
    Private GreenLightsOn As Boolean
    Private MultiLightsOn As Boolean
    Private PowerSupplyOn As Boolean
    Private RedLightUnitCode As UInt16 = 2
    Private BlueLightUnitCode As UInt16 = 3
    Private GreenLightUnitCode As UInt16 = 1
    Private MultiLightUnitCode As UInt16 = 3
    Private PowerSupplyUnitCode As UInt16 = 4
    Private HAHouseCode As String = "c"

    Private InterfaceVersion = "0.0.0"


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        '   Read in XML Interface

        If Not System.IO.File.Exists(InterfaceDefinitionFileName) Then
            MsgBox("Cannot find the interface definition file (" & InterfaceDefinitionFileName & ")", MsgBoxStyle.Critical, "Can't Find File")
            Console.WriteLine("{0} does not exist.", InterfaceDefinitionFileName)
            Return
        End If

        Dim sr As System.IO.StreamReader = System.IO.File.OpenText(InterfaceDefinitionFileName)
        Dim input As String
        input = sr.ReadLine()
        While Not input Is Nothing
            XmlInterface_ = XmlInterface_ & input
            input = sr.ReadLine()
        End While
        Console.WriteLine("The end of the stream has been reached.")
        sr.Close()

        Dim myDoc As New Xml.XmlDocument
        Dim myElem As Xml.XmlElement

        myDoc.LoadXml(XmlInterface_)
        Dim myNodeList As Xml.XmlNodeList = myDoc.GetElementsByTagName("ParticipantTypeDef")
        If myNodeList.Count > 0 Then
            myElem = myNodeList.Item(0)
            InterfaceVersion = myElem.GetAttribute("InterfaceVersion")
        End If


        ' '' ''usbToys = New Striker2API.Usb

        ' '' ''usbToys.Init(Handle)    '  where the h#ll did "Handle" come from?

        MyActiveHome = New ActiveHomeScriptLib.ActiveHome
        HASendActionMessage(BuildHAActionMessage(RedLightUnitCode, HA_ACTION_ON))
        RedLightsOn = True
        HASendActionMessage(BuildHAActionMessage(BlueLightUnitCode, HA_ACTION_ON))
        BlueLightsOn = True
        HASendActionMessage(BuildHAActionMessage(GreenLightUnitCode, HA_ACTION_ON))
        GreenLightsOn = True
        HASendActionMessage(BuildHAActionMessage(PowerSupplyUnitCode, HA_ACTION_ON))
        PowerSupplyOn = True

    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)

        Try
            ' The OnDeviceChange routine processes WM_DEVICECHANGE messages.
            ' '' ''If m.Msg = Striker2API.Usb.WM_DEVICECHANGE Then
            ' '' ''    usbToys.OnDeviceChange(m)
            ' '' ''End If

            '   Let the base form process the message.
            MyBase.WndProc(m)

        Catch ex As Exception
            Console.WriteLine("Exception: " + ex.ToString())
        End Try


    End Sub



    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        ' '' ''usbToys.Close()

        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents RichTextBox_Traffic As System.Windows.Forms.RichTextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TimerUsbToys As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_main))
        Me.RichTextBox_Traffic = New System.Windows.Forms.RichTextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerUsbToys = New System.Windows.Forms.Timer(Me.components)
        Me.btnToggleRedLights = New System.Windows.Forms.Button
        Me.btnToggleBlueLights = New System.Windows.Forms.Button
        Me.btnToggleGreenLights = New System.Windows.Forms.Button
        Me.btnTogglePowerSupply = New System.Windows.Forms.Button
        Me.tmrMove = New System.Windows.Forms.Timer(Me.components)
        Me.lblUsbStatus = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'RichTextBox_Traffic
        '
        Me.RichTextBox_Traffic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RichTextBox_Traffic.Location = New System.Drawing.Point(8, 183)
        Me.RichTextBox_Traffic.Name = "RichTextBox_Traffic"
        Me.RichTextBox_Traffic.Size = New System.Drawing.Size(944, 265)
        Me.RichTextBox_Traffic.TabIndex = 0
        Me.RichTextBox_Traffic.Text = "RichTextBox_Traffic"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 30000
        '
        'TimerUsbToys
        '
        Me.TimerUsbToys.Interval = 2000
        '
        'btnToggleRedLights
        '
        Me.btnToggleRedLights.Location = New System.Drawing.Point(8, 33)
        Me.btnToggleRedLights.Name = "btnToggleRedLights"
        Me.btnToggleRedLights.Size = New System.Drawing.Size(136, 27)
        Me.btnToggleRedLights.TabIndex = 2
        Me.btnToggleRedLights.Text = "Toggle Red Lights"
        Me.btnToggleRedLights.UseVisualStyleBackColor = True
        '
        'btnToggleBlueLights
        '
        Me.btnToggleBlueLights.Location = New System.Drawing.Point(8, 66)
        Me.btnToggleBlueLights.Name = "btnToggleBlueLights"
        Me.btnToggleBlueLights.Size = New System.Drawing.Size(136, 27)
        Me.btnToggleBlueLights.TabIndex = 3
        Me.btnToggleBlueLights.Text = "Toggle Blue Lights"
        Me.btnToggleBlueLights.UseVisualStyleBackColor = True
        '
        'btnToggleGreenLights
        '
        Me.btnToggleGreenLights.Location = New System.Drawing.Point(8, 99)
        Me.btnToggleGreenLights.Name = "btnToggleGreenLights"
        Me.btnToggleGreenLights.Size = New System.Drawing.Size(136, 27)
        Me.btnToggleGreenLights.TabIndex = 4
        Me.btnToggleGreenLights.Text = "Toggle Green Lights"
        Me.btnToggleGreenLights.UseVisualStyleBackColor = True
        '
        'btnTogglePowerSupply
        '
        Me.btnTogglePowerSupply.Location = New System.Drawing.Point(8, 132)
        Me.btnTogglePowerSupply.Name = "btnTogglePowerSupply"
        Me.btnTogglePowerSupply.Size = New System.Drawing.Size(136, 27)
        Me.btnTogglePowerSupply.TabIndex = 5
        Me.btnTogglePowerSupply.Text = "Toggle Power Supply"
        Me.btnTogglePowerSupply.UseVisualStyleBackColor = True
        '
        'tmrMove
        '
        Me.tmrMove.Enabled = True
        Me.tmrMove.Interval = 500
        '
        'lblUsbStatus
        '
        Me.lblUsbStatus.Location = New System.Drawing.Point(5, 9)
        Me.lblUsbStatus.Name = "lblUsbStatus"
        Me.lblUsbStatus.Size = New System.Drawing.Size(215, 23)
        Me.lblUsbStatus.TabIndex = 1
        Me.lblUsbStatus.Text = "lblUsbStatus"
        '
        'form_main
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(960, 454)
        Me.Controls.Add(Me.btnTogglePowerSupply)
        Me.Controls.Add(Me.btnToggleGreenLights)
        Me.Controls.Add(Me.btnToggleBlueLights)
        Me.Controls.Add(Me.btnToggleRedLights)
        Me.Controls.Add(Me.lblUsbStatus)
        Me.Controls.Add(Me.RichTextBox_Traffic)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "form_main"
        Me.Text = "Door Controller"
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub form_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next

        UDPcommSys_ = New StaXCommsLib.StaxCommunications
        UDPcommSys_.ReceivePort = GetSetting(Application.ProductName, "Settings", "ReceivePort", "")
        UDPcommSys_.SendPort = GetSetting(Application.ProductName, "Settings", "SendPort", "")
        UDPcommSys_.ReceiveIP = System.Net.IPAddress.Parse(GetSetting(Application.ProductName, "Settings", "ReceiveIp", ""))
        UDPcommSys_.SendIP = System.Net.IPAddress.Parse(GetSetting(Application.ProductName, "Settings", "SendIp", ""))
        UDPcommSys_.StartListening()

        Me.RichTextBox_Traffic.Clear()

        CreateSystemTrayIconAndMenu()

        InitAppStateXMLdoc()

        SaveSetting(Application.ProductName, "Settings", "ParticipantID", ParticipantID_)

        Me.ShowInTaskbar = False
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False

        TimerUsbToys.Enabled = True

    End Sub

    Private Sub CreateSystemTrayIconAndMenu()

        Me.components = New System.ComponentModel.Container
        Me.SystemTrayContextMenu_ = New System.Windows.Forms.ContextMenu
        Me.MenuItemAbout_ = New System.Windows.Forms.MenuItem
        Me.MenuItemConfig_ = New System.Windows.Forms.MenuItem
        Me.MenuItemExit_ = New System.Windows.Forms.MenuItem
        Me.MenuItemOpen_ = New System.Windows.Forms.MenuItem

        'Initialize main menu items
        Me.SystemTrayContextMenu_.MenuItems.Add(MenuItemOpen_)
        Me.MenuItemOpen_.Text = "&Show Message Traffic"

        Me.SystemTrayContextMenu_.MenuItems.Add(MenuItemConfig_)
        Me.MenuItemConfig_.Text = "&Configure"

        Me.SystemTrayContextMenu_.MenuItems.Add("-")

        Me.SystemTrayContextMenu_.MenuItems.Add(MenuItemExit_)
        Me.MenuItemExit_.Text = "E&xit"

        Me.SystemTrayContextMenu_.MenuItems.Add(MenuItemAbout_)
        Me.MenuItemAbout_.Text = "A&bout"

        'Create icon
        Me.SystemTrayIcon_ = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SystemTrayIcon_.Icon = New Icon(Me.Icon, Me.Icon.Size)


        'assign Menu to Icon
        Me.SystemTrayIcon_.ContextMenu = Me.SystemTrayContextMenu_

        'make icon visible in tray
        Me.SystemTrayIcon_.Text = Application.ProductName
        Me.SystemTrayIcon_.Visible = True

    End Sub

    Private Sub InitAppStateXMLdoc()

        'create the beginning part of the AppStateXMLdoc
        Dim myStringBuilder As New System.Text.StringBuilder
        Dim myOutStream As New IO.StringWriter(myStringBuilder)
        Dim myXMLwriter As New Xml.XmlTextWriter(myOutStream)

        Dim xmlRoot As Xml.XmlElement = AppStateXMLdoc_.CreateElement("Message")
        Dim xmlPropertyReport As Xml.XmlElement = AppStateXMLdoc_.CreateElement("PropertyReport")

        Me.AppStateXMLdocMsgID_ = Me.AppStateXMLdoc_.CreateAttribute("TxID")
        Me.AppStateXMLdocPartID_ = Me.AppStateXMLdoc_.CreateAttribute("ParticipantID")

        xmlPropertyReport.SetAttribute("Name", "ApplicationState")
        xmlRoot.AppendChild(xmlPropertyReport)

        xmlRoot.Attributes.Append(Me.AppStateXMLdocMsgID_)
        xmlRoot.Attributes.Append(Me.AppStateXMLdocPartID_)

        ' '' ''AccountingOnElem_ = Me.AppStateXMLdoc_.CreateElement("Property")
        ' '' ''AccountingOnElem_.SetAttribute("DisplayName", "Accounting On")
        ' '' ''AccountingOnElem_.SetAttribute("ID", "100")
        ' '' ''AccountingOnElem_.SetAttribute("Value", MissileAccountingOn.ToString())
        ' '' ''xmlPropertyReport.AppendChild(AccountingOnElem_)

        ' '' ''MissilesRemainingElem_ = Me.AppStateXMLdoc_.CreateElement("Property")
        ' '' ''MissilesRemainingElem_.SetAttribute("DisplayName", "Missiles Remaining")
        ' '' ''MissilesRemainingElem_.SetAttribute("ID", "200")
        ' '' ''MissilesRemainingElem_.SetAttribute("Value", MissilesRemaining.ToString())
        ' '' ''xmlPropertyReport.AppendChild(MissilesRemainingElem_)

        'Private AvailableSongsXMLDocPropGrp As Xml.XmlElement
        AvailableSongsXMLDocPropGrp = Me.AppStateXMLdoc_.CreateElement("PropertyGrp")
        AvailableSongsXMLDocPropGrp.SetAttribute("DisplayName", "Available Songs")
        AvailableSongsXMLDocPropGrp.SetAttribute("ID", "100")
        xmlPropertyReport.AppendChild(AvailableSongsXMLDocPropGrp)


        'Private CurrentPlaylistXMLDocPropGrp As Xml.XmlElement
        CurrentPlaylistXMLDocPropGrp = Me.AppStateXMLdoc_.CreateElement("PropertyGrp")
        CurrentPlaylistXMLDocPropGrp.SetAttribute("DisplayName", "Current Song Playlist")
        CurrentPlaylistXMLDocPropGrp.SetAttribute("ID", "101")
        xmlPropertyReport.AppendChild(CurrentPlaylistXMLDocPropGrp)

        'Private DoorStatusXMLDocProp As Xml.XmlElement
        DoorStatusXMLDocProp = Me.AppStateXMLdoc_.CreateElement("PropertyGrp")
        DoorStatusXMLDocProp.SetAttribute("DisplayName", "Door Status")
        DoorStatusXMLDocProp.SetAttribute("ID", "102")
        xmlPropertyReport.AppendChild(DoorStatusXMLDocProp)

        'Private RedLightOnXMLDocProp As Xml.XmlElement
        RedLightOnXMLDocProp = Me.AppStateXMLdoc_.CreateElement("Property")
        RedLightOnXMLDocProp.SetAttribute("DisplayName", "Red Lights On")
        RedLightOnXMLDocProp.SetAttribute("ID", "103")
        RedLightOnXMLDocProp.SetAttribute("Value", Convert.ToString(RedLightsOn))
        xmlPropertyReport.AppendChild(RedLightOnXMLDocProp)

        'Private GreenLightOnXMLDocProp As Xml.XmlElement
        GreenLightOnXMLDocProp = Me.AppStateXMLdoc_.CreateElement("Property")
        GreenLightOnXMLDocProp.SetAttribute("DisplayName", "Green Lights On")
        GreenLightOnXMLDocProp.SetAttribute("ID", "104")
        GreenLightOnXMLDocProp.SetAttribute("Value", Convert.ToString(GreenLightsOn))
        xmlPropertyReport.AppendChild(GreenLightOnXMLDocProp)

        'Private BlueLightOnXMLDocProp As Xml.XmlElement
        BlueLightOnXMLDocProp = Me.AppStateXMLdoc_.CreateElement("Property")
        BlueLightOnXMLDocProp.SetAttribute("DisplayName", "Blue Lights On")
        BlueLightOnXMLDocProp.SetAttribute("ID", "105")
        BlueLightOnXMLDocProp.SetAttribute("Value", Convert.ToString(BlueLightsOn))
        xmlPropertyReport.AppendChild(BlueLightOnXMLDocProp)

        'Private PowerSupplyOnXMLDocProp As Xml.XmlElement
        PowerSupplyOnXMLDocProp = Me.AppStateXMLdoc_.CreateElement("Property")
        PowerSupplyOnXMLDocProp.SetAttribute("DisplayName", "Power Supply On")
        PowerSupplyOnXMLDocProp.SetAttribute("ID", "106")
        PowerSupplyOnXMLDocProp.SetAttribute("Value", Convert.ToString(PowerSupplyOn))
        xmlPropertyReport.AppendChild(PowerSupplyOnXMLDocProp)

        '   create position group
        PositionGrpElement_ = AppStateXMLdoc_.CreateElement(PositionElementText)
        PositionGrpElement_.SetAttribute("Altitude_in_Meters", "0")
        PositionGrpElement_.SetAttribute("Orientation_in_DecimalDeg", "0")
        LatLonDDGrpElement_ = AppStateXMLdoc_.CreateElement("LatLonDD")
        PositionGrpElement_.AppendChild(LatLonDDGrpElement_)

        LatitudeElement_ = AppStateXMLdoc_.CreateElement("LatDD")
        LongitudeElement_ = AppStateXMLdoc_.CreateElement("LonDD")
        LatLonDDGrpElement_.AppendChild(LatitudeElement_)
        LatLonDDGrpElement_.AppendChild(LongitudeElement_)

        xmlPropertyReport.AppendChild(PositionGrpElement_)

        AppStateXMLdoc_.InsertBefore(xmlRoot, Nothing)

    End Sub

    Private Sub UDPcommSys__MessageReceived(ByVal SenderIP As System.Net.IPAddress, ByVal SenderPort As Integer, ByVal Message As String) Handles UDPcommSys_.MessageReceived

        Dim myFrom As String
        myFrom = SenderIP.ToString + " " + SenderPort.ToString

        Dim myUpdateTrafficWindow As New UpdateTrafficWindow(AddressOf UpdateRichTextBox_Traffic)
        Me.RichTextBox_Traffic.Invoke(myUpdateTrafficWindow, New Object() {myFrom, Message})

        Dim myProcessMessage As New ProcessMessage(AddressOf ProcessMessageIn)
        myProcessMessage.Invoke(SenderIP, SenderPort, Message)

    End Sub


    Private Sub UpdateRichTextBox_Traffic(ByVal From_in As String, ByVal Message_in As String)

        Me.RichTextBox_Traffic.AppendText(From_in + ": Length(" + Message_in.Length.ToString + "):" + Message_in + Microsoft.VisualBasic.Constants.vbCrLf)
        Me.RichTextBox_Traffic.ScrollToCaret()

    End Sub

    Private Sub ProcessMessageIn(ByVal RequestorIP As System.Net.IPAddress, ByVal RequestorPort As Integer, ByVal message_in As String)
        '   This routine determines what type of xml message was received and processes it accordingly
        Try

            Dim myIOstream As New System.IO.StringReader(message_in)
            Dim doc As New Xml.XmlDocument
            Dim myParentNode As Xml.XmlNode = doc.ReadNode(New Xml.XmlTextReader(myIOstream))
            Dim myParentAttributes As Xml.XmlAttributeCollection = myParentNode.Attributes
            Dim myNode As Xml.XmlNode
            'Dim myAttributes As Xml.XmlAttributeCollection
            Dim myMessageID As String
            Dim myUpdateTrafficWindow As New UpdateTrafficWindow(AddressOf UpdateRichTextBox_Traffic)

            '   determine message type

            Select Case myParentNode.Name
                Case MessageMsgType
                    Dim myParticipantID As String = myParentAttributes.GetNamedItem("ParticipantID").Value

                    'If (AllowAnyID_) Then ParticipantID_ = myParticipantID

                    If (String.Compare(myParticipantID, ParticipantID_, True) = 0) Then 'this is a message for me.
                        'save off message id so it can be sent back
                        myMessageID = myParentAttributes.GetNamedItem("TxID").Value

                        If (myParentNode.HasChildNodes) Then

                            For Each myNode In myParentNode.ChildNodes
                                Dim mySendResultForThisCommand As Boolean = True
                                Dim myCommandResultDescription As String = ""
                                Dim myResponseMsg As String = ""
                                Dim myCommandStatus As String = ""

                                '   Is this a "Command"?
                                If (String.Compare(myNode.Name, "Command", True) = 0) Then

                                    ProcessCommand(RequestorIP, RequestorPort, myNode, myCommandStatus, myCommandResultDescription, mySendResultForThisCommand)

                                    '   If a Command Result message is appropriate then send one
                                    If (mySendResultForThisCommand) Then
                                        myResponseMsg = GenerateXMLcmdResponseMsg(myParticipantID, myMessageID, myCommandResultDescription, myNode.Attributes(0).InnerText, myCommandStatus)
                                        UDPcommSys_.SendMessage(RequestorIP, RequestorPort, myResponseMsg)
                                    End If

                                    Me.RichTextBox_Traffic.Invoke(myUpdateTrafficWindow, New Object() {"Outgoing Message", myResponseMsg})

                                    '   Automatically send out a status message after processing a command
                                    If mySendResultForThisCommand Then
                                        SendApplicationStateMessage(RequestorIP, RequestorPort)
                                    End If
                                End If
                            Next    '   myNode in child nodes
                        End If  '   has child nodes
                    End If  '   participant ID match

                Case RequestForInterfaceMsgType
                    '   Send the xml back that specifies this application's interface
                    Me.RichTextBox_Traffic.Invoke(myUpdateTrafficWindow, New Object() {"Outgoing Message", XmlInterface_})
                    UDPcommSys_.SendMessage(RequestorIP, RequestorPort, XmlInterface_)

            End Select

        Catch ex As Exception
            Dim myUpdateTrafficWindow As New UpdateTrafficWindow(AddressOf UpdateRichTextBox_Traffic)
            UDPcommSys_.SendMessage(RequestorIP, RequestorPort, "Internal Failure")
            Me.RichTextBox_Traffic.Invoke(myUpdateTrafficWindow, New Object() {"Outgoing Message", "Internal Failure: " + ex.ToString})
        End Try

    End Sub

    Private Function GenerateXMLApplicationStateMessage() As String
        '   This function updates the saved XML Document object that contains a State message
        '   and returns the XML string that it generates

        Dim myStringBuilder As New System.Text.StringBuilder
        Dim myOutStream As New IO.StringWriter(myStringBuilder)
        Dim myXMLwriter As New Xml.XmlTextWriter(myOutStream)


        '   Update the light status
        RedLightOnXMLDocProp.InnerText = Convert.ToString(RedLightsOn)
        GreenLightOnXMLDocProp.InnerText = Convert.ToString(GreenLightsOn)
        BlueLightOnXMLDocProp.InnerText = Convert.ToString(BlueLightsOn)
        PowerSupplyOnXMLDocProp.InnerText = Convert.ToString(PowerSupplyOn)


        '   Update the Transmission ID
        Me.AppStateXMLdocMsgID_.InnerText = Me.TxID_.ToString
        '   Update the Participant ID field (This application can respond to several IDs)
        Me.AppStateXMLdocPartID_.InnerText = ParticipantID_


        'update local TxID
        If (TxID_ >= Integer.MaxValue) Then TxID_ = -1
        TxID_ += 1

        '   Update the location
        LatitudeElement_.SetAttribute("Value", LatitudeDD_)
        LongitudeElement_.SetAttribute("Value", LongitudeDD_)

        '   Update Missile Accounting
        ' '' ''AccountingOnElem_.SetAttribute("Value", MissileAccountingOn.ToString())
        ' '' ''MissilesRemainingElem_.SetAttribute("Value", MissilesRemaining.ToString())

        Me.AppStateXMLdoc_.WriteTo(myXMLwriter)
        GenerateXMLApplicationStateMessage = myStringBuilder.ToString

    End Function

    Private Function GenerateXMLcmdResponseMsg(ByVal ParticipantID_in As String, ByVal MessageID_in As String, ByVal Message_in As String, ByVal CmdName_in As String, ByVal CmdResult As String) As String
        '   This function creates the XML message text for a Command Result message
        '   The Command Result message tell Starship II if the command was successful or not
        '   This is not required for State/Status messages
        Dim retval As String = ""
        Dim myXMLdoc As New Xml.XmlDocument
        Dim myStringBuilder As New System.Text.StringBuilder
        Dim myOutStream As New IO.StringWriter(myStringBuilder)
        Dim myXMLwriter As New Xml.XmlTextWriter(myOutStream)

        Dim xmlRoot As Xml.XmlElement = myXMLdoc.CreateElement("Message")
        Dim xmlResult As Xml.XmlElement = myXMLdoc.CreateElement("CommandResult")

        xmlRoot.SetAttribute("ParticipantID", ParticipantID_in)
        xmlRoot.SetAttribute("TxID", MessageID_in)

        xmlResult.SetAttribute("Name", CmdName_in)
        xmlResult.SetAttribute("Description", Message_in)
        xmlResult.SetAttribute("ResultStatus", CmdResult)

        myXMLdoc.InsertBefore(xmlRoot, Nothing)

        xmlRoot.AppendChild(xmlResult)

        myXMLdoc.WriteTo(myXMLwriter)
        retval = myStringBuilder.ToString

        GenerateXMLcmdResponseMsg = retval

    End Function



    Private Function ProcessStatusCommand(ByVal RequestorIP As System.Net.IPAddress, ByVal RequestorPort As Integer, ByRef Status_in As String) As String

        Dim retval As String

        Me.SendApplicationStateMessage(RequestorIP, RequestorPort)
        retval = "Get Status command processed"
        Status_in = SUCCESSFUL_

        ProcessStatusCommand = retval

    End Function


    Private Sub ProcessCommand(ByVal RequestorIP As System.Net.IPAddress, ByVal RequestorPort As Integer, ByVal Node_in As Xml.XmlNode, ByRef CommandStatus As String, ByRef CommandStatusExplaination As String, ByRef SendResponseForThisCommand As Boolean)


        CommandStatus = FAILED_
        CommandStatusExplaination = "Failed: Invalid Node Syntax"
        Dim CommandName As String

        SendResponseForThisCommand = False

        Try

            '   Get the value of the Name attribute
            CommandName = Node_in.Attributes.GetNamedItem("Name").Value

            'process the GetState command
            Select Case CommandName
                Case "Status"
                    CommandStatusExplaination = ProcessStatusCommand(RequestorIP, RequestorPort, CommandStatus)
                    SendResponseForThisCommand = False

                Case "Get The 411"
                    CommandStatusExplaination = ProcessStatusCommand(RequestorIP, RequestorPort, CommandStatus)
                    SendResponseForThisCommand = False

                Case "Red Lights On"
                    SendResponseForThisCommand = True
                    If RedLightsOn Then
                        '   TODO: Send Error Message
                        CommandStatusExplaination = "Already in this state"
                    Else
                        InvokeHASendCommand(BuildHAActionMessage(RedLightUnitCode, HA_ACTION_ON))
                        RedLightsOn = True
                        CommandStatus = SUCCESSFUL_
                    End If

                Case "Red Lights Off"
                    SendResponseForThisCommand = True
                    If RedLightsOn Then
                        InvokeHASendCommand(BuildHAActionMessage(RedLightUnitCode, HA_ACTION_OFF))
                        RedLightsOn = False
                        CommandStatus = SUCCESSFUL_
                    Else
                        CommandStatusExplaination = "Already in this state"
                    End If

                Case "Green Lights On"
                    SendResponseForThisCommand = True
                    If GreenLightsOn Then
                        CommandStatusExplaination = "Already in this state"
                    Else
                        InvokeHASendCommand(BuildHAActionMessage(GreenLightUnitCode, HA_ACTION_ON))
                        GreenLightsOn = True
                        CommandStatus = SUCCESSFUL_
                    End If

                Case "Green Lights Off"
                    SendResponseForThisCommand = True
                    If GreenLightsOn Then
                        InvokeHASendCommand(BuildHAActionMessage(GreenLightUnitCode, HA_ACTION_OFF))
                        GreenLightsOn = False
                        CommandStatus = SUCCESSFUL_
                    Else
                        CommandStatusExplaination = "Already in this state"
                    End If

                Case "Blue Lights On"
                    SendResponseForThisCommand = True
                    If BlueLightsOn Then
                        CommandStatusExplaination = "Already in this state"
                    Else
                        InvokeHASendCommand(BuildHAActionMessage(BlueLightUnitCode, HA_ACTION_ON))
                        BlueLightsOn = True
                        CommandStatus = SUCCESSFUL_
                    End If

                Case "Blue Lights Off"
                    SendResponseForThisCommand = True
                    If BlueLightsOn Then
                        InvokeHASendCommand(BuildHAActionMessage(BlueLightUnitCode, HA_ACTION_OFF))
                        BlueLightsOn = False
                        CommandStatus = SUCCESSFUL_
                    Else
                        CommandStatusExplaination = "Already in this state"
                    End If

                Case "Power Supply On"
                    SendResponseForThisCommand = True
                    If PowerSupplyOn Then
                        CommandStatusExplaination = "Already in this state"
                    Else
                        InvokeHASendCommand(BuildHAActionMessage(PowerSupplyUnitCode, HA_ACTION_ON))
                        PowerSupplyOn = True
                        CommandStatus = SUCCESSFUL_
                    End If

                Case "Power Supply Off"
                    SendResponseForThisCommand = True
                    If PowerSupplyOn Then
                        InvokeHASendCommand(BuildHAActionMessage(PowerSupplyUnitCode, HA_ACTION_OFF))
                        PowerSupplyOn = False
                        CommandStatus = SUCCESSFUL_
                    Else
                        CommandStatusExplaination = "Already in this state"
                    End If


                Case "Set Location"
                    SendResponseForThisCommand = True

                    Try
                        Dim childNode As Xml.XmlNode
                        Dim attribName As Xml.XmlAttribute
                        Dim attribValue As Xml.XmlAttribute
                        For Each childNode In Node_in.ChildNodes
                            attribName = childNode.Attributes.GetNamedItem("Name")
                            If attribName.InnerText = "Latitude" Then
                                attribValue = childNode.Attributes.GetNamedItem("Value")
                                LatitudeDD_ = attribValue.InnerText
                            ElseIf attribName.InnerText = "Longitude" Then
                                attribValue = childNode.Attributes.GetNamedItem("Value")
                                LongitudeDD_ = attribValue.InnerText
                            End If
                        Next childNode
                        CommandStatus = SUCCESSFUL_
                        CommandStatusExplaination = "Location was set"

                    Catch ex As Exception
                        If ex.Message.Contains("""") Then
                            CommandStatus = FAILED_
                            CommandStatusExplaination = "Location was not set"
                        Else
                            CommandStatus = FAILED_
                            CommandStatusExplaination = ex.Message
                        End If
                    End Try

            End Select


        Catch ex As Exception

        End Try

    End Sub

    Private Function BuildHAActionMessage(ByVal UnitCode As String, ByVal Action As String) As String
        Return String.Format("{0}{1} {2}", HAHouseCode, UnitCode, Action)

    End Function

    Private Sub InvokeHASendCommand(ByVal Message As String)
        Dim myDelegate As New HASendActionMessageDelegate(AddressOf HASendActionMessage)
        Invoke(myDelegate, New Object() {Message})

    End Sub

    Private Sub HASendActionMessage(ByVal Message As String)
        MyActiveHome.SendAction(HA_SEND_RF, Message)
        MyActiveHome.SendAction(HA_SEND_PLC, Message)

    End Sub


    Private Sub InvokeMove(ByVal MoveDirection As String)
        Dim myMoveDelegate As New MoveThisDirectionDelegate(AddressOf MoveLauncherThisDirection)
        Invoke(myMoveDelegate, New Object() {MoveDirection})

    End Sub
    Private Sub MoveLauncherThisDirection(ByVal MoveDirection As String)

        Select Case MoveDirection
            Case UP_
                ' '' ''usbToys.MoveUpKeyDown()
            Case DOWN_
                ' '' ''usbToys.MoveDownKeyDown()
            Case RIGHT_
                ' '' ''usbToys.MoveRightKeyDown()
            Case LEFT_
                ' '' ''usbToys.MoveLeftKeyDown()
        End Select
        tmrMove.Enabled = True
    End Sub
    Private Sub ToggleBlueLights(ByRef CommandStatus As String, ByRef CommandStatusExplaination As String, ByRef SendResponseForThisCommand As Boolean)
        SendResponseForThisCommand = True

        If MissileAccountingOn Then
            If MissilesRemaining > 0 Then
                MissilesRemaining -= 1
                ' '' ''usbToys.ToggleBlueLights()
                CommandStatus = SUCCESSFUL_
                CommandStatusExplaination = "Missile Fired"
            Else
                CommandStatus = FAILED_
                CommandStatusExplaination = "No missiles remain.  Must reload."
            End If
        Else
            ' '' ''usbToys.ToggleBlueLights()
            CommandStatus = SUCCESSFUL_
            CommandStatusExplaination = "Missile Fired"
        End If

    End Sub

    Private Sub form_Main_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If (MenuClosing_) Then
            UDPcommSys_.StopListening()
        Else
            e.Cancel() = True
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
        End If

    End Sub

    Private Sub SendApplicationStateMessage(ByVal RequestorIP As System.Net.IPAddress, ByVal RequestorPort As Integer)

        Dim XMLmessage As String = GenerateXMLApplicationStateMessage()
        Dim myUpdateTrafficWindow As New UpdateTrafficWindow(AddressOf UpdateRichTextBox_Traffic)

        Me.UDPcommSys_.SendMessage(RequestorIP, RequestorPort, XMLmessage)
        Me.RichTextBox_Traffic.Invoke(myUpdateTrafficWindow, New Object() {"Outgoing Message", XMLmessage})

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub MenuItemConfig__Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemConfig_.Click
        Dim myConfig As New form_Config
        myConfig.Show()
        myConfig.InitializeForm(Me.UDPcommSys_)
    End Sub

    Private Sub MenuItemOpen__Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemOpen_.Click
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SystemTrayIcon__DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SystemTrayIcon_.DoubleClick
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub MenuItemExit__Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemExit_.Click
        MenuClosing_ = True
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '''''UDPcommSys_.SendMessage(System.Net.IPAddress.Parse("192.168.10.255"), StarshipPortNumber, XmlAnnouncementMessage_)
        '   adjust the announcement message to use the currently selected participant ID
        Dim myDoc As New Xml.XmlDocument
        Dim myElem As Xml.XmlElement

        myDoc.LoadXml(XmlAnnouncementMessage_)
        Dim myNodeList As Xml.XmlNodeList = myDoc.GetElementsByTagName("InstanceName")
        If myNodeList.Count > 0 Then
            myElem = myNodeList.Item(0)
            myElem.InnerText = ParticipantID_
        End If
        myNodeList = myDoc.GetElementsByTagName("InterfaceVersion")
        If myNodeList.Count > 0 Then
            myElem = myNodeList.Item(0)
            myElem.InnerText = InterfaceVersion
        End If
        UDPcommSys_.SendMessage(UDPcommSys_.SendIP, StarshipPortNumber, myDoc.InnerXml)
    End Sub

    Private Sub UDPcommSys__CommandReceived(ByVal SenderIP As System.Net.IPAddress, ByVal SenderPort As Integer, ByVal Message As String) Handles UDPcommSys_.CommandReceived

    End Sub

    Private Sub TimerUsbToys_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerUsbToys.Tick
        ' '' ''If usbToys.bStarted = True Then
        ' '' ''    Dim conn As Boolean = usbToys.isUSBConnected()

        ' '' ''    If conn = True Then
        ' '' ''        Dim nLaunchers As Integer = usbToys.toys.Count / 2
        ' '' ''        lblUsbStatus.Text = nLaunchers.ToString() + " launcher(s) " + CONNECTED_
        ' '' ''    End If
        ' '' ''Else
        ' '' ''    lblUsbStatus.Text = NOT_CONNECTED_
        ' '' ''End If

    End Sub

    Private Sub RichTextBox_Traffic_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox_Traffic.TextChanged

    End Sub

    Private Sub btnToggleRedLights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleRedLights.Click
        If RedLightsOn Then
            HASendActionMessage(BuildHAActionMessage(RedLightUnitCode, HA_ACTION_OFF))
            RedLightsOn = False
        Else
            HASendActionMessage(BuildHAActionMessage(RedLightUnitCode, HA_ACTION_ON))
            RedLightsOn = True
        End If

    End Sub


    Private Sub btnToggleBlueLights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleBlueLights.Click
        If RedLightsOn Then
            HASendActionMessage(BuildHAActionMessage(BlueLightUnitCode, HA_ACTION_OFF))
            RedLightsOn = False
        Else
            HASendActionMessage(BuildHAActionMessage(BlueLightUnitCode, HA_ACTION_ON))
            RedLightsOn = True
        End If
    End Sub

    Private Sub btnTogglePowerSupply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTogglePowerSupply.Click
        If PowerSupplyOn Then
            HASendActionMessage(BuildHAActionMessage(PowerSupplyUnitCode, HA_ACTION_OFF))
            PowerSupplyOn = False
        Else
            HASendActionMessage(BuildHAActionMessage(PowerSupplyUnitCode, HA_ACTION_ON))
            PowerSupplyOn = True
        End If
    End Sub

    Private Sub tmrMove_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMove.Tick
        ' '' ''usbToys.MoveDownKeyUp()
        tmrMove.Enabled = False

    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InvokeMove(UP_)
    End Sub

    Private Sub btnLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InvokeMove(RIGHT_)
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InvokeMove(DOWN_)
    End Sub

    Private Sub btnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InvokeMove(LEFT_)
    End Sub

    Private Sub btnToggleGreenLights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleGreenLights.Click '
        If GreenLightsOn Then
            HASendActionMessage(BuildHAActionMessage(GreenLightUnitCode, HA_ACTION_OFF))
            GreenLightsOn = False
        Else
            HASendActionMessage(BuildHAActionMessage(GreenLightUnitCode, HA_ACTION_ON))
            GreenLightsOn = True
        End If
    End Sub

    Private Sub ToggleGreenLights()
        MissilesRemaining = MAX_MISSILES_

    End Sub

    Private Sub MyActiveHome_RecvAction(ByVal bszAction As Object, ByVal bszParm1 As Object, ByVal bszParm2 As Object, ByVal bszParm3 As Object, ByVal bszParm4 As Object, ByVal bszParm5 As Object, ByVal bszReserved As Object) Handles MyActiveHome.RecvAction
        Dim myUpdateTrafficWindow As New UpdateTrafficWindow(AddressOf UpdateRichTextBox_Traffic)
        Dim msg As String
        msg = bszAction
        If bszParm2 = "c10" Then
            If bszParm3 = HA_ACTION_ON Then
                '   sound the alarm
            Else
                '   turn off the alarm
            End If
        End If
        If bszParm1 <> "" Then
            msg = msg & ", " & bszParm1
        End If
        If bszParm2 <> "" Then
            msg = msg & ", " & bszParm2
        End If
        If bszParm3 <> "" Then
            msg = msg & ", " & bszParm3
        End If
        If bszParm4 <> "" Then
            msg = msg & ", " & bszParm4
        End If
        Me.RichTextBox_Traffic.Invoke(myUpdateTrafficWindow, New Object() {"Incoming Message", msg})
    End Sub
End Class
