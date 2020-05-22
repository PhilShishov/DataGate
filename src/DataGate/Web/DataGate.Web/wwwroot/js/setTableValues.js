(function () {
    const tblValues = document.getElementsByClassName('tblValues');

    for (let cell of tblValues) {
        cell.value = cell.defaultValue;
    }
})();