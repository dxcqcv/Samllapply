<?php
	include_once("smartylibs/Smarty.class.php"); ////包含smarty类文件
	$smarty = new Smarty(); //��bsmartyʵ�����$smarty
	$smarty->config_dir="smartylibs/Config_File.class.php";  //目录变量
	$smarty->caching=false; //是否使用缓存，项目在调试期间，不建议启用缓存
	$smarty->template_dir = "./templates"; //设置模板目录
	$smarty->compile_dir = "./templates_c"; //设置编译目录
	$smarty->cache_dir = "./smarty_cache"; //缓存文件夹
	$smarty->left_delimiter = "{";
	$smarty->right_delimiter = "}";
?>
