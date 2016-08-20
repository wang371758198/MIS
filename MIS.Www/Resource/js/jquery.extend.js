(function ($) {
    $.extend($.fn.tabs.methods, {
        //显示遮罩  
        loading: function (jq, msg) {
            return jq.each(function () {
                var panel = $(this).tabs("getSelected");
                if (msg == undefined) {
                    msg = "正在加载数据，请稍候...";
                }
                $("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: panel.width(), height: panel.height() }).appendTo(panel);
                $("<div class=\"datagrid-mask-msg\"></div>").html(msg).appendTo(panel).css({ display: "block", left: (panel.width() - $("div.datagrid-mask-msg", panel).outerWidth()) / 2, top: (panel.height() - $("div.datagrid-mask-msg", panel).outerHeight()) / 2 });
            });
        }
,
        //隐藏遮罩  
        loaded: function (jq) {
            return jq.each(function () {
                var panel = $(this).tabs("getSelected");
                panel.find("div.datagrid-mask-msg").remove();
                panel.find("div.datagrid-mask").remove();
            });
        }
    });


    $.fn.addTab = function (options) {
        options = typeof options == 'object' ? options : {};
        var tab = $(this).tabs("getTab", options.title);
        if (tab) {
            $(this).tabs("select", options.title);
            return;
        } else {

            $(this).tabs('add', {
                id: options.id,
                title: options.title,
                iconCls: options.iconCls,
                fit: true,
                //content: '<iframe id="' + options.id + '_iframe" src=' + options.src + ' height="100%" width="100%" scrolling="no" frameborder="no" />',
                href: options.href,
                cache: false,
                closable: true
            });
        }
    }

    $.fn.tabRefresh = function (title) {
        var tab = $(this).tabs("getTab", title);
        if (tab) {
            tab.panel("refresh");
        }
    }

    $.fn.fileUpload = function (obj, showImgID, hidUriID, formID) {
        var fileID = $(obj).attr("id");
        $.ajaxFileUpload({
            url: '/Hepler/ImageFileUpload',//处理图片脚本
            secureuri: false,
            fileElementId: fileID,//file控件id
            type: 'post',
            dataType: 'json',
            async: false,
            success: function (result) {
                if (result.Uri) {
                    $('#' + showImgID + ',#' + formID).attr("src", result.Uri);
                    $('#' + hidUriID + ',#' + formID).val(result.Uri);
                }
            },
            error: function (data, status, e) {
                console.log("fail");
            }
        });
    }

    // 对Date的扩展，将 Date 转化为指定格式的String
    // 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
    // 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
    // 例子： 
    // (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
    // (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
    Date.prototype.Format = function (fmt) { //author: meizz 
        var o = {
            "M+": this.getMonth() + 1, //月份 
            "d+": this.getDate(), //日 
            "h+": this.getHours(), //小时 
            "m+": this.getMinutes(), //分 
            "s+": this.getSeconds(), //秒 
            "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
            "S": this.getMilliseconds() //毫秒 
        };
        if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        return fmt;
    };

})(jQuery)