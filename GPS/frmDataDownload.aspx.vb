Imports RGRHCL_Web_App.Bgt_Bll
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LoggingBlock.CreateLogFiles
Partial Class Bagalkot_Entry_frmDataDownload
    Inherits System.Web.UI.Page
    Private _objAdminBll As New ClsBgt_Bll
    Private _objBgt As New BgtProgress
    Private _ObjDs As New DataSet
    Protected Sub chkAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chk As CheckBox = CType(gvUsers.HeaderRow.FindControl("chkAll"), CheckBox)


        For Each row As GridViewRow In gvUsers.Rows
            'Dim chkrow As CheckBox = CType(gvBenfApprove.Rows(i).FindControl("chkApprove"), CheckBox)
            Dim chkrow As CheckBox = (row.FindControl("chkSelect"))
            chkrow.Checked = chk.Checked
        Next

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub
    Private Sub BindGrid()
        _ObjDs = _objAdminBll.Bgt_BindGrid(Session("vGPSOPID"))
        gvUsers.DataSource = _ObjDs
        gvUsers.DataBind()
    End Sub
    Protected Sub btnDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        Dim gpcodes As String = String.Empty
        Dim gpcodes1 As String = String.Empty
        Try
            Dim count As Integer = 0
            For Each row As GridViewRow In gvUsers.Rows
                Dim userInputField As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
                Dim Gpcode As Label = DirectCast(row.FindControl("GpCode"), Label)
                If userInputField.Checked = True Then
                    If count = 0 Then
                        gpcodes = Gpcode.Text
                        count = count + 1
                    Else
                        gpcodes = gpcodes & "." & Gpcode.Text
                        count = count + 1
                    End If

                End If
            Next
            Dim queryString As String = ""


            Dim Districtcode As Integer = 7
            Dim iRet As DataSet
            iRet = _objAdminBll.Bgt_BindDataDownload(Session("vGPSOPID"), gpcodes)
            ExportToCsvFromDataSet(iRet)


        Catch ex As Exception
            ErrorLog("RGRHCL --> Screen Name: HutLessFileDownload Method:btnViewReport_Click() " & ex.Message)
        End Try
    End Sub
    Private Sub ExportToCsvFromDataSet(ByVal dsExport As DataSet)
        Dim IsOutputStreamed As Boolean = False
        Try
            Dim dataToExport As New StringBuilder()
            For Each dtExport As DataTable In dsExport.Tables
                Dim bodyToExport As String = String.Empty
                Dim EmcrptyDataToExport As String = String.Empty
                For Each dRow As DataRow In dtExport.Rows
                    For Each obj As Object In dRow.ItemArray
                        bodyToExport = bodyToExport & obj.ToString() & ChrW(44)
                    Next
                    bodyToExport.Remove(bodyToExport.Length - 1, 1)
                    bodyToExport = bodyToExport + Environment.NewLine
                Next
                Dim Filenamefordownload As String = String.Empty
                Filenamefordownload = Date.Now.ToString("DD_MM_yyyy_HH_mm_ss_") & Convert.ToString(Session("UserName") & ".csv")
                Dim fileNamefordownloadpath As String = String.Empty
                fileNamefordownloadpath = Server.MapPath("~/GPSDownload/" & Filenamefordownload)
                dataToExport.Append(bodyToExport)
                If String.IsNullOrEmpty(dataToExport.ToString()) Then


                Else
                    Response.Clear()
                    Response.ContentType = "Text/vnd.ms-excel"
                    Response.AddHeader("Content-Disposition", "attachment;filename=Bagalkotnk.csv")
                    Response.Write(dataToExport.ToString())
                    IsOutputStreamed = True
                End If
            Next
        Catch ex As Exception
        Finally
            If IsOutputStreamed Then

                Response.End()

            End If
        End Try

    End Sub

    Protected Sub btnCheckList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckList.Click

        Dim gpcodes As String = String.Empty
        Dim gpcodes1 As String = String.Empty

        Dim count As Integer = 0
        For Each row As GridViewRow In gvUsers.Rows
            Dim userInputField As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
            Dim Gpcode As Label = DirectCast(row.FindControl("GpCode"), Label)
            If userInputField.Checked = True Then
                If count = 0 Then
                    gpcodes = Gpcode.Text
                    count = count + 1
                Else
                    gpcodes = gpcodes & "." & Gpcode.Text
                    count = count + 1
                End If
            End If
        Next
        Dim queryString As String = ""
        Dim Districtcode As Integer = 7

        Dim GPsOptId As Integer
        GPsOptId = Session("vGPSOPID")
        Dim strFnName As String = "ReportForm17(" & GPsOptId & "," & gpcodes & ");"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Msg", strFnName, True)
    End Sub
End Class
