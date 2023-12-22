$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

function matchPassword() {
    var pw1 = document.getElementById("password");
    var pw2 = document.getElementById("confirm_password");

    if (pw1.value.length == 0) {
        alert("Password cannot be null");
        return true;
    }

    if (pw1.value != pw2.value) {
        alert("Passwords did not match");
        return false;
    }

    return true;
}