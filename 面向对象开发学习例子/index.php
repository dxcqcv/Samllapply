<?php 
	class Mypc{
		private  $name;
		function  __construct($name=''){
			return  $this->name = $name;
		}
		private function void(){
			return  $this->name."是好人";
		}
		public function OK(){
			return $this->void()."===成功";
		}
		function __get($name){
			return  $this->name;
		}
		function  __set($n,$v){
			if($v === '5555'){
				$this->$n = $v;
			}
		}
	}
	$v = new Mypc("向文文");
	$v->name = '5555';
	echo $v->name;
?>