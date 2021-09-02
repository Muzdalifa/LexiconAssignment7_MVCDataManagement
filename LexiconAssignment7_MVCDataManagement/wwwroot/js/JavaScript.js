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