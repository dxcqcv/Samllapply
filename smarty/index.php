<?php
	include_once("smarty_config.php");	
	$name[] = array("name"=>"魔兽世界","date"=>"2013-8-3");
	$name[] = array("name"=>"星际争霸","date"=>"2013-8-3");
	$name[] = array("name"=>"暗黑破坏神","date"=>"2013-8-3");
	$name[] = array("name"=>"魔兽争霸","date"=>"2013-8-3");
	$smarty->assign("title",$name);  //设置模版需要的内容
	$smarty->display("index.html"); //设置模版名字
?>