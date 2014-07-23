<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControl
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
        Me.lblAccountingStatus = New System.Windows.Forms.Label()
        Me.btnTogglePowerSupply = New System.Windows.Forms.Button()
        Me.btnToggleGreenLights = New System.Windows.Forms.Button()
        Me.btnToggleBlueLights = New System.Windows.Forms.Button()
        Me.btnToggleRedLights = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblAccountingStatus
        '
        Me.lblAccountingStatus.AutoSize = True
        Me.lblAccountingStatus.Location = New System.Drawing.Point(130, 118)
        Me.lblAccountingStatus.Name = "lblAccountingStatus"
        Me.lblAccountingStatus.Size = New System.Drawing.Size(101, 13)
        Me.lblAccountingStatus.TabIndex = 16
        Me.lblAccountingStatus.Text = "lblAccountingStatus"
        '
        'btnTogglePowerSupply
        '
        Me.btnTogglePowerSupply.Location = New System.Drawing.Point(12, 111)
        Me.btnTogglePowerSupply.Name = "btnTogglePowerSupply"
        Me.btnTogglePowerSupply.Size = New System.Drawing.Size(112, 27)
        Me.btnTogglePowerSupply.TabIndex = 15
        Me.btnTogglePowerSupply.Text = "Toggle Power Supply"
        Me.btnTogglePowerSupply.UseVisualStyleBackColor = True
        '
        'btnToggleGreenLights
        '
        Me.btnToggleGreenLights.Location = New System.Drawing.Point(12, 78)
        Me.btnToggleGreenLights.Name = "btnToggleGreenLights"
        Me.btnToggleGreenLights.Size = New System.Drawing.Size(112, 27)
        Me.btnToggleGreenLights.TabIndex = 14
        Me.btnToggleGreenLights.Text = "Toggle Green Lights"
        Me.btnToggleGreenLights.UseVisualStyleBackColor = True
        '
        'btnToggleBlueLights
        '
        Me.btnToggleBlueLights.Location = New System.Drawing.Point(12, 45)
        Me.btnToggleBlueLights.Name = "btnToggleBlueLights"
        Me.btnToggleBlueLights.Size = New System.Drawing.Size(112, 27)
        Me.btnToggleBlueLights.TabIndex = 13
        Me.btnToggleBlueLights.Text = "Toggle Blue Lights"
        Me.btnToggleBlueLights.UseVisualStyleBackColor = True
        '
        'btnToggleRedLights
        '
        Me.btnToggleRedLights.Location = New System.Drawing.Point(12, 12)
        Me.btnToggleRedLights.Name = "btnToggleRedLights"
        Me.btnToggleRedLights.Size = New System.Drawing.Size(112, 27)
        Me.btnToggleRedLights.TabIndex = 12
        Me.btnToggleRedLights.Text = "Toggle RedLights"
        Me.btnToggleRedLights.UseVisualStyleBackColor = True
        '
        'frmControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 190)
        Me.Controls.Add(Me.lblAccountingStatus)
        Me.Controls.Add(Me.btnTogglePowerSupply)
        Me.Controls.Add(Me.btnToggleGreenLights)
        Me.Controls.Add(Me.btnToggleBlueLights)
        Me.Controls.Add(Me.btnToggleRedLights)
        Me.Name = "frmControl"
        Me.Text = "frmControl"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAccountingStatus As System.Windows.Forms.Label
    Friend WithEvents btnTogglePowerSupply As System.Windows.Forms.Button
    Friend WithEvents btnToggleGreenLights As System.Windows.Forms.Button
    Friend WithEvents btnToggleBlueLights As System.Windows.Forms.Button
    Friend WithEvents btnToggleRedLights As System.Windows.Forms.Button
End Class
