function formatInput() {
    const createFormInputField = document.getElementById('createForm').querySelectorAll('input:not(#formatName)');
    const formatName = document.getElementById('formatName');

    for (var i = 0; i < createFormInputField.length; i++) {
        createFormInputField[i].addEventListener('blur', formatInput);
    }

    formatName.addEventListener('blur', formatSubFundAndShareClassName)

    function formatInput() {
        this.value = this.value.trimStart();
        this.value = this.value.trimEnd();
        this.value = this.value.toUpperCase();
    }

    function formatSubFundAndShareClassName() {
        this.value = this.value.trimStart();
        this.value = this.value.trimEnd();
        this.value = capitalLetter(this.value);

        function capitalLetter(str) {
            str = str.split(" ");

            for (let i = 0, x = str.length; i < x; i++) {
                str[i] = str[i][0].toUpperCase() + str[i].substr(1);
            }

            return str.join(" ");
        }
    }
}