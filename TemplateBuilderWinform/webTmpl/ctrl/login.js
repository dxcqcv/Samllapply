/*!
* v1.0  前端工具模版，登录控制器
* http://ygsoft.com/
*
* Author:向文文
* Date: 2012-11-12
*
*/
$$.ctrl.add('login', function () {
    var _sker = $$,
		_self = this,
        _txtUserName = $("#txtUserName"),
        _txtPwd = $("#txtPwd"),
        _code = $("#code"),
        _letter = ['1px solid #9DADC5', '1px solid #e93e3a', '请您输入用户名再登录', '请您输入密码再登录', '请您输入用户名和密码再登录'],
        varType, varUrl, varData, varContentType, varDataType, varProcessData;
    //指定要显示的view目录
    this.UseView = 'none';
    //指定要执行view页里的方法面，与view函数名对应
    this.ActionList = 'login';
    //model里需要执行的动作事件
    this.ActionResult = {};
    ////验证sessionid是否有效，如果有效，直接跳转到main.html页面;
    this.init = function () {
        //Enter按下时或单击时登入
        var KeyDown = function (evt) {
            if (evt.keyCode == 13 || evt.type == 'click') {
                evt.returnValue = false;
                evt.cancel = true;
                var me = $(this),
                    username = _txtUserName.val(),
                    pwd = _txtPwd.val();
                if (username == '' && pwd == '') {
                    _txtUserName.css('border', _letter[1]);
                    _txtPwd.css('border', _letter[1]);
                    _code.html(_letter[4]);
                    evt.preventDefault();
                    return;
                }
                if (username == '') {
                    _txtUserName.css('border', _letter[1]);
                    _code.html(_letter[2]);
                    evt.preventDefault();
                    return;
                }
                if (pwd == '') {
                    _txtPwd.css('border', _letter[1]);
                    _code.html(_letter[3]);
                    evt.preventDefault();
                    return;
                }
                if (username != '' && pwd != '') {

                    //本地测试
                    varType = "GET";
                    varUrl = "../../data/login.js";
                    varDataType = "json";
                    CallService(false);
                    if ($("#ckbUserName")[0].checked) {
                        SaveUserInfo();
                    }
                }
            }
        }
        //登录键盘事件绑定
        $(document).bind('keyup', function (e) {
            var keyevent = e;
            KeyDown(keyevent);
        });
        //登录单击事件绑定
        $("#btnLogin").bind('click', function (e) {
            var clickevent = e;
            KeyDown(clickevent);
        });
        //chekbox是否记录用户名和密码
        $("#ckbUserName").bind('click', function () {
            if (this.checked) {
                SaveUserInfo();
            } else {
                ClearUserInfo();
            }
        });
    }
    //Generic function to call AXMX/WCF  Service         
    function CallService(isloadpage) {
        $("#wait").show();
        _sker.getSrv({
            type: varType, //GET or POST or PUT or DELETE verb
            url: varUrl, // Location of the service
            data: varData, //Data sent to server
            //contentType: varContentType, // content type sent to server
            dataType: varDataType, //Expected data format from server
            processdata: varProcessData, //True or False
            callback: function (msg) {//On Successfull service call
                ServiceSucceeded(msg, isloadpage);
                //var json = $.parseJSON(msg);
                //本地测试
                var json = msg;
                if (json.Value == true) {
                    redirect("main.html")
                    ////window.location.href = "default.html";
                } else {
                    if (!isloadpage) {
                        _txtUserName.css('border', '1px solid #e93e3a');
                        _txtPwd.css('border', '1px solid #e93e3a');
                        var xml = XmlParser(json.RefResult);
                        _code.html($(xml).find("ServerError").text());
                    }
                }
                $("#wait").hide();
            }
        });
    }
    function ServiceSucceeded(result, isloadpage) {
        // When service call is sucessful
        var SESSION_ID = "sessionid";
        var resultObject = null;
        if (varDataType == "json") {
            if (varUrl.indexOf(".asmx/") > 0) {
                resultObject = result.d; // Constructed object name will be object.d //Button 1
            }
            else if (varType == "GET") {
                resultObject = result;
            }
            else {
                var resultdata = $.parseJSON(result).RefResult;
                //获取登录成功后，返回的sessionid;并保存到cookie中
                var xml = XmlParser(resultdata);
                var sessionid = $(xml).find("SessionId").text();
                var loginname = $(xml).find("EmpName").text();
                var userid = $(xml).find("UserId").text();
                var username = $(xml).find("UserName").text();
                if (!isloadpage) {
                    _sker.cookie("loginname", loginname, { path: '/', expires: 1 });
                    _sker.cookie("UserId", userid, { path: '/', expires: 1 });
                    _sker.cookie("loginuser", username, { path: '/', expires: 1 });
                }

                _sker.cookie(SESSION_ID, sessionid, { path: '/', expires: 1 });
            }
        }

        varType = null; varUrl = null; varData = null; varContentType = null; varDataType = null; varProcessData = null;
    };
    function SaveUserInfo() {
        var USER_NAME = "username";
        var PSD = "password"; //我们增加一个新的变量，注意这里变量的值一定要对定相应html元素的id，不然会报错； 
        var CHECKED = "check";
        var pwd = _txtPwd.val();
        var username = _txtUserName.val();
        var user_pwd = pwd + "||" + username;
        //加密cookie密码
        user_pwd = _sker.comm.compile(user_pwd);
        _sker.cookie(USER_NAME, username, { path: '/', expires: 100 });
        _sker.cookie(PSD, user_pwd, { path: '/', expires: 100 })//同上设置
        _sker.cookie(CHECKED, $("#ckbUserName")[0].checked, { path: '/', expires: 100 })//同上设置
    };
    function ClearUserInfo() {
        var USER_NAME = "username";
        var PSD = "password"; //我们增加一个新的变量，注意这里变量的值一定要对定相应html元素的id，不然会报错； 
        var CHECKED = "check";
        _sker.cookie(USER_NAME, "", { path: '/', expires: 100 });
        _sker.cookie(PSD, "", { path: '/', expires: 100 })//同上设置
        _sker.cookie(CHECKED, false, { path: '/', expires: 100 })//同上设置
    };
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
    function redirect(url) {
        if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
            var referLink = document.createElement('a');
            referLink.href = url;
            document.body.appendChild(referLink);
            referLink.click();
        } else {
            location.href = url;
        }
    };
});