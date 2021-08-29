function Clear() {
    document.getElementById("name").value = "";
    document.getElementById("city").value = "";
    document.getElementById("phone").value = "";
}

//for ajax controller
function personShow() {
    console.log("hej");
    /*  var dataRequest = {};*/

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
    $.ajax({
        type: "GET",
        url: `Ajax/Details/${id}`,
        success: function (output) {
            document.getElementById("showResult").innerHTML = output;

        }
    })

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