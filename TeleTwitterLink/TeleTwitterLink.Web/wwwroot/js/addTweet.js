$(function () {
    $('#tweets-list').on('click', 'div div button',
        function (event) {
            event.preventDefault();
            var data = $(this).closest('form').serialize();
            var id = $(this).attr('id');

            $.post(
                '/AddTweet/AddTweet',
                data,
                function (response) {
                    var button = $('#' + id).text('Added').prop('disabled', true);
                }
            )
        }
    )
});