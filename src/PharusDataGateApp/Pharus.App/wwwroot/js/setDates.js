function setDates() {
    const contractDate = document.getElementById('contractDate');
    const activationDate = document.getElementById('activationDate');

    contractDate.addEventListener('change', setActivationDate);
    //activationDate.addEventListener('change', setContractDate);

    function setActivationDate() {
        activationDate.setAttribute('min', contractDate.value);
        activationDate.value = contractDate.value;
    }
}