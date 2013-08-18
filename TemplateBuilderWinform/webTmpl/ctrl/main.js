/*!
* v1.0  前端工具模版，主界面控制器
* http://ygsoft.com/
*
* Author:向文文
* Date: 2012-11-12
*
*/
$$.ctrl.add('main', function () {
		//声明依赖关系
	var _sker = $$,
		_self = this,
		WebSrvURL = _sker.config.WebSrvURL;
	//指定要显示的view目录
	this.UseView = 'none';
	//初始化
	this.init = function () {
			var _au = document.location;
			var _href = _au.href.substring(0,_au.href.lastIndexOf('/'));
			//console.log(_href);
		var skinPATH = _sker.skinPATH;
		_sker.skins.loadcss(_href + '/css/codemirror.css');
		_sker.skins.loadcss(_href + '/css/docs.css');
		//指定要加载的JS类库
		var Loadfiles = [_sker.getUrl("layout.js"), _sker.getUrl("i18n/grid.locale-cn.js"), _sker.getUrl("ui/seeker.ui.jqgrid.js"), _sker.getUrl("ui/seeker.ui.table.js"), _sker.getUrl("ui/seeker.ui.tab.js"),_sker.getUrl("ui/seeker.ui.tree.js"),_sker.getUrl("ui/seeker.ui.fileup.js")];
		_sker.scriptLoader.loadByLAB(Loadfiles, loaded);
		//操作XML
		function XmlParser(xmlstring) {
			var xmlStrDoc = null;
			if (window.DOMParser) {// Mozilla Explorer  
			    parser = new DOMParser();
			    xmlStrDoc = parser.parseFromString(xmlstring, "text/xml");
			} else {// Internet Explorer  
			    xmlStrDoc = new ActiveXObject("Microsoft.XMLDOM");
			    xmlStrDoc.async = "false";
			    xmlStrDoc.loadXML(xmlstring);
			}
			return xmlStrDoc;
		};
		//初始化布局控件，添加登录信息DOM等。
		function loaded() {
			//layout布局
			$('body').layout({
			    scrollToBookmarkOnLoad: false // handled by custom code so can 'unhide' section first
				, defaults: {}
				, north: {
					size: "auto"
					, spacing_open: 0
					, closable: false
					, resizable: false
				}
				, west: {
					size: 175
					, spacing_closed: 22
					, togglerLength_closed: 140
					, togglerTip_open: "点击隐藏"
					, togglerTip_closed: "点击显示"
					, togglerAlign_closed: "top"
					, togglerContent_closed: "功<br>能<br>选<br>项"
					, togglerTip_closed: "打开功能菜单"
					, sliderTip: "显示/隐藏侧边栏"
				    , resizable: false
				}
			});
			//加载完成之后的脚本调用
			$('#conLeft').load('../sutra/left/leftmenu.html');
			$('#logininfo').load('../sutra/center/loginInfo.html');
		}
		//IE6阻止tab键
		if ($.browser.msie) {
			if ($.browser.version == '6.0') {
			    $(document).bind('keydown', function (e) {
			        var keyCodes = e.keyCode;
			        if (keyCodes == 9) {
			            return false;
			        }
			    });
			}
		}
		//公共模版使用的函数
		_sker.tmplsServiceCom = {
			    //菜单栏服务读取
			    ServiceNav:function(src,id){
			        	var varType = 'GET',
							    varUrl = _sker.config.WebSrvURL + '/data/' + src + '.html',
							    varDataType = 'html',
							    $doms = null;
						if(id !== undefined){
							    $doms = $('#'+id);
							    _sker.getSrv({
									type: varType,
									url: varUrl,
									dataType: varDataType,
									callback: function (msg) {
										$doms.empty().append(msg);
									}
								    });
						}	
			    },
			    //系统时间设定
			    SystemTimes:function(id){
			        	if(id !== undefined){
			        			var $timeDate = $('#'+id);
			            	var date = new Date();
							var year = date.getFullYear();
							var month = date.getMonth() + 1;
							var day = date.getDate();
							$timeDate.text(year + '年' + month + '月' + day + '日');
			        	}
			    }
		};
		}
});

