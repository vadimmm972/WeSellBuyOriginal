

var IdMyShop = 0;
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
                htmlShop.push("<div class=\"badgeImage\"><img class=\"logoMyShop\" src=\"../" + response[i].PhotoShop + "\" /></div>\r\n");
                htmlShop.push("<div class=\"badgeNameShop\"><span class=\"positionLogoMyShop\">" + response[i].NameShop+ "</span></div>\r\n");
                htmlShop.push("<div style=\"float:right;\">\r\n");
                htmlShop.push(" <a onclick=\"InsertInfoForUpdatMyMagazine(" + response[i].IdMagazine + ")\"  href=\"#tab5\" role=\"tab\" data-toggle=\"tab\" href=\"#\" class=\"button28\">Изменить</a>\r\n");
               // htmlShop.push(" <a  href=\"#tab5\" role=\"tab\" data-toggle=\"tab\" href=\"#\" class=\"button28\">Изменить</a>\r\n");
                htmlShop.push(" <a href=\"#\" class=\"button28\">Перейти</a>\r\n");
                htmlShop.push(" <a onclick=\"removeThisShop(" + response[i].IdMagazine + ")\" href=\"#\" class=\"button28\">Удалить</a>\r\n");
                htmlShop.push("</div>\r\n");
                htmlShop.push("</li>\r\n");
               // blockShops.append(htmlShop);
            }
            document.getElementById("MyShops").innerHTML = htmlShop.join("");
            htmlShop = [];
        }
    });
}

function removeThisShop(idShop, idMag) {
    if (idShop != "" && idShop != 0) {
        $.ajax({
            url: SPU + 'Manager/RemoveShop',
            type: "POST",
            data: {_idMagazine: idMag },
            success: function (response) {
                opendialog(response);
            }
        });
    }
    else {
        opendialog("Error");
    }
}

function insertInfoCategory() {
    $.ajax({
        url: SPU + 'Manager/GetAllCategory',
        type: "POST",
        success: function (response) {
            $("#categoryForManager").empty();
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



function InsertInfoForUpdatMyMagazine(idMag){
    if (idMag != 0) {
        IdMyShop = idMag;
        $.ajax({
            url: SPU + 'Manager/GetInfoByMagazine',
            type: "POST",
            data: { _id: idMag },
            success: function (response) {
                if (response != null) {

                    $(".button28").removeClass("active");
                    $("#inputnameShop").val(response.NameShop);
                    $("#inputpassword").val(response.Password);
                    $(".profile-img-card").attr('src', response.PhotoShop);
                    $("#IdShop").val(response.IdMagazine);

                    $("#categoryInfoForShop").empty();
                    var regSelect = document.getElementById("categoryInfoForShop");
                    for(var i=0;i<response.AllCategories.length;i++){
                        var option = document.createElement("option");
                        option.text = response.AllCategories[i].name;
                        option.value = response.AllCategories[i].id;
                        regSelect.add(option);
                    }
                    
                    document.getElementById("categoryInfoForShop").value = response.Category;
                }
            }
        });
    }
    else {
        opendialog("Ошыбька");
    }
}


function updatePhotoInServer(op,block){
    if (IdMyShop != 0) {

     
           // op = 4;
            loading(1);
            var data = new FormData();
            var files = $(".hiddenUpdatePhotoMySgop").get(0).files;
            if (files.length > 0) {
                data.append("HelpSectionImages", files[0]);

            }
            else {
                alert("error");
                return;
            }
        

            var nameImageUpd = $("#profileShop-img").attr('src');
            var n = nameImageUpd.lastIndexOf('/');
            var result = nameImageUpd.substring(n + 1);

            data.append("id", 11);
            data.append("elementid", 11);
            data.append("changeUpdate", op);
            data.append("NameImageUpdate", result);
           
            $.ajax({
                url: SPU + 'Base/UpdateImage',
                type: "POST",
                processData: false,
                contentType: false,
                data: data,
                success: function (response) {
                    imageName = response;
                    if (response != "") {
                        //$("#profileShop-img").attr('src', nameImageUpd);
                        // document.location.reload();
                        
                        //var divImgShop = $("#profileShop-img");

                     
                        var src = $("#profileShop-img").attr('src');
                       // $("#profileShop-img").removeAttr('src').attr('src', src);
                        var d = new Date();
                       // $("#profileShop-img").attr("src", $("#profileShop-img").attr(src));
                        $("#profileShop-img").attr('src', src + '?dummy=' + d.getTime());

                       // document.location.reload();
                        
                    }
                    loading(0);
                }
            });
        
    }
}

function UpdatePhotoMyShop() {
    $("#inputPhotoUpdateForFile").click();
}

function SaveInfoMyUpdateShop(event) {
    loading(1);
    var nameShop = $("#inputnameShop").val();
    var passShop = $("#inputpassword").val();
    var idshopCheck = $("#IdShop").val();
    var categoryShop = $('#categoryInfoForShop :selected').map(function () { return $(this).val(); });
    categoryShop = categoryShop[0];

    if (nameShop == "" || passShop == "" || categoryShop == "") {
        opendialog("Заполните все поля");
        loading(0);
    }
    else {
        $.ajax({
            url: SPU + 'Manager/UpdateInfoByShop',
            type: "POST",
            data: { name: nameShop, pass: passShop, cat: categoryShop, IdShop: idshopCheck },
            success: function (response) {
                imageName = response;
                if (response != "") {
                  

                }
                loading(0);
            }
        });
    }
}



