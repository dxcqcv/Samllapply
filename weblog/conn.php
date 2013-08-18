<?php
	@mysql_connect('127.0.0.1:3306','root','0723') or die("mysq连接失败");
	@mysql_select_db('xiangwenwen') or die("mysql数据库连接失败");
	mysql_set_charset("utf-8");
?>