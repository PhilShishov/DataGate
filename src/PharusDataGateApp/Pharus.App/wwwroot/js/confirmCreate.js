function confirmCreate() {
    const confrCrBtn = document.getElementById('confirmCreateBtn');
    confrCrBtn.addEventListener('click', showCreateDialog);

    function showCreateDialog() {
        confirm('Are you sure you want to create this?');
    }
}