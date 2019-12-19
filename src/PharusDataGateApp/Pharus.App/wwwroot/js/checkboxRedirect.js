function checkboxRedirect() {
    const checkbox = document.getElementById('activeCheckBox');

    checkbox.addEventListener('change', submitForm)

    function submitForm() {
        this.form.submit();
    }
}