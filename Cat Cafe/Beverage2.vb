Public Class Beverage2

    Private Sub Beverage2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Beverage' table. You can move, or remove it, as needed.
        Me.BeverageTableAdapter.Fill(Me.DataSet1.Beverage)

    End Sub

    Friend Sub addnew()
        Me.Show()
        Me.BeverageBindingSource.AddNew()
    End Sub
    Friend Sub edit(ByVal MenuID As String) 'ต้องรู้ข้อมูลเก่าก่อน จึงต้องส่งข้อมูลเก่าเข้ามา'
        Me.Show()
        Dim keyword As String = "MenuID = '" & MenuID & "'"
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Me.BeverageBindingSource.EndEdit()
            Me.BeverageTableAdapter.Update(Me.DataSet1.Beverage) 'update ค่าใน database'
            Beverage.setdata()
            MsgBox("Success")
            Me.Close()
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub
End Class