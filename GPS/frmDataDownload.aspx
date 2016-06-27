<%@ Page Language="VB" MasterPageFile="~/SiteMaster/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmDataDownload.aspx.vb" Inherits="Bagalkot_Entry_frmDataDownload"
    Title="Untitled Page" Theme="Koppal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            display: inline-block;
            color: Black;
            border-style: None;
            border-width: 0px;
            margin: 0px;
            padding: 0px;
        }
    </style>

    <script language="javascript" type="text/javascript">
        function ReportForm17(GPSOptId, GpCodes) {

            var rptName = 'Rpt_CheckList_ReportBagalkot';
            var param = GPSOptId + ',' + GpCodes;
            var rptWindow = window.open('../Reports/NewReport.aspx?rptname=' + rptName + '&Param=' + param, 'childwindow7', 'scrollbars=1,width = 980,height = 700,menubar=yes,status=yes,resizable=yes,left=10,top=10');
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 class="title">
        DATA DOWNLOAD FOR GPS CAPTURING</h2>
    <center>
        <table id="tblStage1" runat="server" style="border-color: #062E5E; height: 180px;
            width: 440px;" frame="box">
            <tr>
                <td style="height: 159px">
                    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CellPadding="0" SkinID="prgGrid" Width="414px" CellSpacing="1" EmptyDataText="NO DATA FOUND">
                        <EmptyDataRowStyle Font-Names="Arial" Font-Size="12pt" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="GPCode" HeaderText="GPCode" Visible="False" />
                            <asp:TemplateField HeaderText="GpCode" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="GpCode" runat="server" BorderStyle="none" BorderWidth="0px" ForeColor="Black"
                                        ReadOnly="true" Text='<%# Bind("vTalukCode") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Taluk">
                                <ItemTemplate>
                                    <asp:Label ID="TalukName_Eng" runat="server" BorderStyle="none" BorderWidth="0px"
                                        ForeColor="Black" ReadOnly="true" Text='<%# Bind("vTalukName_Eng") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Font-Names="Arial" Font-Size="10pt" HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No. of Works">
                                <ItemTemplate>
                                    <asp:Label ID="count_gp" runat="server" BorderStyle="none" BorderWidth="0px" ForeColor="Black"
                                        ReadOnly="true" Text='<%# Bind("total") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Font-Names="Arial" Font-Size="10pt" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" Visible="true" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnDownload" runat="server" OnClick="btnDownload_Click" Text="Download"
                        Width="71px" BackColor="#062E5E" ForeColor="White" />
                    <asp:Button ID="btnCheckList" runat="server" Text="CheckList" Width="71px" BackColor="#062E5E"
                        ForeColor="White" />
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
