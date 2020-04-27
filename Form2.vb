Imports MySql.Data.MySqlClient
Public Class Form2
    Dim index
    Dim item As String

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False

    End Sub



    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Panel6.Height = Button1.Height
        Panel6.Top = Button1.Top
        Panel4.Visible = True
        Panel5.Visible = False
        Panel7.Visible = False
        Panel8.Visible = False
        tingnanproduct()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Panel6.Height = Button2.Height
        Panel6.Top = Button2.Top
        Panel4.Visible = True
        Panel5.Visible = True
        Panel7.Visible = False
        Panel8.Visible = False
        tingnansales()
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Panel6.Height = Button3.Height
        Panel6.Top = Button3.Top
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
        Panel8.Visible = False
        tingnanaccount()

    End Sub
  
    

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Panel6.Height = Button4.Height
        Panel6.Top = Button4.Top
        Panel4.Visible = True
        Panel5.Visible = True
        Panel7.Visible = True
        Panel8.Visible = False
        tingnanhistory()
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Me.Hide()
        Form1.TextBox1.Clear()
        Form1.TextBox2.Clear()
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form3.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        tingnanproduct()

    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Form4.Show()
    End Sub




    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        tingnanaccount()
    End Sub


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        constring.Open()
        Try
            cm = New MySqlCommand("delete from product where id like '" & Form4.TextBox1.Text & "'", constring)
            cm.ExecuteNonQuery()
            MsgBox("delete")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        tingnanproduct()


        constring.Close()
    End Sub



    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

        constring.Close()
        constring.Open()

        Dim Encryption As Integer = 3
        For Each letter As String In TextBox4.Text
            item += Chr(Asc(letter) + Encryption)
        Next
        TextBox4.Text = item
        Try
            cm = New MySqlCommand("update account set Fullname = '" & TextBox2.Text & "', Username = '" & TextBox3.Text & "', Password = '" & TextBox4.Text & "' ,Role = '" & ComboBox1.Text & "' where id like '" & TextBox1.Text & "'", constring)
            cm.ExecuteNonQuery()
            MsgBox("successfully")

            item = ""

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        tingnanaccount()


        constring.Close()
    End Sub


    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        constring.Open()
        Try
            cm = New MySqlCommand("delete from account where id like '" & TextBox1.Text & "'", constring)
            cm.ExecuteNonQuery()
            MsgBox("delete")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        tingnanaccount()


        constring.Close()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Form6.Show()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        Form4.TextBox1.Text = selectedRow.Cells(0).Value.ToString()
        Form4.TextBox2.Text = selectedRow.Cells(1).Value.ToString()
        Form4.TextBox3.Text = selectedRow.Cells(2).Value.ToString()
        Form4.TextBox4.Text = selectedRow.Cells(3).Value.ToString()
        Form4.TextBox5.Text = selectedRow.Cells(4).Value.ToString()
    End Sub


    Private Sub DataGridView3_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView3.Rows(index)
        TextBox1.Text = selectedRow.Cells(0).Value.ToString()
        TextBox2.Text = selectedRow.Cells(1).Value.ToString()
        TextBox3.Text = selectedRow.Cells(2).Value.ToString()
        TextBox4.Text = selectedRow.Cells(3).Value.ToString()
        ComboBox1.Text = selectedRow.Cells(4).Value.ToString()
    End Sub

  
    

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        tingnansales()
    End Sub


  
    
  
End Class







