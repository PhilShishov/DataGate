(function () {
    const sideNavIcon = document.getElementById('sideNavIcon');
    const sideNavFooter = document.getElementById('sidenav-footer');
    sideNavIcon.addEventListener('click', toggleSideNavMenu);

    const closebtn = document.getElementById('closeBtn');
    closebtn.addEventListener('click', closeNav);

    function toggleSideNavMenu() {
        navMenuStatus = document.getElementById('mySidenav').style.width;
        if (navMenuStatus == '0px') {
            document.getElementById('mySidenav').style.width = '250px';
            sideNavFooter.style.display = 'block';
        } else {
            document.getElementById('mySidenav').style.width = '0px';
            sideNavFooter.style.display = 'none';
        }
    }

    function closeNav() {
        document.getElementById('mySidenav').style.width = '0px';
        sideNavFooter.style.display = 'none';
    }
})();