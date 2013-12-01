jQuery.fn.cssNumber = function (prop) {
    var v = parseInt(this.css(prop), 10);
    return isNaN(v) ? 0 : v;
};
function capitalize(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}
function isNumeric(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}


var bd = $("body");

bd.addClass("loading");
bd.addClass("notlogreg");

var wrap = $("#wrap");
var bodyd = $("#bodyD");
var twidth = 739;



$(window).resize(function () {
    if (parseInt($(window).width()) < 980) bd.css("overflow-x", "auto");
    else bd.css("overflow-x", "hidden");
});
if (parseInt($(window).width()) < 980) bd.css("overflow-x", "auto");

$("body,*").css("cursor", "progress");

//// --------------------------------------------------  ////

//   1       2        3      4
var news, company, contact, jobs;
var DATA;
$.get('website.aspx', function (data) { DATA = data; });

var hasDoneProgressing = false;
$("#progressValue").animate({ width: "100%" }, 3000, function () { hasDoneProgressing = true; });


$(document).ajaxComplete(function () {
    som();


    news = $(DATA).find('#news').html();
    company = $(DATA).find('#company').html();
    contact = $(DATA).find('#contact').html();
    jobs = $(DATA).find('#jobs').html();


    wrap.animate({ opacity: 1 }, 1000, function () {

        // preload images;
        var imgs = new Array('images/arrow.png', 'images/arrow1.png', 'images/back.png', 'images/exit.png', 'images/head.png');
        for (var i = 0; i < imgs.length; i++) {
            new Image().src = imgs[i];
        }

        wrap.css("width", twidth * 4);
        var nhtml = "";
        for (var i = 1; i <= 4; i++) {
            nhtml += "<div id=" + i + " class='indie'>";
            switch (i) {
                case 1: nhtml += news; break;
                case 2: nhtml += company; break;
                case 3: nhtml += contact; break;
                case 4: nhtml += jobs; break;
            }
            nhtml += "</div>";
        }
        wrap.html(nhtml);
        wrap.css("margin-left", -twidth);


        $("#menu span:nth-child(2)").css("color", "rgba(0,0,0,1)");


        if (hasDoneProgressing == false) {
            $("#progressValue").stop(); // stop the current animation
            $("#progressValue").animate({ width: "100%" }, 800, function () { // start a faster animation until finished                     // ---- 800 ----
                $("#progressValue").animate({ width: "100%" }, 400, function () { // wait 0.4 secs; continue.                                // ---- 400 ----
                    bd.removeClass("loading");
                    bd.addClass("reg");

                    $("body,*").css("cursor", "default");
                    $(".link, a").css("cursor", "pointer");
                    $("input:not([type=submit]):not([type=file]):not([type=checkbox])").css("cursor", "text");
                });
            });
        }
        else {
            $("#progressValue").animate({ width: "100%" }, 400, function () { // wait 0.4 secs; continue.
                bd.removeClass("loading");
                bd.addClass("reg");

                $("body,*").css("cursor", "default");
                $(".link, a").css("cursor", "pointer");
                $("input:not([type=submit]):not([type=file]):not([type=checkbox])").css("cursor", "text");
            });
        }



        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_GB/all.js#xfbml=1";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
        !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');
    });
});




//// --------------------------------------------------  ////


$("#login").click(function () {
    openLogin();
});
$("#exit").click(function () {
    closie();
});
$("#back").click(function () {
    if ($('body').hasClass('regi'))
        $("#registerDiv").animate({ "width": "0%", "height": "0%" }, 400, function () {
            bd.addClass("notlogreg");
            bd.removeClass("logn");
            bd.removeClass("regi");
            bd.removeClass("forg");
            openLogin();
        });
    if ($('body').hasClass('forg'))
        $("#forgottenDiv").animate({ "width": "0%", "height": "0%" }, 400, function () {
            bd.addClass("notlogreg");
            bd.removeClass("logn");
            bd.removeClass("regi");
            bd.removeClass("forg");
            openLogin();
        });
    if ($('body').hasClass('eProf')) {
        bd.removeClass("eProf");
        bd.addClass("prof");
        if (proHtml) $("#ProfileChild").html(proHtml);
        else {
            $("#ProfileChild").css("display", "block");
            $("#imageUploader").css("display", "none");
            $("#ChangePass").css("display", "none");
        }
    }
});
$(document).keyup(function (e) {
    if (e.keyCode == 27) { closie(); }
});


function closie() {
    if ($('body').hasClass('logn')) {
        $("#logindiv").animate({ "width": "0%", "height": "0%" }, 400, function () {
            bd.addClass("notlogreg");
            bd.removeClass("logn");
            bd.removeClass("regi");
            bd.removeClass("forg");
        });
    }
    if ($('body').hasClass('regi')) {
        $("#registerDiv").animate({ "width": "0%", "height": "0%" }, 400, function () {
            $("#logindiv").animate({ "width": "0%", "height": "0%" }, 0, function () {
                bd.addClass("notlogreg");
                bd.removeClass("logn");
                bd.removeClass("regi");
                bd.removeClass("forg");
            });
        });
    }
    if ($('body').hasClass('forg')) {
        $("#forgottenDiv").animate({ "width": "0%", "height": "0%" }, 400, function () {
            $("#logindiv").animate({ "width": "0%", "height": "0%" }, 0, function () {
                bd.addClass("notlogreg");
                bd.removeClass("logn");
                bd.removeClass("regi");
                bd.removeClass("forg");
            });
        });
    }
    if ($('body').hasClass('dgames')) {
        $("#gamesDiv").animate({ "width": "0%", "height": "0%" }, 400, function () {
            bd.addClass("notlogreg");
            bd.removeClass("dgames");
        });
    }
    if ($('body').hasClass('prof')) {
        $("#ProfileChild").css("width", "462px");
        $("#ProfileDiv").animate({ "width": "0%", "height": "0%" }, 400, function () {
            bd.addClass("notlogreg");
            bd.removeClass("prof");
        });
    }
    if ($('body').hasClass('eProf')) {
        $("#ProfileChild").css("width", "462px");
        $("#ProfileDiv").animate({ "width": "0%", "height": "0%" }, 400, function () {
            bd.addClass("notlogreg");
            bd.removeClass("eProf");

            if (proHtml) $("#ProfileChild").html(proHtml);
            else {
                $("#ProfileChild").css("display", "block");
                $("#imageUploader").css("display", "none");
                $("#ChangePass").css("display", "none");
            }
        });
    }

}
function openLogin() {
    bd.removeClass("notlogreg");
    bd.removeClass("regi");
    bd.removeClass("forg");
    bd.removeClass("prof");
    bd.addClass("logn");
    $("#logindiv").animate({ "width": "100%", "height": "80%" }, 600);
}
function openRegister() {
    bd.removeClass("notlogreg");
    bd.removeClass("logn");
    bd.removeClass("forg");
    bd.removeClass("prof");
    bd.addClass("regi");
    $("#registerDiv").animate({ "width": "100%", "height": "80%" }, 600);



    var dayXX = $("#day");
    var monthXX = $("#month");
    var yearXX = $("#year");

    monthXX.change(function () {
        valiDate('m');
    });
    dayXX.change(function () {
        valiDate('d');
    });
    yearXX.change(function () {
        valiDate('y');
    });

    var strin = "<option value='Day'>Day</option>";
    for (var i = 1; i < 32; i++) {
        strin += "<option value='" + i + "'>" + i + "</option>";
    }
    dayXX.html(strin);
    strin = "<option value='Month'>Month</option>";
    for (var i = 1; i < 13; i++) {
        strin += "<option value='" + i + "'>" + i + "</option>";
    }
    monthXX.html(strin);
    strin = "<option value='Year'>Year</option>";
    for (var i = 2013; i > 1909; i--) {
        strin += "<option value='" + i + "'>" + i + "</option>";
    }
    yearXX.html(strin);
}
function openProfile() {
    bd.removeClass("notlogreg");
    bd.removeClass("regi");
    bd.removeClass("forg");
    bd.addClass("prof");

    var counter = 0;

    $.ajax({
        type: "POST",
        url: "default.aspx/FillProfile",
        data: JSON.stringify({}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $(data.d).each(function (index, value) {
                counter++;
                switch (counter) {
                    case 1: $("#usernameLabel").html(value); break;
                    case 2: $("#emailLabel").html(value); break;
                    case 3: $("#firstNameLabel").html(value); break;
                    case 4: $("#lastNameLabel").html(value); break;
                    case 5: $("#countryLabel").html(value); break;
                    case 6: $("#cityLabel").html(value); break;
                    case 7: $("#birthdayLabel").html(value); break;
                    case 8:
                        if (!value) { $("#imageTd").css("border", "border: 1px solid rgba(0,0,0,0.7)"); }
                        $("#imageTd").html(value); break;
                }
            });
        }
    });


    $("#ProfileDiv").animate({ "width": "100%", "height": "80%" }, 600);
}
var proHtml = "";
function openEditProfile() {
    proHtml = $("#ProfileChild").html();

    bd.removeClass("prof");
    bd.addClass("eProf");

    var nHtml = "<br /><br /><span class='headline'>Edit Profile</span><br /><br /><table class='proTable'>";
    nHtml += "<tr><td>First Name:</td><td><input type='text' id='efName' /></td><td style='padding:0px;'><label id='efLabel' style='position:absolute; margin-top: -8px;'/></td></tr>";
    nHtml += "<tr><td>Last Name:</td><td><input type='text' id='elName' /></td><td style='padding:0px;'><label id='elLabel' style='position:absolute; margin-top: -8px;'/></td></tr>";
    nHtml += "<tr><td>Email:</td><td><input type='text' id='eEmail' /></td><td style='padding:0px;'><label id='eeLabel' style='position:absolute; margin-top: -8px;'/></td></tr>";
    nHtml += "<tr><td>Birthday:</td><td><span id='bDaySpan'></span></td></tr>";
    nHtml += "<tr><td>Country:</td><td><input type='text' id='eCountry' /></td><td style='padding:0px;'><label id='ecuLabel' style='position:absolute; margin-top: -8px;'/></td></tr>";
    nHtml += "<tr><td>City:</td><td><input type='text' id='eCity' /></td><td style='padding:0px;'><label id='eciLabel' style='position:absolute; margin-top: -8px;'/></td></tr></table><br /><br />";
    nHtml += "<label id='elabel' style='position:absolute;margin-top:8px;'/>";
    nHtml += "<button id='saveChanges' onclick='saveProfile();return false;' style='margin-left: 316px;'>Save Changes</button>"

    $("#ProfileChild").html(nHtml);

    $("#bDaySpan").html("<select style='width: 50px;' id='eday'></select><select style='width: 68px;' id='emonth'></select><select style='width: 58px;' id='eyear'></select>");

    var dVar, mVar, yVar;
    var counter = 0;
    $.ajax({
        type: "POST",
        url: "default.aspx/FillProfile",
        data: JSON.stringify({}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $(data.d).each(function (index, value) {
                counter++;
                switch (counter) {
                    case 2: $("#eEmail").val(value); break;
                    case 3: $("#efName").val(value); break;
                    case 4: $("#elName").val(value); break;
                    case 5: $("#eCountry").val(value); break;
                    case 6: $("#eCity").val(value); break;
                    case 7: dVar = value.substring(0, value.indexOf('.'));
                        mVar = value.substring(value.indexOf('.') + 1, value.lastIndexOf('.'));
                        yVar = value.substring(value.lastIndexOf('.') + 1); break;
                }



                var dayX = $("#eday");
                var monthX = $("#emonth");
                var yearX = $("#eyear");

                monthX.change(function () {
                    evaliDate('m');
                });
                dayX.change(function () {
                    evaliDate('d');
                });
                yearX.change(function () {
                    evaliDate('y');
                });

                var strin = "<option value='Day'>Day</option>";
                for (var i = 1; i < 32; i++) {
                    if (i == dVar) strin += "<option value='" + i + "' selected='selected'>" + i + "</option>";
                    else strin += "<option value='" + i + "'>" + i + "</option>";
                }
                dayX.html(strin);
                strin = "<option value='Month'>Month</option>";
                for (var i = 1; i < 13; i++) {
                    if (i == mVar) strin += "<option value='" + i + "' selected='selected'>" + i + "</option>";
                    else strin += "<option value='" + i + "'>" + i + "</option>";
                }
                monthX.html(strin);
                strin = "<option value='Year'>Year</option>";
                for (var i = 2013; i > 1909; i--) {
                    if (i == yVar) strin += "<option value='" + i + "' selected='selected'>" + i + "</option>";
                    else strin += "<option value='" + i + "'>" + i + "</option>";
                }
                yearX.html(strin);
            });
        }
    });
    return false;
}
function openImageChanger() {
    bd.removeClass("prof");
    bd.addClass("eProf");

    $("#ProfileChild").css("display", "none");
    $("#imageUploader").css("display", "block");

    proHtml = "";

    return false;
}
function openPassChanger() {
    bd.removeClass("prof");
    bd.addClass("eProf");

    $("#ProfileChild").css("display", "none");
    $("#ChangePass").css("display", "block");

    proHtml = "";

    return false;
}
function openForgotten() {
    bd.removeClass("notlogreg");
    bd.removeClass("logn");
    bd.removeClass("regi");
    bd.addClass("forg");
    $("#forgottenDiv").animate({ "width": "100%", "height": "80%" }, 600);
}
function gamesFunc() {
    bd.removeClass("notlogreg");
    bd.removeClass("prof");
    bd.addClass("dgames");

    $("#gamesDiv").load("website.aspx #Games");
    $("#gamesDiv").animate({ "width": "100%", "height": "100%" }, { duration: 600, queue: false });
}

function valiDate(type) {
    var dayXX = $("#day");
    var monthXX = $("#month");
    var yearXX = $("#year");
    var daysInMonth = new Array(31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);

    var sDay = dayXX.find("option:selected").val();
    var sMonth = monthXX.find("option:selected").val();
    var sYear = yearXX.find("option:selected").val();

    if (type == 'm') {
        if (sDay != "Day" && sMonth != "Month") {
            if (sDay > daysInMonth[sMonth - 1]) {
                dayXX.val("Day");
            }
            else if (sMonth == 2 && sDay == 29 && sYear != "Year") {
                if (Number(sYear.toString().substr(2)) % 4 != 0)
                    dayXX.val("Day");
            }
        }
    }
    if (type == 'd') {
        if (sDay != "Day" && sMonth != "Month") {
            if (sDay > daysInMonth[sMonth - 1]) {
                monthXX.val("Month");
            }
            else if (sMonth == 2 && sDay == 29 && sYear != "Year") {
                if (Number(sYear.toString().substr(2)) % 4 != 0)
                    monthXX.val("Month");
            }
        }
    }
    if (type == 'y') {
        if (sDay != "Day" && sMonth != "Month" && sYear != "Year") {
            if (sMonth == 2 && sDay == 29) {
                if (Number(sYear.toString().substr(2)) % 4 != 0)
                    dayXX.val("Day");
            }
        }
    }
}
function evaliDate(type) {
    var dayX = $("#eday");
    var monthX = $("#emonth");
    var yearX = $("#eyear");
    var daysInMonth = new Array(31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);

    var sDay = dayX.find("option:selected").val();
    var sMonth = monthX.find("option:selected").val();
    var sYear = yearX.find("option:selected").val();

    if (type == 'm') {
        if (sDay != "Day" && sMonth != "Month") {
            if (sDay > daysInMonth[sMonth - 1]) {
                dayX.val("Day");
            }
            else if (sMonth == 2 && sDay == 29 && sYear != "Year") {
                if (Number(sYear.toString().substr(2)) % 4 != 0)
                    dayX.val("Day");
            }
        }
    }
    if (type == 'd') {
        if (sDay != "Day" && sMonth != "Month") {
            if (sDay > daysInMonth[sMonth - 1]) {
                monthX.val("Month");
            }
            else if (sMonth == 2 && sDay == 29 && sYear != "Year") {
                if (Number(sYear.toString().substr(2)) % 4 != 0)
                    monthX.val("Month");
            }
        }
    }
    if (type == 'y') {
        if (sDay != "Day" && sMonth != "Month" && sYear != "Year") {
            if (sMonth == 2 && sDay == 29) {
                if (Number(sYear.toString().substr(2)) % 4 != 0)
                    dayX.val("Day");
            }
        }
    }
}



var currentPage = 2;
//left arrow
$("#a1").click(function () {
    if (currentPage > 1) {
        currentPage--;
        changePage(currentPage);
    }
});
//right arrow
$("#a2").click(function () {
    if (currentPage < 4) {
        currentPage++;
        changePage(currentPage);
    }
});
$("#titleD").click(function () {
    if (currentPage != 2) {
        currentPage = 2;
        changePage(currentPage);
    }
});

function changePage(index) {
    if (index != 1) $("#menu span:nth-child(1)").css("color", "rgba(0,0,0,0.7)");
    if (index != 2) $("#menu span:nth-child(2)").css("color", "rgba(0,0,0,0.7)");
    if (index != 3) $("#menu span:nth-child(3)").css("color", "rgba(0,0,0,0.7)");
    if (index != 4) $("#menu span:nth-child(4)").css("color", "rgba(0,0,0,0.7)");

    wrap.stop(true, false);

    switch (index) {
        case 1: $("#menu span:nth-child(1)").css("color", "rgba(0,0,0,1)"); wrap.animate({ "margin-left": 0 * -twidth }, 1000); break;
        case 2: $("#menu span:nth-child(2)").css("color", "rgba(0,0,0,1)"); wrap.animate({ "margin-left": 1 * -twidth }, 1000); break;
        case 3: $("#menu span:nth-child(3)").css("color", "rgba(0,0,0,1)"); wrap.animate({ "margin-left": 2 * -twidth }, 1000); break;
        case 4: $("#menu span:nth-child(4)").css("color", "rgba(0,0,0,1)"); wrap.animate({ "margin-left": 3 * -twidth }, 1000); break;
    }
}


$("#menu span:nth-child(1)").click(function () {
    if (currentPage != 1) {
        currentPage = 1;
        changePage(currentPage);
    }
});
$("#menu span:nth-child(2)").click(function () {
    if (currentPage != 2) {
        currentPage = 2;
        changePage(currentPage);
    }
});
$("#menu span:nth-child(3)").click(function () {
    if (currentPage != 3) {
        currentPage = 3;
        changePage(currentPage);
    }
});
$("#menu span:nth-child(4)").click(function () {
    if (currentPage != 4) {
        currentPage = 4;
        changePage(currentPage);
    }
});


//// --------------------------------------------------  ////




function LogIn() {
    $("#log").attr('disabled', 'disabled');

    var usr = $('#user').val();
    var pss = $('#pass').val();
    var err = $('#errorLabel');

    if (usr) {
        if (pss)
            $.ajax({
                type: "POST",
                url: "default.aspx/doesExists",
                data: JSON.stringify({ st: usr }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {

                    if (msg.d.toLowerCase() == "true") {
                        $.ajax({
                            type: "POST",
                            url: "default.aspx/isPassword",
                            data: JSON.stringify({ username: usr, password: pss }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (msg3) {
                                if (msg3.d.toLowerCase() == "true") {
                                    err.html("Logged in successfully");
                                    closie();
                                    __doPostBack('loginb', '');
                                    return true;
                                }
                                else err.html("Wrong password");
                            }
                        });
                    }

                    else {
                        $.ajax({
                            type: "POST",
                            url: "default.aspx/isAdmin",
                            data: JSON.stringify({ user: usr, pass: pss }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (msg2) {
                                if (msg2.d == "true") {
                                    err.html("Logged in successfully");
                                    closie();
                                    __doPostBack('loginb', '');
                                    return true;
                                }
                            }
                        });
                    }

                    if (msg.d.toLowerCase() == "false") err.html("This username does not exist");
                    if (msg.d.toLowerCase() == "nonactive") {
                        err.html("This username was not activated");
                        $("#rrrr").html("<input type='text' id='newEmail' style='width: 235px;' placeholder='New email adress; empty for no change.' /><br/><span id='resend' onclick='resendemail()' class='link clickSpan'><span style='color:red;'> ** </span>Re-send activation email</span>");
                    }
                },
                complete: function () {
                    $("#log").removeAttr('disabled');
                }
            });
        else { $("#log").removeAttr('disabled'); err.html("password can not be empty"); }
    }
    else { $("#log").removeAttr('disabled'); err.html("username can not be empty"); }

    return false;
}

var cani = true;
function Register() {
    $("#regis").attr('disabled', 'disabled');
    cani = true;
    validate(2);
    for (var i = 4; i < 9; i++) {
        validate(i);
    }
    vali();


    var rusr = $("#ruser").val();
    var rmail = $("#email").val();

    if (rusr == "admin") {
        $("#Label1").html(" <span style='color:red;'>This username is already taken</span>");
        cani = false;
    }

    $.ajax({
        type: "POST",
        url: "default.aspx/checkBeforeReg",
        data: JSON.stringify({ st: rusr, mail: rmail }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            if (msg.d == "both") {
                $("#Label3").html(" <span style='color:red;'>This email address is already taken</span>");
                $("#Label1").html(" <span style='color:red;'>This username is already taken</span>");
                cani = false;
            }
            if (msg.d == "mail") {
                $("#Label3").html(" <span style='color:red;'>This email address is already taken</span>");
                cani = false;
            }
            if (msg.d == "user") {
                $("#Label1").html(" <span style='color:red;'>This username is already taken</span>");
                cani = false;
            }


            var rlabel = $("#rlabel");
            if (cani) {
                var rpss = $("#rpass").val();
                var rfname = $("#fname").val();
                var rlname = $("#lname").val();
                var rday = $("#day").find(":selected").text();
                var rmonth = $("#month").find(":selected").text();
                var ryear = $("#year").find(":selected").text();
                var rcountry = $("#country").val();
                var rcity = $("#city").val();

                if (!isNumeric(rday)) rday = 0;
                if (!isNumeric(rmonth)) rmonth = 0;
                if (!isNumeric(ryear)) ryear = 0;

                rlabel.html("Processing.");

                $.ajax({
                    type: "POST",
                    url: "default.aspx/registerUser",
                    data: JSON.stringify({ user: rusr, pass: rpss, mail: rmail, fname: rfname, lname: rlname, bday: rday, bmonth: rmonth, byear: ryear, country: rcountry, city: rcity }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d == "done") {
                            rlabel.html("Sending varification email.");
                            $.ajax({
                                type: "POST",
                                url: "default.aspx/sendEmail",
                                data: JSON.stringify({ userTo: rusr, pass: rpss, mail: rmail }),
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (msg) {
                                    if (msg.d == "sent") rlabel.html("Registered successfully: <br />Follow the activation link that was sent to your email to activate your user.");
                                    else rlabel.html("An error occurred while trying to send an activation email.");

                                    cani = true; $("#regis").removeAttr('disabled');
                                }
                            });
                        }

                        if (msg.d == "error") {
                            rlabel.html("An error occurred while registering the user.");
                            cani = true; $("#regis").removeAttr('disabled');
                        }
                    }
                });
            }
            else {
                rlabel.html("Could not proceed because an input is invalid");
                cani = true; $("#regis").removeAttr('disabled');
            }
        }
    });
    return false;
}
function validate(type) {
    switch (type) {
        case 1:
            var varie = $("#ruser");
            if (varie.val() != "admin") {
                if (varie.val() == "") {
                    $("#Label1").html(" Username cannot be empty");
                    cani = false;
                }
                else {
                    $.ajax({
                        type: "POST", url: "default.aspx/doesExists", data: JSON.stringify({ st: varie.val() }), contentType: "application/json; charset=utf-8", dataType: "json", success: function (msg) {
                            if (msg.d.toLowerCase() == "true") {
                                $("#Label1").html(" <span style='color:red;'>This username is already taken</span>");
                                cani = false;
                            }
                            else $("#Label1").html("");
                        }
                    });
                }
            }
            else {
                $("#Label1").html(" <span style='color:red;'>This username is already taken</span>");
                cani = false;
            }
            break;
        case 2:
            var varie = $("#rpass");
            if (varie.val() == "") {
                $("#Label2").html(" Password cannot be empty");
                cani = false;
            }
            else $("#Label2").html(""); break;
        case 3:
            var varie = $("#email");
            if (varie.val() != "") {
                if (varie.val().match(/^[A-Z0-9._%+-/']+@[A-Z0-9.-]+\.[A-Z]{2,6}$/i) == null) {
                    $("#Label3").html(" Invalid email address");
                    cani = false;
                }
                else {
                    $.ajax({
                        type: "POST", url: "default.aspx/doesMailExists", data: JSON.stringify({ st: varie.val() }), contentType: "application/json; charset=utf-8", dataType: "json", success: function (msg) {
                            if (msg.d.toLowerCase() == "true") {
                                $("#Label3").html(" <span style='color:red;'>This email address is already taken</span>");
                                cani = false;
                            }
                            else $("#Label3").html("");
                        }
                    });
                }
            }
            else $("#Label3").html(""); break;
        case 4:
            var varie = $("#fname");
            varie.val(capitalize(varie.val()));
            if (varie.val() != "") {
                if (varie.val().match(/\d+/g) != null) {
                    $("#Label4").html(" First Name cannot contain a number");
                    cani = false;
                }
                else $("#Label4").html("");
            }
            else $("#Label4").html(""); break;
        case 5:
            var varie = $("#lname");
            varie.val(capitalize(varie.val()));
            if (varie.val() != "") {
                if (varie.val().match(/\d+/g) != null) {
                    $("#Label5").html(" Last Name cannot contain a number");
                    cani = false;
                }
                else $("#Label4").html("");
            }
            else $("#Label5").html(""); break;
        case 6: valiDate('m'); valiDate('d'); valiDate('y'); break;
        case 7:
            var varie = $("#country");
            varie.val(capitalize(varie.val()));
            if (varie.val() != "") {
                if (varie.val().match(/\d+/g) != null) {
                    $("#Label7").html(" Country cannot contain a number");
                    cani = false;
                }
                else $("#Label4").html("");
            }
            else $("#Label7").html(""); break;
        case 8:
            var varie = $("#city");
            varie.val(capitalize(varie.val()));
            if (varie.val() != "") {
                if (varie.val().match(/\d+/g) != null) {
                    $("#Label8").html(" City cannot contain a number");
                    cani = false;
                }
                else $("#Label4").html("");
            }
            else $("#Label8").html(""); break;
    }
}
function vali() {
    var varie = $("#ruser");
    if (!varie.val()) {
        $("#Label1").html(" Username cannot be empty");
        cani = false;
    }
    else {
        $("#Label1").html("");
    }
    var varie = $("#email");
    if (!varie.val()) {
        if (varie.val().match(/^[A-Z0-9._%+-/']+@[A-Z0-9.-]+\.[A-Z]{2,6}$/i) == null) {
            $("#Label3").html(" Invalid email address");
            cani = false;
        }
        else {
            $("#Label3").html("");
        }
    }
    else $("#Label3").html("");
}

function logOut() {
    __doPostBack('logoutb', '');
}

var cani2 = true;
function saveProfile() {
    $("#saveChanges").attr('disabled', 'disabled');
    cani2 = true;

    for (var i = 1; i <= 6; i++)
        eValidate(i);

    var elabel = $("#elabel");
    if (cani2) {

        elabel.html("Processing.");

        var rmail = $("#eEmail").val();
        var rfname = $("#efName").val();
        var rlname = $("#elName").val();
        var rday = $("#eday").find(":selected").text();
        var rmonth = $("#emonth").find(":selected").text();
        var ryear = $("#eyear").find(":selected").text();
        var rcountry = $("#eCountry").val();
        var rcity = $("#eCity").val();

        if (!isNumeric(rday)) rday = 0;
        if (!isNumeric(rmonth)) rmonth = 0;
        if (!isNumeric(ryear)) ryear = 0;

        $.ajax({
            type: "POST",
            url: "default.aspx/UpdateUser",
            data: JSON.stringify({ mail: rmail, fname: rfname, lname: rlname, bday: rday, bmonth: rmonth, byear: ryear, country: rcountry, city: rcity }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            complete: function () {
                $('#back').trigger('click');

                var counter = 0;

                $.ajax({
                    type: "POST",
                    url: "default.aspx/FillProfile",
                    data: JSON.stringify({}),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $(data.d).each(function (index, value) {
                            counter++;
                            switch (counter) {
                                case 1: $("#usernameLabel").html(value); break;
                                case 2: $("#emailLabel").html(value); break;
                                case 3: $("#firstNameLabel").html(value); break;
                                case 4: $("#lastNameLabel").html(value); break;
                                case 5: $("#countryLabel").html(value); break;
                                case 6: $("#cityLabel").html(value); break;
                                case 7: $("#birthdayLabel").html(value); break;
                                case 8:
                                    if (!value) { $("#imageTd").css("border", "border: 1px solid rgba(0,0,0,0.7)"); }
                                    $("#imageTd").html(value); break;
                            }
                        });
                    },
                    complete: function () {
                        $("#saveChanges").removeAttr('disabled');
                    }
                });
            }
        });
    }
    else { elabel.html("Could not proceed because an input is invalid"); $("#saveChanges").removeAttr('disabled'); }

}
function eValidate(type) {
    switch (type) {
        case 1:
            var varie = $("#efName");
            varie.val(capitalize(varie.val()));
            if (varie.val() != "") {
                if (varie.val().match(/\d+/g) != null) {
                    $("#efLabel").html(" Cannot contain a number");
                    cani2 = false;
                }
                else $("#efLabel").html("");
            }
            else $("#efLabel").html(""); break;
        case 2:
            var varie = $("#elName");
            varie.val(capitalize(varie.val()));
            if (varie.val() != "") {
                if (varie.val().match(/\d+/g) != null) {
                    $("#elLabel").html(" Cannot contain a number");
                    cani2 = false;
                }
                else $("#elLabel").html("");
            }
            else $("#elLabel").html(""); break;
        case 3:
            var varie = $("#eEmail");
            if (varie.val() != "") {
                if (varie.val().match(/^[A-Z0-9._%+-/']+@[A-Z0-9.-]+\.[A-Z]{2,6}$/i) == null) {
                    $("#eeLabel").html(" Invalid email address");
                    cani2 = false;
                }
                else {
                    $.ajax({
                        type: "POST", url: "default.aspx/doesMailExists_ForUpdate", data: JSON.stringify({ st: varie.val() }), contentType: "application/json; charset=utf-8", dataType: "json", success: function (msg) {
                            if (msg.d.toLowerCase() == "true") {
                                $("#eeLabel").html(" <span style='color:red;'>Already taken</span>");
                                cani2 = false;
                            }
                            if (msg.d == "error") {
                                $("#eeLabel").html(" <span style='color:red;'>Error</span>");
                                cani2 = false;
                            }
                            else if (msg.d.toLowerCase() != "true") $("#eeLabel").html("");
                        }
                    });
                }
            }
            else $("#eeLabel").html(""); break;
        case 4: evaliDate('m'); evaliDate('d'); evaliDate('y'); break;
        case 5:
            var varie = $("#eCountry");
            varie.val(capitalize(varie.val()));
            if (varie.val() != "") {
                if (varie.val().match(/\d+/g) != null) {
                    $("#ecuLabel").html(" Country cannot contain a number");
                    cani2 = false;
                }
                else $("#ecuLabel").html("");
            }
            else $("#ecuLabel").html(""); break;
        case 6:
            var varie = $("#eCity");
            varie.val(capitalize(varie.val()));
            if (varie.val() != "") {
                if (varie.val().match(/\d+/g) != null) {
                    $("#eciLabel").html(" City cannot contain a number");
                    cani2 = false;
                }
                else $("#eciLabel").html("");
            }
            else $("#eciLabel").html(""); break;
    }
}

function ChangePassword() {
    $("#changePassBtn").attr('disabled', 'disabled');

    var old = $("#oPass").val();
    var npass = $("#nPass").val();
    var npass2 = $("#nPass2").val();


    if (old && npass && npass2) {
        if (npass === npass2) {
            $.ajax({
                type: "POST",
                url: "default.aspx/ChangePassword",
                data: JSON.stringify({ old: old, newp: npass }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d == "ok") {
                        // ---- //
                        $("#changePassBtn").removeAttr('disabled');
                        $('#back').trigger('click');

                        $("#oPass").val("");
                        $("#nPass").val("");
                        $("#nPass2").val("");
                        $("#pLabel").html("");
                    }
                    if (msg.d == "old") {
                        $("#pLabel").html("Old password is incorrect");
                        $("#changePassBtn").removeAttr('disabled');
                    }
                }
            });
        }
        else { $("#pLabel").html("new passwords don't match"); $("#changePassBtn").removeAttr('disabled'); }
    }
    else { $("#pLabel").html("One or more of the passwords are missing"); $("#changePassBtn").removeAttr('disabled'); }
}

function checkme(type) {
    if (type == 1)
        if (!($("#UrlImage").val()))
            return false;
    if (type == 2)
        if (!($('#FileUpload1').val().length > 0))
            return false;

    return true;
}

var isRes = false;
function resendemail() {
    $("#resend").attr('disabled', 'disabled');
    if (isRes == false) {

        isRes = true;

        var usr = $('#user').val();
        var pss = $('#pass').val();
        var err = $('#errorLabel');
        var newmail = $("#newEmail").val();

        err.html("Processing.");

        if (usr) {
            if (pss) {
                if (!newmail) {
                    $.ajax({
                        type: "POST",
                        url: "default.aspx/reSendEmail",
                        data: JSON.stringify({ userTo: usr, pass: pss, nmail: newmail }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            if (msg.d == "sent") err.html("Your account activation link was re-sent.");
                            else err.html("An error occurred while trying to send an activation email.");
                        },
                        complete: function () {
                            isRes = false;
                            $("#resend").removeAttr('disabled');
                        }
                    });
                }
                if (newmail && newmail.match(/^[A-Z0-9._%+-/']+@[A-Z0-9.-]+\.[A-Z]{2,6}$/i) != null) {
                    $.ajax({
                        type: "POST",
                        url: "default.aspx/doesMailExists_ForUpdate",
                        data: JSON.stringify({ st: usr, mail: newmail }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg1) {
                            if (msg1.d.toLowerCase() == "false") {
                                $.ajax({
                                    type: "POST",
                                    url: "default.aspx/reSendEmail",
                                    data: JSON.stringify({ userTo: usr, pass: pss, nmail: newmail }),
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (msg) {
                                        if (msg.d == "sent") err.html("Your account activation link was re-sent.");
                                        else err.html("An error occurred while trying to send an activation email.");
                                    },
                                });
                            }
                            else err.html("Email already exists");
                        },
                        complete: function () {
                            isRes = false;
                            $("#resend").removeAttr('disabled');
                        }
                    });
                }
                else {
                    isRes = false;
                    $("#resend").removeAttr('disabled');
                    err.html("invalid email");
                }
            }
            else {
                isRes = false;
                $("#resend").removeAttr('disabled');
                err.html("password can not be empty");
            }
        }
        else {
            $("#resend").removeAttr('disabled');
            isRes = false;
            err.html("username can not be empty");
        }
    }
}

var isRet = false;
function retPass() {
    $("#fButton").attr('disabled', 'disabled');

    if (!isRet) {
        isRet = true;

        var userf = $("#fuser").val();
        var mailf = $("#fmail").val();
        var labelf = $("#fLabel");

        labelf.html("Processing.");

        if ((userf == null || userf == "") && (mailf == null || mailf == "")) {
            labelf.html("no input was provided");
            isRet = false;
            $("#fButton").removeAttr('disabled');
        }
        else {
            if (mailf != null && mailf != "") {
                if (mailf.match(/^[A-Z0-9._%+-/']+@[A-Z0-9.-]+\.[A-Z]{2,6}$/i) != null) {
                    $.ajax({
                        type: "POST",
                        url: "default.aspx/doesExistsFromMail",
                        data: JSON.stringify({ st: mailf }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            if (msg.d.toLowerCase() == "true")
                                $.ajax({
                                    type: "POST",
                                    url: "default.aspx/ForgottenEmail",
                                    data: JSON.stringify({ mailTo: mailf }),
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (msg) {
                                        if (msg.d == "sent") labelf.html("Your password was sent to " + mailf);
                                        else labelf.html("An error occurred while trying to send an email to" + mailf);

                                        isRet = false;
                                        $("#fButton").removeAttr('disabled');
                                    }
                                });
                            else {
                                labelf.html("Email [" + mailf + "] does not exist in our database")
                                isRet = false;
                                $("#fButton").removeAttr('disabled');
                            };
                        }
                    });
                }
                else {
                    labelf.html("Invalid email address");
                    isRet = false;
                    $("#fButton").removeAttr('disabled');
                }
            }

            if (userf && (mailf.match(/^[A-Z0-9._%+-/']+@[A-Z0-9.-]+\.[A-Z]{2,6}$/i) == null) || !mailf) {
                labelf.html("Processing.");
                $.ajax({
                    type: "POST",
                    url: "default.aspx/doesExists",
                    data: JSON.stringify({ st: userf }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d.toLowerCase() == "true" || msg.d.toLowerCase() == "nonactive") {
                            $.ajax({
                                type: "POST",
                                url: "default.aspx/ForgottenEmail2",
                                data: JSON.stringify({ userTo: userf }),
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (msg) {
                                    if (msg.d != "error") labelf.html("Your password was sent to " + msg.d);
                                    else {
                                        labelf.html("An error occurred while trying to send an email to" + msg.d);
                                        isRet = false;
                                        $("#fButton").removeAttr('disabled');
                                    }
                                }
                            });
                        }
                        else {
                            labelf.html("Username does not exist");
                            isRet = false;
                            $("#fButton").removeAttr('disabled');
                        }
                    }
                });
            }
        }
    }
    return false;
}

function som() {
    var bodySt = bd.html();

    if (bodySt.indexOf("somee") != -1) {
        var fi = bodySt.indexOf("<!--SCRIPT GENERATED BY SERVER! PLEASE REMOVE-->");
        var la = fi + bodySt.substring(fi + "<!--SCRIPT GENERATED BY SERVER! PLEASE REMOVE-->".length, bodySt.length).indexOf("<!--SCRIPT GENERATED BY SERVER! PLEASE REMOVE-->");
        if (fi != -1) {
            var block = bodySt.substr(fi, la - (fi - ("<!--SCRIPT GENERATED BY SERVER! PLEASE REMOVE-->".length * 2)));
            if (bodySt.indexOf("<center") != -1) bodySt = bodySt.replace(bodySt.sub(bodySt.indexOf("<center"), bodySt.indexOf("</center>")), "");
            bodySt = bodySt.replace(block, "");
            bodySt = bodySt.replace("http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js?_=1363873986974", "");
            bd.html(bodySt);
        }
    }
}
