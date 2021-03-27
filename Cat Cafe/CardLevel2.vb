Public Class CardLevel2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.CardLevel' table. You can move, or remove it, as needed.
        Me.CardLevelTableAdapter.Fill(Me.DataSet1.CardLevel)

    End Sub

    Friend Sub addnew()
        Me.Show()
        Me.CardLevelBindingSource1.AddNew()
    End Sub
    Friend Sub edit(ByVal Level As String) 'ต้องรู้ข้อมูลเก่าก่อน จึงต้องส่งข้อมูลเก่าเข้ามา'
        Me.Show()
        Dim keyword As String = "Level = '" & Level & "'"
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Me.CardLevelBindingSource1.EndEdit()
            Me.CardLevelTableAdapter.Update(Me.DataSet1.CardLevel) 'update ค่าใน database'
            CardLevel.setdata()
            MsgBox("Success")
            Me.Close()
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub
End Class