<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="gtspace.Web.Admin.Admin" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GTSpace后台管理</title>
    <script type="text/javascript">
		var iframe = "page_content";
		// 使用iframe来打开链接, 参数a代表超链接
		function menu_click(a)
		{
			document.getElementById(iframe).src = a.href;
			return false;
		}
		// 给一个容器下的所有超链接加上iframe打开机制
		function init_href(panelid)
		{
			var links = document.getElementById(panelid).getElementsByTagName("A");
			for (var i = 0; i < links.length; ++i)
			{
				links[i].onclick = function()
				{
					return menu_click(this);
				}
			}
		}
    </script>
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
		<li><a href="#">菜单</a></li>
		<li><a href="#">菜单</a></li>
		<li><a href="#">菜单</a></li>
		<li><a href="#">菜单</a></li>
	</ul>
	
	<!-- 页面内容 -->
	<iframe id="page_content">
	</iframe>
	
	<script type="text/javascript">
		// 初始化
		init_href("admin_nav");
		init_href("main_nav");
		init_href("sub_nav");
	</script>
</body>
</html>
