const HTML = {
    SIDENAV_MAIN: 'main-sidenav',
    SIDENAV_RESPONSIVE: 'sidenav-responsive',
    SIDENAV_ICONS: 'sidenav-icon',
    SIDENAV_FOOTER: 'sidenav-footer',
    SIDENAV_BTN_CLOSE: 'sidenav-btn-close',
    SIDENAV_BTNS_DROPDOWN: 'sidenav-dropdown-btn',
    NAVBAR_USER_MENU: '.responsive-menu',
};

(function () {
    const sidenavIcons = document.getElementsByClassName(HTML.SIDENAV_ICONS);
    const sideNavFooter = document.getElementById(HTML.SIDENAV_FOOTER);
    const sideNavDropdowns = document.getElementsByClassName(HTML.SIDENAV_BTNS_DROPDOWN);
    const searchMenuToogler = document.getElementsByClassName('open-search-box')[0];
    const searchMenuParent = document.getElementsByClassName('search-form-wrapper-responsive')[0];
    const searchMenu = document.getElementsByClassName('search-form-wrapper')[0];
    const userMenuToogler = document.getElementsByClassName('responsive-menu')[0];
    const sidenav = document.getElementById(HTML.SIDENAV_MAIN);

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
        const sidenavBtnsClose = document.getElementsByClassName(HTML.SIDENAV_BTN_CLOSE);

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