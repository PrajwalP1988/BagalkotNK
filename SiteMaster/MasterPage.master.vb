Imports System.Data
Imports System.Data.Common
Imports System.DBNull
Imports System.Data.SqlClient
Imports System.DateTime
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Page
'Imports RGRHCL_Web_App.Admin_Bll
Imports LoggingBlock.CreateLogFiles
Imports System.Web.Security
Imports System.Web.UI.WebControls

Partial Class SiteMaster_MasterPage
    Inherits System.Web.UI.MasterPage
    Dim UserName As String
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session.Clear()
        Session.Abandon()
        Response.Cookies.Add(New HttpCookie("ASP.NET_SessionId", ""))
        Response.Redirect("~/frmLogin.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserName = Session("UserName").ToString()
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
        If Session("UserName") Is Nothing Then
            Response.Redirect("~/frmLogin.aspx")
        End If
        If (Left(Session("UserName").ToString(), 3) = "GPS") Or (Session("RoleId").ToString() = "GPS") Then
            Admin.Visible = False
            GPS.Visible = True
        Else
            Admin.Visible = True
            GPS.Visible = False
        End If
    End Sub
End Class

