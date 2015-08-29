

Public Class CartList
    Inherits System.Collections.ObjectModel.ObservableCollection(Of clsPayCart)

    Private Shared list As New CartList

    Public Sub AddNew(ByVal inPC As clsPayCart)
        MyBase.Add(inPC)
    End Sub

    Public Function GetCount() As Integer
        Return list.Items.Count
    End Function

End Class
