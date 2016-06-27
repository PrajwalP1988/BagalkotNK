<%@ Page Language="VB" MasterPageFile="~/SiteMaster/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmViewGPS.aspx.vb" Inherits="Bagalkot_Entry_frmViewGPS"
    Title="Untitled Page" Theme="Koppal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<%--<script type="text/javascript" src="static/prettify/prettify.js"></script>--%>
  <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=false
                           &amp;key=AIzaSyDHv4FrIoaG279_cfl_IZxA558H0s75VRg" type="text/javascript"></script>
  <%--<script type="text/javascript" src="egeoxml.js"></script>--%>
  <!-- Change the key below to your own Maps API key -->
  <script type="text/javascript" src="http://www.google.com/jsapi?hl=en
                            &amp;key=AIzaSyBCreH8kCyw7D47l0W_JnvrbhVk_CwxMKU"></script>
    
  <script type="text/javascript">
      /* <![CDATA[ */
      var ge;
      google.load("earth", "1");
      var geoxml;

      function init() {
          google.earth.createInstance('map', initCB, failureCB);
      }

      var map;
      var src = window.location.href.substring(0, window.location.href.lastIndexOf('/')) + '/';

      function initCB(instance) {
          ge = instance;
          ge.getWindow().setVisibility(true);
          link = ge.createLink('');
          h = window.location.href.substring(0, window.location.href.lastIndexOf('/')) + '/';

          var ValidateDate = document.getElementById("<%=Validation.ClientID %>").value;


          var nrnewv, lnknewv, hrnewv, lnk47v, hr47v, nr47v;
          var Lat = document.getElementById("<%=Latv.ClientID %>").value;
          var Long = document.getElementById("<%=Long1v.ClientID %>").value;
          var srv = document.getElementById("<%=HdnValid.ClientID %>").value;
          lnknewv = ge.createLink('');
          hrnewv = window.location.href.substring(0, window.location.href.lastIndexOf('/')) + '/';
          var bv = srv;
          var sv = hrnewv.replace("GPS/", "")
          //sv = sv.replace("GPS/", "")
          hrnewv = sv + 'TempKMLFile//' + bv;
          //hrnew='http://localhost:4773/Authonticated/Land236280485.kml'

          lnknewv.setHref(hrnewv);
          nrnewv = ge.createNetworkLink('');
          nrnewv.set(lnknewv, true, true);
          ge.getFeatures().appendChild(nrnewv);
          


          ge.getNavigationControl().setVisibility(ge.VISIBILITY_AUTO)
          // add some layers
          ge.getLayerRoot().enableLayerById(ge.LAYER_BORDERS, true);
          ge.getLayerRoot().enableLayerById(ge.LAYER_ROADS, true);
          ge.getLayerRoot().enableLayerById(ge.LAYER_TERRAIN, true);

          // Fly to the Grand Canyon
          var la = ge.createLookAt('');

          la.set(12.9775744016709, 77.5505345123461, 0, ge.ALTITUDE_RELATIVE_TO_GROUND,
           -30, 40, 10000);
          ge.getView().setAbstractView(la);

      }

      function RemoveAllFeatures() {
          var features = ge.getFeatures();
          var x = features.getName();
          alert(x);
          var x = features.getChildNodes().getlength();
      }

      function failureCB(errorCode) {
      }
  
  </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpKplGPSView" runat="server">
<ContentTemplate>

<fieldset style="border:2px solid; border-color:Maroon; width:500px;">
<table width="500px">
<tr><td align="right"><asp:Label ID="lblSchh" runat="server" Text="Select Scheme : "></asp:Label></td>
<td align="left"><asp:DropDownList ID="ddlSchh" runat="server" AutoPostBack="true">
<asp:ListItem Text="--Select--" Value="0"></asp:ListItem></asp:DropDownList></td></tr>
<tr><td colspan="2" align="center">Or</td></tr>
<tr><td align="right"><asp:Label ID="lblSerr" runat="server" Text="Select Series : "></asp:Label></td>
<td align="left"><asp:DropDownList ID="ddlSerr" runat="server" AutoPostBack="true">
<asp:ListItem Text="--Select--" Value="0"></asp:ListItem></asp:DropDownList></td></tr>
</table>
</fieldset>

<asp:GridView id="grd_ashraya1" runat="server" ForeColor="#333333" Width="552px" EmptyDataText="No Data Found"  
GridLines="None" ShowFooter="True" FooterStyle-HorizontalAlign="Center" PageSize="8" AllowPaging="True" SkinID="prgGrid" AutoGenerateColumns="False" >
<PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
<Columns>

<asp:TemplateField>
<ItemTemplate>
<asp:Button ID="btnConv" runat="server" Text="Show" CommandName="Show" CommandArgument='<%# databinder.eval(Container.dataitem,"vWorkID") %>' />
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="vTalukName_Eng" HeaderText="Taluk">
<ItemStyle Font-Names="Arial" Font-Size="8pt" HorizontalAlign="Left" />
<HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>

<asp:BoundField DataField="vWNature_Eng" HeaderText="Work Nature" Visible="false">
<ItemStyle Font-Names="Arial" Font-Size="8pt" HorizontalAlign="Left" />
<HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>

<asp:BoundField DataField="vWorkId" HeaderText="Work ID">
<ItemStyle Font-Names="Arial" Font-Size="8pt" HorizontalAlign="Left" />
<HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>

<asp:BoundField DataField="vNameWork" HeaderText="Work Name">
<ItemStyle Font-Names="Arial" Font-Size="8pt" HorizontalAlign="Left" />
<HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
</Columns>
</asp:GridView>


<table id="tblPhoto" runat="server"><tbody><tr><td style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" class="style7">

<fieldset  style="border-color :Gray;">
<table style="border: 2px solid #800000; LEFT: 574px; WIDTH: 49%; POSITION: absolute; TOP: 200px; HEIGHT: 329px; font-family: Arial; font-size: small;" 
align="left"></tbody>
<tr>
<td align="center" colspan="3">
<asp:Label ID="lblBenf" runat="server" Font-Bold="True" ForeColor="#0033CC"></asp:Label>
</td>
</tr>
<tr>
<td align="center" colspan="3" >
<asp:Label ID="lblMsg" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td align="center" >
Foundation
<asp:Image ID="Image1" runat="server" Height="150px" Width="200px" />
</td>
<td align="center" >
Plinth
<asp:Image ID="Image2" runat="server" Height="150px" Width="200px" />
</td>
<td align="center" >
Lintel
<asp:Image ID="Image3" runat="server" Height="150px" Width="200px" />
</td>
</tr>
<tr>
<td align="center" >
Roof
<asp:Image ID="Image4" runat="server" Height="150px" Width="200px" />
</td>
<td align="center" >
Finishing
<asp:Image ID="Image5" runat="server" Height="150px" Width="200px" />
</td>
<td align="center" >
Complete
<asp:Image ID="Image6" runat="server" Height="150px" Width="200px" />
</td>
</tr>
</tbody></table></fieldset></td><td>&nbsp;</td></tr></tbody></table></div>
<center>
<table id="tblMap" runat="server" border="2" style="border-color:Maroon; left:20px; position:absolute; top:580px;">
<tr><td><div id="map" style="width:1200px; height:640px;">
</div></td></tr></table>
</center>
<asp:HiddenField ID="Lat" runat="server" />
<asp:HiddenField ID="Long1" runat="server" />
<asp:HiddenField ID="Latv" runat="server" />
<asp:HiddenField ID="Long1v" runat="server" />
<asp:HiddenField ID="Validation" runat="server" />
<asp:HiddenField ID="HdnValue" runat="server" />
<asp:HiddenField ID="HdnValid" runat="server" />
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="grd_ashraya1" />
</Triggers>
</asp:UpdatePanel>
</asp:Content>