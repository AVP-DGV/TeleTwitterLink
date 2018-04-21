$(function () {
    $('#search-results').on('click', 'ul li button', function (event) {
        var id = $('.add-fav-user').attr('id');
        $('#' + id).text('Added');
    });
});