Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class Form5
    Dim total As Integer



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel8.Height = Button1.Height
        Panel8.Top = Button1.Top
        Remove()



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Panel8.Height = Button2.Height
        Panel8.Top = Button2.Top

        payments()


       
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Form1.TextBox1.Clear()
        Form1.TextBox2.Clear()
    End Sub




    


    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        FormBorderStyle = Windows.Forms.FormBorderStyle.None
        WindowState = FormWindowState.Maximized


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        search()


    End Sub

   
End Class


