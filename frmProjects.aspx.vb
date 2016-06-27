Imports RGRHCL_Web_App.Bgt_Bll

Partial Class frmProjects
    Inherits System.Web.UI.Page
    Private clsobj As New ClsBgt_Bll

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub

    Protected Sub grdProjects_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdProjects.PageIndexChanging
        grdProjects.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub grdProjects_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProjects.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblWork As Label = DirectCast(e.Row.FindControl("WorkID"), Label)
            Dim Img As Image = CType(e.Row.FindControl("Img"), Image)
            Img.ImageUrl = "data:image/jpg;base64," + clsobj.Bgt_BindReport(lblWork.Text).Tables(0).Rows(0)("F_Img1").ToString()
        End If
    End Sub

    Protected Sub BindGrid()
        grdProjects.DataSource = clsobj.Bgt_BindReport(0)
        grdProjects.DataBind()
    End Sub
End Class
