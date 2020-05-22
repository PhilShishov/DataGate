(function () {
    const checkbox = document.getElementById('activeCheckBox');
    //const select = document.getElementById('SelectTerm');

    const updateForm = document.getElementById('update-form');

    checkbox.addEventListener('change', submitForm);
    //select.addEventListener('change', submitForm);

    function submitForm() {
        updateForm.submit();
    }
})();