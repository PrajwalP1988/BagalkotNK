<%@ Page Language="VB" MasterPageFile="~/SiteMaster/MasterPage.master" AutoEventWireup="false" CodeFile="DeptMaster.aspx.vb" Inherits="Bagalkot_MasterPages_DeptMaster" title="Untitled Page"  Theme="Koppal"%>

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
        
        else if(document.getElementById('ctl00_ContentPlaceHolder1_txtSchemeName_Kan').value=="")
        {
            alert('Scheme Name(In Kannada) is required !');
            document.getElementById('ctl00_ContentPlaceHolder1_txtSchemeName_Kan').focus();
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
        <h2 class="title"> Department Master</h2>
    <TABLE cellSpacing=2 cellPadding=2 width="60%" align=center border=0>
           <TBODY><TR><TD align=center width="100%" colSpan=2><asp:Label id="lblMsg" runat="server" Font-Bold="true" EnableViewState="false"></asp:Label> </TD></TR><TR><TD align=center colSpan=2>
        <asp:GridView id="grdscheme" runat="server" AllowPaging="True" Width="80%" AutoGenerateColumns="False" SkinID="prgGrid"><Columns>

<asp:TemplateField HeaderText="Department – English"><ItemTemplate>
                                <asp:Label ID="lblSchemeEng" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vDeptName_Eng")%>' />
                            
</ItemTemplate>

<HeaderStyle Font-Names="Arial" Font-Size="11pt" ></HeaderStyle>

<ItemStyle Height="5%" Width="30%" Font-Names="Arial" Font-Size="11pt"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Department - Kannada"><ItemTemplate>
                                <asp:Label ID="lblSchemeKan" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vDeptName_Kan")%>' />
                            
</ItemTemplate>

<HeaderStyle Font-Names="Arial" Font-Size="11pt" ></HeaderStyle>

<ItemStyle Height="5%" Width="30%" Font-Names="Arial" Font-Size="11pt"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Edit"><ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" SkinID="btnEdit" />
                            
</ItemTemplate>

<HeaderStyle Font-Names="Arial" Font-Size="11pt"></HeaderStyle>

<ItemStyle Font-Names="Arial" Font-Size="11pt" Height="5%" Width="3%"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField Visible="False"><ItemTemplate>
                                <asp:Label ID="lblSchemeCode" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vDeptID")%>' />
                            
</ItemTemplate>

<ItemStyle Height="5%"></ItemStyle>
</asp:TemplateField>
</Columns>
</asp:GridView> 
               <asp:HiddenField ID="HiddenField1" runat="server" />
               </TD></TR><TR><TD align=right>
                   <asp:Label ID="lblSchemeName" runat="server" Font-Names="Arial" 
                       Font-Size="11pt" Text="Department (English) :"></asp:Label>
                   </TD><TD align=left>
                       <asp:TextBox ID="txtSchemeName" runat="server" AutoCompleteType="disabled" 
                           Font-Names="Arial" Font-Size="11pt" tabIndex="1"></asp:TextBox>
                   </TD></TR><TR><TD align=right>
                   <asp:Label ID="lblSchemeNameKan" runat="server" Font-Names="Arial" 
                       Font-Size="11pt" Text="Department (Kannada) :"></asp:Label>
                   </TD>
                   <td align="left">
                       <asp:TextBox ID="txtSchemeName_Kan" runat="server" AutoCompleteType="disabled" 
                           Font-Bold="True" Font-Names="Arial Unicode ms" Font-Size="11pt" tabIndex="2" 
                           Width="145px"></asp:TextBox>
                   </td>
               </TR><TR><TD colSpan=2 align="center">
                   <asp:Button ID="btnAdd" runat="server" OnClientClick="return ValidateScheme();" 
                       tabIndex="3" Text="Add" />
                   <asp:Button ID="btnCancel" runat="server" tabIndex="4" Text="Cancel" />
                   </TD></TR></TBODY></TABLE>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

