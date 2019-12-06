function inputCaps() {

    const createFundForm = document.getElementById('createFundForm').getElementsByTagName('input');

    for (var i = 0; i < createFundForm.length; i++) {
        createFundForm[i].addEventListener('blur', caps);
    }    

    function caps() {
        this.value = this.value.toUpperCase();
    }
}