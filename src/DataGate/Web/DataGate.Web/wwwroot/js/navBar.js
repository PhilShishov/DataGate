const HTML_NAVBAR = {
    SIDENAV_MAIN: 'main-sidenav',
    SIDENAV_RESPONSIVE: 'sidenav-responsive',
    SIDENAV_ICONS: 'sidenav-icon',
    SIDENAV_FOOTER: 'sidenav-footer',
    SIDENAV_BTN_CLOSE: 'sidenav-btn-close',
    SIDENAV_BTNS_DROPDOWN: 'sidenav-dropdown-btn',
    USER_MENU_TOOGLER: 'responsive-menu',
    SEARCH_MENU_PARENT: 'search-form-wrapper-responsive',
    SEARCH_MENU: 'search-form-wrapper',
    SEARCH_MENU_TOOGLER: 'open-search-box',
};

(function () {
    const sidenav = document.getElementById(HTML_NAVBAR.SIDENAV_MAIN);
    const sidenavIcons = document.getElementsByClassName(HTML_NAVBAR.SIDENAV_ICONS);
    const sideNavFooter = document.getElementById(HTML_NAVBAR.SIDENAV_FOOTER);
    const sideNavDropdowns = document.getElementsByClassName(HTML_NAVBAR.SIDENAV_BTNS_DROPDOWN);
    const searchMenuParent = document.getElementsByClassName(HTML_NAVBAR.SEARCH_MENU_PARENT)[0];
    const searchMenu = document.getElementsByClassName(HTML_NAVBAR.SEARCH_MENU)[0];
    const searchMenuToogler = document.getElementsByClassName(HTML_NAVBAR.SEARCH_MENU_TOOGLER)[0];
    const userMenuToogler = document.getElementsByClassName(HTML_NAVBAR.USER_MENU_TOOGLER)[0];

    // Toogle sidenav menu and sidenavdropdowns
    if (sidenavIcons) {
        for (let icon of sidenavIcons) {
            icon.addEventListener('click', toggleSideNavMenu);
        }

        for (let i = 0; i < sideNavDropdowns.length; i++) {
            sideNavDropdowns[i].addEventListener('click', function () {
                this.classList.toggle('active');
                let dropdownContent = this.nextElementSibling;
                if (dropdownContent.style.display === 'block') {
                    dropdownContent.style.display = 'none';
                } else {
                    dropdownContent.style.display = 'block';
                }
            });
        }
    }

    // Toogle search menu
    if (searchMenuToogler) {
        searchMenuToogler.addEventListener('click', toggleSearchMenu);

        function toggleSearchMenu() {

            if (userMenuToogler.classList.contains('open')) {
                userMenuToogler.classList.toggle('open');
            }
            if (sidenav.style.width != '0px') {
                sidenav.style.width = '0px';
                sideNavFooter.style.display = 'none';
            }

            searchMenuParent.classList.toggle('opened');
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
                searchMenuParent.classList.toggle('opened');
                searchMenu.classList.add('d-none');
            }
            if (sidenav.style.width != '0px') {
                sidenav.style.width = '0px';
                sideNavFooter.style.display = 'none';
            }
            userMenuToogler.classList.toggle('open');
        })
    }

    function toggleSideNavMenu() {
        const sidenavBtnsClose = document.getElementsByClassName(HTML_NAVBAR.SIDENAV_BTN_CLOSE);

        for (var btn of sidenavBtnsClose) {
            btn.addEventListener('click', closeNav);
        }

        const navMenuStatus = sidenav.style.width;

        if (navMenuStatus == '0px' || navMenuStatus === '') {
            if (!searchMenu.classList.contains('d-none')) {
                searchMenuParent.classList.toggle('opened');
                searchMenu.classList.add('d-none');
            }
            if (userMenuToogler.classList.contains('open')) {
                userMenuToogler.classList.toggle('open');
            }
            sidenav.style.width = '250px';
            sideNavFooter.style.display = 'block';
        } else {
            sidenav.style.width = '0px';
            sideNavFooter.style.display = 'none';
        }

        function closeNav() {
            sidenav.style.width = '0px';
            sideNavFooter.style.display = 'none';
        }
    }
})();