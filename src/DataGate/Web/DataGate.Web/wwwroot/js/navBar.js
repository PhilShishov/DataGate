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

    if (sidenavIcons) {
        for (let icon of sidenavIcons) {
            icon.addEventListener('click', toggleSideNavMenu);
        }
    }

    function toggleSideNavMenu() {
        const sidenavBtnsClose = document.getElementsByClassName(HTML.SIDENAV_BTN_CLOSE);
        const sidenav = document.getElementById(HTML.SIDENAV_MAIN);
        const sidenavResp = document.getElementById(HTML.SIDENAV_RESPONSIVE);

        for (var btn of sidenavBtnsClose) {
            btn.addEventListener('click', closeNav);
        }

        const navMenuStatus = sidenav.style.width;

        if (navMenuStatus == '0px' || navMenuStatus === '') {
            sidenav.style.width = '250px';
            sideNavFooter.style.display = 'block';
        } else {
            sidenav.style.width = '0px';
            sideNavFooter.style.display = 'none';
        }

        const respNavMenuStatus = sidenavResp.style.width;

        if (respNavMenuStatus == '0px' || respNavMenuStatus === '') {
            sidenavResp.style.width = '250px';
            sideNavFooter.style.display = 'block';
        } else {
            sidenavResp.style.width = '0px';
            sideNavFooter.style.display = 'none';
        }

        function closeNav() {
            sidenav.style.width = '0px';
            sidenavResp.style.width = '0px';
            sideNavFooter.style.display = 'none';
        }
    }

})();

(function () {
    const sideNavDropdowns = document.getElementsByClassName(HTML.SIDENAV_BTNS_DROPDOWN);

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
})();

$(HTML.NAVBAR_USER_MENU).on('click', function () {
    $(this).toggleClass('open');
});

(function () {
    const searchMenuToogler = document.getElementsByClassName('search-form-wrapper-responsive')[0];
    //const searchMenu = document.getElementsByClassName('search-form-responsive')[0];

    if (searchMenuToogler) {
        searchMenuToogler.addEventListener('click', toggleSearchMenu);

        function toggleSearchMenu() {
            searchMenuToogler.classList.toggle('opened');
            //const searchMenuStatus = searchMenu.classList.contains('d-none');

            //if (searchMenuStatus) {
            //    userMenu.classList.remove('d-none');
            //} else {
            //    userMenu.classList.add('d-none');
            //}
        };
    }
})();