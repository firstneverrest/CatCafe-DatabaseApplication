Imports System.IO
Public Class Employee
    Friend Sub setdata()
        Me.EmployeeAdapter.Fill(Me.DataSet1.Employee)
    End Sub
    Friend Sub EmployeeShow()
        Me.Show()
    End Sub

    Private Sub CatCafe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Employee' table. You can move, or remove it, as needed.
        Me.EmployeeAdapter.Fill(Me.DataSet1.Employee)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles Add.Click
        Empolyee2.addnew() 'open form2'
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Try
            Me.EmployeeBindingSource1.RemoveCurrent()
            Me.EmployeeAdapter.Update(Me.DataSet1.Employee) 'update ค่าใน database'
            setdata()
            MsgBox("Success")
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles Edit.Click
        Try
            Dim i As Integer = Me.DataGridView1.CurrentRow.Index
            Dim EmpID As String = Me.DataGridView1.CurrentRow.Cells(i).Value
            Empolyee2.edit(EmpID)
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Dim keyword As String = "EmpID = '" & Me.ToolStripTextBox1.Text & "' OR EName LIKE '%" & Me.ToolStripTextBox1.Text & "%'"
            Me.EmployeeBindingSource1.Filter = keyword
        Catch ex As Exception
            MsgBox("Not Found")
        End Try

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.ToolStripTextBox1.Clear()
        Me.EmployeeBindingSource1.Filter = ""
    End Sub


    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim writer As TextWriter = New StreamWriter("C:\Users\LOKI\Documents\Visual Studio 2015\Projects\Cat Cafe\export file\Employee.txt")
        writer.Write("|" & vbTab & "EmpID" & vbTab & "|" & vbTab & "EName" & vbTab & vbTab & "|" & vbTab & "Position" & vbTab & vbTab & "|" & vbTab & "Salary" & vbTab & "|" & vbTab & "PhoneNo" & vbTab & vbTab & "|")
        writer.WriteLine("")
        writer.WriteLine("______________________________________________________________________________________________________________________")
        For i As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
            writer.Write("|")
            For j As Integer = 0 To DataGridView1.Columns.Count - 1 Step +1
                writer.Write(vbTab & DataGridView1.Rows(i).Cells(j).Value.ToString() & vbTab & "|")
            Next

            writer.WriteLine("")
            writer.WriteLine("______________________________________________________________________________________________________________________")

        Next
        writer.Close()
        MessageBox.Show("Data Exported")
    End Sub
End Class
