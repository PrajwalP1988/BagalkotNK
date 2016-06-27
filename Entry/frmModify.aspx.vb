Imports RGRHCL_Web_App.Bgt_Bll
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LoggingBlock.CreateLogFiles
Imports System.IO
Partial Class Bagalkot_Entry_frmModify
    Inherits System.Web.UI.Page
    Private _objAdminBll As ClsBgt_Bll
    Private _objBgt As New BgtProgress
    Private _ObjDs As New DataSet
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        _objAdminBll = New ClsBgt_Bll()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'txtTotal.Text = hdn.Value
        Try
            If Not IsPostBack Then
                BindScheme(1)
                BindSeries(1)
                BindDepartment(1)
                BindWorkNature(1)
                fieldset1.Visible = False
                grdModify.Visible = True
            End If
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:Page_Load(): '")
        End Try
    End Sub
    Private Sub BindTaluk()
        Dim li As New ListItem
        Try
            _ObjDs = _objAdminBll.Bgt_BindTaluk(7)
            ddlTaluk.DataSource = _ObjDs
            ddlTaluk.DataTextField = "vTalukName_Eng"
            ddlTaluk.DataValueField = "vTalukCode"
            ddlTaluk.DataBind()
            li = New ListItem("--Select--", 0)
            ddlTaluk.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDropBankName()" & ex.Message)
        End Try
    End Sub

    Private Sub BindScheme(ByVal Cat As Integer)
        If Cat = 1 Then
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
        Else
            Dim li As New ListItem
            Try
                _ObjDs = _objAdminBll.Bgt_BindSCheme
                ddlScheme.DataSource = _ObjDs
                ddlScheme.DataTextField = "vSchemeName_Eng"
                ddlScheme.DataValueField = "vSchemeCode"
                ddlScheme.DataBind()
                li = New ListItem("--Select--", 0)
                ddlScheme.Items.Insert(0, li)
            Catch ex As Exception
                ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDropBankName()" & ex.Message)
            End Try
        End If
    End Sub
    Private Sub BindSeries(ByVal Cat As Integer)
        If Cat = 1 Then
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
        Else
            Dim li As New ListItem
            Try
                _ObjDs = _objAdminBll.Bgt_BindSeries
                ddlSeriesYEar.DataSource = _ObjDs
                ddlSeriesYEar.DataTextField = "vSeriesName_Eng"
                ddlSeriesYEar.DataValueField = "vSeriesCode"
                ddlSeriesYEar.DataBind()
                li = New ListItem("--Select--", 0)
                ddlSeriesYEar.Items.Insert(0, li)
            Catch ex As Exception
                ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDropBankName()" & ex.Message)
            End Try
        End If
    End Sub
    Private Sub BindDepartment(ByVal Cat As Integer)
        If Cat = 1 Then
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
        Else
            Dim li As New ListItem
            Try
                drpDepartment.DataSource = _objAdminBll.Bgt_BindDepartment
                drpDepartment.DataTextField = "vDeptName_Eng"
                drpDepartment.DataValueField = "vDeptID"
                drpDepartment.DataBind()
                li = New ListItem("--Select--", 0)
                drpDepartment.Items.Insert(0, li)
            Catch ex As Exception
                ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDepartment()" & ex.Message)
            End Try
        End If
    End Sub

    Private Sub BindWorkNature(ByVal Cat As Integer)
        Dim li As New ListItem
        If Cat = 1 Then
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
        Else
            Try
                ddlNature.DataSource = _objAdminBll.Bgt_BindWorkNature
                ddlNature.DataTextField = "vWNature_Eng"
                ddlNature.DataValueField = "vWorkId"
                ddlNature.DataBind()
                li = New ListItem("--Select--", 0)
                ddlNature.Items.Insert(0, li)
            Catch ex As Exception
                ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindWorkNature()" & ex.Message)
            End Try
        End If
    End Sub
    Private Sub BindEngg()
        Dim li As New ListItem
        Try
            drpEngginer.DataSource = _objAdminBll.Bgt_BindEngg
            drpEngginer.DataTextField = "VEnggName"
            drpEngginer.DataValueField = "vEnggID"
            drpEngginer.DataBind()
            li = New ListItem("--Select--", 0)
            drpEngginer.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDropBankName()" & ex.Message)
        End Try
    End Sub
    Private Sub BindGPSOp()
        Dim li As New ListItem
        Try
            ddlGPSOperator.DataSource = _objAdminBll.Bgt_BindGPSOperator
            ddlGPSOperator.DataTextField = "vGPSOptName"
            ddlGPSOperator.DataValueField = "vGpsOptID"
            ddlGPSOperator.DataBind()
            li = New ListItem("--Select--", 0)
            ddlGPSOperator.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDropBankName()" & ex.Message)
        End Try
    End Sub

    Protected Sub ddlTechSanc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTechSanc.SelectedIndexChanged
        If ddlTechSanc.SelectedValue = "1" Then
            tsSan.Visible = True
        Else
            tsSan.Visible = False
        End If
    End Sub

    Protected Sub ddlAdminSanc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAdminSanc.SelectedIndexChanged
        If ddlAdminSanc.SelectedValue = "1" Then
            refSan.Visible = True
        Else
            refSan.Visible = False
        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedValue = "1" Then
            drpDepartment.Visible = True
            txtDept.Visible = False
        Else
            drpDepartment.Visible = False
            txtDept.Visible = True
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim IRet As Integer
            Dim DeptName As String
            _objBgt.TalukCode = ddlTaluk.SelectedValue
            _objBgt.SchemeCode = ddlScheme.SelectedValue
            _objBgt.SeriesYearCode = ddlSeriesYEar.SelectedValue

            If RadioButtonList1.SelectedValue = "1" Then
                _objBgt.DeptId = drpDepartment.SelectedValue
            Else
                DeptName = txtDept.Text
            End If
            _objBgt.WorkId = ddlNature.SelectedValue
            _objBgt.Work = txtNameWork.Text

            _objBgt.Location = txtLocation.Text
            _objBgt.Nuntis = txtNUnits.Text
            _objBgt.Tuntis = txtTUnits.Text
            _objBgt.Unitcost = txtUnitCost.Text
            _objBgt.TotalCost = txtTotal.Text
            If ddlTechSanc.SelectedValue = "1" Then

                _objBgt.TSDate = txtTSDate.Text
            End If
            If ddlAdminSanc.SelectedValue = "1" Then
                _objBgt.RefNumber = txtRefNo.Text
                _objBgt.RefDate = txtRefDate.Text
            End If
            _objBgt.GPSOperator = ddlGPSOperator.SelectedValue
            _objBgt.EnggId = drpEngginer.SelectedValue

            If hdDoc.Value = 0 Then
                _objBgt.DocFile = BindDocuments()
            Else
            End If

            IRet = _objAdminBll.Bgt_ModifyBeneficiary(Integer.Parse(Session("WorkID")), _objBgt)
            lblmsg.Text = "Updated Successfully"
            'BindModify(0)
            'lblmsg.ForeColor = Drawing.Color.Green
            'lblmsg.Font.Bold = True
            'ClearFields()
            'grdModify.Visible = True
            'fieldset1.Visible = False
            fieldset1.Visible = False
            grdModify.Visible = True
            'BindModify(0)
        Catch ex As Exception
            lblmsg.Text = "Error in Adding"
            lblmsg.ForeColor = Drawing.Color.Green
            lblmsg.Font.Bold = True
        End Try
    End Sub
    Private Sub ClearFields()
        ddlSeriesYEar.SelectedValue = 0
        ddlTaluk.SelectedValue = 0
        ddlScheme.SelectedValue = 0
        drpDepartment.SelectedValue = 0
        ddlNature.SelectedValue = 0
        txtNameWork.Text = ""
        txtLocation.Text = ""
        txtNUnits.Text = ""
        txtTUnits.Text = ""
        txtUnitCost.Text = ""
        txtTotal.Text = ""

        txtTSDate.Text = ""
        ddlGPSOperator.SelectedValue = 0
        txtRefNo.Text = ""
        txtRefDate.Text = ""
        drpEngginer.SelectedValue = 0

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

        BindTaluk()
        BindScheme(0)
        BindSeries(0)
        BindDepartment(0)

        BindGPSOp()
        BindEngg()
        BindWorkNature(0)
        txtDept.Visible = False

        Dim lblWork As Label
        Dim grd As GridViewRow = grdModify.Rows(e.NewEditIndex)
        lblWork = CType(grd.FindControl("lblWorkId"), Label)
        Session("WorkID") = lblWork.Text
        Dim dsgrd As DataSet = _objAdminBll.Bgt_BindModify(Integer.Parse(lblWork.Text), 0, 0)

        ddlTaluk.SelectedValue = Convert.ToInt32(dsgrd.Tables(1).Rows(0)("vTalukCode"))
        ddlScheme.SelectedValue = Convert.ToInt32(dsgrd.Tables(1).Rows(0)("vSchemeCode"))
        ddlSeriesYEar.SelectedValue = Convert.ToInt32(dsgrd.Tables(1).Rows(0)("vSeriesYearCode"))
        ddlTaluk.SelectedValue = Convert.ToInt32(dsgrd.Tables(1).Rows(0)("vTalukCode"))
        ddlNature.SelectedValue = Convert.ToInt32(dsgrd.Tables(1).Rows(0)("vWNature"))
        txtNameWork.Text = dsgrd.Tables(1).Rows(0)("vNameWork")
        txtLocation.Text = dsgrd.Tables(1).Rows(0)("vLocationProject")
        txtNUnits.Text = dsgrd.Tables(1).Rows(0)("vNoUnits")
        txtTUnits.Text = dsgrd.Tables(1).Rows(0)("vTotalUnits")
        txtUnitCost.Text = dsgrd.Tables(1).Rows(0)("vUnitCost")
        txtTotal.Text = dsgrd.Tables(1).Rows(0)("vTotalCost")
        drpEngginer.SelectedValue = Convert.ToInt32(dsgrd.Tables(1).Rows(0)("vEngginer"))
        ddlGPSOperator.SelectedValue = Convert.ToInt32(dsgrd.Tables(1).Rows(0)("vGpsOptr"))

        If IsDBNull(dsgrd.Tables(1).Rows(0)("vDeptName")) Then
            RadioButtonList1.SelectedValue = 1
            txtDept.Visible = False
            drpDepartment.Visible = True
            drpDepartment.SelectedValue = Convert.ToInt32(dsgrd.Tables(1).Rows(0)("vDeptID"))
        Else
            RadioButtonList1.SelectedValue = 2
            txtDept.Visible = False
            drpDepartment.Visible = True
            txtDept.Text = dsgrd.Tables(1).Rows(0)("vDeptName")
        End If

        If IsDBNull(dsgrd.Tables(1).Rows(0)("vTsNumber")) Then
            ddlTechSanc.SelectedValue = 2
            tsSan.Visible = False
        Else
            ddlTechSanc.SelectedValue = 1
            txtTSDate.Text = dsgrd.Tables(1).Rows(0)("vTsDate")
            tsSan.Visible = True
        End If

        If IsDBNull(dsgrd.Tables(1).Rows(0)("vRefNo")) Then
            ddlAdminSanc.SelectedValue = 2
            refSan.Visible = False
        Else
            ddlAdminSanc.SelectedValue = 1
            txtRefNo.Text = dsgrd.Tables(1).Rows(0)("vRefNo")
            txtRefDate.Text = dsgrd.Tables(1).Rows(0)("vRefDate")
            refSan.Visible = True
        End If

        btnView.Visible = True
        btnNew.Visible = True
        fuDoc.Visible = False
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        fieldset1.Visible = False
        grdModify.Visible = True
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

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        GetDocuments("vDocument")
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        btnView.Visible = False
        btnNew.Visible = False
        hdDoc.Value = 0
        fuDoc.Visible = True
    End Sub
    Protected Sub GetDocuments(ByVal Name As String)
        Try
            Response.ClearContent()
            Response.ClearHeaders()
            Response.ContentType = "application/vnd.pdf"
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Name + ".pdf")
            Response.BinaryWrite(Convert.FromBase64String(_objAdminBll.Bgt_BindDoc(Session("WorkID")).Tables(0).Rows(0)(Name)))
            Response.Flush()
            Response.End()
        Catch ex As Exception
        End Try
    End Sub
    Protected Function BindDocuments() As String
        Dim rd As New Random
        Dim Name As String = rd.Next
        Dim pdfBytes() As Byte
        Dim Certificate As String = String.Empty, sPath1 As String
        Try
            If fuDoc.HasFile And fuDoc.PostedFile.ContentType = "application/pdf" Then
                fuDoc.SaveAs(Server.MapPath("") & Name)
                sPath1 = Server.MapPath("") & Name
                pdfBytes = File.ReadAllBytes(sPath1)
                Certificate = Convert.ToBase64String(pdfBytes)
            End If
        Catch ex As Exception
        End Try
        Return Certificate
    End Function
End Class
