window.onload = function () {
    LoadInfoUserProfileAtTheContent();
}

var copySurname = "";
var copyName = "";
var copyLastname = "";
var copyPhone = "";
var copyMail = "";
var copyLogin = "";
var copyPass = "";
myelem = 0;

function LoadInfoUserProfileAtTheContent() {
    $.ajax({
        url: 'UserProfile/LoadUserInfo',
        type: "POST",
        processData: false,
        contentType: false,
        success: function (response) {
            if(response != null){
                $("#infoP_surname").val(response.Surname);
                copySurname = response.Surname;

                $("#infoP_name").val(response.Name);
                copyName = response.Name;

                $("#infoP_lastname").val(response.LastName);
                copyLastname = response.LastName;

                $("#infoP_phone").val(response.Phone);
                copyPhone = response.Phone;

                $("#infoP_mail").val(response.Mail);
                copyMail = response.Mail;

                $("#infoP_login").val(response.Login);
                copyLogin = response.Login;

                $(".imgcssProfileUpdate ").attr('src', '' + response.Image + '');
              
                $("#infoP_password").val(response.Password);


                $("#drtCountryInfo").val(response.Country);
                $("#drtRegionInfo").val(response.Region);
                $("#drtCityInfo").val(response.City);
            }
            else {
                alert("Ошыбка обратитесь к администратору сайта")
            }
        }
    });
}


function UpdateInfoProfileParam(param) {
    var newInfoParam = "";
    var errorParam = "";
    var errorString = "Вы не можете измень одинаковые значения";
    if (param == 1) {
        //updateSurname();
        newInfoParam = $("#infoP_surname").val();
        if (newInfoParam == copySurname) {
            errorParam = errorString;
        }
        else {
            copySurname = newInfoParam;
        }
    }
    else if (param == 2) {
        newInfoParam = $("#infoP_name").val();
        if (copyName == newInfoParam) {
            errorParam = errorString;
        }
        else {
            copyName = newInfoParam;
        }
    }
    else if (param == 3) {
        newInfoParam = $("#infoP_lastname").val();
        if (copyLastname == newInfoParam) {
            errorParam = errorString;
        }
        else {
            copyLastname = newInfoParam;
        }
    }
    else if (param == 4) {
        newInfoParam = $("#infoP_phone").val();
        if (copyPhone == newInfoParam) {
            errorParam = errorString;
        }
        else {
            copyPhone = newInfoParam;
        }
    }
    else if (param == 5) {
        newInfoParam = $("#infoP_mail").val();
        if (copyMail == newInfoParam) {
            errorParam = errorString;
        }
        else {
            copyMail = newInfoParam;
        }
    }
    else if (param == 6) {
        newInfoParam = $("#infoP_login").val();
        if (copyLogin == newInfoParam) {
            errorParam = errorString;
        }
        else {
            copyLogin = newInfoParam;
        }
    }
    else if (param == 7) {
        newInfoParam = $("#infoP_password").val();
        if (copyPass == newInfoParam) {
            errorParam = errorString;
        }
        else {
            copyPass = newInfoParam;
        }
    }
    else if (param == 8) {
        if (imageName != "") {
            newInfoParam = imageName;
        }
        else {
            errorParam = errorString;
        }
    }

    if (errorParam == "" && newInfoParam != "") {
        $.ajax({
            url: 'UserProfile/UpdateInfoMyProfileInParam',
            type: "POST",
            data: { _idparam: param, newInfo: newInfoParam },
            success: function (response) {
                // alert(response);
                opendialog(response);
             
               
               
            }
        });
    }
    else{
        if (newInfoParam == "") {
            errorParam = "Поле не может быть пустым";
        }
        opendialog(errorParam);
    }

    
}


function openGetDirections() {

    getCountries();


    $(".btnUpdInfo ").css('display', 'none');
    $(".infoDrt").css('display', 'none');
    $(".btnSaveInfo").css('display','block');
}


function updateLocation() {
    if (checkIdCountry == 0 || checkIdRegion == 0 || checkIdCity == 0) {
        opendialog("Не все поля выбраны")
    }
    else {
        $.ajax({
            url: 'UserProfile/UpdateLocationUserProfile',
            type: "POST",
            data: { _idCountry: checkIdCountry, _idRegion: checkIdRegion, _idCity: checkIdCity },
            success: function (response) {
                // alert(response);
                opendialog(response);

                $("#drtCountryInfo").val(nameCountry.trim());
                $("#drtRegionInfo").val(nameRegion.trim());
                $("#drtCityInfo").val(nameCity.trim());

                $(".btnSaveInfo").css('dipslay', 'none');
                $(".btnUpdInfo ").css('display', 'block');
                $(".directionInfo").css('display', 'none');
                $(".infoDrt").css('display','block');
            }
        });
    }
    
}

function updateAllInfoProfile() {
    var surname = $("#infoP_surname").val();
    var name = $("#infoP_name").val();
    var lastname = $("#infoP_lastname").val();
    var phone = $("#infoP_phone").val();
    var mail = $("#infoP_mail").val();
    var login = $("#infoP_login").val();
    var password = $("#infoP_password").val();
    var idcountry = checkIdCountry;
    var idregion = checkIdRegion;
    var idcity = checkIdCity;

    if (surname == "" || name == "" || lastname == "" || phone == "" || mail == "" || login == "" || password == "" || idcountry == "" || idregion == "" || idcity == "" || imageName == "") {
        opendialog("Заполние все поля !");
    }
    else {
        $.ajax({
            url: 'UserProfile/UpdateAllInfoForUserInProfile',
            type: "POST",
            data: { _surname: surname, _name: name, _lastname: lastname, _phone: phone, _mail: mail, _login: login, _password: password, _idCountry: idcountry, _idRegion: idregion, _idCity: idcity, _image: imageName },
            success: function (response) {
                // alert(response);
                opendialog(response);

            }
        });
    }
}