// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//$(document).ready(function () {
    
//    $('#savedata').click(function () {

//        //alert("WRONG");
//        $('#invalid').fadeIn(200);

//    });
//});

$(document).ready(function () {
    $("#rep").click(function () {

        $(this).hide();
        $.get('/Home/Reply', function (result) {
            $('#reply').html(result);
        });

    });
});
$(document).ready(function () {
    $("#canc").click(function () {
        console.log("YO");
        $('#rep').show();
        

    });
});
//$(document).ready(function () {
//    $("#emailRow").click(function () { 
//        alert("Opened");
//        //$.get('/Home/MailDetail', function (result) {
//        //    $('#reply').html(result);
//        //});
//    });
//});