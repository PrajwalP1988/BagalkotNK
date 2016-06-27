<%@ Page Language="VB" MasterPageFile="~/SiteMaster/MasterPage.master" AutoEventWireup="false" CodeFile="frmAdd.aspx.vb" Inherits="Bagalkot_Entry_frmAdd" title="Untitled Page" Theme="Koppal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script language="javascript" type="text/javascript" >
        function Validation() {
            var allowedFiles = [".pdf"];
            var DocFile = document.getElementById("<%=fuDoc.ClientID %>");
            var regex = new RegExp("([a-zA-Z0-9\s_\\.\-:])+(" + allowedFiles.join('|') + ")$");

            if (document.getElementById("ctl00_ContentPlaceHolder1_ddlTaluk").value == 0) {
                alert("Taluk Name is required !");
                return false;
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_ddlScheme").value == 0) {
                alert("Scheme Name is required !");
                return false;
            }

            else if (document.getElementById("ctl00_ContentPlaceHolder1_ddlSeriesYear").value == 0) {
                alert("Series Year is required !");
                return false;
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_ddlNature").value == 0) {
                alert("Work Category is required !");
                return false;
            }

            else if (document.getElementById("ctl00_ContentPlaceHolder1_txtNameWork").value == "") {
                alert("Please enter the Name of the work !");
                return false;
            }

            else if (document.getElementById("ctl00_ContentPlaceHolder1_txtLocation").value == "") {
                alert("Location is required !");
                return false;
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_txtNUnits").value == "") {
                alert("No of Units is required !");
                return false;
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_txtTUnits").value == "") {
                alert("Total Units is required !");
                return false;
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_txtUnitCost").value == "") {
                alert("Units Cost is required !");
                return false;
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_txtTotal").value == "") {
                alert("Total is required !");
                return false;
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_drpEngginer").value == 0) {
                alert("Enginner Incharge required !");
                return false;
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_ddlGPSOperator").value == 0) {
                alert("GPS Operator is required !");
                return false;
            } else if (DocFile.value == "") {
                alert("Select Documents");
                return false;
            } else if (!regex.test(DocFile.value.toLowerCase())) {
                alert('Please upload Document file having extensions .pdf only.');
                return false;
            } else { return true; }
            
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

        function validateNewNumber() {
            if (event.keyCode >= 48 && event.keyCode <= 57) {
                var a = document.getElementById("<%=txtTUnits.ClientID %>").value;
                var b = document.getElementById("<%=txtUnitCost.ClientID %>").value;
                var c = document.getElementById("<%=txtTotal.ClientID %>").value;
                document.getElementById("<%=txtTotal.ClientID %>").innerHTML = parseInt(a) * parseInt(b);
                document.getElementById("<%=hdn.ClientID %>").value = parseInt(a) * parseInt(b);
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
        <h2 class="title"> WORKS ADD</h2>
    <fieldset id="fieldset1" style="border: 2px solid #405086; WIDTH: 820px;  background-color:#E9EAEC;" 
							runat="server">
						    <center>
    <table style="width: 99%; background-color: #E9EAEC;" >
       
        <tr>
            <td align="center" colspan="4" >
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
               </td>
        </tr>
       
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="11pt" 
                    Text="Taluk"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlTaluk" runat="server" Font-Names="Arial" 
                    Font-Size="11pt" Width="154px">
                </asp:DropDownList>
            </td>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
       
        <tr>
            <td align="right" >
               
                <asp:Label ID="Label3" runat="server" Text="Scheme" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
              
                <asp:DropDownList ID="ddlScheme" runat="server" Width="154px" Font-Size="11pt" 
                    Font-Names="Arial">
                </asp:DropDownList>
            </td>
            <td align="right" >
               
                <asp:Label ID="Label4" runat="server" Text="Series Year" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
                <asp:DropDownList ID="ddlSeriesYEar" runat="server" Font-Size="11pt" Font-Names="Arial"> 
                </asp:DropDownList>
            </td>
        </tr>
       
        <tr>
            <td align="right" >
               
                <asp:Label ID="Label6" runat="server" Text="Source" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
              
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Size="11pt" Font-Names="Arial"
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Value="1">Govt.</asp:ListItem>
                    <asp:ListItem Value="2">Non Govt.</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td align="right" >
               
                <asp:Label ID="Label7" runat="server" Text="Name of the Dept." Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
                <asp:DropDownList ID="drpDepartment" runat="server" Font-Size="11pt" Font-Names="Arial">
                </asp:DropDownList>
                <asp:TextBox ID="txtDept" runat="server"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td align="right" >
               
                <asp:Label ID="Label8" runat="server" Text="Nature of Work" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
              
                <asp:DropDownList ID="ddlNature" runat="server" Width="154px" Font-Size="11pt" 
                    Font-Names="Arial">
                </asp:DropDownList>
            </td>
            <td align="right" >
               
                <asp:Label ID="Label9" runat="server" Text="Name of the Work" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
                <asp:TextBox ID="txtNameWork" runat="server" Font-Size="11pt" 
                    Font-Names="Arial" Width="256px"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td align="right" >
               
                &nbsp;</td>
            <td align="left" >
              
                &nbsp;</td>
            <td align="right" >
               
                <asp:Label ID="Label11" runat="server" Text="Location of Project" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
                <asp:TextBox ID="txtLocation" runat="server" Font-Size="11pt" Font-Names="Arial"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td align="right" >
               
                <asp:Label ID="Label12" runat="server" Text="No. of Units" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
              
                <asp:TextBox ID="txtNUnits"   onKeyPress="validateNumber()" runat="server" Font-Size="11pt" Font-Names="Arial"></asp:TextBox>
            </td>
            <td align="right" >
               
                <asp:Label ID="Label13" runat="server" Text="Total Units" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
                <asp:TextBox ID="txtTUnits"  onKeyPress="validateNumber()" runat="server" Font-Size="11pt" Font-Names="Arial"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td align="right" >
               
                <asp:Label ID="Label14" runat="server" Text="Unit Cost" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
              
                <asp:TextBox ID="txtUnitCost"  onKeyPress="validateNewNumber()" runat="server" Font-Size="11pt" Font-Names="Arial"></asp:TextBox>
                <asp:Label ID="Label24" runat="server" Font-Names="Arial" Font-Size="11pt" 
                    Text="(in Rupees)"></asp:Label>
            </td>
            <td align="right" >
               
                <asp:Label ID="Label15" runat="server" Text="Total Cost" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
              
                <asp:Label ID="txtTotal" onKeyPress="validateNumber()" runat="server" Font-Size="11pt" Font-Names="Arial"></asp:Label>
                <asp:Label ID="Label25" runat="server" Font-Names="Arial" Font-Size="11pt" 
                    Text="(in Rupees)"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td align="right" colspan="2" >
               
                <asp:Label ID="Label16" runat="server" Text="Wheather technically Sanctioned?" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" colspan="2" >
              
                <asp:RadioButtonList ID="ddlTechSanc" runat="server" Font-Size="11pt" Font-Names="Arial"
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
       <div id="tsSan" runat="server">
        <tr>
            <td align="right" colspan="1" >
               
                &nbsp;</td>
            <td align="left" colspan="1" >
              
                &nbsp;</td>
            <td align="right" >
               
                <asp:Label ID="Label18" runat="server" Text="TS Date" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
              
                <asp:TextBox ID="txtTSDate" runat="server" Font-Size="11pt" Font-Names="Arial"></asp:TextBox>
                <asp:ImageButton id="ImgDate1" tabIndex=90 runat="server" AlternateText="Click to show calendar" ImageUrl="~/Images/date.gif"></asp:ImageButton> 
                <Ajax:CalendarExtender id="CalendarExtender4" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImgDate1" TargetControlID="txtTSDate" __designer:wfdid="w1"></Ajax:CalendarExtender> 
                <Ajax:MaskedEditExtender id="MaskedEditExtender5" runat="server" TargetControlID="txtTSDate" InputDirection="LeftToRight" OnInvalidCssClass="MaskedEditError" OnFocusCssClass="MaskedEditFocus" MessageValidatorTip="true" CultureName="en-GB" MaskType="Date" Mask="99/99/9999" __designer:wfdid="w2">
                </Ajax:MaskedEditExtender>
            </td>
        </tr></div>
       
        <tr>
            <td align="right" colspan="2" >
               
                <asp:Label ID="Label19" runat="server" Text="Wheather admin Sanctioned?" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" colspan="2" >
              
                <asp:RadioButtonList ID="ddlAdminSanc" runat="server" Font-Size="11pt" Font-Names="Arial"
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <div id="refSan" runat="server">
        <tr>
            <td align="right"  >
               
                <asp:Label ID="Label20" runat="server" Text="Ref Number" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left"  >
              
                <asp:TextBox ID="txtRefNo" runat="server" Font-Size="11pt" Font-Names="Arial"></asp:TextBox>
            </td>
            <td align="right" >
               
                <asp:Label ID="Label21" runat="server" Text="Ref. Date" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
              
                <asp:TextBox ID="txtRefDate" runat="server" Font-Size="11pt" Font-Names="Arial"></asp:TextBox>
                <asp:ImageButton id="ImageButton1" tabIndex=90 runat="server" AlternateText="Click to show calendar" ImageUrl="~/Images/date.gif"></asp:ImageButton> 
                <Ajax:CalendarExtender id="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1" TargetControlID="txtRefDate" __designer:wfdid="w1"></Ajax:CalendarExtender> 
                <Ajax:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtRefDate" InputDirection="LeftToRight" OnInvalidCssClass="MaskedEditError" OnFocusCssClass="MaskedEditFocus" MessageValidatorTip="true" CultureName="en-GB" MaskType="Date" Mask="99/99/9999" __designer:wfdid="w2">
                </Ajax:MaskedEditExtender>
            </td>
        </tr>
       </div>
        <tr>
            <td align="right"  >
               
                <asp:Label ID="Label22" runat="server" Text="Enginner Incharge" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left"  >
              
                <asp:DropDownList ID="drpEngginer" runat="server" Width="154px" 
                    Font-Size="11pt" Font-Names="Arial">
                </asp:DropDownList>
            </td>
            <td align="right" >
               
                <asp:Label ID="Label23" runat="server" Text="GPS Operator" Font-Size="11pt" Font-Names="Arial"></asp:Label>
            </td>
            <td align="left" >
              
                <asp:DropDownList ID="ddlGPSOperator" runat="server" Font-Size="11pt" Font-Names="Arial"
                    Width="154px">
                </asp:DropDownList>
            </td>
        </tr>
       
       <tr>
            <td align="right" ><asp:Label ID="lblDoc" runat="server" Text="Documents : "></asp:Label></td>
            <td align="left"><asp:FileUpload ID="fuDoc" runat="server" /></td>
            <td align="left" colspan="2"  >
            </td>
        </tr>
       
        <tr>
            <td align="right" colspan="2"  >
               
                <asp:Button ID="Button1" runat="server" Text="SAVE" BackColor="#062E5E" 
                    ForeColor="White" onclientclick="return Validation();" />
            </td>
            <td align="left" colspan="2"  >
              
                <asp:Button ID="Button2" runat="server" Text="CANCEL" BackColor="#062E5E" 
                    ForeColor="White" />
            </td>
        </tr>
        </table></center>
        </fieldset> </center>
        <asp:HiddenField ID="hdn" runat="server" />
        </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
        </asp:UpdatePanel> 
</asp:Content>

