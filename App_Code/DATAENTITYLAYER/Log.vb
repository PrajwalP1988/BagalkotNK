Imports System.Web.HttpContext
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Text
Public Class log
    Public Function Crt(ByVal str As String) As Integer
        Dim fol As String = Date.Today.ToString("ddMMyyyy") + ".txt"
        Dim path As String = System.AppDomain.CurrentDomain.BaseDirectory + "log"
        Dim fi As DirectoryInfo = New DirectoryInfo(path)
        If Not fi.Exists Then
            fi.Create()
        End If
        Dim sw As StreamWriter = New StreamWriter(path + "\" + fol.ToString(), True)
        sw.WriteLine(str)
        sw.Flush()
        sw.Close()
        Return 1
    End Function
End Class
