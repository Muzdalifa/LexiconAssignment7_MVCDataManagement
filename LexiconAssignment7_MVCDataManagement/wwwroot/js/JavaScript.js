function Clear() {
    document.getElementById("name").value = "";
    document.getElementById("city").value = "";
    document.getElementById("phone").value = "";
}

function showDiv(p) {
    console.log(p)
    document.getElementById("editID").value = p.id;
    console.log(document.getElementById("editID").value);
    document.getElementById("editName").value = p.name;
    document.getElementById("editCity").value = p.city;
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