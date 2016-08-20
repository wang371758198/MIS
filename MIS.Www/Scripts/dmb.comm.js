/*
框架公用的js方法，以及扩展的js方法
创建时间:2016-07-22
创建人:王俊桥
*/

document.oncontextmenu = function (e) {
   
   
    $('.page-content').rightHand({
        nodes: [{
            id: "reload",
            name: "刷新",
            click: function () {
                location.reload();
            }
        }, { id: "copy", name: "复制", click: function () { } },
        { id: "paste",name:"粘贴" }
        ],
        pageX: e.pageX,
        pageY: e.pageY,
        complete: function () {
            /*复制*/
            $('#copy').zclip({
                path: '/Scripts/jquery.zclip/ZeroClipboard.swf',
                copy: function () {
                    try {
                        var selecter = window.getSelection();
                        if (selecter.toString().length > 1) {
                            //console.log(selecter.toString());
                            return selecter.toString();
                        } else {
                            return "";
                        }
                    } catch (err) {
                        console.log("粘贴板错误信息");
                        return "";
                    }
                },
                afterCopy: function () {
                    //alert("完成");
                }
            });
            
        }
    });
    return false;
}

$.fn.rightHand = function (params) {
    var rightMenu = {
        create: function () {
            var ul = document.createElement("ul");
            ul.className = "ui-menu ui-widget ui-widget-content";
            ul.id = "right_handMenu";
            ul.style.position = "fixed";
            ul.style.left = params.pageX+"px";
            ul.style.top = params.pageY + "px";

            params.nodes.forEach(function (e) {
                var li = document.createElement("li");
                li.className = "ui-menu-item";
                li.id = e.id;
                li.onclick = e.click;
                li.innerHTML = e.name;
                ul.appendChild(li);
            });
            self.append(ul);
            params.complete();
            $('body').on('click', function () {
                var menu = $('#right_handMenu');
                if (menu) {
                    if (menu.css("display") != "none") {
                        menu.hide();
                    }
                }
            });

        }
    };

    if (typeof params == "object" && !params.length) {
        var self = this;
       
        if (document.getElementById('right_handMenu')) {
            $('#right_handMenu').css({left:params.pageX+'px',top:params.pageY+'px'});
            $('#right_handMenu').show();
        } else {
            rightMenu.create();
        };

        
    } else {
        return;
    }
}




/*
$('#right_handMenu').on('click', '#copy', function (e) {
   
    $(this).append(Html(10, 10));
    var movie = document.getElementById("copyMovie");
    try {
        var selecter = window.getSelection();
        if (selecter.toString().length > 1) {
            console.log(selecter.toString());
            console.log(movie);
           movie.setText(selecter.toString());
        } else {
           console.log(selecter)
        }
    } catch (err) {
      
            alert(err)
        
    }
   
});
*/
/*
//阻塞复制的鼠标
$('#right_handMenu').on('mousedown', '#copy', function () {
    return false;
})
*/
