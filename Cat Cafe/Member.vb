Imports System.IO
Public Class Member
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Member' table. You can move, or remove it, as needed.
        Me.MemberTableAdapter.Fill(Me.DataSet1.Member)

    End Sub
    Friend Sub setdata()
        Me.MemberTableAdapter.Fill(Me.DataSet1.Member)
    End Sub

    Friend Sub MemberShow()
        Me.Show()
    End Sub

    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Member2.addnew() 'open form5'
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Try
            Me.MemberBindingSource1.RemoveCurrent()
            Me.MemberTableAdapter.Update(Me.DataSet1.Member) 'update ค่าใน database'
            setdata()
            MsgBox("Success")
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles Edit.Click
        Try
            Dim mID As String = Me.DataGridView1.CurrentRow.Cells(1).Value
            Member2.edit(mID)
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Dim keyword As String = "mID = '" & Me.ToolStripTextBox1.Text & "' OR MName LIKE '%" & Me.ToolStripTextBox1.Text & "%'"
            Me.MemberBindingSource1.Filter = keyword
        Catch ex As Exception
            MsgBox("Not Found")
        End Try

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.ToolStripTextBox1.Clear()
        Me.MemberBindingSource1.Filter = ""
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim writer As TextWriter = New StreamWriter("C:\Users\LOKI\Documents\Visual Studio 2015\Projects\Cat Cafe\export file\Member.txt")
        writer.Write("|" & vbTab & "mID" & vbTab & "|" & vbTab & "mName" & vbTab & "|" & vbTab & "Level" & vbTab & "|" & vbTab & "MBMonth" & vbTab & "|" & vbTab & "ISDate" & vbTab & "|" & vbTab & "EXDate" & vbTab & "|")
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