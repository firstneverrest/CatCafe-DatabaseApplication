Imports System.IO
Public Class Food
    Private Sub Food_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Food' table. You can move, or remove it, as needed.
        Me.FoodTableAdapter.Fill(Me.DataSet1.Food)

    End Sub

    Friend Sub setdata()
        Me.FoodTableAdapter.Fill(Me.DataSet1.Food)
    End Sub

    Friend Sub FoodShow()
        Me.Show()
    End Sub

    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Food2.addnew() 'open form5'
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Try
            Me.FoodBindingSource.RemoveCurrent()
            Me.FoodTableAdapter.Update(Me.DataSet1.Food) 'update ค่าใน database'
            setdata()
            MsgBox("Success")
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles Edit.Click
        Try
            Dim MenuID As String = Me.DataGridView1.CurrentRow.Cells(0).Value
            Food2.edit(MenuID)
        Catch ex As Exception
            MsgBox("Fail")
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Dim keyword As String = "MenuID = '" & Me.ToolStripTextBox1.Text & "' OR Material LIKE '%" & Me.ToolStripTextBox1.Text & "%'"
            Me.FoodBindingSource.Filter = keyword
        Catch ex As Exception
            MsgBox("Not Found")
        End Try

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.ToolStripTextBox1.Clear()
        Me.FoodBindingSource.Filter = ""
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim writer As TextWriter = New StreamWriter("C:\Users\LOKI\Documents\Visual Studio 2015\Projects\Cat Cafe\export file\Food.txt")
        writer.Write("|" & vbTab & "MenuID" & vbTab & "|" & vbTab & "Material" & vbTab & "|" & vbTab & "Price" & vbTab & "|")
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