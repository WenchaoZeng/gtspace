﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="gtspace.Plugin.Demo1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		
    	<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
		<br />
		<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
		<br />
		<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
		<br />
		<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
		
    </div>
    </form>
</body>
</html>
