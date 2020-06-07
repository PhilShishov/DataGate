
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