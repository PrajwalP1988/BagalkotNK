<%@ Page Language="VB" MasterPageFile="~/SiteMaster/MasterPage.master" AutoEventWireup="false" CodeFile="UserMaster.aspx.vb" Inherits="Bagalkot_MasterPages_UserMaster" title="Untitled Page"  Theme="Koppal"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script language="javascript" type="text/javascript" >
    function ValidateScheme()
    {
        if(document.getElementById('ctl00_ContentPlaceHolder1_txtSchemeName').value=="")
        {
            alert('Scheme Name(In English) is required !');
            document.getElementById('ctl00_ContentPlaceHolder1_txtSchemeName').focus();
            return false;
        }
        
      
        
        else
             return true;
        
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <h2 class="title">User Master</h2>
    <TABLE cellSpacing=2 cellPadding=2 width="60%" align=center border=0>
           <TBODY><TR><TD align=center width="100%" colSpan=2><asp:Label id="lblMsg" runat="server" Font-Bold="true" EnableViewState="false"></asp:Label> </TD></TR><TR><TD align=center colSpan=2>
        <asp:GridView id="grdscheme" runat="server" AllowPaging="True" Width="80%" AutoGenerateColumns="False" SkinID="prgGrid"><Columns>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
                                <asp:Label ID="lblSchemeEng2" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vGPSOptName")%>' />
                            
</ItemTemplate>

<HeaderStyle Font-Names="Arial" Font-Size="11pt"></HeaderStyle>

<ItemStyle Height="5%" Width="30%" Font-Names="Arial" Font-Size="11pt"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UserName"><ItemTemplate>
                                <asp:Label ID="lblSchemeEng" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vUserName")%>' />
                            
</ItemTemplate>

<HeaderStyle Font-Names="Arial" Font-Size="11pt"></HeaderStyle>

<ItemStyle Height="5%" Width="30%" Font-Names="Arial" Font-Size="11pt"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Password"><ItemTemplate>
                                <asp:Label ID="lblSchemeEng1" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vPassword")%>' />
                            
</ItemTemplate>

<HeaderStyle Font-Names="Arial" Font-Size="11pt"></HeaderStyle>

<ItemStyle Height="5%" Width="30%" Font-Names="Arial" Font-Size="11pt"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Edit"><ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" SkinID="btnEdit" />
                            
</ItemTemplate>

<HeaderStyle  Font-Names="Arial" Font-Size="11pt" ></HeaderStyle>

<ItemStyle Height="5%" Width="3%" Font-Names="Arial" Font-Size="11pt"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField Visible="False"><ItemTemplate>
                                <asp:Label ID="lblSchemeCode" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vGpsOptID")%>' />
                            
</ItemTemplate>

<ItemStyle Height="5%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField Visible="False"><ItemTemplate>
                                <asp:Label ID="lblUserCode" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vUserCode")%>' />
                            
</ItemTemplate>

<ItemStyle Height="5%"></ItemStyle>
</asp:TemplateField>
</Columns>
</asp:GridView> </TD></TR><TR><TD align=center colspan="2">
                   <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                       RepeatDirection="Horizontal" AutoPostBack="True">
                       <asp:ListItem Value="1">Admin</asp:ListItem>
                       <asp:ListItem Value="GPS">GPS Operator</asp:ListItem>
                   </asp:RadioButtonList>
                   </TD></TR>
                   <div id="ds" runat="server">
               <tr>
                   <td align="right" >
                       <asp:Label ID="lblSchemeName1" runat="server" Font-Names="Arial" 
                           Font-Size="11pt" Text="GPS Operator :"></asp:Label>
                   </td>
                   <td>
                       <asp:DropDownList ID="drpGPS" runat="server" AutoPostBack="True">
                       </asp:DropDownList>
                   </td>
               </tr></div>
               <TR><TD align=right>
                   <asp:Label ID="lblSchemeName" runat="server" Font-Names="Arial" 
                       Font-Size="11pt" Text="UserName :"></asp:Label>
                   </TD>
                   <td align="left">
                       <asp:TextBox ID="txtSchemeName" runat="server" AutoCompleteType="disabled" 
                           tabIndex="1"></asp:TextBox>
                   </td>
               </TR>
               <tr>
                   <td align="right">
                       <asp:Label ID="lblSchemeName0" runat="server" Font-Names="Arial" 
                           Font-Size="11pt" Text="Pasword"></asp:Label>
                   </td>
                   <td align="left">
                       <asp:TextBox ID="txtVIMEI" runat="server" AutoCompleteType="disabled" 
                           tabIndex="1"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td align="center" colspan="2">
                       <asp:Button ID="btnAdd" runat="server" Font-Names="Arial" Font-Size="11pt" 
                           OnClientClick="return ValidateScheme();" tabIndex="3" Text="Add" />
                       <asp:Button ID="btnCancel" runat="server" Font-Names="Arial" Font-Size="11pt" 
                           tabIndex="4" Text="Cancel" />
                   </td>
               </tr>
           </TBODY></TABLE>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

