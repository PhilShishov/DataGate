function confirmEvent() {
    const confrBtn = document.getElementById('confirmBtn');

    confrBtn.addEventListener('click', showConfirmDialog);

    function showConfirmDialog() {
        confirm('Are you sure you want to delete this?');
    }
}