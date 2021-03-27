Imports System.IO
Public Class Cat
    Private Sub Cat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Cat' table. You can move, or remove it, as needed.
        Me.CatTableAdapter.Fill(Me.DataSet1.Cat)

    End Sub
    Friend Sub setdata()
        Me.CatTableAdapter.Fill(Me.DataSet1.Cat)
    End Sub

    Friend Sub CatShow()
        Me.Show()
    End Sub

    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Cat2.addnew() 'open form5'
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Try
            Me.CatBindingSource.RemoveCurrent()
            Me.CatTableAdapter.Update(Me.DataSet1.Cat) 'update ค่าใน database'
            setdata()
            MsgBox("Success")
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles Edit.Click
        Try
            Dim CatID As String = Me.DataGridView1.CurrentRow.Cells(0).Value
            Beverage2.edit(CatID)
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Dim keyword As String = "CatID = '" & Me.ToolStripTextBox1.Text & "' OR CatName LIKE '%" & Me.ToolStripTextBox1.Text & "%'"
            Me.CatBindingSource.Filter = keyword
        Catch ex As Exception
            MsgBox("Not Found")
        End Try

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.ToolStripTextBox1.Clear()
        Me.CatBindingSource.Filter = ""
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim writer As TextWriter = New StreamWriter("C:\Users\LOKI\Documents\Visual Studio 2015\Projects\Cat Cafe\export file\Cat.txt")
        writer.Write("|" & vbTab & "CatID" & vbTab & "|" & vbTab & "CatName" & vbTab & "|" & vbTab & "Birth" & vbTab & "|" & vbTab & "Species" & vbTab & "|" & vbTab & "Sex" & vbTab & "|")
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