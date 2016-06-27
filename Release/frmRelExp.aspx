<%@ Page Language="VB" MasterPageFile="~/SiteMaster/MasterPage.master" AutoEventWireup="false" CodeFile="frmRelExp.aspx.vb" Inherits="Release_frmRelExp" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" language="javascript">
    function validateNumber() {
        if (event.keyCode >= 48 && event.keyCode <= 57) {

        }
        else {
            event.keyCode = 0;
            alert("Enter Number Only.");
            return false;
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">Update Release/Expenditure</h2>
<br />
<center>

<fieldset style="border:2px solid; border-color:Maroon; width:1100px;">
<legend style="width:100px;"><asp:Label ID="lblSelect" runat="server" Text="Select : " Font-Bold="true" Font-Size="12pt"></asp:Label></legend>
<table width="1100px">

<tr><td align="center"><asp:Label ID="lblSchh" runat="server" Text="Scheme : " Font-Bold="true"></asp:Label></td>
<td align="center"><asp:Label ID="lblSerr" runat="server" Text="Series : " Font-Bold="true"></asp:Label></td>
<td align="center"><asp:Label ID="lblDept" runat="server" Text="Department : " Font-Bold="true"></asp:Label></td>
<td align="center"><asp:Label ID="lblNatWor" runat="server" Text="Nature of Work : " Font-Bold="true"></asp:Label></td></tr>

<tr><td align="left" style="width:200px;"><asp:DropDownList ID="ddlSchh" runat="server" AutoPostBack="true">
<asp:ListItem Text="--Select--" Value="0"></asp:ListItem></asp:DropDownList></td>

<td align="left" style="width:150px;"><asp:DropDownList ID="ddlSerr" runat="server" AutoPostBack="true">
<asp:ListItem Text="--Select--" Value="0"></asp:ListItem></asp:DropDownList></td>

<td align="left" style="width:200px;"><asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="true">
<asp:ListItem Text="--Select--" Value="0"></asp:ListItem></asp:DropDownList></td>

<td align="left" style="width:180px;"><asp:DropDownList ID="ddlNatWork" runat="server" AutoPostBack="true">
<asp:ListItem Text="--Select--" Value="0"></asp:ListItem></asp:DropDownList></td></tr>
</table>
</fieldset>

<br /><br />
<asp:GridView ID="grdRelExp" Width="90%" runat="server" AllowPaging="true" SkinID="prgGrid" AutoGenerateColumns="false">
<Columns>
<asp:TemplateField HeaderText="Sl. No.">
<ItemTemplate>
<asp:Label ID="lblSl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
</ItemTemplate>
<ItemStyle Width="5%" HorizontalAlign="Center" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Work ID">
<ItemTemplate>
<asp:Label ID="lblWorkId" runat="server" Text='<%#Bind("vWorkID")%>'></asp:Label>
</ItemTemplate>
<ItemStyle Width="5%" HorizontalAlign="Center" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Release">
<ItemTemplate>
<asp:Label ID="lblRelease" runat="server" Text='<%#Bind("vRelease")%>'></asp:Label>
<asp:TextBox ID="txtRelease" runat="server" Visible="false" onKeyUp="return validateNumber();" ></asp:TextBox>
</ItemTemplate>
<ItemStyle Width="5%" HorizontalAlign="Right" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Expenditure">
<ItemTemplate>
<asp:Label ID="lblExp" runat="server" Text='<%#Bind("vExpenditure")%>'></asp:Label>
<asp:TextBox ID="txtExp" runat="server" Visible="false" onKeyUp="return validateNumber();" ></asp:TextBox>
</ItemTemplate>
<ItemStyle Width="5%" HorizontalAlign="Right" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Remarks">
<ItemTemplate>
<asp:Label ID="lblRemarks" runat="server" Text='<%#Bind("vRemarks")%>'></asp:Label>
<asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="100%" Visible="false" ></asp:TextBox>
</ItemTemplate>
<ItemStyle Width="30%" HorizontalAlign="Left" />
<HeaderStyle Width="30%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Edit">
<ItemTemplate>
<asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.gif" CommandName="Edit" />
<asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" Visible="false" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" Visible="false" />
</ItemTemplate>
<ItemStyle Width="8%" HorizontalAlign="Center" />
<HeaderStyle Width="8%" HorizontalAlign="Center" />
</asp:TemplateField>

</Columns>
</asp:GridView>
</center>
</asp:Content>

