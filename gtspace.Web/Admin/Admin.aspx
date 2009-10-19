<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="gtspace.Web.Admin.Admin" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GTSpace后台管理系统</title>
    <script type="text/javascript" src="Javascripts/admin.js"></script>
    <link href="Styles/admin.css" rel="Stylesheet" type="text/css" />
</head>
<body>
	<h1 id="head">GTSpace后台管理系统</h1>

	<!-- 主导航栏 -->
	<ul id="main_nav">
		<%=_main_nav %>
	</ul>
	
	<!-- 二级导航栏 -->
	<div id="sub_nav">
		<%=_sub_nav %>
	</div>
	
	<!-- 页面内容 -->
	<iframe id="page_content" frameborder="0" src="<%=_load %>">
	</iframe>
	
	<!-- 网站信息 -->
	<div id="siteinfo">
		<p class="copyright">版权所有 GTeam公司 2009</p>
	</div>
	
</body>
</html>
