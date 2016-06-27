Imports RGRHCL_Web_App.Bgt_Bll
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LoggingBlock.CreateLogFiles
Partial Class Bagalkot_Entry_frmBlock
    Inherits System.Web.UI.Page
    Private _objAdminBll As ClsBgt_Bll
    Private _objBgt As New BgtProgress
    Private _ObjDs As New DataSet
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        _objAdminBll = New ClsBgt_Bll()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                BindScheme()
                BindSeries()
                BindDepartment()
                BindWorkNature()
                fieldset1.Visible = False
                grdModify.Visible = True
            End If
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:Page_Load(): '")
        End Try
    End Sub
    Protected Sub BindModify(ByVal lol As Integer)
        If lol = 1 Then
            grdModify.DataSource = _objAdminBll.Bgt_BindModify(0, Session("Chk"), ddlSchh.SelectedValue)
            grdModify.DataBind()
        ElseIf lol = 2 Then
            grdModify.DataSource = _objAdminBll.Bgt_BindModify(0, Session("Chk"), ddlSerr.SelectedValue)
            grdModify.DataBind()
        ElseIf lol = 3 Then
            grdModify.DataSource = _objAdminBll.Bgt_BindModify(0, Session("Chk"), ddlDept.SelectedValue)
            grdModify.DataBind()
        ElseIf lol = 4 Then
            grdModify.DataSource = _objAdminBll.Bgt_BindModify(0, Session("Chk"), ddlNatWork.SelectedValue)
            grdModify.DataBind()
        Else
            grdModify.DataSource = _objAdminBll.Bgt_BindModify(0, 0, 0)
            grdModify.DataBind()
        End If
    End Sub
    Private Sub ClearFields()
        txtReason.Text = ""
    End Sub
    Private Sub BindDepartment()
        Dim li As New ListItem
        Try
            ddlDept.DataSource = _objAdminBll.Bgt_BindDepartment
            ddlDept.DataTextField = "vDeptName_Eng"
            ddlDept.DataValueField = "vDeptID"
            ddlDept.DataBind()
            li = New ListItem("--Select--", 0)
            ddlDept.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDepartment()" & ex.Message)
        End Try
    End Sub

    Private Sub BindWorkNature()
        Dim li As New ListItem
        Try
            ddlNatWork.DataSource = _objAdminBll.Bgt_BindWorkNature
            ddlNatWork.DataTextField = "vWNature_Eng"
            ddlNatWork.DataValueField = "vWorkId"
            ddlNatWork.DataBind()
            li = New ListItem("--Select--", 0)
            ddlNatWork.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindWorkNature()" & ex.Message)
        End Try
    End Sub
    Protected Sub grdModify_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdModify.PageIndexChanging
        grdModify.PageIndex = e.NewPageIndex
        If Session("Chk") = "Scheme" Then
            BindModify(1)
        ElseIf Session("Chk") = "Series" Then
            BindModify(2)
        ElseIf Session("Chk") = "Department" Then
            BindModify(3)
        ElseIf Session("Chk") = "WorkNature" Then
            BindModify(4)
        End If
    End Sub

    Protected Sub grdModify_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdModify.RowEditing
        fieldset1.Visible = True
        grdModify.Visible = False

        Dim lblWork As Label
        Dim grd As GridViewRow = grdModify.Rows(e.NewEditIndex)
        lblWork = CType(grd.FindControl("lblWorkId"), Label)
        Session("WorkID") = lblWork.Text
        Dim dsgrd As DataSet = _objAdminBll.Bgt_BindModify(Integer.Parse(lblWork.Text), 0, 0)
        txtWorkID.Text = lblWork.Text
        txtName.Text = dsgrd.Tables(1).Rows(0)("vNameWork")
        txtLocation.Text = dsgrd.Tables(1).Rows(0)("vLocationProject")
        txtCost.Text = dsgrd.Tables(1).Rows(0)("vTotalCost")
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim IRet As Integer
            IRet = _objAdminBll.Bgt_BlockBeneficiary(Integer.Parse(Session("WorkID")), txtReason.Text)
            ClearFields()
            grdModify.Visible = True
            fieldset1.Visible = False
            BindModify(0)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddlSchh_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSchh.SelectedIndexChanged
        Session("Chk") = "Scheme"
        BindModify(1)
    End Sub

    Protected Sub ddlSerr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSerr.SelectedIndexChanged
        Session("Chk") = "Series"
        BindModify(2)
    End Sub
    Protected Sub ddlDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDept.SelectedIndexChanged
        Session("Chk") = "Department"
        BindModify(3)
    End Sub

    Protected Sub ddlNatWork_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNatWork.SelectedIndexChanged
        Session("Chk") = "WorkNature"
        BindModify(4)
    End Sub
    Protected Sub btnCan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCan.Click
        fieldset1.Visible = False
        grdModify.Visible = True
    End Sub
    Private Sub BindScheme()
        Dim li As New ListItem
        Try
            _ObjDs = _objAdminBll.Bgt_BindSCheme
            ddlSchh.DataSource = _ObjDs
            ddlSchh.DataTextField = "vSchemeName_Eng"
            ddlSchh.DataValueField = "vSchemeCode"
            ddlSchh.DataBind()
            li = New ListItem("--Select--", 0)
            ddlSchh.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDropBankName()" & ex.Message)
        End Try
    End Sub
    Private Sub BindSeries()
        Dim li As New ListItem
        Try
            _ObjDs = _objAdminBll.Bgt_BindSeries
            ddlSerr.DataSource = _ObjDs
            ddlSerr.DataTextField = "vSeriesName_Eng"
            ddlSerr.DataValueField = "vSeriesCode"
            ddlSerr.DataBind()
            li = New ListItem("--Select--", 0)
            ddlSerr.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDropBankName()" & ex.Message)
        End Try
    End Sub
End Class
