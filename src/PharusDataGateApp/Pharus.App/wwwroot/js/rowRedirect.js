function rowRedirect(controllerName, entityId, chosenDate) {
    const tableRow = document.getElementsByClassName('tableRowPharus');

    console.log(controllerName);
    console.log(entityId);
    console.log(chosenDate);

    for (const row of tableRow) {
        row.addEventListener('click', redirect);
    }

    function redirect() {
        document.location = `/${controllerName}/ViewEntitySE/${entityId}/${chosenDate}`;
    }
}