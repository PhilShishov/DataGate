function enterKeySubmit() {
    const searchField = document.getElementById('searchField');
    searchField.addEventListener('keypress', function (e) {
        let key = e.which || e.keyCode;
        if (key === 13) {
            key.preventDefault();
            alert("Enter was pressed was presses");
        }
    });
}