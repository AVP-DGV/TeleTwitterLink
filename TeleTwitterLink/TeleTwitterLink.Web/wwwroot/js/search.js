$(function () {
    $('#search-form').on('submit', function (event) {
        event.preventDefault();

        var data = $(this).serialize();

        $.post(
            '/search/searchResult', 
            data,
            function (searchResult) { 
                $('#search-results').html(searchResult);
            }
        );
    });
});