<?php
	class Ci_Upload_insert extends CI_Model{
		function __construct(){
			parent::__construct();
			$this->load->database();
		}
		function upload_insert($arr){
			$this->db->insert('upload',$arr);
		}
	}
?>