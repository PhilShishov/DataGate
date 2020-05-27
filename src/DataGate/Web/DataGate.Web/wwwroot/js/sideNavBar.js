(function () {
    const sideNavIcon = document.getElementById('sideNavIcon');
    const sideNavFooter = document.getElementById('sidenav-footer');
    console.log('here');

    if (sideNavIcon) {
        sideNavIcon.addEventListener('click', toggleSideNavMenu);
        console.log('here2');
    }

    function toggleSideNavMenu() {
        console.log('here3');
        const closebtn = document.getElementById('closeBtn');
        closebtn.addEventListener('click', closeNav);
        navMenuStatus = document.getElementById('mySidenav').style.width;
        debugger;
        if (navMenuStatus == '0px' || navMenuStatus === '') {
            document.getElementById('mySidenav').style.width = '250px';
            sideNavFooter.style.display = 'block';
        } else {
            document.getElementById('mySidenav').style.width = '0px';
            sideNavFooter.style.display = 'none';
        }
        function closeNav() {
            document.getElementById('mySidenav').style.width = '0px';
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