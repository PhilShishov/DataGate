function submitForm() {
    const checkbox = document.getElementById('activeCheckBox');
    const select = document.getElementById('SelectTerm');
    const formPharus = document.getElementById('entity-form-pharus');

    checkbox.addEventListener('change', submitForm);
    select.addEventListener('change', submitForm);

    function submitForm() {
        formPharus.submit();
    }
}