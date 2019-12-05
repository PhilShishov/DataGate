function manageSESelectMenu() {
    const selectMenu = document.getElementsByName('fundChoicesSelect')[0];

    const searchFieldSEDiv = document.getElementById('searchFieldDiv');

    const extractBtnExl = document.getElementById('extractBtnExl');
    const extractBtnPdf = document.getElementById('extractBtnPDF');

    selectMenu.addEventListener('change', openSelectMenu);

    function openSelectMenu() {
        if (selectMenu.options[selectMenu.selectedIndex].text === 'SubFunds') {
            searchFieldSEDiv.removeAttribute('hidden');
            extractBtnExl.removeAttribute('hidden');
            extractBtnPdf.removeAttribute('hidden');
        }
        else {
            searchFieldSEDiv.setAttribute('hidden', true);
            extractBtnExl.setAttribute('hidden', true);
            extractBtnPdf.setAttribute('hidden', true);
        }
    }
}