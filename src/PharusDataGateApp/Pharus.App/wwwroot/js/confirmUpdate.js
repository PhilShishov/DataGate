function confirmUpdate() {
    const confrEditBtn = document.getElementById('confirmEditBtn');
    confrEditBtn.addEventListener('click', showUpdateDialog);

    function showUpdateDialog() {
        confirm('Are you sure you want to update this?');
    }
}