<!DOCTYPE html>
<html lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>小型博客</title>
<link rel="stylesheet" type="text/css" href="css/bootstrap.css">
<script type="text/javascript" src="libs/jquery.js"></script>
<script type="text/javascript" src="libs/bootstrap.js"></script>
<?php 
	include 'conn.php';
	
	if(!empty($_GET['keys'])){
		$w = "`title` like '%".$_GET['keys']."%'";
	}else{
		$w = 1;
	}
	
	$sql = "select * from `weblog` where $w order by id desc";
	$query = mysql_query($sql);
?>
</head>
<body>
	<div class="container-fluid">
	  <div class="row-fluid">
	    <div class="span2">
	      <a href="add.php" class="btn">添加内容</a>
	    </div>
	    <div class="span10">
	    	<form action="" method="get">
				<input type="text" name="keys" class="input-xlarge focused">
				<input type="submit" name="subkeys" class="btn" value="搜索">
			</form>
	      	<?php 
				while ($rs = mysql_fetch_array($query)){
			?>
				<h2>标题：<a href="view.php?id=<?php echo $rs['id']?>"><?php echo $rs['title']?></a> | 
					<a href="edit.php?id=<?php echo $rs['id']?>">编辑</a> | 
					<a href="del.php?del=<?php echo $rs['id']?>">删除</a>
				</h2>
				<dl>
					<dt><?php echo $rs['dates']?></dt>
					<dd><?php echo iconv_substr($rs['contents'],0,140,"utf-8")?>
					<a href="view.php?id=<?php echo $rs['id']?>">...</a></dd>
				</dl>
			<?php 
				}
			?>
	    </div>
	  </div>
	</div>
	

</body>
</html>

