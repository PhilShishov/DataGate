const HTML_NAVBAR = {
    USER_MENU_TOOGLER: 'responsive-menu',
    SEARCH_MENU_PARENT: 'search-form-wrapper-responsive',
    SEARCH_MENU: 'search-form-wrapper',
    SEARCH_MENU_TOOGLER: 'open-search-box',
};

const CLASSES_NAVBAR = {
    ACTIVE: 'active',
    OPEN: 'open',
    OPENED: 'opened'
};

(function () {
    const searchMenuParent = document.getElementsByClassName(HTML_NAVBAR.SEARCH_MENU_PARENT)[0];
    const searchMenu = document.getElementsByClassName(HTML_NAVBAR.SEARCH_MENU)[0];
    const searchMenuToogler = document.getElementsByClassName(HTML_NAVBAR.SEARCH_MENU_TOOGLER)[0];
    const userMenuToogler = document.getElementsByClassName(HTML_NAVBAR.USER_MENU_TOOGLER)[0];

    // Toogle search menu
    if (searchMenuToogler) {
        searchMenuToogler.addEventListener('click', toggleSearchMenu);

        function toggleSearchMenu() {

            if (userMenuToogler.classList.contains(CLASSES_NAVBAR.OPEN)) {
                userMenuToogler.classList.toggle(CLASSES_NAVBAR.OPEN);
            }

            searchMenuParent.classList.toggle(CLASSES_NAVBAR.OPENED);
            const searchMenuStatus = searchMenu.classList.contains('d-none');

            if (searchMenuStatus) {
                searchMenu.classList.remove('d-none');
            } else {
                searchMenu.classList.add('d-none');
            }
        };
    }

    // Toggle user menu
    if (userMenuToogler) {
        userMenuToogler.addEventListener('click', () => {
            if (!searchMenu.classList.contains('d-none')) {
                searchMenuParent.classList.toggle(CLASSES_NAVBAR.OPENED);
                searchMenu.classList.add('d-none');
            }
            userMenuToogler.classList.toggle(CLASSES_NAVBAR.OPEN);
        })
    }
})();


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