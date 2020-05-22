(function () {
    const rows = document.getElementById('tbody-entities').getElementsByTagName('tr');
    for (var row of rows) {
        const cells = row.getElementsByTagName('td');
        for (var cell of cells) {
            if (cell.textContent.includes('Inactive')) {
                row.classList.add('inactive-entity');
            }
        }
    }
})();