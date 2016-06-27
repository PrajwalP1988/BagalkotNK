<%@ Page Language="VB" MasterPageFile="~/SiteMaster/MasterPage.master" AutoEventWireup="false" CodeFile="frmBlock.aspx.vb" Inherits="Bagalkot_Entry_frmBlock" title="Untitled Page" Theme="Koppal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <script language="javascript" type="text/javascript" >
        function Validation() {

            if (document.getElementById("ctl00_ContentPlaceHolder1_txtRemarks").value == "") {
                alert("Remarks is required !");
                return false;
            }
            else {
                return true;
            }
        }

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate><center>
<h2 class="title"> WORKS BLOCK</h2>

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

<asp:GridView ID="grdModify" Width="90%" SkinID="prgGrid" runat="server" AllowPaging="true" AutoGenerateColumns="false">
<Columns>
<asp:TemplateField HeaderText="Sl. No.">
<ItemTemplate>
<asp:Label ID="lblSl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
</ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="3%" HorizontalAlign="Center" />
<HeaderStyle Width="3%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Work ID">
<ItemTemplate>
<asp:Label ID="lblWorkId" runat="server" Text='<%#Bind("vWorkID")%>'></asp:Label>
</ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="5%" HorizontalAlign="Center" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Taluk">
<ItemTemplate>
<asp:Label ID="lblTaluk" runat="server" Text='<%#Bind("vTalukName_Eng")%>'></asp:Label>
</ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="5%" HorizontalAlign="Left" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Scheme">
<ItemTemplate>
<asp:Label ID="lblScheme" runat="server" Text='<%#Bind("vSchemeName_Eng")%>'></asp:Label>
</ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="5%" HorizontalAlign="Left" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Nature of Work">
<ItemTemplate>
<asp:Label ID="lblNature" runat="server" Text='<%#Bind("vWNature_Eng")%>'></asp:Label>
</ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="10%" HorizontalAlign="Left" />
<HeaderStyle Width="10%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Name of Work">
<ItemTemplate>
<asp:Label ID="lblName" runat="server" Text='<%#Bind("vNameWork")%>'></asp:Label>
</ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="10%" HorizontalAlign="Left" />
<HeaderStyle Width="10%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Total Units">
<ItemTemplate>
<asp:Label ID="lblTotal" runat="server" Text='<%#Bind("vTotalUnits")%>'></asp:Label>
</ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="5%" HorizontalAlign="Right" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Unit Cost">
<ItemTemplate>
<asp:Label ID="lblUnit" runat="server" Text='<%#Bind("vUnitCost")%>'></asp:Label>
</ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="5%" HorizontalAlign="Right" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Engineer Incharge">
<ItemTemplate>
<asp:Label ID="lblEngg" runat="server" Text='<%#Bind("VEnggName")%>'></asp:Label>
</ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="5%" HorizontalAlign="Left" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="GPS Operator">
<ItemTemplate>
<asp:Label ID="lblGPSOp" runat="server" Text='<%#Bind("vGPSOptName")%>'></asp:Label>
</ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="5%" HorizontalAlign="Left" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Block">
<ItemTemplate>
<asp:Label ID="lblBlock" runat="server" Text='<%#Bind("vBlock")%>'></asp:Label>
</ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="5%" HorizontalAlign="Center" />
<HeaderStyle Width="5%" HorizontalAlign="Center" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Edit">
<ItemTemplate>
<asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/edit.gif" CommandName="Edit" /></ItemTemplate>
<ItemStyle Font-Names="Arial" Font-Size="8pt" Width="3%" HorizontalAlign="Center" />
<HeaderStyle Width="3%" HorizontalAlign="Center" />
</asp:TemplateField>
</Columns>
</asp:GridView>
<br />

<fieldset id="fieldset1" style="border: 2px solid #405086; WIDTH: 820px;  background-color:#E9EAEC;" runat="server">
<table>
<tr><td align="right" style="width:200px;"><asp:Label ID="lblWorkId" runat="server" Text="Work ID : "></asp:Label></td>
<td align="left" style="width:200px;"><asp:Label ID="txtWorkID" runat="server" ></asp:Label></td>
<td align="right" style="width:200px;"><asp:Label ID="lblName" runat="server" Text="Work Name : "></asp:Label></td>
<td align="left" style="width:200px;"><asp:Label ID="txtName" runat="server" ></asp:Label></td></tr>

<tr><td align="right" style="width:200px;"><asp:Label ID="lblLocation" runat="server" Text="Location : "></asp:Label></td>
<td align="left" style="width:200px;"><asp:Label ID="txtLocation" runat="server" ></asp:Label></td>
<td align="right" style="width:200px;"><asp:Label ID="lblCost" runat="server" Text="Total Cost : "></asp:Label></td>
<td align="left" style="width:200px;"><asp:Label ID="txtCost" runat="server" ></asp:Label></td></tr>

<tr><td align="right" style="width:200px;"><asp:Label ID="lblReason" runat="server" Text="Reason : "></asp:Label></td>
<td align="left" colspan="3"><asp:TextBox ID="txtReason" runat="server" Width="600px" ></asp:TextBox></td></tr>

<tr><td align="right" colspan="2"><asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return Validation();" /></td>
<td align="left" colspan="2"><asp:Button ID="btnCan" runat="server" Text="Cancel" /></td></tr>

</table>
</fieldset>
</center>
<asp:HiddenField ID="hdn" runat="server" />
</ContentTemplate>
</asp:UpdatePanel> 
</asp:Content>

