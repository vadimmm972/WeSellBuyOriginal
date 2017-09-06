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
            url: 'Manager/CreateNewShop',
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