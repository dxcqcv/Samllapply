<!DOCTYPE html>
<html lang="en">
<head>
	<?php 
		$url = base_url();
	?>
	<link rel="stylesheet" type="text/css" href="<?php echo $url.'resources/css/bootstrap.css'?>">
	<script type="text/javascript" src="<?php echo $url.'resources/libs/jquery.js'?>"></script>
	<script type="text/javascript" src="<?php echo $url.'resources/libs/bootstrap.js'?>"></script>
</head>
<body>
	<form action="../index.php/upload/up" method="post" enctype="multipart/form-data">
		<input type="file" name="upfile">
		<input type="submit" name="sub" value="上传">
	</form>
	<div id="delete" style="margin:10px 0 0 0;">
		<form action="../index.php/upload/del" method="post">
			<input type="text" name="delname">
			<input type="submit" name="subdel" value="删除">
		</form>
	</div>
	<div id="content" style="margin:10px 0 0 0;">

