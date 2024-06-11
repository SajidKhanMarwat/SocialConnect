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

function UserSearch() {
    var input = $('#searchInput').val();
    debugger;
    $.ajax({
        url: "/Feed/SearchUser/",
        type: "GET",
        contentType: "application/json",
        data: { search: input },
        success: function (response) {
            var res = response;
            debugger
            if (response != null) {

            }
        }
    })
}