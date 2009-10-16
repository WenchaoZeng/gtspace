<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zwc_test1.aspx.cs" Inherits="gtspace.Web.TestCase.zwc_test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		
    	<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
		<br />
		<br />
		<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="加载插件" />
		<br />
		<br />
		<asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="卸载插件" />
		<br />
		<br />
		<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
		<br />
		<br />
		<asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
			Text="设置Session" />
		<br />
		<br />
		<asp:Button ID="Button4" runat="server" Text="刷新" />
		<br />
		<br />
		<asp:HyperLink ID="HyperLink1" runat="server" 
			NavigateUrl="~/TestCase/Default.aspx" Target="_blank">访问插件</asp:HyperLink>
		<br />
		
    </div>
    </form>
</body>
</html>
