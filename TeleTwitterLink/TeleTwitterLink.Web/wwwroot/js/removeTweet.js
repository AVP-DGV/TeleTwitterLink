$(function () {
    $('#list-favourite-tweets').on('click', 'div div button',
        function (event) {
            event.preventDefault();
            var data = $(this).closest('form').serialize();
            var id = $(this).attr('id');

            $.post(
                '/RemoveTweet/RemoveTweet',
                data,
                function (response) {
                    var button = $('#' + id).text('Removed').prop('disabled', true);
                }
            )
        }
    )
});