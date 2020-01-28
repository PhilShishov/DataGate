function formatName() {
    const formatNameInput = document.getElementById('formatName');
    formatNameInput.addEventListener('blur', formatSubFundAndShareClassName);

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