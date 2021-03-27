Public Class Cat2
    Private Sub Cat2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Cat' table. You can move, or remove it, as needed.
        Me.CatTableAdapter.Fill(Me.DataSet1.Cat)

    End Sub

    Friend Sub addnew()
        Me.Show()
        Me.CatBindingSource.AddNew()
    End Sub
    Friend Sub edit(ByVal CatID As String) 'ต้องรู้ข้อมูลเก่าก่อน จึงต้องส่งข้อมูลเก่าเข้ามา'
        Me.Show()
        Dim keyword As String = "CatID = '" & CatID & "'"
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Me.CatBindingSource.EndEdit()
            Me.CatTableAdapter.Update(Me.DataSet1.Cat) 'update ค่าใน database'
            Cat.setdata()
            MsgBox("Success")
            Me.Close()
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub
End Class