$(document).ready(function () {
    //to enable ajax, uncomment the on click event handler for changeName
    $("#zipsubmit").on("click", function() {
        var data = {
            zip: $("#zipcode").val()
        };
        $.ajax(
        {

            // The URL for the request
            url: "/Home/UpdateZip",
            // The data to send (will be converted to a query string)
            data: data,
            // Whether this is a POST or GET request
            type: "POST",

            // Code to run if the request succeeds;
            // the response is passed to the function
            success: function(json) {
                $("#zipcode").attr("placeholder", $("#zipcode").val());
                $("#zipcode").val("");
                console.log("du");
            },
            // Code to run if the request fails; the raw request and
            // status codes are passed to the function
            error: function(xhr, status, errorThrown) {
                console.log("Sorry, there was a problem!");
                console.log("Error: " + errorThrown);
                console.log("Status: " + status);
                console.dir(xhr);
            },
            // Code to run regardless of success or failure
            complete: function(xhr, status) {
                console.log("The request is complete!");
            }
        });
    });
});