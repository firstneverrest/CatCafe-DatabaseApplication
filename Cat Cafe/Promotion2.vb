Public Class Promotion2
    Friend Sub addnew()
        Me.Show()
        Me.PromotionBindingSource.AddNew()
    End Sub
    Friend Sub edit(ByVal pID As String) 'ต้องรู้ข้อมูลเก่าก่อน จึงต้องส่งข้อมูลเก่าเข้ามา'
        Me.Show()
        Dim keyword As String = "pID = '" & pID & "'"
    End Sub


    Private Sub Promotion2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Promotion' table. You can move, or remove it, as needed.
        Me.PromotionTableAdapter.Fill(Me.DataSet1.Promotion)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Me.PromotionBindingSource.EndEdit()
            Me.PromotionTableAdapter.Update(Me.DataSet1.Promotion) 'update ค่าใน database'
            Promotion.setdata()
            MsgBox("Success")
            Me.Close()
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub
End Class