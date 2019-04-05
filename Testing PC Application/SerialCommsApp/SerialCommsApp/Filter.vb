Imports Microsoft.VisualBasic

Public Class Filter
    Dim num As List(Of Double) = New List(Of Double)
    Dim den As List(Of Double) = New List(Of Double)
    Dim delayInL, delayOutL, delayInR, delayOutR As List(Of Double)

    Public Sub New(n As List(Of Double), d As List(Of Double))
        num = n
        den = d
        delayInL = Enumerable.Repeat(0.0, num.Count).ToList()
        delayInR = Enumerable.Repeat(0.0, num.Count).ToList()
        delayOutL = Enumerable.Repeat(0.0, num.Count).ToList()
        delayOutR = Enumerable.Repeat(0.0, num.Count).ToList()
    End Sub

    Public Function FilterSig(rawSnap As Snapshot) As Snapshot
        Dim filt_L As Double = rawSnap.getLeft() * num(0)
        Dim filt_R As Double = rawSnap.getRight() * num(0)

        For i As Integer = 1 To num.Count - 1
            filt_L += num(i) * delayInL(i - 1) - den(i) * delayOutL(i - 1)
            filt_R += num(i) * delayInR(i - 1) - den(i) * delayOutR(i - 1)
        Next

        Dim filtSnap As Snapshot = New Snapshot(rawSnap.getTime, filt_L, filt_R)

        For i As Integer = num.Count - 1 To 1 Step -1
            delayInL(i) = delayInL(i - 1)
            delayInR(i) = delayInR(i - 1)
            delayOutL(i) = delayOutL(i - 1)
            delayOutR(i) = delayOutR(i - 1)
        Next

        delayInL(0) = rawSnap.getLeft()
        delayInR(0) = rawSnap.getRight()
        delayOutL(0) = filtSnap.getLeft()
        delayOutR(0) = filtSnap.getRight()

        Return filtSnap

    End Function

    Public Sub ImpulseResponse(n As Integer)
        'TODO: If you have time, write an impulse response method for testing purposes
        Dim dummy1 As Snapshot = New Snapshot(1, 1, 1)
        Dim dummy0 As Snapshot = New Snapshot(0, 0, 0)
        Dim res As Snapshot
        res = FilterSig(dummy1)
        Console.WriteLine("1: " + res.getLeft().ToString)
        For i As Integer = 2 To n
            res = FilterSig(dummy0)
            Console.WriteLine(i.ToString + ": " + res.getLeft().ToString)
        Next

        delayInL.Clear()
        delayInR.Clear()
        delayOutL.Clear()
        delayOutR.Clear()
    End Sub
End Class