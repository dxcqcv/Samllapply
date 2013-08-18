/*!
* v1.0  前端工具模版，主界面控制器
* http://ygsoft.com/
*
* Author:向文文
* Date: 2012-11-12
*
*/
$$.ctrl.add('trinomialmain', function () {
    var _sker = $$,
        _nav = $('#nav'),
        WebSrvURL = _sker.config.WebSrvURL;
    this.UseView = 'none';
    this.init = function () {
    		var _au = document.location;
			 	var _href = _au.href.substring(0,_au.href.lastIndexOf('/'));
        var skinPATH = _sker.skinPATH;
        _sker.skins.loadcss(_href + '/css/codemirror.css');
			  _sker.skins.loadcss(_href + '/css/docs.css');
        //指定要加载的JS类库
        var Loadfiles = [_sker.getUrl("layout.js"), _sker.getUrl("i18n/grid.locale-cn.js"), _sker.getUrl("ui/seeker.ui.jqgrid.js"), _sker.getUrl("ui/seeker.ui.table.js"), _sker.getUrl("ui/seeker.ui.tab.js"),_sker.getUrl("ui/seeker.ui.tree.js"),_sker.getUrl("ui/seeker.ui.fileup.js")];
        _sker.scriptLoader.loadByLAB(Loadfiles, LoadPages);
    }
    function LoadPages() {
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
			            spacing_closed: 22
	                , resizable: false
			        }
			});
			//加载完成之后的脚本调用
		  $('#head').load('../trinomial/top/topmenu.html');
		  //$('#head').load('../trinomial/top/topmenu2.html');
		  $('#logininfos').load('../trinomial/top/loginInfo.html');
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
});