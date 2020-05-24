(function () {
    const contractDate = document.getElementById('contractDate');
    const activationDate = document.getElementById('activationDate');
    const expirationDate = document.getElementById('expirationDate');

    contractDate.value = '';
    activationDate.value = '';
    expirationDate = '';

    contractDate.addEventListener('change', setActivationDate);

    function setActivationDate() {
        //activationDate.setAttribute('min', contractDate.value);
        expirationDate.setAttribute('min', contractDate.value);
        activationDate.value = contractDate.value;
    }
})();