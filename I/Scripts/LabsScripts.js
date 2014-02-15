var Labs = {
    loadLabs: function () {
        $("#labs").jqGrid({
            url: '/Lab',
            data: 'a=b',
            datatype: 'json',
            mtype: 'POST',
            colNames: ['Lab Name', 'Start time', 'End time', 'Total Vms', 'Hkey'],
            colModel: [
                { name: 'Name', index: 'Name', width: 100 },
                { name: 'Start', index: 'Start', width: 200 },
                { name: 'End', index: 'End', width: 200 },
                { name: 'TotalVMs', index: 'TotalVMs', width: 100 },
                { name: 'Hkey', index: 'Hkey', width: 300 }
            ],
            pager: '#labs-pager',
            rowNum: 10,
            rowList: [10, 20, 30],
            sortname: 'Name',
            viewrecords: true,
            sortorder: "desc",
            caption: "Existing Labs"
        }).navGrid('#labs-pager', { edit: true, add: true, del: true, search: true },
            {
                url: "/Lab/EditLab"
            },
            {
                url: "/Lab/CreateLab"
            },
            {
                url: "/Lab/DeleteLab",
            },
            {
                url: "/Lab/SearchLab"
            }
        );
    }
}
$(document).ready(function () {
    $(function () {
        var name = $("#lab-name"),
        start = $("#lab-start"),
        end = $("#lab-end"),
        allFields = $([]).add(name).add(start).add(end),
        tips = $(".validateTips");
        function updateTips(t) {
            tips
            .text(t)
            .addClass("ui-state-highlight");
            setTimeout(function () {
                tips.removeClass("ui-state-highlight", 1500);
            }, 500);
        }
        $("#lab-create-form-wrap").dialog({
            autoOpen: false,
            height: 300,
            width: 350,
            modal: true,
            title: "Create a new Lab",
            buttons: {
                "Create it": function () {
                    $("#lab-create-form").trigger("submit");
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            },
            close: function () {
                allFields.val("").removeClass("ui-state-error");
            }
        });
        $("#create-lab").button().click(function () {
            $("#lab-create-form-wrap").dialog("open");
        });
    });
})