function LogOut() {
    $.ajax({
        url: "/Auth/Logout",
        dataType: 'json',
        success: function (response) {
            if (response == 200) {
                window.location.href = '/Auth/Login'; //Redirecting User to Login page
            }
        },
        error: function (xhr, status, error) {
            // Handle error
            console.error(xhr.responseText);
        }
    });
}