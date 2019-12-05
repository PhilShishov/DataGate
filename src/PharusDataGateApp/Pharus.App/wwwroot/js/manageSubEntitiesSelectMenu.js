function manageSESelectMenu() {
    const selectMenu = document.getElementById('fundChoicesSelect');

    const searchFieldSEDiv = document.getElementById('searchFieldDiv');

    const extractSEDiv = document.getElementById('extractDiv');

    selectMenu.addEventListener('change', openSelectMenu);

    function openSelectMenu() {
        if (selectMenu.options[selectMenu.selectedIndex].text === 'SubFunds') {
            searchFieldSEDiv.removeAttribute('hidden');
            extractSEDiv.removeAttribute('hidden');
        }
        else {
            searchFieldSEDiv.setAttribute('hidden', true);
            extractSEDiv.setAttribute('hidden', true);
        }
    }
}