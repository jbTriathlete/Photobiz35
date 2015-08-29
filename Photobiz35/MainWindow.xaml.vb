

Class MainWindowX
    Dim x As Style
    Private mystyles As ResourceDictionary
    Dim stopload As Boolean = False
    Public Shared payCol As New Collection
    Public g As New CartList
    
    Private Sub order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xsub As Integer
        Dim order As New Button
        Dim Dir As String
        Dim index As Integer
        ''Dim xpc As ClsPayCart
        Dim file As String
        Dim total As Decimal = 0
        Dim but As Button
        StackPanel1.Children.Clear()
        ' stackpanel.Controls.Clear()
        ' stackpanel.RowStyles.Clear()
        ' DockPanel1.Controls.Clear()
        but = sender
        addbackBut(but.Tag.ToString.Substring(0, but.Tag.ToString.LastIndexOf("\")))

        If IO.Directory.Exists(but.Tag) Then
            If My.Computer.FileSystem.GetDirectories(but.Tag).Count > 0 Then
                For Each Dir In My.Computer.FileSystem.GetDirectories(but.Tag)
                    '   StackPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
                    order = New Button
                    index = Dir.LastIndexOf("\")
                    order.Style = Button1.Style
                    order.Content = Dir.Substring(index + 1, Dir.Length - index - 1)
                    order.Tag = Dir
                    AddHandler order.Click, AddressOf order_Click
                    StackPanel1.Children.Add(order)
                    '   StackPanel.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                Next
            Else
                WrapPanel1.Children.Clear()
                'Dim img As New Image

                For Each file In My.Computer.FileSystem.GetFiles(but.Tag)
                    If InStr(file.ToUpper, ".JPG") Then
                        Dim frame As New System.Windows.Threading.DispatcherFrame
                        Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(Windows.Threading.DispatcherPriority.Background, New Windows.Threading.DispatcherOperationCallback(AddressOf ExitFrame), frame)
                        Dim myImage As New Image()
                        mystyles = New ResourceDictionary
                        mystyles.Source = New Uri("rdict.xaml",
                               UriKind.RelativeOrAbsolute)

                        myImage.Width = 120

                        ' Create source
                        Dim myBitmapImage As New BitmapImage()

                        ' BitmapImage.UriSource must be in a BeginInit/EndInit block
                        myBitmapImage.BeginInit()
                        myBitmapImage.UriSource = New Uri(file)
                        myBitmapImage.CacheOption = BitmapCacheOption.OnLoad
                        ' AddHandler myImage.MouseUp, AddressOf myimage_click
                        myBitmapImage.DecodePixelWidth = 150
                        myBitmapImage.EndInit()
                        'set image source
                        myImage.Tag = file
                        myImage.Margin = New Thickness(15)
                        myImage.Source = myBitmapImage
                        Dim panel As New StackPanel
                        panel.Children.Add(myImage)

                        Dim btn As New Button

                        Dim mybuttonstyle As Style
                        mybuttonstyle = mystyles("myStyle")

                        btn.Content = "View Image"
                        btn.Tag = file
                        btn.Style = mybuttonstyle
                        '   btn.Style = Button1.Style
                        AddHandler btn.Click, AddressOf myimage_click

                        panel.Children.Add(btn)
                        panel.Margin = New Thickness(21)
                        'Dim uc As New UserControl1
                        'uc.loadControl(file)
                        'uc.Margin = New Thickness(20)

                        If stopload Then
                            Exit Sub
                        End If
                        WrapPanel1.Children.Add(panel)
                        Windows.Threading.Dispatcher.PushFrame(frame)
                    End If
                Next

            End If

        Else



            Throw New System.IO.DirectoryNotFoundException()
        End If


    End Sub


    Private Sub myimage_click(ByVal sender As Object, ByVal e As EventArgs)
        WrapPanel1.Children.Clear()
        Dim f As New ctrlZoom
        f.inCurrent = sender.tag
        stopload = True
        WrapPanel1.Children.Add(f)


    End Sub

    Private Sub addbackBut(ByVal inPath As String)
        Dim but As Button
        but = New Button
        ' index = Dir.LastIndexOf("\")
        but.Style = Button1.Style
        but.Content = "BACK"
        but.Tag = inPath
        AddHandler but.Click, AddressOf But_Click

        StackPanel1.Children.Add(but)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim xsub As Integer
        Dim order As New Button
        Dim Dir As String
        Dim index As Integer
        ''Dim xpc As ClsPayCart
        Dim total As Decimal = 0
        ' TableLayoutPanel1.Controls.Clear()
        ' TableLayoutPanel1.RowStyles.Clear()
        StackPanel1.Children.Clear()

        If IO.Directory.Exists("c:\horse show") Then
            For Each Dir In My.Computer.FileSystem.GetDirectories("c:\horse show")

                '   TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
                order = New Button
                index = Dir.LastIndexOf("\")
                order.Content = Dir.Substring(index + 1, Dir.Length - index - 1)
                order.Tag = Dir
                order.Style = Button1.Style
                AddHandler order.Click, AddressOf order_Click
                StackPanel1.Children.Add(order)
                ' TableLayoutPanel1.Controls.Add(order, 0, xsub)
                ' TableLayoutPanel1.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink

            Next
        Else
            Throw New System.IO.DirectoryNotFoundException()
        End If

    End Sub

    Private Sub But_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim xsub As Integer
        Dim order As New Button
        Dim Dir As String
        Dim Dira As String
        Dim index As Integer
        ''Dim xpc As ClsPayCart
        Dim total As Decimal = 0
        ' TableLayoutPanel1.Controls.Clear()
        ' TableLayoutPanel1.RowStyles.Clear()
        StackPanel1.Children.Clear()
        stopload = False
        If IO.Directory.Exists(sender.tag) Then
            Dira = sender.tag.ToString.Substring(0, sender.tag.ToString.LastIndexOf("\"))
            addbackBut(Dira)
            For Each Dir In My.Computer.FileSystem.GetDirectories(sender.tag)

                '   TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
                order = New Button
                index = Dir.LastIndexOf("\")
                order.Content = Dir.Substring(index + 1, Dir.Length - index - 1)
                order.Tag = Dir
                order.Style = Button1.Style
                AddHandler order.Click, AddressOf order_Click
                StackPanel1.Children.Add(order)
                ' TableLayoutPanel1.Controls.Add(order, 0, xsub)
                ' TableLayoutPanel1.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink

            Next
        Else
            Throw New System.IO.DirectoryNotFoundException()
        End If

    End Sub

    Public Function ExitFrame(ByVal f As Object) As Object
        CType(f, Windows.Threading.DispatcherFrame).Continue = False

        Return Nothing
    End Function

    Private Sub CommonClickHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim feSource As FrameworkElement = TryCast(e.Source, FrameworkElement)
        MsgBox("Hello")
        e.Handled = True
    End Sub

    Public Property blah() As String
        Get
            Return GetValue(blahproperty)
        End Get
        Set(ByVal value As String)
            SetValue(blahproperty, value)
            ''  MsgBox(value)
        End Set
    End Property

    Public Shared blahproperty As DependencyProperty =
   DependencyProperty.Register("blah", GetType(String), GetType(MainWindowX), New FrameworkPropertyMetadata(" ", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault))

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        '' Dim checkout As New fr
        Dim checkout As New frmCheckOut
        checkout.load()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button3.Click
        payCol.Clear()
        blah = ""
    End Sub
End Class
