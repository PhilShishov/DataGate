const HTML = {
    SIDENAV: 'sidenav-pharus',
    SIDENAV_ICON: 'sidenav-icon',
    SIDENAV_FOOTER: 'sidenav-footer',
    SIDENAV_BTN_CLOSE: 'sidenav-btn-close',
    PLACEHOLDER_MODAL_AGR: '#modal-placeholder-agreement',
};

(function () {
    const sidenavIcon = document.getElementById('sidenav-icon');
    const sideNavFooter = document.getElementById('sidenav-footer');

    if (sidenavIcon) {
        sidenavIcon.addEventListener('click', toggleSideNavMenu);
    }

    function toggleSideNavMenu() {
        const sidenavBtnClose = document.getElementById('sidenav-btn-close');
        sidenavBtnClose.addEventListener('click', closeNav);
        navMenuStatus = document.getElementById('sidenav-pharus').style.width;
        if (navMenuStatus == '0px' || navMenuStatus === '') {
            document.getElementById('sidenav-pharus').style.width = '250px';
            sideNavFooter.style.display = 'block';
        } else {
            document.getElementById('sidenav-pharus').style.width = '0px';
            sideNavFooter.style.display = 'none';
        }
        function closeNav() {
            document.getElementById('sidenav-pharus').style.width = '0px';
            sideNavFooter.style.display = 'none';
        }
    }

})();

(function () {
    const sideNavDropdowns = document.getElementsByName('dr-btn-SideNav');

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

    const subEntDropdowns = document.getElementsByName('dr-btn-SubEntities');

    for (let i = 0; i < subEntDropdowns.length; i++) {
        subEntDropdowns[i].addEventListener('click', function () {
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