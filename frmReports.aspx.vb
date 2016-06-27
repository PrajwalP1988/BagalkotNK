Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.BoundField
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports RGRHCL_Web_App.Bgt_Bll

Partial Class frmReports
    Inherits System.Web.UI.Page
    Private clsobj As New ClsBgt_Bll

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            grdReports.DataSource = clsobj.Bgt_BindReport(0)
            grdReports.DataBind()
        End If
    End Sub

    Protected Sub grdReports_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdReports.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim HeaderGrid As GridView = DirectCast(sender, GridView)
            Dim HeaderGridRow As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert)
            Dim HeaderCell As New TableCell()
            HeaderCell.Text = ""
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.ColumnSpan = 13
            HeaderGridRow.Font.Size = 8
            HeaderGridRow.Font.Bold = True
            HeaderGridRow.Height = 20
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell()
            HeaderCell.Text = "Progress"
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.ColumnSpan = 1
            HeaderGridRow.Font.Size = 8
            HeaderGridRow.Font.Bold = True
            HeaderGridRow.Height = 20
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell()
            HeaderCell.Text = "Completed"
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.ColumnSpan = 1
            HeaderGridRow.Font.Bold = True
            HeaderGridRow.Font.Size = 8
            HeaderGridRow.Height = 20
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell()
            HeaderCell.Text = "UnStarted"
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.ColumnSpan = 1
            HeaderGridRow.Font.Bold = True
            HeaderGridRow.Font.Size = 8
            HeaderGridRow.Height = 20
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell()
            HeaderCell.Text = ""
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.ColumnSpan = 1
            HeaderGridRow.Font.Bold = True
            HeaderGridRow.Font.Size = 8
            HeaderGridRow.Height = 20
            HeaderGridRow.Cells.Add(HeaderCell)

            grdReports.Controls(0).Controls.AddAt(0, HeaderGridRow)

            Dim HeaderGridRow1 As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert)
            Dim HeaderCell1 As New TableCell()
            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Sl.No."
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Work ID"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Scheme"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Series"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Taluk"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Work Name"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Commencement of Project"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Completion of Project"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Project Cost"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Releases"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Expenditure"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Balance"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Bal. to be Rel."
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Physical Progress"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 3
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)

            HeaderCell1 = New TableCell()
            HeaderCell1.Text = "Remarks"
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center
            HeaderCell1.ColumnSpan = 1
            HeaderGridRow1.Font.Size = 8
            HeaderGridRow1.Font.Bold = True
            HeaderGridRow1.Height = 20
            HeaderGridRow1.Cells.Add(HeaderCell1)
            grdReports.Controls(0).Controls.AddAt(0, HeaderGridRow1)
        End If
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim filename As String = "Report.xls"
        Dim dtdata As DataTable = clsobj.Bgt_BindReport(0).Tables(0)
        Dim attach As String = "attachment;filename=" & filename
        Response.ClearContent()
        Response.ClearHeaders()
        Response.ContentType = "application/ms-excel"
        Response.AddHeader("content-disposition", attach)
        If dtdata IsNot Nothing Then
            For Each dc As DataColumn In dtdata.Columns
                Response.Write(dc.ColumnName + vbTab)
            Next
            Response.Write(System.Environment.NewLine)
            For Each dr As DataRow In dtdata.Rows
                For i As Integer = 0 To dtdata.Columns.Count - 1
                    Response.Write(dr(i).ToString() & vbTab)
                Next
                Response.Write(vbLf)
            Next
            'Response.[End]()
        End If
        Response.Flush()
        Response.Close()
    End Sub
End Class
