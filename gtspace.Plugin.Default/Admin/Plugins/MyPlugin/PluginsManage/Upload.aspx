<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="gtspace.Plugin.Default.Admin.Plugins.MyPlugin.PluginsManage.Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上传插件</title>
</head>
<body>
    <form id="form1" runat="server">
		<h1>上传插件</h1>
		<label for="PluginFileUpload">选择插件压缩包<br />
		<br />
		</label>&nbsp;<asp:FileUpload ID="PluginFileUpload" runat="server" />
		<br />
		<br />
		<asp:Button ID="UploadButton" runat="server" Text="点击开始上传" 
			onclick="UploadButton_Click" />
		<br />
		<br />
		<asp:Label ID="JavascriptLabel" runat="server" EnableViewState="false" Text=""></asp:Label>
    </form>
</body>
</html>
