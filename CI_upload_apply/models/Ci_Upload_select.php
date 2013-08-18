<?php
	class Ci_Upload_select extends CI_Model{
		function __construct(){
			parent::__construct();
			$this->load->database();
		}
		function upload_select(){
			$this->db->select('*');
			$query = $this->db->get('upload');
			return $query->result();
		}
	}
?>