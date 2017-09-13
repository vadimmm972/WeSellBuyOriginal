function CerateShop() {
    var name = $("#nameShop");
    var pass = $("#passShop");
    var conpass = $("#confPassShop");

    if (pass != conpass) {
        opendialog("Пароли не свопадают");
    }
    else {
        if (imageName == "") {
            imageName = "notImageForShop";
        }

        $.ajax({
            url: SPU+ 'Manager/CreateNewShop',
            type: "POST",
            processData: false,
            contentType: false,
            data: { _name: name, _image: imageName, _password: pass },
            success: function (response) {
                if (response != null) {
                    
                }
            }
        });
    }
}

function LogOutManager(){
    $.ajax({
        url: SPU + 'Manager/SignOutUserManager',
        type: "POST",
        processData: false,
        contentType: false,
        //data: { _name: name, _image: imageName, _password: pass },
        success: function (response) {
            window.location.reload();
        }
    });
}


function insertInfoCategory() {
    $.ajax({
        url: SPU + 'Manager/GetAllCategory',
        type: "POST",
        success: function (response) {
            var regSelect = document.getElementById("categoryForManager");
            for (var i = 0; i < response.length; i++) {
                var option = document.createElement("option");
                option.text = response[i].name;
                option.value = response[i].id;
                regSelect.add(option);
            }
        }
    });
}


function createNewShop() {
    var name = $("#nameShop").val();
    var category = $('#categoryForManager :selected').map(function () { return $(this).val(); });
    var pass = $("#passShop").val();
    var confPass = $("#confPassShop").val();
    if(name == "")
    {
        opendialog("Введите названия магазина");
    }
    else if (category[0] == "0") {
        opendialog("Выберете категорию");
    }
    else if (pass != confPass) {
        opendialog("Пароли не совпадают");
    }
    else {
        $.ajax({
            url: SPU + 'Manager/CareateNewShop',
            type: "POST",
            success: function (response) {
               
            }
        });
    }
}