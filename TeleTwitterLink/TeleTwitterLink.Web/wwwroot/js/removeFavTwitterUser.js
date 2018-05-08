$(function () {
    $('#favourite-users').on('click', 'div div div button', function (event) {
        event.preventDefault();
        var data = $(this).closest('form').serialize();
        var id = $(this).attr('id');
        console.log(data);
        $.post(
            '/RemoveTwitterUser/RemoveUser',
            data,
            function (response) {
                var button = $('#' + id).text('Removed').prop('disabled', true);
            });
    });
});