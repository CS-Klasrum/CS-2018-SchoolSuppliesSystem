Imports MySql.Data.MySqlClient
Public Class Form4

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        prev()
        constring.Open()

        Try

            cm = New MySqlCommand("update product set Barcode = '" & TextBox2.Text & "', SKU = '" & TextBox3.Text & "', Quantity = '" & TextBox4.Text & "', Price = '" & TextBox5.Text & "' where id like '" & TextBox1.Text & "'", constring)
            cm.ExecuteNonQuery()
            MsgBox("successfully")
            Form7.Label20.Text = TextBox1.Text
            Form7.Label18.Text = TextBox2.Text
            Form7.Label17.Text = TextBox3.Text
            Form7.Label16.Text = TextBox4.Text
            Form7.Label15.Text = TextBox5.Text
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        tingnanproduct()
        Form7.Show()

        Me.Hide()
        constring.Close()
    End Sub

    
End Class