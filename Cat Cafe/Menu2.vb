Public Class Menu2
    Friend Sub addnew()
        Me.Show()
        Me.MenuBindingSource.AddNew()
    End Sub
    Friend Sub edit(ByVal MenuID As String) 'ต้องรู้ข้อมูลเก่าก่อน จึงต้องส่งข้อมูลเก่าเข้ามา'
        Me.Show()
        Dim keyword As String = "MenuID = '" & MenuID & "'"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Menu' table. You can move, or remove it, as needed.
        Me.MenuTableAdapter.Fill(Me.DataSet1.Menu)

    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Me.MenuBindingSource.EndEdit()
            Me.MenuTableAdapter.Update(Me.DataSet1.Menu) 'update ค่าใน database'
            Menu1.setdata()
            MsgBox("Success")
            Me.Close()
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

End Class