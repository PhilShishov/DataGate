
//window.onload = loadDate();

function getDerivatives() {
    const deriv = document.getElementById('derivatives');

    const derivMarket = document.getElementById('derivMarket');
    const derivMarketLbl = document.getElementById('derivMarketLabel');

    const derivPurpose = document.getElementById('derivPurpose');
    const derivPurposeLbl = document.getElementById('derivPurposeLabel');

    if (deriv.options[deriv.selectedIndex].text === 'Yes') {
        derivMarket.removeAttribute('hidden');
        derivMarketLbl.removeAttribute('hidden');
        derivPurpose.removeAttribute('hidden');
        derivPurposeLbl.removeAttribute('hidden');
    }
    else {
        derivMarket.setAttribute('hidden', true);
        derivMarketLbl.setAttribute('hidden', true);
        derivPurpose.setAttribute('hidden', true);
        derivPurposeLbl.setAttribute('hidden', true);
    }
}

function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}

function loadDate() {
    if (document.getElementById("fundDatetime").value == "") {
        let date = (formatDate(new Date())).toString();

        document.getElementById("fundDatetime").value = date;
    }
    function formatDate(date) {
        var day = ('0' + date.getDate()).slice(-2);
        var month = ('0' + (date.getMonth() + 1)).slice(-2);
        var year = date.getFullYear();

        return year + '-' + month + '-' + day;
    }
}

//TODO js function bug with bootstrap
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