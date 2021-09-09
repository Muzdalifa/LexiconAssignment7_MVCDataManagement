function Clear() {
    document.getElementById("name").value = "";
    document.getElementById("addCity").selectedIndex = 0;
    console.log(document.getElementById("selectCity").value);
    document.getElementById("phone").value = "";
}

//$("#reset").on("click", function () {
//    $('#addCity').prop('selectedIndex', 0);
//});

function showDiv(p) {
    console.log(p.city);
    document.getElementById("editID").value = p.id;
    document.getElementById("editName").value = p.name;
    //change the value of drop down list
    //if (document.getElementById("selectCity").value == p.city)
    itemList = document.getElementById("selectCity");
    var item = p.city;
    for (var i = 1; i < itemList.options.length; i++) {
        if (itemList.options[i].innerHTML === item) {
            itemList.selectedIndex = i;
            break;
        }
    }
    //document.getElementById("selectCity").selectedIndex = p.city;
    document.getElementById("editPhoneNumber").value = p.phoneNumber;
}



//for ajax controller
function personShow() {

    $.ajax({
        type: "GET",
        url: "Ajax/People",
        success: function (output) {
            //console.log(output);
            document.getElementById("showResult").innerHTML = output;
            
        }
    })
}

function personDetails() {
    var id = document.getElementById("personId").value;
   /* console.log(!id);*/
    if (id) {
        $.ajax({
            type: "GET",
            url: `Ajax/Details/${id}`,
            success: function (output) {
                document.getElementById("showResult").innerHTML = output;

            }
        })
    }
    else {
        $.ajax({
            type: "GET",
            url: "Ajax/Error",
            success: function (output) {
                document.getElementById("showResult").innerHTML = output;

            }
        })
    }
}


function personDelete() {
    var id = document.getElementById("personId").value
    $.ajax({
        type: "GET",
        url: `Ajax/Delete/${id}`,
        success: function (output) {
            console.log(output);
            document.getElementById("showResult").innerHTML = output;
        }
    })
}