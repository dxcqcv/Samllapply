/*!
* v1.0  前端工具模版，newbillTmplPlus控制器
* http://ygsoft.com/
*
* Author:向文文
* Date: 2012-11-12
*
*/
$$.ctrl.add('newbillTmplPlus', function () {
    var _sker = $$;
    var skinPATH = _sker.skinPATH;
    var array = [];
    var tab = null;
    var classid = null;
    var jGrid_Searched = false;
    var rowsNum = 20;
    var page = 1;
    var pzdetail = "";
    var w = _sker.comm.getWindowWidth() - 10;
    //创建新窗口tabs函数，调用jquery_ui
    var CreateSubPageTabs = function () {
        maintab = $('#tabs').tabs({
            add: function (e, ui) {   //添加选项卡
                var tabid = ui.panel.id;
                if (tabid.slice(0, 4) == "bill") {
                    $(ui.tab).parents('li:first').append('<span class="ui-tabs-close ui-icon ui-icon-close" title="关闭标签页"></span>').find('span.ui-tabs-close').click(function () {
                        maintab.tabs('remove', $('li', maintab).index($(this).parents('li:first')[0]));
                        maintab.tabs('select', 0);
                    });
                    maintab.tabs('select', '#' + tabid);
                }
            },
            select: function (event, ui) {  //注册事件
                var pln = $(ui.panel);
                var tabid = ui.panel.id;
                var clsid = tabid.split('_')[1];
                if (pln.html().length == 0) {
                    CreateBillJqgrid(clsid);
                }
            }
        });
        return maintab;
    };
    var SubPageTabs = CreateSubPageTabs();
    //渲染grid
    function CreateBillJqgrid(classid) {
        //在选项卡下添加需要初始化的gird容器
        $("#tabs_" + classid, "#tabs").empty().append('<table id="billtypegrid_' + classid + '"><tr><td style="padding:10px;font-weight:bold;font-size:14px;color:#525252;">分类列表载入中...</td></tr></table>\
                <div id="gridpager_' + classid + '"></div>');
        //获取需要初始化的jquery-DOM对象
        var gridTable = $("#billtypegrid_" + classid);
        //初始化grid
        gridTable.jqGrid({
            url: _sker.config.WebSrvURL + "/data/billqueryservice" + classid + ".js",
            datatype: 'json',
            ajaxGridOptions: { contentType: 'application/json; charset=utf-8' },
            colNames: ["BillTypeID", "ClassID", "单据类型编号", "单据类型名称", "单据说明"],
            colModel: [
	          	{ name: 'BillTypeID', index: 'BillTypeID', width: 50, hidden: true }, //单据类型id
		        {name: 'ClassID', index: 'ClassID', width: 50, hidden: true },  //单据分类id
	            {name: 'BillTypeCode', index: 'BillTypeCode', width: 200 },  //单据类型编号
	            {name: 'BillTypeName', index: 'BillTypeName', width: 250 },  //单据类型名称
	            {name: 'Description', index: 'Description', width: 400}  //单据说明
	          ],
            rowNum: rowsNum,
            //rowList:[30,60,90],
            jsonReader: { root: "Value", page: "currpage", total: "totalpages", records: "totalrecords", userdata: "userdata", repeatitems: false, id: "0" }
	         , cmTemplate: { sortable: false }
            //, loadui: "disable"
	          , mtype: "GET"
	          , viewrecords: true
	          , pager: '#gridpager_' + classid
	          , emptyrecords: "没有找到数据"
              , autowidth: true
	          , forceFit: true
	          , gridview: true
	          , height: "auto"
            //,postData: {_search: true},prmNames:{search:"true"}
	          , loadError: function (xhr, status, error) { _sker.ShowMsg("加载错误\n\n" + status + "-" + error); }
	          , loadBeforeSend: function (xhr) {
	              var SESSION_ID = "sessionid";
	              var sessionid = $$.cookie(SESSION_ID);
	              xhr.setRequestHeader("sessionid", sessionid);

	          }
	          , loadComplete: function (xhr) {
	              //console.log(xhr);
	              var records = $(this).getGridParam('records');
	              if (records == 0 || xhr.Value[0].ID_Num == null || xhr.Value[0].ID_Num == "" || xhr.Value[0].ID_Num === undefined) {
	                  $(this).clearGridData();
	                  //alert("没有符合查询条件的记录")
	              }
	          }
		        , ondblClickRow: function (rowid, iRow, iCol, e) {
		            var billtypeid = $(this).getCell(rowid, 0);
		            var billtypename = $(this).getCell(rowid, 3);
		            if (billtypeid == null) {
		                _sker.ShowMsg("找不到该单据！");
		                return;
		            }
		            //打开窗口
		            OpenBillServiceCodes(billtypeid, billtypename);
		        }
		    });
        //动态设置一个宽度
        //gridTable.setGridWidth(w);
    };
    //打开单据
    var OpenBillServiceCodes = function (billtypeid, billtypename){
        //打开地址
        var url = "../../data/bill.html";
        //打开单据的名字
        var label = billtypename;
        //打开单据的id
        var st = "#bill_" + billtypeid;
        //如果打开的是相同的单据，则显示那个已经打开的单据
        if ($(st).html() != null){
            SubPageTabs.tabs('select', st);
        } else {
            //调用开打单据tabs选项卡的方法
            SubPageTabs.tabs('add', st, label);
            //每个单据只添加一条iframe
            $(st, "#tabs").empty().append('<iframe frameborder="0" src="' + url + '" style="width: 100%; height: 94%;" id="billTabItemiframe"></iframe>');
        }
    };
    //初始化选项卡，和第一个grid表格展示区域
    var loadInfo = function (){
        //加载分类
        _sker.getSrv({
            type: 'GET',
            url: $$.config.WebSrvURL + "/data/billclass.js",
            callback: function (data) {
                var json = data;
                for (var index = 0; index < json.Value.length; index++) {
                    var item = json.Value[index];
                    if (item.ParentID != "-1") {
                        //渲染tabs选项卡
                        SubPageTabs.tabs('add', "#tabs_" + item.ClassID, item.ClassName);
                        if (classid == null) {
                            classid = item.ClassID;
                            //初始化第一个grid表格
                            CreateBillJqgrid(classid);
                        }
                    }
                }
            }
        });
    };
    loadInfo();
});
