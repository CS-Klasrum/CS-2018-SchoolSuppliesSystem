Imports MySql.Data.MySqlClient
Public Class Form1
    Dim item As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Form2.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Form2.WindowState = FormWindowState.Maximized
        

        connection()
    End Sub
    Public Sub txt1()

        Dim Encryption As Integer = 3
        For Each letter As String In TextBox2.Text
            item += Chr(Asc(letter) + Encryption)
        Next
        TextBox2.Text = item
    End Sub
    Public Sub txt2()

        Dim Encryption As Integer = 3
        For Each letter As String In TextBox2.Text
            item += Chr(Asc(letter) + Encryption)
        Next
        TextBox2.Text = item
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form5.Label4.Text = System.DateTime.Now.ToString((" MM-dd-yyyy "))
        Form5.Label5.Text = System.DateTime.Now.ToString((" hh :mm : ss tt"))
        Form2.Label8.Text = System.DateTime.Now.ToString((" MM-dd-yyyy "))
        Form2.Label9.Text = System.DateTime.Now.ToString((" hh :mm : ss tt"))

        Form2.Label6.Text = TextBox1.Text
        Form5.Label6.Text = TextBox1.Text
        connection()


        txt2()

        Try
            cm = New MySqlCommand("select * from data1.account where Username = '" & TextBox1.Text & "'and Password = '" & TextBox2.Text & "'", constring)
            dr = cm.ExecuteReader

            If dr.HasRows = True Then
                MsgBox("Log in successfully ")
                item = ""
                login()

            ElseIf TextBox1.Text = "" Then
                MsgBox("username is empty")
            ElseIf TextBox2.Text = "" Then
                MsgBox("password is empty")
            Else
                MsgBox("Invalid Account")


            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

      
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
End Class
