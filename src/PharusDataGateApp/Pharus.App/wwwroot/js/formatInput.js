function formatInput() {

    const createForm = document.getElementById('createForm').getElementsByTagName('input');

    for (var i = 0; i < createForm.length; i++) {
        createForm[i].addEventListener('blur', caps);
    }    

    function caps() {
        this.value = this.value.trimStart();
        this.value = this.value.trimEnd();
        this.value = this.value.toUpperCase();
    }
}