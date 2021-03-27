Imports System.IO
Public Class Customer
    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Customer' table. You can move, or remove it, as needed.
        Me.CustomerTableAdapter1.Fill(Me.DataSet1.Customer)

    End Sub
    Friend Sub setdata()
        Me.CustomerTableAdapter1.Fill(Me.DataSet1.Customer)
    End Sub

    Friend Sub CustomerShow()
        Me.Show()
    End Sub

    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Customer2.addnew() 'open form5'
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Try
            Me.CustomerBindingSource1.RemoveCurrent()
            Me.CustomerTableAdapter1.Update(Me.DataSet1.Customer) 'update ค่าใน database'
            setdata()
            MsgBox("Success")
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles Edit.Click
        Try
            Dim CusID As String = Me.DataGridView1.CurrentRow.Cells(0).Value
            Customer2.edit(CusID)
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Dim keyword As String = "CusID = '" & Me.ToolStripTextBox1.Text & "' OR CusName LIKE '%" & Me.ToolStripTextBox1.Text & "%'"
            Me.CustomerBindingSource1.Filter = keyword
        Catch ex As Exception
            MsgBox("Not Found")
        End Try

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.ToolStripTextBox1.Clear()
        Me.CustomerBindingSource1.Filter = ""
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim writer As TextWriter = New StreamWriter("C:\Users\LOKI\Documents\Visual Studio 2015\Projects\Cat Cafe\export file\Customer.txt")
        writer.Write("|" & vbTab & "CusID" & vbTab & "|" & vbTab & "CusName" & vbTab & vbTab & "|")
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