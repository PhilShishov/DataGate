
window.onscroll = function () { showBackToTop() };
function showBackToTop() {
    if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
        document.getElementsByClassName("back-to-top")[0].style.display = "inline";
    } else {
        document.getElementsByClassName("back-to-top")[0].style.display = "none";
    }
}

function backToTop() {
    this.scrollTo(0, 0);
}

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