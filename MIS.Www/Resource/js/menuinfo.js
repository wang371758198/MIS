(function ($) {

    var MenuInfoTable = {
        add: function () {
            $('#edit').dialog({
                title: "菜单信息",
                cache: false,
                width: 400,
                height: 350,
                model: true,
                // shadow: true,
                href: "/MenuInfo/GetEntity",
                method: "post",
                queryParams: null,
                inline: true,
                buttons: [{
                    text: "保存",
                    iconCls: "icon-ok",
                    handler: function () {
                        $('#menuInfoForm').form("submit", {
                            url: "/MenuInfo/Edit",
                            success: function (result) {
                                var obj = JSON.parse(result);
                                obj = JSON.parse(obj);
                              
                                if (obj.Status == 1) {
                                    $.messager.alert("系统提示", obj.Msg);
                                    $("#edit").dialog("close");
                                    $('#tabs').tabRefresh("菜单列表");
                                } else {
                                    $.messager.alert("系统提示", obj.Msg);
                                }
                            }
                        });
                    }
                }, {
                    text: "取 消",
                    iconCls: "icon-cancel",
                    handler: function () {
                        $('#edit').dialog("close");
                    }
                }]
            });
        },
        update: function () {
            var row = $('#MenuInfoTable').treegrid("getSelected");
            if (row) {
                row.ParentMenuID = row._parentId;
                $('#edit').dialog({
                    title: "菜单信息",
                    cache: false,
                    width: 400,
                    height: 350,
                    model: true,
                    // shadow: true,
                    href: "/MenuInfo/GetEntity",
                    method: "post",
                    queryParams: row,
                    inline: true,
                    buttons: [{
                        text: "保存",
                        iconCls: "icon-ok",
                        handler: function () {
                            $('#menuInfoForm').form("submit", {
                                url: "/MenuInfo/Edit",
                                success: function (result) {
                                    var obj = JSON.parse(result);
                                    obj = JSON.parse(obj);
                                   
                                    if (obj.Status == 1) {
                                        $.messager.alert("系统提示", obj.Msg);
                                        $("#edit").dialog("close");
                                        $('#tabs').tabRefresh("菜单列表");
                                    } else {
                                        $.messager.alert("系统提示", obj.Msg);
                                    }
                                }
                            });
                        }
                    }, {
                        text: "取 消",
                        iconCls: "icon-cancel",
                        handler: function () {
                            $('#edit').dialog("close");
                        }
                    }]

                });
            }
        },
        formatter: function (value, row, index) {
            if (value) {
                return '<img src="'+value+'" style="width:30px;height:24px;margin:0px;" />'
            }
        },
        del: function () {
            $.messager.confirm("系统提示", "您确定删除吗？", function (r) {
                if (r) {
                    var row = $('#MenuInfoTable').datagrid("getSelected");
                    if (row) {
                        $.ajax({
                            type: 'post',
                            url: '/MenuInfo/Delete',
                            data: { id: row.ID }
                        }).done(function (result) {
                            if (result == 1) {
                                $('#tabs').tabRefresh("菜单列表");
                            } else {
                                $.messager.alert("系统提示","删除失败！");
                            }
                        }).fail(function (err,status,code) {
                            console.log(status);
                        });
                    }
                }
            });
        }
    };

    $('#MenuInfoTable').treegrid({
        idField: 'ID',
        treeField: 'MenuName',
        fit: true,
        url: '/menuinfo/getlist',
        method: 'post',
        columns: [[
            { field: 'ID', checkbox: true, width: '5%' },
            { field: 'MenuName', title: '菜单名称', width: '15%' },
            { field: 'Uri', title: 'Uri', width: '20%' },
            { field: 'Grade', title: '排序(从小到大)', width: '10%' },
            { field: 'Icon', title: '图标', width: '10%', formatter: function (value, row, index) { return  MenuInfoTable.formatter(value, row, index); } },
            { field: 'Remark', title: '备注', width: '20%' },
            { field: 'CreateDateTime', title: '创建时间', width: '10%' },
            { field: 'UpdateDateTime', title: '更新时间', width: '10%' }
        ]],
        toolbar: '#menuToolbar',
        onSelect: function (rowIndex, rowData) {
            $('#btnEdit').linkbutton("enable");
            $('#btnDel').linkbutton("enable");
        }
    });


    $('#btnAdd').on('click', function () {
        MenuInfoTable.add();
    });
    $('#btnEdit').on('click', function () {
        MenuInfoTable.update();
    });
    $('#btnDel').on('click', function () {
        MenuInfoTable.del();
    });
})(jQuery);
