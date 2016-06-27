<%@ Page Language="VB" MasterPageFile="~/SiteMaster/StaticMaster.master" AutoEventWireup="false" CodeFile="frmProjects.aspx.vb" Inherits="frmProjects" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="Up" runat="server">
<ContentTemplate>
<center>
<br />
<asp:GridView ID="grdProjects" runat="server" AutoGenerateColumns="false" AllowPaging="true" Width="95%" SkinID="prgGrid">
<Columns>
<asp:BoundField DataField="Sl" HeaderText="Sl.No.">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="5%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="vSchemeName_Eng" HeaderText="Scheme">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="15%" HorizontalAlign="Left" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="15%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="vSeriesName_Eng" HeaderText="Series">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Center" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="vTalukName_Eng" HeaderText="Taluk">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Left" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="vNameWork" HeaderText="Work Name">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Left" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="ProjectCost" HeaderText="Project Cost">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Right" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="Release" HeaderText="Release">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Right" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="Expenditure" HeaderText="Expenditure">
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Right" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="10%" HorizontalAlign="Center" />
</asp:BoundField>

<asp:TemplateField HeaderText="Image">
<ItemTemplate>
<asp:Image ID="Img" runat="server" Height="200px" Width="300px" />
</ItemTemplate>
<ItemStyle Font-Size="8pt" Font-Names="Arial" Width="30%" HorizontalAlign="Left" />
<HeaderStyle Font-Size="8pt" Font-Names="Arial" Width="30%" HorizontalAlign="Left" />
</asp:TemplateField>

<asp:TemplateField Visible="false">
<ItemTemplate>
<asp:Label ID="WorkID" runat="server" Text='<%#Bind("vWorkID") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</center>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>