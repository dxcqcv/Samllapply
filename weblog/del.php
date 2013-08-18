<?php
	include 'conn.php';
	if(!empty($_GET['del'])){
		$id  = $_GET['del'];
		$sql = "delete from `weblog` where `id` = '$id'";
		mysql_query($sql);
		echo "delete yes";
	}
?>