<!DOCTYPE html>
<html lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<link rel="stylesheet" type="text/css" href="css/bootstrap.css">
<script type="text/javascript" src="libs/jquery.js"></script>
<script type="text/javascript" src="libs/bootstrap.js"></script>
<?php
	include 'conn.php';
	if(!empty($_GET['id'])){
		$id = $_GET['id'];
		$sql = "select * from `weblog` where `id`='$id'";
		$query = mysql_query($sql);
		$rs = mysql_fetch_array($query);
		
		$conSql = "update `weblog` set hits=hits+1 where id='$id'";
		mysql_query($conSql);
	}
?>
</head>
<body>
	<h2>标题：<?php echo $rs['title']?></h2>
	<h2>点击量：<?php echo $rs['hits']?></h2>
	<dl>
		<dt>时间：<?php echo $rs['dates']?></dt>
		<dd><?php echo $rs['contents']?></dd>
	</dl>
	
</body>
</html>
