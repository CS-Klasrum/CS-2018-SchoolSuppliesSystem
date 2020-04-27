Public Class OR23
    Public y As Integer
    Dim quantity1 As String
    Dim des As String
    Dim price As String
    Dim subs As String
    Dim number As String
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.Panel1.Width, Me.Panel1.Height)
        Panel1.DrawToBitmap(bm, New Rectangle(0, 0, Me.Panel1.Width, Me.Panel1.Height))
        e.Graphics.DrawImage(bm, 0, 0)
        Dim aPS As New PageSetupDialog
        aPS.Document = PrintDocument1
    End Sub
    Private Sub LoadReceiptInfo()
        Try

            lblEmpName.Text = Form5.Label6.Text
            lblDate.Text = Date.Now.ToString("MM/dd/yyyy")
            lblTime.Text = Date.Now.ToString("hh:mm:ss")
            lblCash.Text = payment
            lblSubtotal.Text = Form5.Label3.Text
            lblTotal.Text = Form5.Label3.Text
            lblChange.Text = total



        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub

    Private Sub OR23_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadReceiptInfo()
        datagrid()
        PrintDocument1.Print()
    End Sub

    Private Sub lblChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblChange.Click

    End Sub

    Public Sub datagrid()
        For j = Form5.DataGridView1.RowCount - 1 To 0 Step -1
            des = Form5.DataGridView1(1, j).Value
            price = Form5.DataGridView1(2, j).Value
            quantity1 = Form5.DataGridView1(3, j).Value
            subs = Form5.DataGridView1(4, j).Value
            dgw.Rows.Add(quantity1, des, price, subs)
            Me.dgw.Height += 30
            y += 19


        Next

        Panel2.Location = New Point(11, 290 + y)
        Panel1.Height += y
        Height += y
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub lblThank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblThank.Click

    End Sub
End Class