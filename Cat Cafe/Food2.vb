Public Class Food2
    Private Sub Food2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Food' table. You can move, or remove it, as needed.
        Me.FoodTableAdapter.Fill(Me.DataSet1.Food)

    End Sub

    Friend Sub addnew()
        Me.Show()
        Me.FoodBindingSource.AddNew()
    End Sub
    Friend Sub edit(ByVal MenuID As String) 'ต้องรู้ข้อมูลเก่าก่อน จึงต้องส่งข้อมูลเก่าเข้ามา'
        Me.Show()
        Dim keyword As String = "MenuID = '" & MenuID & "'"
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Me.FoodBindingSource.EndEdit()
            Me.FoodTableAdapter.Update(Me.DataSet1.Food) 'update ค่าใน database'
            Food.setdata()
            MsgBox("Success")
            Me.Close()
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

End Class