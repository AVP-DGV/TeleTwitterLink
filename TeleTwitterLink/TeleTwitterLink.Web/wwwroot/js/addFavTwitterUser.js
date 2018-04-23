$(function () {
    $('#search-results').on('click', 'ul li button', function (event) {
        event.preventDefault();
        var id = $(this).attr('id');

        var button = $('#' + id).text('Added').prop('disabled', true);
        
    });
});