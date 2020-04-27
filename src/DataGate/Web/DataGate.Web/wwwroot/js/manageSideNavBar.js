function manageSideNavBar() {
    const sideNavIcon = document.getElementById("sideNavIcon");
    sideNavIcon.addEventListener('mouseover', openNav);

    const sideNav = document.getElementById("mySidenav");
    sideNav.addEventListener('mouseleave', closeNav);

    const closebtn = document.getElementById("closeBtn");
    closebtn.addEventListener('click', closeNav);

    function openNav() {
        document.getElementById("mySidenav").style.width = "250px";
    }

    function closeNav() {
        sideNav.style.width = "0";
    }  
}