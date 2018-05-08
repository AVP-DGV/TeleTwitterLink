$(function () {
    $('.credentials-link').on('click', function (event) {
        event.preventDefault();

        $.post(this.href, null, function (result) {
            if (result === 'Added successfully.') {
                toastr.success('Added successfully.');
            }
            else {
                toastr.error('Error');
            }
        });
    });
});
