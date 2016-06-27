Imports RGRHCL_Web_App.Bgt_Bll
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LoggingBlock.CreateLogFiles
Imports System.Web.Security

Partial Class SiteMaster_StaticMaster
    Inherits System.Web.UI.MasterPage
    Private _objAdminBll As ClsBgt_Bll
    Private _loginStat As Boolean
    Public Sub New()
        _objAdminBll = New ClsBgt_Bll
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtUser.Focus()
    End Sub
    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim objDS As DataSet = New DataSet
        Dim RoleId As String = String.Empty
        Try
            objDS = _objAdminBll.Bgt_CheckLogin(txtUser.Text.Trim(), txtPwd.Text.Trim())
            If objDS.Tables(0).Rows.Count > 0 Then
                Session("DistrictCode") = objDS.Tables(0).Rows(0)("vDistrictCode")
                Session("TalukCode") = objDS.Tables(0).Rows(0)("vTalukCode")
                Session("DistrictName") = objDS.Tables(0).Rows(0)("vDistrictName_Eng")
                Session("TalukName") = objDS.Tables(0).Rows(0)("vTalukName_Eng")
                Session("RoleId") = objDS.Tables(0).Rows(0)("vRoleId").ToString
                If Session("RoleId") = "GPS" Then
                    Session("vGPSOPID") = objDS.Tables(0).Rows(0)("vGpsOptID").ToString
                    Session("UserName") = objDS.Tables(0).Rows(0)("vUserName").ToString
                    Response.Redirect("Home/frmHome.aspx")
                ElseIf Session("RoleId") = "1" Then
                    Session("UserName") = objDS.Tables(0).Rows(0)("vUserName").ToString
                    Response.Redirect("Home/frmHome.aspx")
                End If
            Else
                lblmsg.Text = "Inavlid User"
                lblmsg.ForeColor = Drawing.Color.Red
                txtUser.Text = ""
                txtPwd.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class

