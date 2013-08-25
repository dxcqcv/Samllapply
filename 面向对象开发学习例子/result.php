<?php
/**
 * 	·â×°£¬¼Ì³Ð£¬ÖØÔØ
 *
 */
class Root{
	function dayin(){
		return  "ROOT<br/>";
	}
}

class Son extends Root{
	function dayin(){
		return "SON ECHO <br/>".Root::dayin();
	}
}

$v = new Son();
echo $v->dayin();
?>