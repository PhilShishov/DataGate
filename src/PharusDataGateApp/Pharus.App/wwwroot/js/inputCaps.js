function inputCaps() {

    const fundNameInput = document.getElementById('fundNameInput');

    fundNameInput.addEventListener('blur', caps);

    function caps() {
        this.value = fundNameInput.value.toUpperCase();
    }
}