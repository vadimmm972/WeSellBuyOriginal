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