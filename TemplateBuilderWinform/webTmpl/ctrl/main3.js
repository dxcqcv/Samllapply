/*!
* v1.0  前端工具模版，主界面控制器
* http://ygsoft.com/
*
* Author:向文文
* Date: 2012-11-12
*
*/
$$.ctrl.add('main3', function () {
    var _sker = $$,
        _self = this,
        WebSrvURL = _sker.config.WebSrvURL;
    //指定要显示的view目录
    this.UseView = 'none';
    this.init = function () {
        var skinPATH = _sker.skinPATH;
        //指定要加载的JS类库
        var Loadfiles = [_sker.getUrl("layout.js"), _sker.getUrl("i18n/grid.locale-cn.js"), _sker.getUrl("ui/seeker.ui.jqgrid.js"), _sker.getUrl("ui/seeker.ui.table.js"), _sker.getUrl("ui/seeker.ui.tab.js"),_sker.getUrl("ui/seeker.ui.tree.js"),_sker.getUrl("ui/seeker.ui.fileup.js")];
        _sker.scriptLoader.loadByLAB(Loadfiles, loaded);
        //退出登录
        var logoutEv = function () {
            location.href = "login.html?code=1001";
        };
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
            //加入登录信息
            $('#content').prepend('<div class="login_letter"><div class="login_info"><span id="userinfo"></span>| <span id="timeDate"></span>| <span><a class="close" id="logout" href="#">退出</a></span></div></div>');
            //获取系统时间
            var $timeDate = $("#timeDate");
            var date = new Date();
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            var day = date.getDate();
            $timeDate.text(year + '年' + month + '月' + day + '日');
            $("#logout").bind('click', function () {
                _sker.ShowMsg('是否要退出系统？', '3', { confirm: logoutEv });
            });
            $("#userinfo").text("登录用户:向文文");
            LoadEventNav('newbill');
        }
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
        //菜单栏服务读取
        function ServiceNav(src) {
            var varType = 'GET',
            varUrl = _sker.config.WebSrvURL + '/data/' + src + '.html',
            varDataType = 'html',
            $allcons = $('#allcons');
            _sker.getSrv({
                type: varType,
                url: varUrl,
                dataType: varDataType,
                callback: function (msg) {
                    $allcons.empty().append(msg);
                }
            });
        }
        //菜单栏事件委派模拟
        function LoadEventNav(firstsrc) {
            var firstsrc = firstsrc;
            if (firstsrc !== undefined) {
                ServiceNav(firstsrc);
            }
            var _nav = $('#nav');
            $('#nav li').eq(0).addClass('newshover');
            _nav.bind('click', function (e) {
                var tar = e.target,
            $tar = $(tar),
            nodeName = tar.nodeName,
            $li = $('#nav li');
                if (nodeName === 'A') {
                    var href = $tar.attr('href'),
                src = href.substring(1),
                li = $tar.parent();
                    $li.removeClass('newshover');
                    li.addClass('newshover');
                    ServiceNav(src);
                }
                if (nodeName === 'SPAN') {
                    var s = $tar.attr('s'),
                        x = $tar.next();
                    if (s !== undefined) {
                        if (s == 'b') {
                            x.hide();
                            $tar.attr('s', 'n');
                            return;
                        } else {
                            x.show();
                            $tar.attr('s', 'b');
                            return;
                        }
                    }
                }
            });
        }
    }
});

