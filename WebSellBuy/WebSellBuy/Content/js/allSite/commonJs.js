imageName = "";
checkIdCountry = 0;
checkIdRegion = 0;
checkIdCity = 0;

nameCountry = "";
nameRegion = "";
nameCity = "";
var redirectUrl = "";
SPU = window.location.origin + "/";

$(document).ready(function () {
    if (window.location.pathname.indexOf("Manager") == -1)
    loadInfoUser();
});
function getIdCity(event) {
    checkIdCity = event.value;
    nameCity = event.selectedOptions[0].label;;
}



function loadInfoUser() {
    $.ajax({
        url: 'Authentication/LoadUserInfo',
        type: "POST",
        processData: false,
        contentType: false,
        success: function (response) {
            if(response != null){
                $(".nameBlockInfoUser").text(response.userName);
                $(".SurnameLastNameInfo").text(response.userSurname + " " + response.userName);
               // $(".SurnameLastNameInfo").text(response.userSurname + " " + response.userName);
                $(".emailProfileInfo").text(response.userMail);
                if (response.userPhotoProfile == null) {
                    $(".userPhoto").addClass("glyphicon-user");
                }
                else {
                    var imgProfile = "<img class=\"imgProfileStyle\" src=\"" + response.userPhotoProfile + "\"/>";
                    $(".userPhoto").append(imgProfile);
                }
            }
        }
    });
}


function loading(change) {
    if (change == 1) {
        $(".loadingBlock").css("display", "block");
    }
    else if (change == 0) {
        $(".loadingBlock").css("display", "none");
    }
}

function UploadImage(option) {
    var op = option;
    loading(1);
    var data = new FormData();
    var files = $(".uploadImage").get(0).files;
    if (files.length > 0) {
        data.append("HelpSectionImages", files[0]);

    }
    else {
        alert("error");
        return;
    }
    data.append("id", 11);
    data.append("elementid", 11);
    data.append("operation", op);
    $.ajax({
        url: 'http://localhost:57363/Base/UploadImage',
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            imageName = response;
            loading(0);
        }
    });
}



function SinIn_SIgnOut_RegisterUser_click(param) {
    if (param == 1) {
        window.location.href = SPU +"SignIn";
    }
    else if (param == 2) {

       // $(location).attr('href', 'Authorization');
        document.location.href = SPU + "Authorization";
    }
    else if (param == 3) {
        $.ajax({
            url: 'Authentication/SignOut',
            type: "POST",
            processData: false,
            contentType: false,
            success: function (response) {
                    window.location.reload();
            }
        });
    }
}


function goUserProfilePage() {
    window.location.href = "UserProfile";
}

// get Country Region City


function getCountries() {

    $.ajax({
        url: 'Base/GetCountries',
        type: "POST",
        //  processData: false,
        // contentType: false,
        success: function (response) {

            var regSelect = document.getElementById("country");
            regSelect.add(document.createElement("option"));
            for (var i = 0; i < response.length; i++) {
                var option = document.createElement("option");
                option.text = response[i].NameCountry;
                option.value = response[i].idCountry;
                regSelect.add(option);
            }
            $("#region").empty();
            $('.countryClass').css('display', 'block');
        },
        error: function (e) {

        }
    });
}


function getRegion(event) {
    var idCountry = event.value;
    checkIdCountry = idCountry;
    nameCountry = event.selectedOptions[0].label;;
    //$(".regionClass").empty();
    $("#city").empty();
    $("#region").empty();
    $.ajax({
        url: 'Base/GetRegions',
        type: "POST",
        data: { id: idCountry },
        //  processData: false,
        // contentType: false,
        success: function (response) {

            var regSelect = document.getElementById("region");
            regSelect.add(document.createElement("option"));
            for (var i = 0; i < response.length; i++) {
                var option = document.createElement("option");
                option.text = response[i].NameRegion;
                option.value = response[i].idRegion;
                regSelect.add(option);
            }
           
            $(".regionClass").css('display', 'block');
        },
        error: function (e) {

        }
    });
}


function getCity(event) {
    var idRegion = event.value;
    checkIdRegion = idRegion;
    nameRegion = event.selectedOptions[0].label;
    $("#city").empty();
    $.ajax({
        url: 'Base/GetCity',
        type: "POST",
        data: { id: idRegion },
        //  processData: false,
        // contentType: false,
        success: function (response) {

            var regSelect = document.getElementById("city");
            regSelect.add(document.createElement("option"));
            for (var i = 0; i < response.length; i++) {
                var option = document.createElement("option");
                option.text = response[i].NameCity;
                option.value = response[i].idCity;
                regSelect.add(option);
            }

            $(".sityClass").css('display', 'block');
        },
        error: function (e) {

        }
    });
}

function ClickUserProfileLink() {
    redirectUrl = "UserProfile";
}

function ClickManagerLink() {
    redirectUrl = "Manager";
}

//function CheckUserPassForManager() {

//    var check = ChecUserkPassword();
//    if (check == "success") {
//        window.location.href = SPU + redirectUrl;
//    }
//}

function ChecUserkPassword(){
    var pass = $("#passModalManager").val();
    if (pass == "") {
        opendialog("Введите пароль");
    }
    else {
        $.ajax({
            url: SPU + 'Manager/CheckUserPassword',
            type: "POST",
            data: { _password: pass, _url: redirectUrl },
            success: function (response) {
                if (response == "success") {
                    if (redirectUrl != "") {
                        if (redirectUrl == "Manager")
                        {
                            window.open(SPU + redirectUrl);
                        }
                        else {
                            window.location.href = SPU + redirectUrl;
                        }
                        
                    }
                    else {
                        opendialog(response);
                    }
                }
                else {
                    opendialog(response);
                }
             
            },
            error: function (e) {

            }
        });
    }
}