Imports RGRHCL_Web_App.Bgt_Bll
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LoggingBlock.CreateLogFiles
Partial Class Bagalkot_MasterPages_SeriesYearMaster
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
        grdscheme.DataSource = _objAdminBll.Bgt_BindSeries
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

        Try
            _objBgt.Series = txtSchemeName.Text


            If btnAdd.Text = "Add" Then
                _objBgt.SeriesYearCode = 0
                strMsg = "Added Successfully"
                iRes = _objAdminBll.Bgt_AddSeries(_objBgt)
            Else
                _objBgt.SeriesYearCode = Session("SeriesYearCode")
                strMsg = "Updated Successfully"
                iRes = _objAdminBll.Bgt_AddSeries(_objBgt)
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
            Session("SeriesYearCode") = lblgrdSchemeCode.Text

            txtSchemeName.Text = CType(grdscheme.Rows(intRowIndex).FindControl("lblSchemeEng"), Label).Text

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

            btnAdd.Text = "Add"
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:ClearFields(): '")
        End Try

    End Sub
End Class
