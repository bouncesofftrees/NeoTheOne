Public Class frmControl
    Private MyAppMainForm As form_main = Nothing


    Private Sub frmControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(ByRef MainForm As form_main, ByVal AccountingOn As Boolean)

        MyAppMainForm = MainForm

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblAccountingStatus.Text = AccountingOn.ToString()

    End Sub


    Private Sub btnToggleRedLights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleRedLights.Click
        ' '' ''MyAppMainForm.ToggleRedLights()
    End Sub

    Private Sub btnToggleBlueLights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleBlueLights.Click
        ' '' ''MyAppMainForm.ToggleBlueLights()
    End Sub

    Private Sub btnToggleGreenLights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleGreenLights.Click
        ' '' ''MyAppMainForm.ToggleGreenLights()
    End Sub

    Private Sub btnTogglePowerSupply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTogglePowerSupply.Click
        ' '' ''lblAccountingStatus.Text = MyAppMainForm.TogglePowerSupply().ToString()
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        ' '' ''MyAppMainForm.InvokeMove("U")
    End Sub

    Private Sub btnLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeft.Click
        ' '' ''MyAppMainForm.InvokeMove("L")
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        ' '' ''MyAppMainForm.InvokeMove("D")
    End Sub

    Private Sub btnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRight.Click
        ' '' ''MyAppMainForm.InvokeMove("R")
    End Sub
End Class