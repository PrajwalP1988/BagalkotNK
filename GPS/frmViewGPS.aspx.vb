Imports RGRHCL_Web_App.Bgt_Bll
Imports LoggingBlock.CreateLogFiles
Imports System.Data
Imports System.IO
Imports System.Collections.Generic

Partial Class bagalkot_Entry_frmViewGPS
    Inherits System.Web.UI.Page
    Private _objAdminBll As ClsBgt_Bll
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        _objAdminBll = New ClsBgt_Bll()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindScheme()
            BindSeries()
        End If
    End Sub
    Private Sub BindScheme()
        Dim li As New ListItem
        Try
            ddlSchh.DataSource = _objAdminBll.Bgt_BindSCheme
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
            ddlSerr.DataSource = _objAdminBll.Bgt_BindSeries
            ddlSerr.DataTextField = "vSeriesName_Eng"
            ddlSerr.DataValueField = "vSeriesCode"
            ddlSerr.DataBind()
            li = New ListItem("--Select--", 0)
            ddlSerr.Items.Insert(0, li)
        Catch ex As Exception
            ErrorLog("RGRHCl--> Screen Name:SubSchemeMaster --> Method: BindDropBankName()" & ex.Message)
        End Try
    End Sub
    Protected Sub BindGrid(ByVal Chk As Integer)
        If Chk = 0 Then
            Dim dtResult As DataTable = Nothing
            Dim dvResults As New DataView(_objAdminBll.Bgt_BindGPSView(0).Tables(1))
            dvResults.RowFilter = "vSchemeCode='" + ddlSchh.SelectedValue + "'"
            dtResult = dvResults.ToTable()

            grd_ashraya1.DataSource = dtResult
            grd_ashraya1.DataBind()
        ElseIf Chk = 1 Then
            Dim dtResult As DataTable = Nothing
            Dim dvResults As New DataView(_objAdminBll.Bgt_BindGPSView(0).Tables(1))
            dvResults.RowFilter = "vSeriesYearCode='" + ddlSerr.SelectedValue + "'"
            dtResult = dvResults.ToTable()

            grd_ashraya1.DataSource = dtResult
            grd_ashraya1.DataBind()
        End If
    End Sub
    Protected Sub grd_ashraya1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd_ashraya1.PageIndexChanging
        grd_ashraya1.PageIndex = e.NewPageIndex
        If Session("Chk") = "0" Then
            BindGrid(0)
        ElseIf Session("Chk") = "1" Then
            BindGrid(1)
        End If
    End Sub
    Protected Sub grd_ashraya1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grd_ashraya1.RowCommand
        Try
            If e.CommandName = "Show" Then

                Session("Image1") = ""
                Session("Image2") = ""
                Session("Image3") = ""
                Session("Image4") = ""
                Session("Image5") = ""
                Session("Image6") = ""

                Image1.ImageUrl = ""
                Image2.ImageUrl = ""
                Image3.ImageUrl = ""
                Image4.ImageUrl = ""
                Image5.ImageUrl = ""
                Image6.ImageUrl = ""

                Dim index As String = e.CommandArgument.ToString
                lblMsg.Text = ""
                lblBenf.Text = "Work ID : " & index
                Session("Bcode") = index
                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Button).NamingContainer, GridViewRow)

                Dim ds As New DataSet()

                ds = _objAdminBll.Bgt_BindGPSView(index)
                Session("WorkID") = index

                If ds.Tables(3).Rows.Count > 0 Then
                    tblPhoto.Visible = True
                    Session("WorkID") = index

                    If ds.Tables(3) IsNot Nothing AndAlso ds.Tables(3).Rows.Count <> 0 Then

                        For Each drow As DataRow In ds.Tables(3).Rows
                            BindImageFromBase64String(drow)
                        Next

                    Else
                        Image1.ImageUrl = ""
                        Image2.ImageUrl = ""
                        Image3.ImageUrl = ""
                        Image4.ImageUrl = ""
                        Image5.ImageUrl = ""
                        Image6.ImageUrl = ""
                    End If
                End If

            End If

        Catch ex As Exception

        End Try
        If IsDBNull(Session("WorkID")) = True Then
        Else
            BindMap()
        End If
    End Sub

    Private Sub BindImageFromBase64String(row As DataRow)
        Dim imgDict As Dictionary(Of String, Image) = New Dictionary(Of String, Image)
        imgDict.Add("F", Image1)
        imgDict.Add("L", Image2)
        imgDict.Add("PL", Image3)
        imgDict.Add("R", Image4)
        imgDict.Add("Fn", Image5)
        imgDict.Add("C", Image6)
        Try
            If Not String.IsNullOrEmpty(row("F_Img1")) Then
                Dim imgView As New Image
                imgDict.TryGetValue(row("vStage"), imgView)
                imgView.ImageUrl = "data:image/png;base64," & row("F_Img1")
            End If
        Catch ex As Exception
            ErrorLog(ex.Message)
        End Try
    End Sub

    Protected Sub BindMap()
        Validation.Value = 1
        GetDataa1()
        tblMap.Visible = True
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Msg", "init();", True)
    End Sub
    Public Sub GetDataa1()
        Try
            Dim x As Integer = 0, z As Integer = 0
            Dim count As Integer = 1
            Dim CurURL As String = String.Empty
            Dim newstr As String = String.Empty
            CurURL = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath
            Dim ds As New DataSet()
            Dim ds1 As New DataSet()
            Dim coordinates As String = String.Empty, Stg As String
            Dim Cor As String = String.Empty
            Dim kmlstr As String = String.Empty
            Dim vLat As String = String.Empty
            Dim vLongi As String = String.Empty

            Dim filename As String = String.Empty

            ds1 = _objAdminBll.Bgt_BindGPSView(Integer.Parse(Session("WorkID")))

            For j As Integer = 0 To ds1.Tables(2).Rows.Count - 1
                x = ds1.Tables(2).Rows(j)("Ct") - 1
                Stg = ds1.Tables(2).Rows(j)("Stage").ToString()

                kmlstr += "<Folder>" & Environment.NewLine
                kmlstr += "<Placemark>" & Environment.NewLine
                kmlstr += "<name>Stage : " + Stg.ToString() + "</name>" & Environment.NewLine
                kmlstr += "<description><![CDATA[Work ID : " & Session("WorkID") & " ]]></description>" & Environment.NewLine
                kmlstr += "<styleUrl>#m_ylw-pushpin7</styleUrl>" & Environment.NewLine
                kmlstr += "<Point>" & Environment.NewLine

                For k As Integer = z To (x + z)
                    coordinates = coordinates & ds1.Tables(0).Rows(k)("vLong") & "," & ds1.Tables(0).Rows(k)("vLat") & ",0  "
                    If count = 1 Then
                        vLongi = ds1.Tables(0).Rows(k)("vLong")
                        vLat = ds1.Tables(0).Rows(k)("vLat")
                        Lat.Value = vLat
                        Long1.Value = vLongi
                    End If
                    count = count + 1
                Next
                Cor = coordinates & vLongi & "," & vLat & "," & "0" & Environment.NewLine

                kmlstr += "<coordinates>" + vLongi + "," + vLat + ",0</coordinates>" & Environment.NewLine
                kmlstr += "</Point>" & Environment.NewLine
                kmlstr += "</Placemark>" & Environment.NewLine
                kmlstr += "<Placemark>" & Environment.NewLine
                kmlstr += "<styleUrl>#m_ylw-pushpin7</styleUrl>" & Environment.NewLine
                kmlstr += "<Polygon>" & Environment.NewLine
                kmlstr += "<outerBoundaryIs>" & Environment.NewLine
                kmlstr += "<LinearRing>" & Environment.NewLine
                kmlstr += "<coordinates>" & Environment.NewLine
                kmlstr += Cor & Environment.NewLine
                kmlstr += "</coordinates>" & Environment.NewLine
                kmlstr += "</LinearRing>" & Environment.NewLine
                kmlstr += "</outerBoundaryIs>" & Environment.NewLine
                kmlstr += "</Polygon>" & Environment.NewLine
                kmlstr += "</Placemark>" & Environment.NewLine
                kmlstr += "</Folder>" & Environment.NewLine
                z = (z + x + 1)
                count = 1
                Cor = ""
                coordinates = ""
                vLat = ""
                vLongi = ""
            Next

            Dim tempkmlfilename As String = String.Empty
            tempkmlfilename = preparekmlfile1(kmlstr, "Work")
        Catch ex As Exception
            ErrorLog("GPS>frmViewGPS>GetDataa1>" & ex.Message.ToString())
        End Try
    End Sub
    Public Function preparekmlfile1(ByVal kmlstr As String, ByVal nm As String) As String
        Try
            Dim tempkmlfilepath, tempkmlfilename, sourcefile As String
            Dim rd As New Random
            tempkmlfilename = nm & rd.Next & ".kml"

            If nm = "Land" Then
                tempkmlfilepath = Server.MapPath("TempKMLFile/" & tempkmlfilename).Replace("\GPS", "")
                sourcefile = Server.MapPath("KML/Duplicate.kml")
                HdnValue.Value = tempkmlfilename
            Else
                tempkmlfilepath = Server.MapPath("TempKMLFile/" & tempkmlfilename).Replace("\GPS", "")
                sourcefile = Server.MapPath("KML/Duplicate.kml")
                'tempkmlfilepath = "E:\HostingSpaces\a0bf8a97\bagalkotnirmithikendra.in\wwwroot\TempKMLFile\" & tempkmlfilename
                'sourcefile = "E:\HostingSpaces\a0bf8a97\bagalkotnirmithikendra.in\wwwroot\GPS\KML\DuplicateValid.kml"
                HdnValid.Value = tempkmlfilename
            End If
            System.IO.File.Copy(sourcefile, tempkmlfilepath)
            kmlstr = kmlstr & "</Document>" & Environment.NewLine
            kmlstr = kmlstr & "</kml>" & Environment.NewLine
            WtitetokmlFile(kmlstr, tempkmlfilepath)
            Return 1
        Catch ex As Exception
            Return 1
        End Try
    End Function
    Private Sub ClearFile(ByVal FileName As String)
        Dim fi As New System.IO.FileInfo(FileName)
        If fi.Exists Then
            Dim fr As New System.IO.StreamWriter(FileName)
            fr.Close()
        End If
    End Sub
    Public Sub WtitetokmlFile(ByVal inputstr As String, ByVal filename As String)
        Try
            Dim sw As StreamWriter
            sw = New StreamWriter(filename, True)
            sw.WriteLine(inputstr)
            sw.Close()
        Catch ex As Exception
            'Console.WriteLine("UnSuccess    (WtitetokmlFile) -> Error in writing data to KML File")
        End Try
    End Sub

    Protected Sub ddlSchh_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSchh.SelectedIndexChanged
        BindGrid(0)
        Session("Chk") = "0"
    End Sub

    Protected Sub ddlSerr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSerr.SelectedIndexChanged
        BindGrid(1)
        Session("Chk") = "1"
    End Sub

End Class
