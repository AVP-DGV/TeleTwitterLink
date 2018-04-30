$(document).ajaxStart(function () {
    // Show image container
    $("#loader").show();
});
$(document).ajaxComplete(function () {
    // Hide image container
    $("#loader").hide();
});