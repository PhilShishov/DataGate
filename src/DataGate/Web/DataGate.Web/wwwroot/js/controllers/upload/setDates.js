(function () {
    let contractDate = document.getElementById('contractDate');
    let activationDate = document.getElementById('activationDate');
    let expirationDate = document.getElementById('expirationDate');

    contractDate.addEventListener('change', setActivationDate);

    function setActivationDate() {
        //activationDate.setAttribute('min', contractDate.value);
        expirationDate.setAttribute('min', contractDate.value);
        activationDate.value = contractDate.value;
    }
})();