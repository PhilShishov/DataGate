
function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}

//TODO update value of input after submit
//function updateTableWithChosenDate(chosenDate) {
//    chosenDate = document.getElementById("fundDatetime").value;
//    document.getElementById("fundDatetime").value = chosenDate;   
//    console.log(document.getElementById("fundDatetime").value);
//    console.log(chosenDate);
//}

var dropdown = document.getElementsByClassName("dropdown-btn");
var i;

for (i = 0; i < dropdown.length; i++) {
    dropdown[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var dropdownContent = this.nextElementSibling;
        if (dropdownContent.style.display === "block") {
            dropdownContent.style.display = "none";
        } else {
            dropdownContent.style.display = "block";
        }
    });
}