<?php
	if ( ! defined('BASEPATH')) exit('No direct script access allowed');
	class Upload extends CI_Controller{
		function index(){
			$this->load->helper('url');
			$this->load->view('Ci_upload_header.php');
			$this->load->model('Ci_Upload_select');
			$arr = $this->Ci_Upload_select->upload_select('name');
			//var_dump($arr);
			if(!empty($arr)){
			    for ($i = 0; $i < count($arr); $i++) {
			    	//print_r($arr[$i]);
			    	$jsonArray = get_object_vars($arr[$i]);
			    	//var_dump($jsonArray);
			    	$this->load->view('Ci_upload_con',$jsonArray);
			    }
			}
			$this->load->view('Ci_upload_foot.php');
			
		}
		function del(){
			if(!empty($_POST['subdel'])){
				$this->load->model('Ci_Upload_delete');
				if(!empty($_POST['delname'])){
					$id = $_POST['delname'];
					$this->Ci_Upload_delete->upload_del($id);
					echo "<script>alert('delete ture'); document.location.href='http://127.0.0.1/CI/index.php/upload';</script> ";
				}else{
					echo "<script>alert('id is not'); document.location.href='http://127.0.0.1/CI/index.php/upload';</script>";
				}
			}
		}
		function up(){
			$this->load->helper('url');
			$config['upload_path'] = './upload';
			$config['allowed_types'] = 'gih|jpg|png';
			$config['max_size'] = '120000';
			$this->load->library('upload',$config);
			if($this->upload->do_upload('upfile')){
				$data = array('upload_data'=>$this->upload->data());
				$arr_insert = array('name'=>$data['upload_data']['file_name']);
				//var_dump($arr_insert);
				$this->load->model('Ci_Upload_insert');
				$this->Ci_Upload_insert->upload_insert($arr_insert);
				var_dump($data);
				echo "<script>alert('upload ture');document.location.href='http://127.0.0.1/CI/index.php/upload';</script>";				
			}else{
				$error = array('error'=>$this->upload->display_errors());
				var_dump($error);
			}

			/*
			if(!empty($_POST['sub'])){
				if(isset($_FILES['upfile'])){
					$file = $_FILES['upfile'];
					var_dump($file);
					if($file['size'] >= 120000){
						echo 'size no';
					}else{
						switch ($file['type']){
							case 'image/jpeg':
								$hx = '.jpg';
								break;
							default:
								$hx = false;
								break;
						}	
						if($hx){
							$time = time();
							move_uploaded_file($file['tmp_name'],"./upload/$time.$hx");
						}else{
							echo 'type no update File not';
						}
					}
				}else{
					echo "获取为空";
				}
			}
			*/
		}
	}
?>