Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class StaxCommunications

    Public Event MessageReceived(ByVal SenderIP As IPAddress, ByVal SenderPort As Integer, ByVal Message As String)
    Public Event CommandReceived(ByVal SenderIP As IPAddress, ByVal SenderPort As Integer, ByVal Message As String)

    Private Const StaxMessageMsgType As String = "Message"
    Private Const StaxRequestForInterfaceMsgType As String = "RequestForInterfaceDefinition"
    Private Const StaxAckMsgType As String = "Ack"

    Private RcvPortNum As Integer = 9399
    Private RcvIpAddress As IPAddress = IPAddress.Broadcast
    Private SendPortNum As Integer = 1396
    Private SendIpAddress As IPAddress = IPAddress.Broadcast
    Private Listener As UdpClient
    Private Listening As Boolean = False
    Private RcvThread As Threading.Thread

    Delegate Sub ProcessDataInDelegate(ByVal Sender As System.Net.IPAddress, ByVal Port As Integer, ByVal Message As String)

    Public Property ReceivePort() As Integer
        Get
            ReceivePort = RcvPortNum
        End Get
        Set(ByVal Port_in As Integer)
            If (RcvPortNum = Port_in) Then
            Else
                RcvPortNum = Port_in
                StopListening()
                StartListening()
            End If
        End Set
    End Property

    Public Property ReceiveIP() As IPAddress
        Get
            ReceiveIP = RcvIpAddress
        End Get
        Set(ByVal IP_in As IPAddress)
            If (RcvIpAddress.Equals(IP_in)) Then
            Else
                RcvIpAddress = IP_in
                StopListening()
                StartListening()
            End If
        End Set
    End Property

    Public Property SendPort() As Integer
        Get
            SendPort = SendPortNum
        End Get
        Set(ByVal Port_in As Integer)
            SendPortNum = Port_in
        End Set
    End Property

    Public Property SendIP() As IPAddress
        Get
            SendIP = SendIpAddress
        End Get
        Set(ByVal IP_in As IPAddress)
            SendIpAddress = IP_in
        End Set
    End Property

    Public Sub StartListening()
        If (Listening) Then
        Else
            Listening = True
            Listener = New UdpClient(RcvPortNum)
            RcvThread = New Threading.Thread(AddressOf Listen)
            RcvThread.Start()
        End If
    End Sub

    Public Sub StopListening()
        If (Listening) Then
            Listening = False
            Listener.Close()
            RcvThread.Join()
        End If
    End Sub

    Private Sub Listen()
        Dim myGroupEP As New IPEndPoint(RcvIpAddress, RcvPortNum)
        Dim mySenderIP As IPAddress
        Dim mySenderPort As Integer
        Dim myMessage As String
        Dim myBytesMessage As Byte()
        While Listening
            Try
                myBytesMessage = Listener.Receive(myGroupEP)
                mySenderIP = myGroupEP.Address
                mySenderPort = myGroupEP.Port
                myMessage = Encoding.ASCII.GetString(myBytesMessage)
                '   TODO:   Thread the call to ProcessDataIn
                ProcessDataIn(mySenderIP, mySenderPort, myMessage)
            Catch ex As Exception
                Console.WriteLine("Receive " + ex.ToString)
            Finally
                Listener.Close()
                'if not closing the connection intentionally then there was a real error -- create a new connection and try again
                If (Listening) Then Listener = New UdpClient(RcvPortNum)
            End Try
        End While
    End Sub

    Private Sub ProcessDataIn(ByVal Sender As System.Net.IPAddress, ByVal Port As Integer, ByVal Message As String)
        Dim myIOstream As New System.IO.StringReader(Message)
        Dim doc As New Xml.XmlDocument
        Dim myParentNode As Xml.XmlNode = doc.ReadNode(New Xml.XmlTextReader(myIOstream))
        Dim myParentAttributes As Xml.XmlAttributeCollection = myParentNode.Attributes
        Dim myNode As Xml.XmlNode
        'Dim myAttributes As Xml.XmlAttributeCollection
        Dim myMessageID As String

        '   determine message type
        Select Case myParentNode.Name
            Case StaxMessageMsgType
                Dim myParticipantID As String = myParentAttributes.GetNamedItem("ParticipantID").Value
                myMessageID = myParentAttributes.GetNamedItem("TxID").Value
                SendAckMsg(Sender, Port, myMessageID)
                If (myParentNode.HasChildNodes) Then
                    For Each myNode In myParentNode.ChildNodes
                        Dim mySendResult As Boolean = True
                        Dim myResultMsg As String = ""
                        Dim myResponseMsg As String = ""
                        Dim myStatus As String = ""
                        '   Is this a "Command"?
                        If (String.Compare(myNode.Name, "Command", True) = 0) Then
                            RaiseEvent MessageReceived(Sender, Port, Message)
                        End If
                    Next    '   myNode in child nodes
                Else    '   has child nodes
                    RaiseEvent MessageReceived(Sender, Port, Message)
                End If  '   has child nodes
            Case StaxRequestForInterfaceMsgType
                '   Send the xml back that specifies this application's interface
                RaiseEvent MessageReceived(Sender, Port, Message)
            Case StaxAckMsgType
                '   TODO:  Handle Ack Message
        End Select
    End Sub

    Public Sub SendCommandResponseMsg(ByVal ParticipantID As String, ByVal MessageID As String, ByVal ResultMsg As String, ByVal CommandName As String, ByVal myStatus As String, ByVal Sender As System.Net.IPAddress, ByVal Port As Integer, ByVal Message_in As String)
        '   This function creates the XML message text for a Command Result message
        '   The Command Result message tell Starship II if the command was successful or not
        '   This is not required for State/Status messages
        Dim myXMLdoc As New Xml.XmlDocument
        Dim myStringBuilder As New System.Text.StringBuilder
        Dim myOutStream As New IO.StringWriter(myStringBuilder)
        Dim myXMLwriter As New Xml.XmlTextWriter(myOutStream)
        Dim xmlRoot As Xml.XmlElement = myXMLdoc.CreateElement("Message")
        Dim xmlResult As Xml.XmlElement = myXMLdoc.CreateElement("CommandResult")
        xmlRoot.SetAttribute("ParticipantID", ParticipantID)
        xmlRoot.SetAttribute("TxID", MessageID)
        xmlResult.SetAttribute("Name", CommandName)
        xmlResult.SetAttribute("Description", Message_in)
        xmlResult.SetAttribute("ResultStatus", ResultMsg)
        myXMLdoc.InsertBefore(xmlRoot, Nothing)
        xmlRoot.AppendChild(xmlResult)
        myXMLdoc.WriteTo(myXMLwriter)
        SendMessage(Sender, Port, myStringBuilder.ToString)
    End Sub

    Public Sub SendAckMsg(ByVal Sender As System.Net.IPAddress, ByVal Port As Integer, ByVal MessageID As String)
    End Sub

    Public Sub SendAnnouncement()
    End Sub

    Public Property ParticipantDefinition() As String
        '   TODO:  Accept definition XML
        Get
            ParticipantDefinition = ""
        End Get
        Set(ByVal Value As String)

        End Set
    End Property

    Public Sub SendMessage(ByVal Sender As System.Net.IPAddress, ByVal Port As Integer, ByVal Message_in As String)
        Dim mySocket As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        Dim mySendBuff As Byte() = Encoding.ASCII.GetBytes(Message_in)
        Dim myGroupEP As New IPEndPoint(Sender, SendPortNum)
        Try
            mySocket.SendTo(mySendBuff, myGroupEP)
        Catch ex As Exception
            Console.WriteLine("SendMessage " + ex.ToString)
        End Try
    End Sub

    Public Sub New()

    End Sub

End Class
