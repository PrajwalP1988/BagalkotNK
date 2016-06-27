<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NewReport.aspx.vb" Inherits="Reports_NewReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="grdChkList" runat="server" AllowPaging="false" AutoGenerateColumns="false">
    <Columns>
    <asp:BoundField DataField="vSchemeName_Eng" HeaderText="Scheme">
    <HeaderStyle HorizontalAlign="Center" Width="5%" />
    <ItemStyle HorizontalAlign="Left" Width="5%" />
    </asp:BoundField>
    
    <asp:BoundField DataField="vSeriesName_Eng" HeaderText="Series">
    <HeaderStyle HorizontalAlign="Center" Width="5%" />
    <ItemStyle HorizontalAlign="Left" Width="5%" />
    </asp:BoundField>
    
    <asp:BoundField DataField="vTalukName_Eng" HeaderText="Taluk">
    <HeaderStyle HorizontalAlign="Center" Width="5%" />
    <ItemStyle HorizontalAlign="Left" Width="5%" />
    </asp:BoundField>
    
    <asp:BoundField DataField="vWorkId" HeaderText="Work ID">
    <HeaderStyle HorizontalAlign="Center" Width="2%" />
    <ItemStyle HorizontalAlign="Left" Width="2%" />
    </asp:BoundField>
    
    <asp:BoundField DataField="vWNature_Eng" HeaderText="Work Nature">
    <HeaderStyle HorizontalAlign="Center" Width="5%" />
    <ItemStyle HorizontalAlign="Left" Width="5%" />
    </asp:BoundField>
    
    <asp:BoundField DataField="vLocationProject" HeaderText="Location">
    <HeaderStyle HorizontalAlign="Center" Width="10%" />
    <ItemStyle HorizontalAlign="Left" Width="8%" />
    </asp:BoundField>
    
    <asp:BoundField DataField="vNameWork" HeaderText="Work Name">
    <HeaderStyle HorizontalAlign="Center" Width="10%" />
    <ItemStyle HorizontalAlign="Left" Width="8%" />
    </asp:BoundField>
    
    <asp:BoundField DataField="Stage" HeaderText="Stage">
    <HeaderStyle HorizontalAlign="Center" Width="3%" />
    <ItemStyle HorizontalAlign="Left" Width="3%" />
    </asp:BoundField>
    </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
