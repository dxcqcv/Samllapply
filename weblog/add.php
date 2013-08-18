<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<link rel="stylesheet" type="text/css" href="css/bootstrap.css">
<script type="text/javascript" src="libs/jquery.js"></script>
<script type="text/javascript" src="libs/bootstrap.js"></script>
<?php
	include 'conn.php';
	if(!empty($_POST['submits'])){
		$title = $_POST['title'];
		$content = $_POST['content'];
		$sql = "insert into `weblog` (`title`,`dates`,`contents`) values ('$title',now(),'$content')";
		mysql_query($sql) or die(mysql_error());
		echo "<script type='text/javascript'>alert('添加成功');location.href='index.php';</script>";
	}
?>
</head>
<body>
	<form action="add.php" method="post">
		"标题"：<input type="text" name="title" title=""><br/>
		"内容"：<textarea rows="5" cols="30" name="content"></textarea><br/>
		<input type="submit" name="submits" value="提交">
	</form>
</body>
</html>
