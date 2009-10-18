<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="gtspace.Web.Admin.Admin" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GTSpace后台管理</title>
    <style type="text/css">
		#page_content
		{
			width:100%;
			height:500px;
		}
		h1
		{
			color:Red;
		}
    </style>
</head>
<body>
	<h1>GTSpace后台管理</h1>
	
	<!-- 管理员导航 -->
	<ul id="admin_nav">
		<li><a href="#">菜单</a></li>
		<li><a href="#">菜单</a></li>
		<li><a href="#">菜单</a></li>
		<li><a href="#">菜单</a></li>
	</ul>
	
	<!-- 主导航栏 -->
	<ul id="main_nav">
		<%=_main_nav %>
	</ul>
	
	<!-- 二级导航栏 -->
	<ul id="sub_nav">
		<%=_sub_nav %>
	</ul>
	
	<!-- 页面内容 -->
	<iframe id="page_content" src="<%=_load %>">
	</iframe>

</body>
</html>
