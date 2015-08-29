Public Class ctrlZoom
    '''Private mw As MainWindow
    Public inCurrent As String
    Dim _piclist As picturelist
    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        _piclist = New picturelist()
        _piclist.init(inCurrent)
        Dim str As String
        str = _piclist.peek
        displaypicture(str)
        '' mw = sender
        readXml()
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnPrev.Click
        Dim str As String
        str = _piclist.prev
        displaypicture(str)
        readXml()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnNext.Click
        Dim str As String
        str = _piclist.next
        displaypicture(str)
        readXml()
    End Sub

    Private Sub displaypicture(ByVal str As String)
        Dim bi As BitmapImage
        bi = New BitmapImage(New Uri(str))

        Image1.Source = bi
        Image1.ClipToBounds = True
    End Sub

    Private Sub readXml()
        Dim ds As New System.Data.DataSet
        Dim xcnt As Integer
        Dim item As String
        StackPanel1.Children.Clear()
        Dim price As String
        ds.ReadXml("C:\photobiz35\Photobiz35\Photobiz35\Products.xml")

        For xcnt = 0 To ds.Tables(0).Rows.Count - 1
            item = ds.Tables(0).Rows(xcnt).Item("Item")

            price = ds.Tables(0).Rows(xcnt).Item("price")
            Dim od As New order
            od.loadControl(item, price, Image1.Source.ToString)

            StackPanel1.Children.Add(od)
        Next
        'xmlDoc = New XmlDocument
        'xmlDoc.Load("C:\photobiz35\Photobiz35\Photobiz35\Products.xml")
        'Dim xRoot As XmlNode = xmlDoc.FirstChild

        'MsgBox(xRoot("Item").OuterXml)

    End Sub
End Class
