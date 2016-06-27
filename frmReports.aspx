<%@ Page Language="VB" MasterPageFile="~/SiteMaster/StaticMaster.master" AutoEventWireup="false" CodeFile="frmReports.aspx.vb" Inherits="frmReports" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="Up" runat="server">
<ContentTemplate>
<center>
<br />
<asp:Button ID="btnExport" runat="server" Text="Export To Excel" />
<br /><br />
<br /><br />
<asp:GridView ID="grdReports" runat="server" AutoGenerateColumns="false" Width="98%" SkinID="prgGrid">
<Columns>
<asp:BoundField DataField="Sl" HeaderText="1">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="2%" HorizontalAlign="Center" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="2%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="vWorkID" HeaderText="2">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="2%" HorizontalAlign="Center" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="2%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="vSchemeName_Eng" HeaderText="3">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Left" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="vSeriesName_Eng" HeaderText="4">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="vTalukName_Eng" HeaderText="5">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Left" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="vNameWork" HeaderText="6">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Left" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="DateofCommence" HeaderText="7">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="DateofComp" HeaderText="8">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="ProjectCost" HeaderText="9">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Right" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="Release" HeaderText="10">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Right" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="Expenditure" HeaderText="11">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Right" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="Balance" HeaderText="12">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Right" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="BalanceToBe" HeaderText="13">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Right" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="Stage" HeaderText="14">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="2%" HorizontalAlign="Center" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="2%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="CO" HeaderText="15">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="2%" HorizontalAlign="Center" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="2%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="UN" HeaderText="16">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="2%" HorizontalAlign="Center" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="2%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="vRemarks" HeaderText="17">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Left" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Center" />
</asp:BoundField>
</Columns>
</asp:GridView>
</center>
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="btnExport" />
</Triggers>
</asp:UpdatePanel>
</asp:Content>