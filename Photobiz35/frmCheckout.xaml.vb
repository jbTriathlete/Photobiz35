Imports System.Xml

Public Class frmCheckOut
    Dim ctrlinfo As New ctrlInfo
    Public Function load() As Boolean
        stackorders.Children.Clear()
        If MainWindowX.payCol.Count = 0 Then
            MsgBox("There are no items in the Cart")
            Return False
        End If

        Dim cpc As clsPayCart
        Dim key As String
        For xsub = 1 To MainWindowX.payCol.Count
            cpc = New clsPayCart
            cpc = MainWindowX.payCol.Item(xsub)

            Dim ctrl As New CtrlReview
            ctrl.loadcontrol(cpc.pcItem, cpc.pcPrice, cpc.pcSize, cpc.pckey)
            '' stackorders.AddHandler(Button.Click, New RoutedEventHandler(stackorders_Click))
            stackorders.Children.Add(ctrl)

        Next
        Me.ShowDialog()
        Return True
    End Function

    ''' Public Shared ReadOnly removeItem As RoutedEvent = EventManager.RegisterRoutedEvent(removeitem,RoutingStrategy.Bubble,TypeOf(RoutedEventhandler),)

    Private Sub stackorders_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        ''  MsgBox(CType(sender, FrameworkElement).Tag)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click

        If Button1.Content = "Checkout" Then
            stackorders.Children.Clear()


            stackorders.Children.Add(ctrlinfo)
            Button1.Content = "Submit"
        Else
            Dim pnlCust As ctrlInfo
            Dim pc As New clsPayCart

            For xsub = 1 To MainWindowX.payCol.Count
                pc = New clsPayCart
                pc = MainWindowX.payCol.Item(xsub)
                ' ssql = "Insert into base_order (order_id,customer_id,order_item,order_price,order_quantity,order_itemtotal,order_date) values(" & orderId & "," & CustId & ",'" & pc.pcItem & " " & pc.pcSize & "','" & pc.pcPrice & "','" & pc.pcQuantity & "','" & pc.pcPrice * pc.pcQuantity & "','" & Now & "' )"
                ' xCmd.CommandText = ssql
                '   subtotal = subtotal + (pc.pcPrice * pc.pcQuantity)

                Dim str As String
                Dim rep As String
                Dim str1 As String

                str = pc.pcItem

                str = IO.Path.GetFileName(str)
                '  str = str.Substring(str.LastIndexOf("\") + 1, str.Length - str.LastIndexOf("\") - 1)
                If Not IO.Directory.Exists("z:\Orders\" & ctrlinfo.txtFullname.Text) Then
                    IO.Directory.CreateDirectory("z:\Orders\" & ctrlinfo.txtFullname.Text)
                End If
                Try
                    If IO.File.Exists("z:\Orders\" & ctrlinfo.txtFullname.Text & "\" & str) Then
                        rep = xsub.ToString & ".jpg"
                        str = str.Substring(0, str.Length - 4) & rep
                    End If
                    FileCopy(pc.pcItem.Replace("file:///", ""), "z:\Orders\" & ctrlinfo.txtFullname.Text & "\" & pc.pcSize & str)

                Catch ex As Exception
                    MsgBox("Not so fast")
                End Try

            Next
            writeXmlfile("z:\Orders\" & ctrlinfo.txtFullname.Text & "\customerinfo.xml")
            CType(WpfApplication1.Application.Current.MainWindow, MainWindowX).blah = ""
            MainWindowX.payCol.Clear()
            MsgBox("Thank you for your order.  Please tell the photographer your name and the size of prints you would like.")
            Me.Close()
        End If
      
    End Sub

    Private Sub writeXmlfile(ByVal infilename As String)
        Try
            Dim writer As New XmlTextWriter(infilename, System.Text.Encoding.UTF8)
            writer.WriteStartDocument(True)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2
            writer.WriteStartElement("Customer")

            ' writer.WriteStartElement("Product")
            writer.WriteStartElement("Customer_Fullname")
            writer.WriteString(ctrlinfo.txtFullname.Text)
            writer.WriteEndElement()
            writer.WriteStartElement("Customer_address")
            writer.WriteString(ctrlinfo.txtAddress.Text)
            writer.WriteEndElement()
            writer.WriteStartElement("Customer_city")
            writer.WriteString(ctrlinfo.txtCity.Text)
            writer.WriteEndElement()

            writer.WriteStartElement("Customer_state")
            writer.WriteString(ctrlinfo.txtState.Text)
            writer.WriteEndElement()
            writer.WriteStartElement("Customer_zip")
            writer.WriteString(ctrlinfo.txtZip.Text)
            writer.WriteEndElement()
            writer.WriteStartElement("Customer_email")
            writer.WriteString(ctrlinfo.txtEmail.Text)
            writer.WriteEndElement()
            writer.WriteStartElement("Customer_phone")
            writer.WriteString(ctrlinfo.txtPhone.Text)
            writer.WriteEndElement()
            writer.WriteStartElement("Customer_notes")
            writer.WriteString(ctrlinfo.txtNotes.Text)
            writer.WriteEndElement()
            '   writer.WriteEndElement()


            writer.WriteEndElement()
            writer.WriteEndDocument()
            writer.Close()

        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.ToString())
        End Try
    End Sub

    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
