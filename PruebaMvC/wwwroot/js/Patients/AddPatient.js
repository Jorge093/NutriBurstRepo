$(document).ready(function () {
    $("#btnAddPatient").click(btnAddPatientClick);
});

function calculateBMI(e) {
    //var height = parseFloat(document.getElementById("Height").value);
    var height = parseFloat($("#Height").val());
    //var weight = parseFloat(document.getElementById("Weight").value);
    var weight = parseFloat($("#Weight").val());


    if (!isNaN(height) && !isNaN(weight) && height > 0 && weight > 0) {
        var bodyMassIndex = weight / (height * height);


        //document.getElementById("BodyMassIndex").value = bodyMassIndex.toFixed(2);
        $("#BodyMassIndex").val(bodyMassIndex.toFixed(2));

    } else {
        alert('Please enter valid height and weight values.');
    }
}

function beforeSubmit() {
    //document.getElementById("BodyMassIndex").removeAttribute("readonly");
    $("#BodyMassIndex").attr("readonly", false);
}

function btnAddPatientClick(e) {
    e.preventDefault();

    beforeSubmit();

    var request = {
        "patientsId": null,
        "firstName": $("#FirstName").val(),
        "lastName": $("#LastName").val(),
        "age": +$("#Age").val(),
        "height": +$("#Height").val(),
        "weight": +$("#Weight").val(),
        "bodyMassIndex": +$("#BodyMassIndex").val(),
        "email": $("#Email").val(),
        "phone": $("#Phone").val()
    }

    $.ajax({
        url: "Add",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(request),
        dataType: "json",
        success: function (response) {


            alert("Save Complete");
        }
    });
}