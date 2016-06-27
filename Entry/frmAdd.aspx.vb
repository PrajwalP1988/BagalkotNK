Imports RGRHCL_Web_App.Bgt_Bll
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LoggingBlock.CreateLogFiles
Imports System.IO
Partial Class Bagalkot_Entry_frmAdd
    Inherits System.Web.UI.Page
    Private _objAdminBll As ClsBgt_Bll
    Private _objBgt As New BgtProgress
    Private _ObjDs As New DataSet
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        _objAdminBll = New ClsBgt_Bll()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtTotal.Text = hdn.Value
        Try
            If Not IsPostBack Then
                BindTaluk()
                BindScheme()
                BindSeries()
                BindDepartment()

                BindGPSOp()
                BindEngg()
                BindWorkNature()
                txtDept.Visible = False
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
    Private Sub BindScheme()
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
    End Sub
    Private Sub BindSeries()
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
    End Sub
    Private Sub BindDepartment()
        Dim li As New ListItem
        Try
            _ObjDs = _objAdminBll.Bgt_BindDepartment
            drpDepartment.DataSource = _ObjDs
            drpDepartment.DataTextField = "vDeptName_Eng"
            drpDepartment.DataValueField = "vDeptID"
            drpDepartment.DataBind()
            li = New ListItem("--Select--", 0)
            drpDepartment.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDropBankName()" & ex.Message)
        End Try
    End Sub

    Private Sub BindWorkNature()
        Dim li As New ListItem
        Try
            _ObjDs = _objAdminBll.Bgt_BindWorkNature
            ddlNature.DataSource = _ObjDs
            ddlNature.DataTextField = "vWNature_Eng"
            ddlNature.DataValueField = "vWorkId"
            ddlNature.DataBind()
            li = New ListItem("--Select--", 0)
            ddlNature.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDropBankName()" & ex.Message)
        End Try
    End Sub
    Private Sub BindEngg()
        Dim li As New ListItem
        Try
            _ObjDs = _objAdminBll.Bgt_BindEngg
            drpEngginer.DataSource = _ObjDs
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
            _ObjDs = _objAdminBll.Bgt_BindGPSOperator
            ddlGPSOperator.DataSource = _ObjDs
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
            _objBgt.DocFile = BindDocuments()

            IRet = _objAdminBll.Bgt_AddBeneficiary(_objBgt)
            lblmsg.Text = "Added Successfully"
            lblmsg.ForeColor = Drawing.Color.Green
            lblmsg.Font.Bold = True
            ClearFields()
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
