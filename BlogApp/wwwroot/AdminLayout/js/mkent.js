document.getElementById('button').addEventListener('click', function () {
    document.querySelector('.modal').style.display = "flex";
});
var modal = document.getElementById('id01');

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

//document.getElementById('buttonLog').addEventListener('click', function () {
//    document.querySelector('.loginForm').style.display = "flex";
//});

function enableTxt() {
    document.getElementById("inputEmail").readOnly = false;
}

$("#loginSubmit").click(function () {
    debugger;
    var form = $('#loginForm');
    $.ajax({
        cache: false,
        async: true,
        type: "POST",
        url: "/Home/LoginCheck",
        data: form.serialize(),
        success: function (data) {
            if (data == "Invalid Login.") {
                $.toaster('Please check the credentials', 'Invalid Login', 'danger');
            }
            else if (data == "Success") {

                $.toaster('Welcome Admin', 'Please Wait', 'success');
                location.href = "/Home/MasterSetup/"
            }
        }
    });
})