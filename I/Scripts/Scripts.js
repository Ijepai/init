Util = {
    loginAnimTime: 1000,
    logoutAnimTime: 1000,
    setTopNavLinks: function () {
        var pages = new Array("labNav", "usersNav", "configNav", "helpNav", "contactNav", "forumNav");
        for (i in pages) {
            $("#" + pages[i] + " a").bind("click", function (event) {
                event.preventDefault();
                $("#activeTab").attr("id", "");
                $(this).attr("id", "activeTab");
                $("#tabContent .activeSec").hide().removeClass("activeSec");
                $($(this).attr("href")).show().addClass("activeSec");
            })
        }
        $("#logout").bind("click", function (event) {
            event.preventDefault();
            $("#activeTab").attr("id", "");
            $(this).attr("id", "activeTab");
            $("#logoutForm").trigger("submit");
        });
    },
    loginUI: function (animTime) {
        $("#topNav .hidden").show(animTime);
        $("#loginSec").slideUp(animTime, function () {
            $("#loginStatus").attr("class", "").html("");
            $("#form0")[0].reset();
            $("#labNav").trigger("click");
        })
        $("#topNav #activeTab").attr("id", "");
    },
    logoutUI: function (animTime) {
        $("#topNav .hidden").hide(animTime);
        $("#loginSec").slideDown(animTime, function () {
        })
    },
    loginEvt: function (animTime) {
        Util.loginUI(animTime);
        Labs.loadLabs();
        $("#labNav a").trigger("click");
    },
    logoutEvt: function (animTime) {
        Util.logoutUI(animTime);
    },
    getLogoutForm: function (act) {
        act = act ? act : "login";
        $.ajax({
            url: "/Account/LogoutSec",
            type: "POST",
            data: {},
            success: function (result) {
                $("#logoutSec").html(result);
                Util.xs = $("#logoutForm input[name=__RequestVerificationToken]").val();
                if (act == "logout") {
                    Util.logoutEvt();
                    $("#form0 input[name=__RequestVerificationToken]").val(Util.xs);
                } else {
                    Util.loginEvt(Util.loginAnimTime);
                }
                $.ajaxSetup({ data: { "__RequestVerificationToken": Util.xs, "OrganizationHkey": Util.OrganizationHkey, "OrganizationCode": Util.OrganizationCode } })
            }
        })
    },
    logoutSuccess: function (response) {
        if (response.Status == "0") {
            Util.getLogoutForm("logout");
            //location.reload(true)
        } else if (response.Status == "1") {
        }
    },
    logoutFailure: function (response) {

    },
    loginSuccess: function (response) {
        if (response.Status == "0") {
            Util.getLogoutForm();
            $("#loginStatus").attr("class", "loginSuccess").html(response.Message);
            Util.user = response.Hkey;
        } else if (response.Status == "1") {
            $("#loginStatus").attr("class", "loginFailure").html(response.Message);
        }
    },
    loginFailure: function (response) {

    }
}
$(document).ready(function () {
    Util.xs = $("#logoutForm input[name=__RequestVerificationToken]").val();
    setTimeout(function () {
        document.getElementById('OrganizationCode').focus();
        document.getElementById("form0").reset();
    }, 10);
    if (Util.loggedIn) {
        Util.loginEvt(0);
        $.ajaxSetup({ data: { "__RequestVerificationToken": Util.xs } })
    }
    $("#page").css("display", "block")
    Util.setTopNavLinks();
    $("#content").outerHeight($(document).height() - $("header").outerHeight() - $("footer").outerHeight() - 3);
    var contentHeight = $("#content").height();
    var pages = new Array("mainContent", "tabContent", "loginSec", "pages", "labsSec", "usersSec", "contactSec", "configSec", "forumSec", "helpSec")
    for (i in pages) {
        $("#" + pages[i]).outerHeight(contentHeight);
    }
})