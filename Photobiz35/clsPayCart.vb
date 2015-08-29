Imports System.ComponentModel

Public Class clsPayCart
    Implements INotifyPropertyChanged
    Public pcItem As String
    Public pcSize As String
    Public pckey As String
    Public pcPrice As Decimal




    Public Event PropertyChanged( _
      ByVal sender As Object, _
      ByVal e As PropertyChangedEventArgs) _
      Implements INotifyPropertyChanged.PropertyChanged

    Protected Overridable Sub OnPropertyChanged( _
      ByVal PropertyName As String)

        ' Raise the event, and make this procedure
        ' overridable, should someone want to inherit from
        ' this class and override this behavior:
        RaiseEvent PropertyChanged( _
          Me, New PropertyChangedEventArgs(PropertyName))
    End Sub

End Class
