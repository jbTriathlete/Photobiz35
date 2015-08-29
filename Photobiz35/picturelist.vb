
Class picturelist
    Dim _piclist() As String
    Dim _current As Integer = 0
    Dim _folder As String
    Dim _File As String
    Dim index As Integer

    Sub init(ByVal infile As String)
        index = infile.LastIndexOf("\")
        _folder = infile.Substring(0, index)
        _File = infile
        _piclist = System.IO.Directory.GetFiles(_folder, "*.jpg")
        setCurrent()
    End Sub
    Private Sub setCurrent()
        Dim xcnt As Integer = 0
        For xcnt = 0 To _piclist.Count
            If _piclist(xcnt) = _File Then
                _current = xcnt
                Exit Sub
            End If
        Next
    End Sub
    Function peek() As String
        Return _piclist(_current)
    End Function

    Function prev() As String
        _current = _current - 1
        If _current < 0 Then
            _current = _piclist.Length - 1
        End If
        Return peek()
    End Function

    Function [next]() As String
        _current = _current + 1
        If _current >= _piclist.Length Then
            _current = 0
        End If
        Return peek()
    End Function

End Class
