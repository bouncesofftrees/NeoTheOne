<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMsgTraffic
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.RichTextBox_Traffic = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'RichTextBox_Traffic
        '
        Me.RichTextBox_Traffic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RichTextBox_Traffic.Location = New System.Drawing.Point(2, 2)
        Me.RichTextBox_Traffic.Name = "RichTextBox_Traffic"
        Me.RichTextBox_Traffic.Size = New System.Drawing.Size(928, 368)
        Me.RichTextBox_Traffic.TabIndex = 1
        Me.RichTextBox_Traffic.Text = "RichTextBox_Traffic"
        '
        'frmMsgTraffic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 371)
        Me.Controls.Add(Me.RichTextBox_Traffic)
        Me.Name = "frmMsgTraffic"
        Me.Text = "frmMsgTraffic"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RichTextBox_Traffic As System.Windows.Forms.RichTextBox
End Class
