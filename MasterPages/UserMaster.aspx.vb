Imports RGRHCL_Web_App.Bgt_Bll
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LoggingBlock.CreateLogFiles
Partial Class Bagalkot_MasterPages_UserMaster
    Inherits System.Web.UI.Page
    Private _objAdminBll As ClsBgt_Bll
    Private _objBgt As New BgtProgress
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        _objAdminBll = New ClsBgt_Bll()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not IsPostBack Then

                ds.Visible = False
            End If
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:Page_Load(): '")
        End Try


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
        Dim Drp As Integer
        Dim UserName As String
        Dim Pasword As String
        Dim x As Integer
        Try
            UserName = txtSchemeName.Text
            Pasword = txtVIMEI.Text
            If drpGPS.Visible = True Then
                Drp = drpGPS.SelectedValue
            Else
                Drp = 0
            End If
            If btnAdd.Text = "Add" Then

                strMsg = "Added Successfully"
                iRes = _objAdminBll.Bgt_AddUser(UserName, Pasword, 0, RadioButtonList2.SelectedValue, Drp)
            Else
                x = Session("lblUserCode")
                strMsg = "Updated Successfully"
                iRes = _objAdminBll.Bgt_AddUser(UserName, Pasword, x, RadioButtonList2.SelectedValue, Drp)
            End If

            If iRes = 1 Then
                lblMsg.ForeColor = Drawing.Color.Green
                lblMsg.Text = strMsg
                ClearFields()

                Binddata(1)
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

            Dim lblgrdSchemeCode As Label = CType(grdscheme.Rows(intRowIndex).FindControl("lblUserCode"), Label)
            Session("lblUserCode") = lblgrdSchemeCode.Text
            Dim lblgrdSchemeCode1 As Label = CType(grdscheme.Rows(intRowIndex).FindControl("lblSchemeCode"), Label)
            Session("lblSchemeCode") = lblgrdSchemeCode1.Text


            txtSchemeName.Text = CType(grdscheme.Rows(intRowIndex).FindControl("lblSchemeEng"), Label).Text
            txtVIMEI.Text = CType(grdscheme.Rows(intRowIndex).FindControl("lblSchemeEng1"), Label).Text
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:schememaster Method:PopulateData(): '")
        End Try

    End Sub

    Protected Sub grdscheme_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdscheme.PageIndexChanging
        Try
            grdscheme.PageIndex = e.NewPageIndex

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
    Private Sub Binddata(ByVal Ref As String)
        Dim _obj As DataSet
        _obj = _objAdminBll.Bgt_BindUSer(Ref)
        grdscheme.DataSource = _obj
        grdscheme.DataBind()
    End Sub
    Protected Sub RadioButtonList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList2.SelectedIndexChanged
        If RadioButtonList2.SelectedValue = "1" Then
            Binddata(RadioButtonList2.SelectedValue)
            ds.Visible = False
        Else
            grdscheme.DataSource = Nothing
            grdscheme.DataBind()
            ds.Visible = True
            BindGPSOp()
        End If
    End Sub
    Private Sub BindGPSOp()
        Dim _ObjDs As DataSet
        Dim li As New ListItem
        Try
            _ObjDs = _objAdminBll.Bgt_BindGPSOperator
            drpGPS.DataSource = _ObjDs
            drpGPS.DataTextField = "vGPSOptName"
            drpGPS.DataValueField = "vGpsOptID"
            drpGPS.DataBind()
            li = New ListItem("--Select--", 0)
            drpGPS.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDropBankName()" & ex.Message)
        End Try
    End Sub

    Protected Sub drpGPS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpGPS.SelectedIndexChanged
        Dim _ObjDs As DataSet
        _ObjDs = _objAdminBll.Bgt_BindGPSOperatorUser(drpGPS.SelectedValue)
        If _ObjDs.Tables(0).Rows.Count > 0 Then
            grdscheme.DataSource = _ObjDs
            grdscheme.DataBind()
        Else
            grdscheme.DataSource = Nothing
            grdscheme.DataBind()
        End If
    End Sub
End Class
