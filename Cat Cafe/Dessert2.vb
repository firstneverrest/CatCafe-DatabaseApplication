Public Class Dessert2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Dessert' table. You can move, or remove it, as needed.
        Me.DessertTableAdapter.Fill(Me.DataSet1.Dessert)

    End Sub

    Friend Sub addnew()
        Me.Show()
        Me.DessertBindingSource.AddNew()
    End Sub
    Friend Sub edit(ByVal MenuID As String) 'ต้องรู้ข้อมูลเก่าก่อน จึงต้องส่งข้อมูลเก่าเข้ามา'
        Me.Show()
        Dim keyword As String = "MenuID = '" & MenuID & "'"
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Me.DessertBindingSource.EndEdit()
            Me.DessertTableAdapter.Update(Me.DataSet1.Dessert) 'update ค่าใน database'
            Dessert.setdata()
            MsgBox("Success")
            Me.Close()
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub
End Class