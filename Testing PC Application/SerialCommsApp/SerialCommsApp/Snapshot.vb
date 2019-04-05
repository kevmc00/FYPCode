Public Class Snapshot
    Dim time As Integer
    Dim value1 As Double
    Dim value2 As Double

    Public Sub New(t As String, v As String)
        time = CType(t, Integer)
        value1 = CType(v, Long)
    End Sub

    Public Sub New(t As String, v1 As String, v2 As String)
        time = CType(t, Integer)
        value1 = CType(v1, Double)
        value2 = CType(v2, Double)
    End Sub

    Public Function getTime() As Integer
        Return time
    End Function

    Public Function getLeft() As Double
        Return value1
    End Function

    Public Function getRight() As Double
        Return value2
    End Function

    Public Function getValues() As String
        If Form1.modeSelect.Checked Then
            Return value1 + "," + value2
        Else
            Return value1
        End If
    End Function

    Public Function toString() As String
        Return ("Time: " + time.ToString() + vbTab + "Values: " + value1.ToString() + " " + value2.ToString())
    End Function

    Public Function commaSeparated() As String
        Return value1.ToString() + "," + value2.ToString()
    End Function
End Class
