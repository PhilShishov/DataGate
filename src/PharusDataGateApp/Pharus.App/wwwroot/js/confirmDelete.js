function confirmDelete() {
    const confrDelBtn = document.getElementById('confirmDelBtn');
    confrDelBtn.addEventListener('click', showDeleteDialog);

    function showDeleteDialog() {
        confirm('Are you sure you want to delete this?');
    }  
}