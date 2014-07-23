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
        Me.btnUp = New System.Windows.Forms.Button
        Me.btnRight = New System.Windows.Forms.Button
        Me.btnDown = New System.Windows.Forms.Button
        Me.btnLeft = New System.Windows.Forms.Button
        Me.lblAccountingStatus = New System.Windows.Forms.Label
        Me.btnTogglePowerSupply = New System.Windows.Forms.Button
        Me.btnToggleGreenLights = New System.Windows.Forms.Button
        Me.btnToggleBlueLights = New System.Windows.Forms.Button
        Me.btnToggleRedLights = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnUp
        '
        Me.btnUp.Location = New System.Drawing.Point(399, 10)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(50, 50)
        Me.btnUp.TabIndex = 20
        Me.btnUp.Text = "Up"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnRight
        '
        Me.btnRight.Location = New System.Drawing.Point(455, 66)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(50, 50)
        Me.btnRight.TabIndex = 19
        Me.btnRight.Text = "Right"
        Me.btnRight.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Location = New System.Drawing.Point(399, 115)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(50, 50)
        Me.btnDown.TabIndex = 18
        Me.btnDown.Text = "Down"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnLeft
        '
        Me.btnLeft.Location = New System.Drawing.Point(343, 66)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(50, 50)
        Me.btnLeft.TabIndex = 17
        Me.btnLeft.Text = "Left"
        Me.btnLeft.UseVisualStyleBackColor = True
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
        Me.ClientSize = New System.Drawing.Size(535, 190)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnRight)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnLeft)
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
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnRight As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnLeft As System.Windows.Forms.Button
    Friend WithEvents lblAccountingStatus As System.Windows.Forms.Label
    Friend WithEvents btnTogglePowerSupply As System.Windows.Forms.Button
    Friend WithEvents btnToggleGreenLights As System.Windows.Forms.Button
    Friend WithEvents btnToggleBlueLights As System.Windows.Forms.Button
    Friend WithEvents btnToggleRedLights As System.Windows.Forms.Button
End Class
