Module mod_Globals
    Public ParticipantID_ As String = GetSetting(Application.ProductName, "Settings", "ParticipantID", "Launch Site 1")
    'Public AllowAnyID_ As Boolean = True

    Public Searching_ As Boolean = False

    Public Const MessageMsgType As String = "Message"
    Public Const RequestForInterfaceMsgType As String = "RequestForInterfaceDefinition"

    Public Const InterfaceDefinitionFileName As String = "DoorControllerInterfaceDefinition.xml"
    Public XmlInterface_ As String = ""
    Public XmlAnnouncementMessage_ As String = "<Announcement TxID=""1""><TypeName>Christmas Door Controller</TypeName><InterfaceVersion>0.3169.6</InterfaceVersion><InstanceName>Launch Site 1</InstanceName></Announcement>"
    Public Const StarshipPortNumber As Integer = 1396
    Public LatitudeDD_ As Double = 39.5
    Public LongitudeDD_ As Double = -76.5

End Module
