Imports System
Imports System.IO
Imports System.Text
Imports System.Web

Namespace LoggingBlock
    Public Class CreateLogFiles
        Private Shared strLogFormat As String
        Private Shared strErrorTime As String

        Public Shared Sub ErrorLog(ByVal strErrMsg As String)
            Try
                'sLogFormat used to create log files format :
                'dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
                strLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> "

                'this variable used to create log filename format "
                'for example filename : ErrorLogDD_MM_YYYY
                Dim strYear As String = DateTime.Now.Year.ToString()
                Dim strMonth As String = DateTime.Now.Month.ToString() + "_"
                Dim strDay As String = DateTime.Now.Day.ToString() + "_"
                strErrorTime = strDay + strMonth + strYear

                Dim strPathName As String = System.AppDomain.CurrentDomain.BaseDirectory + "Logs"
                Dim di As DirectoryInfo = New DirectoryInfo(strPathName)
                If Not di.Exists Then
                    di.Create()
                End If
                Dim sw As StreamWriter = New StreamWriter(strPathName + "\ErrorLog" + strErrorTime + ".txt", True)
                sw.WriteLine(strLogFormat + strErrMsg)
                sw.Flush()
                sw.Close()
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace

