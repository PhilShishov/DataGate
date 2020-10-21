if (window.history.replaceState) {
    window.history.replaceState(null, null, window.location.href);
}

$(document).ready(function () {
    $('a[href].no-link').each(function () {
        let href = this.href;

        $(this).removeAttr('href').css('cursor', 'pointer').click(function () {
            window.open(href, '_self');
        });
    });
});