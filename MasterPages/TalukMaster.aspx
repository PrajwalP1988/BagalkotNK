<%@ Page Language="VB" MasterPageFile="~/SiteMaster/MasterPage.master" AutoEventWireup="false"
    CodeFile="TalukMaster.aspx.vb" Inherits="Bagalkot_MasterPages_TalukMaster" Title="Untitled Page"
    Theme="Koppal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script language="javascript" type="text/javascript">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 class="title">
                Taluk Master</h2>
            <table cellspacing="2" cellpadding="2" width="60%" align="center" border="0">
                <tbody>
                    <tr>
                        <td align="center" width="100%" colspan="2">
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="true" EnableViewState="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="grdscheme" runat="server" AllowPaging="True" Width="80%" AutoGenerateColumns="False"
                                SkinID="prgGrid">
                                <Columns>
                                    <asp:TemplateField HeaderText="Taluk – English">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSchemeEng" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vTalukName_Eng")%>' />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Names="Arial" Font-Size="11pt"></HeaderStyle>
                                        <ItemStyle Height="5%" Width="30%" Font-Names="Arial" Font-Size="11pt"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Taluk - Kannada">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSchemeKan" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vTalukName_Kan")%>' />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Names="Arial" Font-Size="11pt"></HeaderStyle>
                                        <ItemStyle Height="5%" Width="30%" Font-Names="Arial" Font-Size="11pt"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" SkinID="btnEdit" />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Names="Arial" Font-Size="11pt"></HeaderStyle>
                                        <ItemStyle Height="5%" Width="3%" Font-Names="Arial" Font-Size="11pt"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSchemeCode" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vTalukCode")%>' />
                                        </ItemTemplate>
                                        <ItemStyle Height="5%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSchemeName" runat="server" Text="Taluk (English) :" Font-Names="Arial"
                                Font-Size="11pt"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSchemeName" TabIndex="1" runat="server" AutoCompleteType="disabled"
                                Font-Names="Arial" Font-Size="11pt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSchemeNameKan" runat="server" Text="Taluk (Kannada) :" Font-Names="Arial"
                                Font-Size="11pt"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSchemeName_Kan" TabIndex="2" runat="server" Font-Names="Arial Unicode ms"
                                Font-Bold="True" Width="145px" AutoCompleteType="disabled" Font-Size="11pt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnAdd" TabIndex="3" runat="server" Text="Add" OnClientClick="return ValidateScheme();">
                            </asp:Button>
                            <asp:Button ID="btnCancel" TabIndex="4" runat="server" Text="Cancel"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
