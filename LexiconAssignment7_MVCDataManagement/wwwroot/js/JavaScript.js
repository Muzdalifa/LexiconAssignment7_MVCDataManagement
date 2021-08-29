
$("#reset").click(function () {
    $("#create-form").val = "";
})


function showDiv(p) {
    console.log(p)

    document.getElementById("editID").value = p.id;
    console.log(document.getElementById("editID").value);
    document.getElementById("editName").value = p.name;
    document.getElementById("editCity").value = p.city;
    document.getElementById("editPhoneNumber").value = p.phoneNumber;
    

}
