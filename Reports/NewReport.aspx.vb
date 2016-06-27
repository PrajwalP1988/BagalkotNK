Imports RGRHCL_Web_App.Bgt_Bll

Partial Class Reports_NewReport
    Inherits System.Web.UI.Page
    Dim objCls As New ClsBgt_Bll

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim Rpt As String = Request.QueryString("rptname").ToString()
            Dim str As String() = Request.QueryString("Param").Split(",")

            If Rpt = "Rpt_CheckList_ReportBagalkot" Then
                grdChkList.DataSource = objCls.Bgt_BindDataDownload(str(0), str(1))
                grdChkList.DataBind()
            End If
        End If
    End Sub
End Class
