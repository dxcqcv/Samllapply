<?php
	class Ci_Upload_delete extends CI_Model{
		function __construct(){
			parent::__construct();
			$this->load->database();
		}
		function upload_del($id){
			$this->db->where('id',$id);
			$this->db->delete('upload');
		}
	}
?>