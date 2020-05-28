const HTML = {
    SIDENAV: 'sidenav-pharus',
    SIDENAV_ICON: 'sidenav-icon',
    SIDENAV_FOOTER: 'sidenav-footer',
    SIDENAV_BTN_CLOSE: 'sidenav-btn-close',
    SIDENAV_BTNS_DROPDOWN: 'sidenav-dropdown-btn',
};

(function () {
    const sidenavIcon = document.getElementById(HTML.SIDENAV_ICON);
    const sideNavFooter = document.getElementById(HTML.SIDENAV_FOOTER);

    if (sidenavIcon) {
        sidenavIcon.addEventListener('click', toggleSideNavMenu);
    }

    function toggleSideNavMenu() {
        const sidenavBtnClose = document.getElementById(HTML.SIDENAV_BTN_CLOSE);
        sidenavBtnClose.addEventListener('click', closeNav);
        navMenuStatus = document.getElementById(HTML.SIDENAV).style.width;
        if (navMenuStatus == '0px' || navMenuStatus === '') {
            document.getElementById(HTML.SIDENAV).style.width = '250px';
            sideNavFooter.style.display = 'block';
        } else {
            document.getElementById(HTML.SIDENAV).style.width = '0px';
            sideNavFooter.style.display = 'none';
        }
        function closeNav() {
            document.getElementById(HTML.SIDENAV).style.width = '0px';
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

$('.responsive-menu').on('click', function () {
    $(this).toggleClass('open');
});