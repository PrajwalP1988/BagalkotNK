Imports RGRHCL_Web_App.Bgt_Bll
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LoggingBlock.CreateLogFiles

Partial Class Release_frmRelExp
    Inherits System.Web.UI.Page
    Private _objAdminBll As ClsBgt_Bll
    Private _objKpl As New BgtProgress
    Private _ObjDs As New DataSet
    Private lblRel, lblExp, lblRem As Label
    Private txtRel, txtExp, txtRem As TextBox
    Private btnUp, btnCan As Button
    Private btEdit As ImageButton

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        _objAdminBll = New ClsBgt_Bll()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindScheme()
            BindSeries()
            BindDepartment()
            BindWorkNature()
            'grdRelExp.Visible = False
        End If
    End Sub
    Protected Sub BindScheme()
        Dim li As New ListItem
        Try
            ddlSchh.DataSource = _objAdminBll.Bgt_BindSCheme
            ddlSchh.DataTextField = "vSchemeName_Eng"
            ddlSchh.DataValueField = "vSchemeCode"
            ddlSchh.DataBind()
            li = New ListItem("--Select--", 0)
            ddlSchh.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:frmRelExp --> Method: BindScheme()" & ex.Message)
        End Try
    End Sub
    Protected Sub BindSeries()
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
            ErrorLog("RGRHCl--> Screen Name:frmRelExp --> Method: BindSeries()" & ex.Message)
        End Try
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
    Protected Sub grdRelExp_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdRelExp.PageIndexChanging
        grdRelExp.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub grdRelExp_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdRelExp.RowCancelingEdit
        BindData(3, e.RowIndex)
    End Sub

    Protected Sub grdRelExp_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdRelExp.RowEditing
        BindData(1, e.NewEditIndex)
    End Sub

    Protected Sub grdRelExp_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdRelExp.RowUpdating
        BindData(2, e.RowIndex)
    End Sub

    Protected Sub BindData(ByVal Cat As Integer, ByVal row As Integer)
        Dim gvr As GridViewRow = grdRelExp.Rows(row)
        lblRel = CType(gvr.FindControl("lblRelease"), Label)
        lblExp = CType(gvr.FindControl("lblExp"), Label)
        lblRem = CType(gvr.FindControl("lblRemarks"), Label)
        txtRel = CType(gvr.FindControl("txtRelease"), TextBox)
        txtExp = CType(gvr.FindControl("txtExp"), TextBox)
        txtRem = CType(gvr.FindControl("txtRemarks"), TextBox)
        btEdit = CType(gvr.FindControl("btnEdit"), ImageButton)
        btnUp = CType(gvr.FindControl("btnUpdate"), Button)
        btnCan = CType(gvr.FindControl("btnCancel"), Button)
        If Cat = 1 Then
            txtRel.Text = lblRel.Text
            txtExp.Text = lblExp.Text
            txtRem.Text = lblRem.Text
            lblRel.Visible = False
            lblExp.Visible = False
            lblRem.Visible = False
            txtRel.Visible = True
            txtExp.Visible = True
            txtRem.Visible = True
            btEdit.Visible = False
            btnUp.Visible = True
            btnCan.Visible = True
        ElseIf Cat = 2 Then
            _objAdminBll.Bgt_UpdateRel_Exp(CType(gvr.FindControl("lblWorkId"), Label).Text, txtRel.Text, txtExp.Text, txtRem.Text)
            lblRel.Visible = True
            lblExp.Visible = True
            lblRem.Visible = True
            txtRel.Visible = False
            txtExp.Visible = False
            txtRem.Visible = False
            btEdit.Visible = True
            btnUp.Visible = False
            btnCan.Visible = False
            txtRel.Text = ""
            txtRel.Text = ""
            txtRel.Text = ""
            BindModify(Session("lol"))
        ElseIf Cat = 3 Then
            lblRel.Visible = True
            lblExp.Visible = True
            lblRem.Visible = True
            txtRel.Visible = False
            txtExp.Visible = False
            txtRem.Visible = False
            btEdit.Visible = True
            btnUp.Visible = False
            btnCan.Visible = False
            txtRel.Text = ""
            txtRel.Text = ""
            txtRel.Text = ""
        End If
    End Sub
    Protected Sub BindModify(ByVal lol As Integer)
        Session("lol") = lol
        If lol = 1 Then
            grdRelExp.DataSource = _objAdminBll.Bgt_BindModify(0, Session("Chk"), ddlSchh.SelectedValue)
            grdRelExp.DataBind()
        ElseIf lol = 2 Then
            grdRelExp.DataSource = _objAdminBll.Bgt_BindModify(0, Session("Chk"), ddlSerr.SelectedValue)
            grdRelExp.DataBind()
        ElseIf lol = 3 Then
            grdRelExp.DataSource = _objAdminBll.Bgt_BindModify(0, Session("Chk"), ddlDept.SelectedValue)
            grdRelExp.DataBind()
        ElseIf lol = 4 Then
            grdRelExp.DataSource = _objAdminBll.Bgt_BindModify(0, Session("Chk"), ddlNatWork.SelectedValue)
            grdRelExp.DataBind()
        Else
            grdRelExp.DataSource = _objAdminBll.Bgt_BindModify(0, 0, 0)
            grdRelExp.DataBind()
        End If
        grdRelExp.Visible = True
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
End Class
