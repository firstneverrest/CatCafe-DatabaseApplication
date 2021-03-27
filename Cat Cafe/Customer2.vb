Public Class Customer2
    Private Sub Customer2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Customer' table. You can move, or remove it, as needed.
        Me.CustomerTableAdapter1.Fill(Me.DataSet1.Customer)


    End Sub
    Friend Sub addnew()
        Me.Show()
        Me.CustomerBindingSource1.AddNew()
    End Sub
    Friend Sub edit(ByVal CusID As String) 'ต้องรู้ข้อมูลเก่าก่อน จึงต้องส่งข้อมูลเก่าเข้ามา'
        Me.Show()
        Dim keyword As String = "CusID = '" & CusID & "'"
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Me.CustomerBindingSource1.EndEdit()
            Me.CustomerTableAdapter1.Update(Me.DataSet1.Customer) 'update ค่าใน database'
            Customer.setdata()
            MsgBox("Success")
            Me.Close()
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class