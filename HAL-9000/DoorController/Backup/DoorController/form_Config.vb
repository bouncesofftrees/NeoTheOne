Public Class form_Config
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
    Friend WithEvents GroupBox_UDPsettings As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox_UDPrcvPort As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_UDPsendPort As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_UDPsendIP As System.Windows.Forms.TextBox
    Friend WithEvents Button_OK As System.Windows.Forms.Button
    Friend WithEvents Button_Apply As System.Windows.Forms.Button
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label_UDPsendIP As System.Windows.Forms.Label
    Friend WithEvents Label_UDPrcvPort As System.Windows.Forms.Label
    Friend WithEvents Label_UDPsendPort As System.Windows.Forms.Label
    Friend WithEvents TextBox_UDPrcvIP As System.Windows.Forms.TextBox
    Friend WithEvents Label_UDPrcvIP As System.Windows.Forms.Label
    Friend WithEvents GroupBox_Other As System.Windows.Forms.GroupBox
    Friend WithEvents Label_ParticipantID As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLongitudeDD As System.Windows.Forms.TextBox
    Friend WithEvents txtLatitudeDD As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_ParticipantID As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox_UDPsettings = New System.Windows.Forms.GroupBox
        Me.Label_UDPsendPort = New System.Windows.Forms.Label
        Me.Label_UDPrcvPort = New System.Windows.Forms.Label
        Me.Label_UDPrcvIP = New System.Windows.Forms.Label
        Me.Label_UDPsendIP = New System.Windows.Forms.Label
        Me.TextBox_UDPsendIP = New System.Windows.Forms.TextBox
        Me.TextBox_UDPrcvIP = New System.Windows.Forms.TextBox
        Me.TextBox_UDPsendPort = New System.Windows.Forms.TextBox
        Me.TextBox_UDPrcvPort = New System.Windows.Forms.TextBox
        Me.Button_OK = New System.Windows.Forms.Button
        Me.Button_Apply = New System.Windows.Forms.Button
        Me.Button_Cancel = New System.Windows.Forms.Button
        Me.GroupBox_Other = New System.Windows.Forms.GroupBox
        Me.TextBox_ParticipantID = New System.Windows.Forms.TextBox
        Me.Label_ParticipantID = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtLatitudeDD = New System.Windows.Forms.TextBox
        Me.txtLongitudeDD = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox_UDPsettings.SuspendLayout()
        Me.GroupBox_Other.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_UDPsettings
        '
        Me.GroupBox_UDPsettings.Controls.Add(Me.Label_UDPsendPort)
        Me.GroupBox_UDPsettings.Controls.Add(Me.Label_UDPrcvPort)
        Me.GroupBox_UDPsettings.Controls.Add(Me.Label_UDPrcvIP)
        Me.GroupBox_UDPsettings.Controls.Add(Me.Label_UDPsendIP)
        Me.GroupBox_UDPsettings.Controls.Add(Me.TextBox_UDPsendIP)
        Me.GroupBox_UDPsettings.Controls.Add(Me.TextBox_UDPrcvIP)
        Me.GroupBox_UDPsettings.Controls.Add(Me.TextBox_UDPsendPort)
        Me.GroupBox_UDPsettings.Controls.Add(Me.TextBox_UDPrcvPort)
        Me.GroupBox_UDPsettings.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_UDPsettings.Name = "GroupBox_UDPsettings"
        Me.GroupBox_UDPsettings.Size = New System.Drawing.Size(232, 184)
        Me.GroupBox_UDPsettings.TabIndex = 0
        Me.GroupBox_UDPsettings.TabStop = False
        Me.GroupBox_UDPsettings.Text = "UDP Settings"
        '
        'Label_UDPsendPort
        '
        Me.Label_UDPsendPort.Location = New System.Drawing.Point(88, 56)
        Me.Label_UDPsendPort.Name = "Label_UDPsendPort"
        Me.Label_UDPsendPort.Size = New System.Drawing.Size(56, 16)
        Me.Label_UDPsendPort.TabIndex = 7
        Me.Label_UDPsendPort.Text = "Send Port"
        '
        'Label_UDPrcvPort
        '
        Me.Label_UDPrcvPort.Location = New System.Drawing.Point(72, 136)
        Me.Label_UDPrcvPort.Name = "Label_UDPrcvPort"
        Me.Label_UDPrcvPort.Size = New System.Drawing.Size(72, 16)
        Me.Label_UDPrcvPort.TabIndex = 6
        Me.Label_UDPrcvPort.Text = "Receive Port"
        '
        'Label_UDPrcvIP
        '
        Me.Label_UDPrcvIP.Location = New System.Drawing.Point(16, 104)
        Me.Label_UDPrcvIP.Name = "Label_UDPrcvIP"
        Me.Label_UDPrcvIP.Size = New System.Drawing.Size(64, 16)
        Me.Label_UDPrcvIP.TabIndex = 5
        Me.Label_UDPrcvIP.Text = "Receive IP"
        '
        'Label_UDPsendIP
        '
        Me.Label_UDPsendIP.Location = New System.Drawing.Point(16, 24)
        Me.Label_UDPsendIP.Name = "Label_UDPsendIP"
        Me.Label_UDPsendIP.Size = New System.Drawing.Size(56, 16)
        Me.Label_UDPsendIP.TabIndex = 4
        Me.Label_UDPsendIP.Text = "Send IP"
        '
        'TextBox_UDPsendIP
        '
        Me.TextBox_UDPsendIP.Location = New System.Drawing.Point(80, 24)
        Me.TextBox_UDPsendIP.Name = "TextBox_UDPsendIP"
        Me.TextBox_UDPsendIP.Size = New System.Drawing.Size(136, 20)
        Me.TextBox_UDPsendIP.TabIndex = 3
        Me.TextBox_UDPsendIP.Text = "TextBox_SendIP"
        '
        'TextBox_UDPrcvIP
        '
        Me.TextBox_UDPrcvIP.Location = New System.Drawing.Point(80, 104)
        Me.TextBox_UDPrcvIP.Name = "TextBox_UDPrcvIP"
        Me.TextBox_UDPrcvIP.Size = New System.Drawing.Size(136, 20)
        Me.TextBox_UDPrcvIP.TabIndex = 2
        Me.TextBox_UDPrcvIP.Text = "TextBox_RcvIP"
        '
        'TextBox_UDPsendPort
        '
        Me.TextBox_UDPsendPort.Location = New System.Drawing.Point(152, 56)
        Me.TextBox_UDPsendPort.Name = "TextBox_UDPsendPort"
        Me.TextBox_UDPsendPort.Size = New System.Drawing.Size(64, 20)
        Me.TextBox_UDPsendPort.TabIndex = 1
        Me.TextBox_UDPsendPort.Text = "TextBox_UDPsendPort"
        '
        'TextBox_UDPrcvPort
        '
        Me.TextBox_UDPrcvPort.Location = New System.Drawing.Point(152, 136)
        Me.TextBox_UDPrcvPort.Name = "TextBox_UDPrcvPort"
        Me.TextBox_UDPrcvPort.Size = New System.Drawing.Size(64, 20)
        Me.TextBox_UDPrcvPort.TabIndex = 0
        Me.TextBox_UDPrcvPort.Text = "TextBox_UDPrcvPort"
        '
        'Button_OK
        '
        Me.Button_OK.Location = New System.Drawing.Point(144, 192)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(75, 23)
        Me.Button_OK.TabIndex = 1
        Me.Button_OK.Text = "OK"
        '
        'Button_Apply
        '
        Me.Button_Apply.Location = New System.Drawing.Point(224, 192)
        Me.Button_Apply.Name = "Button_Apply"
        Me.Button_Apply.Size = New System.Drawing.Size(75, 23)
        Me.Button_Apply.TabIndex = 2
        Me.Button_Apply.Text = "Apply"
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Location = New System.Drawing.Point(304, 192)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cancel.TabIndex = 3
        Me.Button_Cancel.Text = "Cancel"
        '
        'GroupBox_Other
        '
        Me.GroupBox_Other.Controls.Add(Me.TextBox_ParticipantID)
        Me.GroupBox_Other.Controls.Add(Me.Label_ParticipantID)
        Me.GroupBox_Other.Location = New System.Drawing.Point(238, 0)
        Me.GroupBox_Other.Name = "GroupBox_Other"
        Me.GroupBox_Other.Size = New System.Drawing.Size(146, 184)
        Me.GroupBox_Other.TabIndex = 4
        Me.GroupBox_Other.TabStop = False
        Me.GroupBox_Other.Text = "Other"
        '
        'TextBox_ParticipantID
        '
        Me.TextBox_ParticipantID.Location = New System.Drawing.Point(16, 40)
        Me.TextBox_ParticipantID.Name = "TextBox_ParticipantID"
        Me.TextBox_ParticipantID.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_ParticipantID.TabIndex = 1
        Me.TextBox_ParticipantID.Text = "Launch Site 1"
        '
        'Label_ParticipantID
        '
        Me.Label_ParticipantID.Location = New System.Drawing.Point(16, 24)
        Me.Label_ParticipantID.Name = "Label_ParticipantID"
        Me.Label_ParticipantID.Size = New System.Drawing.Size(100, 16)
        Me.Label_ParticipantID.TabIndex = 0
        Me.Label_ParticipantID.Text = "Participant ID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtLongitudeDD)
        Me.GroupBox1.Controls.Add(Me.txtLatitudeDD)
        Me.GroupBox1.Location = New System.Drawing.Point(390, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 183)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Location"
        '
        'txtLatitudeDD
        '
        Me.txtLatitudeDD.Location = New System.Drawing.Point(12, 36)
        Me.txtLatitudeDD.Name = "txtLatitudeDD"
        Me.txtLatitudeDD.Size = New System.Drawing.Size(127, 20)
        Me.txtLatitudeDD.TabIndex = 0
        '
        'txtLongitudeDD
        '
        Me.txtLongitudeDD.Location = New System.Drawing.Point(13, 81)
        Me.txtLongitudeDD.Name = "txtLongitudeDD"
        Me.txtLongitudeDD.Size = New System.Drawing.Size(127, 20)
        Me.txtLongitudeDD.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Latitude"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Longitude"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 58)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "The latitude and longitude should be entered as decimal degrees (eg. 39.5, 73.3)"
        '
        'form_Config
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(551, 221)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox_Other)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_Apply)
        Me.Controls.Add(Me.Button_OK)
        Me.Controls.Add(Me.GroupBox_UDPsettings)
        Me.Name = "form_Config"
        Me.Text = "Configuration"
        Me.GroupBox_UDPsettings.ResumeLayout(False)
        Me.GroupBox_UDPsettings.PerformLayout()
        Me.GroupBox_Other.ResumeLayout(False)
        Me.GroupBox_Other.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private UDPcommSys_ As StaXCommsLib.StaxCommunications

    Public Sub InitializeForm(ByRef CommSys_in As StaXCommsLib.StaxCommunications)

        UDPcommSys_ = CommSys_in
        Me.TextBox_UDPrcvPort.Text = CommSys_in.ReceivePort.ToString
        Me.TextBox_UDPrcvIP.Text = CommSys_in.ReceiveIP.ToString
        Me.TextBox_UDPsendPort.Text = CommSys_in.SendPort.ToString
        Me.TextBox_UDPsendIP.Text = CommSys_in.SendIP.ToString

        Me.TextBox_ParticipantID.Text = ParticipantID_
        'Me.CheckBox_AcceptAnyID.Checked = AllowAnyID_
        txtLatitudeDD.Text = LatitudeDD_.ToString
        txtLongitudeDD.Text = LongitudeDD_.ToString



    End Sub

    Private Sub Button_Apply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Apply.Click

        Dim SaveWasSuccessful As Boolean = True
        SaveSettings(SaveWasSuccessful)
        If SaveWasSuccessful Then
        Else
            MsgBox("Please correct the settings and try to Apply them again", MsgBoxStyle.Critical, "Correct Settings")
        End If
    End Sub

    Private Sub SaveSettings(ByRef SaveWasSuccessful As Boolean)

        SaveWasSuccessful = True

        Try
            Me.UDPcommSys_.ReceivePort = Integer.Parse(Me.TextBox_UDPrcvPort.Text)
        Catch
            MsgBox("There is a problem with the Receive Port (" & Me.TextBox_UDPrcvPort.Text & ")", MsgBoxStyle.Critical)
            SaveWasSuccessful = False
        End Try
        Try
            Me.UDPcommSys_.SendPort = Integer.Parse(Me.TextBox_UDPsendPort.Text)
        Catch
            MsgBox("There is a problem with the send port (" & Me.TextBox_UDPsendPort.Text & ")", MsgBoxStyle.Critical)
            SaveWasSuccessful = False
        End Try
        Try
            Me.UDPcommSys_.ReceiveIP = System.Net.IPAddress.Parse(Me.TextBox_UDPrcvIP.Text)
        Catch
            MsgBox("There is a problem with the Receive IP (" & Me.TextBox_UDPrcvIP.Text & ")", MsgBoxStyle.Critical)
            SaveWasSuccessful = False
        End Try
        Try
            Me.UDPcommSys_.SendIP = System.Net.IPAddress.Parse(Me.TextBox_UDPsendIP.Text)
        Catch
            MsgBox("There is a problem with the Send IP (" & Me.TextBox_UDPsendIP.Text & ")", MsgBoxStyle.Critical)
            SaveWasSuccessful = False
        End Try


        Try

            ParticipantID_ = Me.TextBox_ParticipantID.Text
            'AllowAnyID_ = Me.CheckBox_AcceptAnyID.Checked

            SaveSetting(Application.ProductName, "Settings", "ReceivePort", Me.TextBox_UDPrcvPort.Text)
            SaveSetting(Application.ProductName, "Settings", "SendPort", Me.TextBox_UDPsendPort.Text)
            SaveSetting(Application.ProductName, "Settings", "ReceiveIp", Me.TextBox_UDPrcvIP.Text)
            SaveSetting(Application.ProductName, "Settings", "SendIp", Me.TextBox_UDPsendIP.Text)
            SaveSetting(Application.ProductName, "Settings", "ParticipantID", ParticipantID_)
            'SaveSetting(Application.ProductName, "Settings", "AllowAnyID", AllowAnyID_)
            SaveSetting(Application.ProductName, "Settings", "LatitudeDD", Me.txtLatitudeDD.Text)
            LatitudeDD_ = Me.txtLatitudeDD.Text
            SaveSetting(Application.ProductName, "Settings", "LongitudeDD", Me.txtLongitudeDD.Text)
            LongitudeDD_ = Me.txtLongitudeDD.Text

        Catch
            MsgBox("An error occurred while saving application settings", MsgBoxStyle.Critical, "Error Saving Settings")
            SaveWasSuccessful = False
        End Try

    End Sub

    Private Sub Button_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_OK.Click
        Dim SaveWasSuccessful As Boolean = True
        SaveSettings(SaveWasSuccessful)
        If SaveWasSuccessful Then
            Me.Close()
        Else
            MsgBox("Please correct the settings or choose 'Cancel' to exit the form", MsgBoxStyle.Critical, "Correct Settings")
        End If
    End Sub

    Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub

    Private Sub form_Config_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
