function formatInput() {
    const createFormInputFields = document.getElementById('createForm').querySelectorAll('input:not(#formatName)');

    for (var i = 0; i < createFormInputFields.length; i++) {
        createFormInputFields[i].addEventListener('blur', formatInput);
    }

    function formatInput() {
        this.value = this.value.trimStart();
        this.value = this.value.trimEnd();
        this.value = this.value.toUpperCase();
    }
}