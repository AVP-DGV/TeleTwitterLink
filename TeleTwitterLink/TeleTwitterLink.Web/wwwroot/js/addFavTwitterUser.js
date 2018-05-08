$(function () {
    $('#search-results').on('click', 'ul li button', function (event) {
        event.preventDefault();
        var data = $(this).closest('form').serialize();
        var id = $(this).attr('id');

        $.post(
            '/AddTwitterUser/AddUser',
            data,
            function (response) {
                var button = $('#' + id).text('Added').prop('disabled', true);
            });
    });
});