Public Class Form2




    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        p4.Height = Button1.Height
        p4.Top = Button1.Top
        Panel4.Visible = True
        Panel5.Visible = False
        Panel6.Visible = False
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        p4.Height = Button2.Height
        p4.Top = Button2.Top
        Panel4.Visible = True
        Panel5.Visible = True
        Panel6.Visible = False
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        p4.Height = Button3.Height
        p4.Top = Button3.Top
        Panel4.Visible = False
        Panel5.Visible = True
        Panel6.Visible = True
        Panel7.Visible = False
    End Sub
    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Hide()
    End Sub


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form3.Show()
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Form4.Show()
    End Sub
End Class







