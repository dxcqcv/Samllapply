/*!
* v1.0  前端工具模版，公共调用器
* http://ygsoft.com/
*
* Author:向文文
* Date: 2012-11-12
*
*/
var _sker = $$;
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
    if(firstsrc !== undefined){
        ServiceNav(firstsrc);
    } 
    var _nav = $('#nav');
    $('#nav li').eq(0).addClass('newshover');
    _nav.bind('click', function (e) {
        var tar = e.target,
            $tar = $(tar),
            nodeName = tar.nodeName,
            $li = $('#nav li');
        if(nodeName === 'A'){
            var href = $tar.attr('href'),
                src = href.substring(1),
                li = $tar.parent();
            $li.removeClass('newshover');
            li.addClass('newshover');
            ServiceNav(src);
        }
        if(nodeName === 'SPAN'){
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