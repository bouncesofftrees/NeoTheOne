Public Class frmMsgTraffic

    Public Sub AddTraffic(ByVal From_in As String, ByVal Message_in As String)
        Try
            UpdateRichTextBox_Traffic(From_in, Message_in)
            Dim myUpdateTrafficWindow As New UpdateTrafficWindow(AddressOf UpdateRichTextBox_Traffic)
            Me.RichTextBox_Traffic.Invoke(myUpdateTrafficWindow, New Object() {From_in, Message_in})

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try

    End Sub

    Private Sub UpdateRichTextBox_Traffic(ByVal From_in As String, ByVal Message_in As String)
        Try
            Me.RichTextBox_Traffic.AppendText(From_in + ": Length(" + Message_in.Length.ToString + "):" + Message_in + Microsoft.VisualBasic.Constants.vbCrLf)
            Me.RichTextBox_Traffic.ScrollToCaret()

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try

    End Sub

End Class