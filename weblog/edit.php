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
	}
	
	if(!empty($_POST['submits'])){
		$title = $_POST['title'];
		$content = $_POST['content'];
		$hid = $_POST['hid'];
		$sqls = "update `weblog` set `title`='$title',`contents`='$content' where id='$hid' limit 1";
		mysql_query($sqls) or die(mysql_error());
		echo "<script type='text/javascript'>alert('更新成功');location.href='index.php';</script>";
	}

?>
</head>
<body>
	<form action="edit.php" method="post">
		<input type="hidden" name="hid" value="<?php echo $rs['id']?>">
		"标题"：<input type="text" name="title" title="" value="<?php echo $rs['title']?> "/><br/>
		"内容"：<textarea rows="5" cols="30" name="content"><?php echo $rs['contents']?></textarea><br/>
		<input type="submit" name="submits" value="提交">
	</form>
</body>
</html>
