Public Class Member2
    Friend Sub addnew()
        Me.Show()
        Me.MemberBindingSource1.AddNew()
    End Sub
    Friend Sub edit(ByVal mID As String) 'ต้องรู้ข้อมูลเก่าก่อน จึงต้องส่งข้อมูลเก่าเข้ามา'
        Me.Show()
        Dim keyword As String = "mID = '" & mID & "'"
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Member' table. You can move, or remove it, as needed.
        Me.MemberTableAdapter.Fill(Me.DataSet1.Member)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Me.MemberBindingSource1.EndEdit()
            Me.MemberTableAdapter.Update(Me.DataSet1.Member) 'update ค่าใน database'
            Member.setdata()
            MsgBox("Success")
            Me.Close()
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

End Class