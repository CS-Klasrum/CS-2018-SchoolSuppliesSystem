Imports MySql.Data.MySqlClient
Module Module1
    Public constring As MySqlConnection
    Public cm As New MySqlCommand
    Public dr As MySqlDataReader
    Dim COMMAND As MySqlCommand

    Dim dbDataSet As New DataTable
    Dim role As String
    Public total As Integer
    Dim index
    Dim subtotal As String
    Dim quantity As String
    Dim quantity1 As String
    Public payment As String
    Dim item As String
    Dim ID As Integer
    Dim cmd As MySqlCommand


    Sub connection()
        Try
            constring = New MySqlConnection("server=localhost; database=data1; username=root; password=;")
            constring.Open()
        Catch ex As Exception
            MsgBox("not connected")
        End Try
    End Sub

    Public Sub login()
        constring = New MySqlConnection
        constring.ConnectionString = "server=localhost; database=data1; username=root; password=;"
        Dim READER As MySqlDataReader


        Try
            constring.Open()
            Dim query As String
            query = "select * from data1.account where UserName = '" & Form1.TextBox1.Text & "'"
            COMMAND = New MySqlCommand(query, constring)
            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
                If READER("Role") = "Admin" Then
                    role = "Admin"
                    Form2.Show()
                ElseIf READER("Role") = "Cashier" Then
                    role = "Cashier"
                    Form5.Show()
                End If
            End While


            If count = 1 Then
                If role = "Admin" Then

                ElseIf role = "Cashier" Then

                ElseIf count > 1 Then
                    MsgBox(" invalid user or pass")
                Else
                    MsgBox(" invalid user or pass")
                End If
            End If

            constring.Close()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub tingnanproduct()
        constring = New MySqlConnection
        constring.ConnectionString = "server=localhost; user=root; database=data1"
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource
        reset()

        Try
            constring.Open()
            Dim Query As String
            Query = "SELECT * FROM data1.product"
            COMMAND = New MySqlCommand(Query, constring)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            Form2.DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet)
            constring.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Public Sub tingnanaccount()
        constring = New MySqlConnection
        constring.ConnectionString = "server=localhost; user=root; database=data1"
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource
        reset()

        Try
            constring.Open()
            Dim Query As String
            Query = "SELECT * FROM data1.account"
            COMMAND = New MySqlCommand(Query, constring)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            Form2.DataGridView3.DataSource = bSource
            SDA.Update(dbDataSet)
            constring.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Public Sub addAccount()
        constring.Open()

        Dim Encryption As Integer = 3
        For Each letter As String In Form6.TextBox3.Text
            item += Chr(Asc(letter) + Encryption)
        Next
        Form6.TextBox3.Text = item

        Try
            cm = New MySqlCommand("insert into data1.account values('" & Form6.TextBox4.Text & "','" & Form6.TextBox1.Text & "','" & Form6.TextBox2.Text & "','" & Form6.TextBox3.Text & "','" & Form6.ComboBox1.Text & "')", constring)
            cm.ExecuteNonQuery()
            MsgBox("success")
            item = ""
            Form6.TextBox4.Text = ""
            Form6.TextBox1.Text = ""
            Form6.TextBox2.Text = ""
            Form6.TextBox3.Text = ""
            Form6.ComboBox1.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        tingnanaccount()
        constring.Close()

    End Sub

    Public Sub addproduct()
        constring.Open()

        Try
            cm = New MySqlCommand("INSERT INTO `product` (`ID`, `Barcode`, `SKU`, `Quantity`, `Price`) VALUES (NULL, '" & Form3.TextBox2.Text & "', '" & Form3.TextBox3.Text & "', '" & Form3.TextBox4.Text & "', '" & Form3.TextBox5.Text & "' '" & Form3.TextBox1.Text & "')", constring)
            cm.ExecuteNonQuery()
            MsgBox("success")
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Form3.Hide()
        tingnanaccount()
        constring.Close()

    End Sub


    Public Sub reset()
        dbDataSet.Columns.Clear()
        dbDataSet.Rows.Clear()
    End Sub



    Public Sub search()



        constring = New MySqlConnection
        constring.ConnectionString = "server=localhost; database=data1; username=root; password=;"
        Dim READER As MySqlDataReader


        Try
            constring.Open()
            Dim query As String
            query = "select * from data1.product where Barcode = '" & Form5.TextBox1.Text & "'"
            COMMAND = New MySqlCommand(query, constring)
            READER = COMMAND.ExecuteReader



            While READER.Read

                If (Form5.TextBox1.Text <= 0) Then
                    MsgBox("No Product")

                Else

                    quantity = InputBox("How many ? ")
                    subtotal = READER("Price") * quantity
                    Form5.DataGridView1.Rows.Add(READER("Barcode"), READER("SKU"), READER("Price"), quantity, subtotal)
                    total += subtotal
                    Form5.Label3.Text = total
                End If
            End While

            constring.Close()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Remove()
        Dim delete As String
        Try
            delete = Form5.DataGridView1.CurrentRow.Index()
            Form5.DataGridView1.Rows.RemoveAt(delete)
            total -= subtotal
            Form5.Label3.Text = total

        Catch ex As Exception

        End Try
        



    End Sub

    Public Sub payments()
        Dim delete As String
        constring.Open()


        Try

       

        payment = InputBox("Payment")


            
        If payment >= total Then


            total = payment - Form5.Label3.Text
            MsgBox(total)

            Try
                OR23.Show()
                cm = New MySqlCommand("insert into sales values('" & Form5.Label4.Text & "',  '" & Form5.Label6.Text & "', '" & Form5.Label3.Text & "')", constring)
                cm.ExecuteNonQuery()
                
                   
                quantityMi()
                    tingnanaccount()
                    Form5.DataGridView1.Rows.Clear()
                    Form5.TextBox1.Clear()
                    Form5.Label3.Text = 0

                    total = 0
                Catch ex As Exception
                    MsgBox(ex.Message)
            End Try

        ElseIf payment < total Then
            MsgBox("Invalid input ")

        Else
                MsgBox("Invalid input ")



        End If

        Catch ex As Exception

        End Try



        constring.Close()

    End Sub

    Public Sub tingnansales()
        constring = New MySqlConnection
        constring.ConnectionString = "server=localhost; user=root; database=data1"
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource
        reset()

        Try
            constring.Open()
            Dim Query As String
            Query = "SELECT * FROM data1.sales"
            COMMAND = New MySqlCommand(Query, constring)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            Form2.DataGridView2.DataSource = bSource
            SDA.Update(dbDataSet)
            constring.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Sub saving()

        constring = New MySqlConnection("server=localhost; user=root; database=data1")

        Try

            Dim query As String = "UPDATE product SET Quantity =@Q WHERE  Barcode=@ID "

            constring.Open()

            cmd = New MySqlCommand(query, constring)
            cmd.Parameters.AddWithValue("@ID", ID)
            cmd.Parameters.AddWithValue("@Q", quantity1)

            cmd.ExecuteNonQuery()


            constring.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Public Sub quantityMi()

        constring = New MySqlConnection
        constring.ConnectionString = "server=localhost;username=root;password=;database=data1"
        Dim READER As MySqlDataReader



        For j = Form5.DataGridView1.RowCount - 1 To 0 Step -1

            Try
                constring.Open()
                Dim Query As String
                Query = "select * from product where Barcode ='" & Form5.DataGridView1(0, j).Value & "'"

                COMMAND = New MySqlCommand(Query, constring)
                READER = COMMAND.ExecuteReader
                While READER.Read
                    ID = Form5.DataGridView1(0, j).Value
                    quantity1 = READER("Quantity") - Form5.DataGridView1(3, j).Value
                    saving()

                End While


            Catch ex As MySqlException
                MessageBox.Show(ex.Message)

            End Try
        Next
    End Sub

    Public Sub prev()
        constring = New MySqlConnection
        constring.ConnectionString = "server=localhost; database=data1; username=root; password=;"
        Dim READER As MySqlDataReader


        Try
            constring.Open()
            Dim query As String
            query = "select * from data1.product where ID = '" & Form4.TextBox1.Text & "'"
            COMMAND = New MySqlCommand(query, constring)
            READER = COMMAND.ExecuteReader



            While READER.Read

                

                Form7.Label10.Text = READER("ID")
                Form7.Label6.Text = READER("Barcode")
                Form7.Label7.Text = READER("SKU")
                Form7.Label8.Text = READER("Quantity")
                Form7.Label9.Text = READER("Price")
            End While

            constring.Close()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub history()
        constring.Open()
        Try

            cm = New MySqlCommand("INSERT INTO `history`(`ID`, `Date`, `Admin Name`, `Barcode`, `SKU`, `Previous Quantity`, `New Quantity`, `Previous Price`, `New Price`) VALUES (NULL, '" & Form2.Label8.Text & "', '" & Form2.Label6.Text & "', '" & Form7.Label6.Text & "',  '" & Form7.Label7.Text & "', '" & Form7.Label8.Text & "', '" & Form7.Label16.Text & "', '" & Form7.Label15.Text & "', '" & Form7.Label10.Text & "')", constring)
            cm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        constring.Close()

    End Sub

   

    Public Sub tingnanhistory()
        constring = New MySqlConnection
        constring.ConnectionString = "server=localhost; user=root; database=data1"
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource
        reset()

        Try
            constring.Open()
            Dim Query As String
            Query = "SELECT * FROM data1.history"
            COMMAND = New MySqlCommand(Query, constring)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            Form2.DataGridView4.DataSource = bSource
            SDA.Update(dbDataSet)
            constring.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub
End Module












