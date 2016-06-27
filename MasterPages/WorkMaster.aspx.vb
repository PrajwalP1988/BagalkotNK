Imports RGRHCL_Web_App.Bgt_Bll
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LoggingBlock.CreateLogFiles
Partial Class Bagalkot_MasterPages_WorkMaster
    Inherits System.Web.UI.Page
    Private _objAdminBll As ClsBgt_Bll
    Private _objBgt As New BgtProgress
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        _objAdminBll = New ClsBgt_Bll()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not IsPostBack Then

                BindData()
            End If
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:Page_Load(): '")
        End Try


    End Sub
    Private Sub BindData()
        grdscheme.DataSource = _objAdminBll.Bgt_BindWorkNature
        grdscheme.DataBind()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            SaveDetails()
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:Page_Load(): '")
        End Try

    End Sub
    Private Sub SaveDetails()
        Dim iRes As Integer
        Dim strMsg As String
        Dim WorkCate As String
        Try
            _objBgt.WorkNature_Eng = txtSchemeName.Text
            _objBgt.WorkNature_Kan = txtSchemeName_Kan.Text
            WorkCate = rdoGPs.SelectedValue
            If btnAdd.Text = "Add" Then
                _objBgt.WorkId = 0
                strMsg = "Added Successfully"
                iRes = _objAdminBll.Bgt_AddNatureofWork(_objBgt, WorkCate)
            Else
                _objBgt.WorkId = Session("WorkCode")
                strMsg = "Updated Successfully"
                iRes = _objAdminBll.Bgt_AddNatureofWork(_objBgt, WorkCate)
            End If

            If iRes = 1 Then
                lblMsg.ForeColor = Drawing.Color.Green
                lblMsg.Text = strMsg
                ClearFields()
                BindData()
            ElseIf iRes = 0 Then
                lblMsg.ForeColor = Drawing.Color.Red
                lblMsg.Text = "Record already exists ...."
            Else
                lblMsg.ForeColor = Drawing.Color.Red
                lblMsg.Text = "Error in saving ...."
            End If
        Catch ex As Exception
            lblMsg.ForeColor = Drawing.Color.Red
            lblMsg.Text = "Error in Database Connection ..."
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:SaveDetails(): '")
        End Try
    End Sub

    Protected Sub grdscheme_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdscheme.RowEditing
        Try
            PopulateData(e.NewEditIndex)
            btnAdd.Text = "Update"
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:grdscheme_RowEditing(): '")
        End Try
    End Sub
    Private Sub PopulateData(ByVal intRowIndex As Integer)
        Try

            Dim lblgrdSchemeCode As Label = CType(grdscheme.Rows(intRowIndex).FindControl("lblSchemeCode"), Label)
            Session("WorkCode") = lblgrdSchemeCode.Text

            txtSchemeName.Text = CType(grdscheme.Rows(intRowIndex).FindControl("lblSchemeEng"), Label).Text
            txtSchemeName_Kan.Text = CType(grdscheme.Rows(intRowIndex).FindControl("lblSchemeKan"), Label).Text
            rdoGPs.SelectedValue = CType(grdscheme.Rows(intRowIndex).FindControl("lblSchemeCat"), Label).Text
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:PopulateData(): '")
        End Try

    End Sub

    Protected Sub grdscheme_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdscheme.PageIndexChanging
        Try
            grdscheme.PageIndex = e.NewPageIndex
            BindData()
            grdscheme.DataBind()
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:grdscheme_PageIndexChanging(): '")
        End Try

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            ClearFields()
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:btnCancel_Click(): '")
        End Try

    End Sub
    Private Sub ClearFields()
        Try
            txtSchemeName.Text = String.Empty
            txtSchemeName_Kan.Text = String.Empty
            btnAdd.Text = "Add"
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:ClearFields(): '")
        End Try

    End Sub
End Class
