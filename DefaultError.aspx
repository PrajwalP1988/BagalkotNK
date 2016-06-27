

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Error Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    <h1>
        <span style="font-size: 16pt; font-family: Arial"></span>&nbsp;</h1>
        <h1>
            <span style="font-size: 16pt; font-family: Arial">Rajiv Gandhi Rural Housing Corporation Limited<br />
            </span><span style="font-size: 16pt; font-family: Arial">Bangalore</span></h1>
    <b><span style="font-size: 11pt; font-family: Arial">You have entered wrongly your UserName
            or Password for more than 3 times!!!<br />
    Please enter the correct UserName and Password or contact to:<br />
            <br />
            Office Tel: 080-23118888<br />
            EmailID: rgrhcl@rediffmail.com<br />
            <br />
            <span style="color: #0033cc">Mr. John Paul D.<br />
            </span>System Analyst<br />
            Mobile No. 9448287512<br />
            <br />
            <span style="color: #0066cc">Mrs. Madhu Kumari</span><br />
            Executive Assistant (Computer Division)<br />
            Mobile No. 9448287353<br />
            <br />
        </span>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Red" NavigateUrl="~/Login.aspx"
            Width="247px">Click Here Back to Login Page</asp:HyperLink>
    </b>
    
    
    
    </div>
    </form>
</body>
</html>
