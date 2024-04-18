function calculateBMI(e) {
    var height = parseFloat(document.getElementById("Height").value);
    var weight = parseFloat(document.getElementById("Weight").value);


    if (!isNaN(height) && !isNaN(weight) && height > 0 && weight > 0) {
        var bodyMassIndex = weight / (height * height);


        document.getElementById("BodyMassIndex").value = bodyMassIndex.toFixed(2);

    } else {
        alert('Please enter valid height and weight values.');
    }
}

function beforeSubmit() {
    document.getElementById("BodyMassIndex").removeAttribute("readonly");
}