<%@ Page Language="VB" MasterPageFile="~/SiteMaster/MasterPage.master" AutoEventWireup="false" CodeFile="SeriesYearMaster.aspx.vb" Inherits="Bagalkot_MasterPages_SeriesYearMaster" title="Untitled Page"  Theme="Koppal"%>

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
        <h2 class="title"> Series Year</h2>
    <TABLE cellSpacing=2 cellPadding=2 width="60%" align=center border=0>
           <TBODY><TR><TD align=center width="100%" colSpan=2><asp:Label id="lblMsg" runat="server" Font-Bold="true" EnableViewState="false"></asp:Label> </TD></TR><TR><TD align=center colSpan=2>
        <asp:GridView id="grdscheme" runat="server" AllowPaging="True" Width="80%" AutoGenerateColumns="False" SkinID="prgGrid"><Columns>

<asp:TemplateField HeaderText="Series Year"><ItemTemplate>
                                <asp:Label ID="lblSchemeEng" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vSeriesName_Eng")%>' />
                            
</ItemTemplate>

<HeaderStyle Font-Names="Arial" Font-Size="11pt" ></HeaderStyle>

<ItemStyle Height="5%" Width="30%" Font-Names="Arial" Font-Size="11pt"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Edit"><ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" SkinID="btnEdit" />
                            
</ItemTemplate>

<HeaderStyle Font-Names="Arial" Font-Size="11pt"></HeaderStyle>

<ItemStyle Height="5%" Width="3%"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField Visible="False"><ItemTemplate>
                                <asp:Label ID="lblSchemeCode" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.vSeriesCode")%>' />
                            
</ItemTemplate>

<ItemStyle Height="5%"></ItemStyle>
</asp:TemplateField>
</Columns>
</asp:GridView> </TD></TR><TR><TD align=right>
            <asp:Label id="lblSchemeName" runat="server" 
                Text="Series Year:"></asp:Label> </TD><TD align=left><asp:TextBox id="txtSchemeName" tabIndex=1 runat="server" AutoCompleteType="disabled"></asp:TextBox> </TD></TR><TR><TD align=center colSpan=2>
            <asp:Button id="btnAdd" tabIndex=3 runat="server" Text="Add" 
                OnClientClick="return ValidateScheme();"></asp:Button> 
            <asp:Button id="btnCancel" tabIndex=4 runat="server" Text="Cancel"></asp:Button> </TD></TR></TBODY></TABLE>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

