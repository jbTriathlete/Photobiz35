Public Class order

    '  Private mw As MainWindow
    Private mystyles As ResourceDictionary

    Public Sub loadControl(ByVal inItem As String, ByVal inPrice As String, ByVal inPicId As String)
       
        mystyles = New ResourceDictionary
        mystyles.Source = New Uri("rdict.xaml",
               UriKind.RelativeOrAbsolute)
        Dim mybuttonstyle As Style
        mybuttonstyle = mystyles("myStyle")
        ' Dim btn As New Button
        Button1.Content = "I WANT THIS"
        Button1.Tag = inPicId
        Button1.Style = mybuttonstyle
        Button1.Style = Button1.Style
        '''  Button1 = btn
        lblPrice.Content = inPrice
        lblitem.Content = inItem

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim pc As New clsPayCart
        Dim btn As Button
        btn = sender
        pc.pcItem = btn.Tag
        pc.pcSize = lblitem.Content
        pc.pckey = pc.pcItem & "-" & pc.pcSize & " - " & Now.Second
        pc.pcPrice = lblPrice.Content
        Try

            MainWindowX.payCol.Add(pc, pc.pckey)
            CType(WpfApplication1.Application.Current.MainWindow, MainWindowX).blah = "There are " & MainWindowX.payCol.Count & " items in the Cart."

        Catch ex As Exception

        End Try

        ' End Try

    End Sub

    
End Class
