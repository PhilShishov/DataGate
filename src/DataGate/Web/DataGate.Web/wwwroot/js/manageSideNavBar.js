function manageSideNavBar() {
    const sideNavIcon = document.getElementById("sideNavIcon");
    sideNavIcon.addEventListener('click', openNav);

    const closebtn = document.getElementById("closeBtn");
    closebtn.addEventListener('click', closeNav);

    function openNav() {
        document.getElementById("mySidenav").style.width = "250px";
    }

    function closeNav() {
        document.getElementById("mySidenav").style.width = '0px';
    }
}
