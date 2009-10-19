<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="gtspace.Plugin.Default.Admin.Plugins.MyPlugin.PluginsManage.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>插件列表</title>
</head>
<body>
    <form id="form1" runat="server">
		<h1>插件列表</h1>
		<asp:GridView ID="PluginsGridView" runat="server" AutoGenerateColumns="False" 
			onrowdeleting="PluginsGridView_RowDeleting">
			<Columns>
				<asp:BoundField DataField="Name" HeaderText="插件名称" />
				<asp:BoundField DataField="Version" HeaderText="版本" />
				<asp:BoundField DataField="Author" HeaderText="作者" />
				<asp:BoundField DataField="Description" HeaderText="描述" />
				<asp:CommandField ShowDeleteButton="True" />
			</Columns>
		</asp:GridView>
	<asp:Label ID="JavaScriptLabel" runat="server" EnableViewState="false" Text=""></asp:Label>
    </form>
</body>
</html>
