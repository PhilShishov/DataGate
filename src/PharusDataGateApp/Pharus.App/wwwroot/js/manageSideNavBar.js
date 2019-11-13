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

    const dropdown = document.getElementsByClassName("dropdown-btn");

    for (let i = 0; i < dropdown.length; i++) {
        dropdown[i].addEventListener("click", function () {
            this.classList.toggle("active");
            let dropdownContent = this.nextElementSibling;
            if (dropdownContent.style.display === "block") {
                dropdownContent.style.display = "none";
            } else {
                dropdownContent.style.display = "block";
            }
        });
    }
}