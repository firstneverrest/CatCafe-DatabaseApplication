Public Class Empolyee2
    Friend Sub addnew()
        Me.Show()
        Me.EmployeeBindingSource1.AddNew()
    End Sub
    Friend Sub edit(ByVal EmpID As String) 'ต้องรู้ข้อมูลเก่าก่อน จึงต้องส่งข้อมูลเก่าเข้ามา'
        Me.Show()
        Dim keyword As String = "EmpID = '" & EmpID & "'"
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Employee' table. You can move, or remove it, as needed.
        Me.EmployeeAdapter.Fill(Me.DataSet1.Employee)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Me.EmployeeBindingSource1.EndEdit()
            Me.EmployeeAdapter.Update(Me.DataSet1.Employee) 'update ค่าใน database'
            Employee.setdata()
            MsgBox("Success")
            Me.Close()
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

End Class