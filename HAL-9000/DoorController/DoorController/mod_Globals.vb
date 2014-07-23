Module mod_Globals
    Public ParticipantID As String = GetSetting(Application.ProductName, "Settings", "ParticipantID", "Launch Site 1")
    Public Searching As Boolean = False
    Public XmlInterface As String = ""
    Public XmlAnnouncementMessage As String = "<Announcement TxID=""1""><TypeName>Christmas Door Controller</TypeName><InterfaceVersion>0.3169.6</InterfaceVersion><InstanceName>Launch Site 1</InstanceName></Announcement>"
    Public LatitudeDD As Double = 39.5
    Public LongitudeDD As Double = -76.5

    Public Const MessageMsgType As String = "Message"
    Public Const RequestForInterfaceMsgType As String = "RequestForInterfaceDefinition"
    Public Const InterfaceDefinitionFileName As String = "DoorControllerInterfaceDefinition.xml"
    Public Const StarshipPortNumber As Integer = 1396

End Module
