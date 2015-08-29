Public Class CtrlReview
    Dim key As String

    Public Sub loadcontrol(ByVal image As String, ByVal inprice As Integer, ByVal inSize As String, ByVal inKey As String)
        displaypicture(image)
        lblPrice.Content = inprice
        lblSize.Content = inSize
        key = inKey
    End Sub

     
    Private Sub displaypicture(ByVal str As String)
        Dim bi As BitmapImage
        bi = New BitmapImage(New Uri(str))

        Image1.Source = bi
        Image1.ClipToBounds = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        '  MainWindowX.payCol.Remove(key)
        '  CType(WpfApplication1.Application.Current.MainWindow, MainWindowX).blah = "There are " & MainWindowX.payCol.Count & " items in the Cart."
        MsgBox("This function is not working yet!  Please continue with checkout and inform the photographer which picture you do not want.  Sorry for the inconvience.")

    End Sub
End Class
