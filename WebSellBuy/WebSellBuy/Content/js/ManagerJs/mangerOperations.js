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
function addNewShop() {  // доделать магазин
    var name = $("#nameShop").val();
    var category = $('#categoryForManager :selected').map(function () { return $(this).val(); });
    // category = parseInt(category[0]);
    category = category[0];
    var pass = $("#passShop").val();
    var confPass = $("#confPassShop").val();
    if(name == "")
    {
        opendialog("Введите названия магазина");
    }
    else if (category == 0) {
        opendialog("Выберете категорию");
    }
    else if (pass != confPass) {
        opendialog("Пароли не совпадают");
    }
    else if (imageName == "") {
        imageName = "anonymousShop";
    }
    else {
        $.ajax({
            url: SPU + 'Manager/CreateShop',
            type: "POST",
            data: { _nameShop: name, _passShop: pass, _categoryShop: category, _photoShop: imageName },
            success: function (response) {
                opendialog(response);
            }
        });
    }
}

function insertMyShops() {
    $.ajax({
        url: SPU + 'Manager/GetAllMyShops',
        type: "POST",
        success: function (response) {
            var htmlShop = [];
            var blockShops = $("#MyShops");
            for(var i=0;i<response.length;i++)
            {
                htmlShop.push("<li class=\"list-group-item styleBlockShop\">\r\n");
                htmlShop.push("<div class=\"badgeImage\"><img class=\"logoMyShop\" src=\"" + response[i].PhotoShop + "\" /></div>\r\n");
                htmlShop.push("<div class=\"badgeNameShop\"><span class=\"positionLogoMyShop\">" + response[i].NameShop+ "</span></div>\r\n");
                htmlShop.push("<div style=\"float:right;\">\r\n");
                htmlShop.push(" <a href=\"#\" class=\"button28\">Изменить</a>\r\n");
                htmlShop.push(" <a href=\"#\" class=\"button28\">Открыть</a>\r\n");
                htmlShop.push(" <a href=\"#\" class=\"button28\">Удалить</a>\r\n");
                htmlShop.push("</div>\r\n");
                htmlShop.push("</li>\r\n");

               // blockShops.append(htmlShop);
                document.getElementById("MyShops").innerHTML = htmlShop.join("");
                htmlShop = [];
            }
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


